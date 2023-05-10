using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

namespace UsbLibrary {
	public abstract class HIDDevice : global::UsbLibrary.Win32Usb, global::System.IDisposable {
		#region Privates variables
		/// <summary>Filestream we can use to read/write from</summary>
		private global::System.IO.FileStream m_oFile;

		/// <summary>Length of input report : device gives us this</summary>
		private int m_nInputReportLength;

		/// <summary>Length if output report : device gives us this</summary>
		private int m_nOutputReportLength;

		/// <summary>Handle to the device</summary>
		public global::System.IntPtr m_hHandle;
		#endregion

		#region IDisposable Members
		bool IsDisposing = false;

		public void Dispose() {
			this.IsDisposing = true;
			this.Dispose(bDisposing: true);
			global::System.GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool bDisposing) {
			try {
				if (bDisposing && this.m_oFile != null) {
					this.m_oFile.Close();
					this.m_oFile = null; }
				if (this.m_hHandle != global::System.IntPtr.Zero) {
					global::UsbLibrary.Win32Usb.CloseHandle(this.m_hHandle); }
			} catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); } }
		#endregion

		#region Privates/protected
		private static System.IntPtr GetPreparsedData(global::System.IntPtr hFile) {
			// get windows to read the device data into an internal buffer
			IntPtr lpData;
			if (!Win32Usb.HidD_GetPreparsedData(hFile, out lpData)) {
				// GetPreparsedData failed? Chuck an exception
				throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed"); }
			return lpData; }

		private static Win32Usb.HidCaps GetCaps(IntPtr lpData) {
			Win32Usb.HidCaps oCaps;
			Win32Usb.HidP_GetCaps(lpData, out oCaps);
			return oCaps; }

		void Initialise(string strPath, FileAccess fileAccess = FileAccess.Read | FileAccess.Write, int bufferLength = -1) {
			// Create the file from the device path
			this.m_hHandle = Win32Usb.CreateFile(strPath, Win32Usb.GENERIC_READ | Win32Usb.GENERIC_WRITE, 0, IntPtr.Zero, Win32Usb.OPEN_EXISTING, Win32Usb.FILE_FLAG_OVERLAPPED, IntPtr.Zero);

			// File open failed? Chuck an exception
			if (this.m_hHandle == Win32Usb.InvalidHandleValue) {
				this.m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError("Failed to create device file"); }

			// if the open worked... get windows to read the device data into an internal buffer
			IntPtr lpData = HIDDevice.GetPreparsedData(this.m_hHandle);

			try {
				// extract the device capabilities from the internal buffer
				Win32Usb.HidCaps oCaps = HIDDevice.GetCaps(lpData);
				this.m_nInputReportLength = oCaps.InputReportByteLength; // get the input...
				this.m_nOutputReportLength = oCaps.OutputReportByteLength;   // ... and output report lengths

				// Adjust the buffer length to the input report length if a default value was handed over
				if (bufferLength == -1) { bufferLength = this.m_nInputReportLength; }

				//m_oFile = new FileStream(m_hHandle, FileAccess.Read | FileAccess.Write, true, m_nInputReportLength, true);
				this.m_oFile = new FileStream(new SafeFileHandle(this.m_hHandle, false), fileAccess, this.m_nInputReportLength, true);

				// kick off the first asynchronous read
				if (fileAccess == FileAccess.Read || fileAccess == (FileAccess.Read | FileAccess.Write)) { 
					this.BeginAsyncRead(); }                                
			} catch (Exception ex) {
				throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid. Error '" + ex.ToString() + "'.");
			} finally {
				Win32Usb.HidD_FreePreparsedData(ref lpData); // before we quit the funtion, we must free the internal buffer reserved in GetPreparsedData
			}
		}

		void BeginAsyncRead() {
			try {
				if (this.IsDisposing) { return; }

				byte[] arrInputReport = new byte[this.m_nInputReportLength];
				if (this.m_oFile != null) {
					//m_oFile.BeginRead(arrInputReport, 0, m_nInputReportLength, ReadCompleted, arrInputReport);
					this.m_oFile.BeginRead(arrInputReport, 0, this.m_nInputReportLength, new global::System.AsyncCallback(this.ReadCompleted), arrInputReport); }
			} catch (Exception ex) { throw HIDDeviceException.GenerateWithWinError("HIDDevice.BeginAsyncRead Error.ToString(): '" + ex.ToString() + "'."); } }

		protected void ReadCompleted(IAsyncResult iResult) {
			//if (IsDisposing) { return; }

			// retrieve the read buffer
			byte[] data = (byte[])iResult.AsyncState;
			try {
				// call end read : this throws any exceptions that happened during the read
				if (m_oFile != null) { m_oFile.EndRead(iResult); }
				try {
					// Create the input report for the device
					InputReport inputReport = this.CreateInputReport();
					// and set the data portion - this processes the data received into a more easily understood format depending upon the report type
					inputReport.SetData(data);

					// pass the new input report on to the higher level handler
					this.HandleDataReceived(inputReport); 
				} finally {
					// when all that is done, kick off another read for the next report
					this.BeginAsyncRead(); }
			} catch (IOException) {
				// if we got an IO exception, the device was removed
				this.HandleDeviceRemoved();
				if (this.OnDeviceRemoved != null) { this.OnDeviceRemoved(this, new EventArgs()); }
				this.Dispose(); } }

		protected void Write(global::UsbLibrary.OutputReport oOutRep) {
			try { this.m_oFile.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
			} catch (global::System.IO.IOException) { throw new global::UsbLibrary.HIDDeviceException("Probbaly the device was removed");
			} catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); } }

		protected virtual void HandleDataReceived(global::UsbLibrary.InputReport oInRep) { }
		protected virtual void HandleDeviceRemoved() { }

		/// <summary>
		/// Helper method to return the device path given a DeviceInterfaceData structure and an InfoSet handle.
		/// Used in 'FindDevice' so check that method out to see how to get an InfoSet handle and a DeviceInterfaceData.
		/// </summary>
		/// <param name="hInfoSet">Handle to the InfoSet</param>
		/// <param name="oInterface">DeviceInterfaceData structure</param>
		/// <returns>The device path or null if there was some problem</returns>
		private static string GetDevicePath(global::System.IntPtr lpDeviceInfoSet, ref global::UsbLibrary.Win32Usb.DeviceInterfaceData oInterfaceData) {
			uint nDeviceInterfaceDetailDataSize = 0U;
			// Get the device interface details
			if (!global::UsbLibrary.Win32Usb.SetupDiGetDeviceInterfaceDetail(lpDeviceInfoSet, ref oInterfaceData, global::System.IntPtr.Zero, 0U, ref nDeviceInterfaceDetailDataSize, global::System.IntPtr.Zero)) {

				// hardcoded to 5! Sorry, but this works and trying more future proof versions by setting the size to the struct sizeof failed miserably. If you manage to sort it, mail me! Thx
				global::UsbLibrary.Win32Usb.DeviceInterfaceDetailData deviceInterfaceDetailData = new global::UsbLibrary.Win32Usb.DeviceInterfaceDetailData();
				if (global::System.IntPtr.Size == 4) { deviceInterfaceDetailData.Size = 5;
				} else { deviceInterfaceDetailData.Size = 8; }

				if (global::UsbLibrary.Win32Usb.SetupDiGetDeviceInterfaceDetail(lpDeviceInfoSet, ref oInterfaceData, ref deviceInterfaceDetailData, nDeviceInterfaceDetailDataSize, ref nDeviceInterfaceDetailDataSize, global::System.IntPtr.Zero)) {
					return deviceInterfaceDetailData.DevicePath; } }

			// Failed to get them!
			return null; }
		#endregion

		// Initialise(string strPath, FileAccess fileAccess = FileAccess.Read | FileAccess.Write, int bufferLength = -1)

		public static HIDDevice NewHIDDevice(Type oType, string strDevicePath, FileAccess fileAccess = FileAccess.Read | FileAccess.Write, int bufferLength = -1) {
			// create an instance of the class for this device
			HIDDevice oNewDevice = (HIDDevice)Activator.CreateInstance(oType);


			// initialise it with the device path
			oNewDevice.Initialise(strDevicePath, fileAccess, bufferLength);

			// and return it
			return oNewDevice; }

		/// <summary>
		/// Finds a device given its PID and VID
		/// </summary>
		/// <param name="strSearch">Search path snippet for the HiD device path in the registry</param>
		/// <param name="oType">Type of device class to create</param>
		/// <param name="writer">Whether this is a writer or reader device</param>
		/// <returns>A new device class of the given type or null</returns>
		public static HIDDevice FindDevice(string strSearch, Type oType, FileAccess fileAccess = FileAccess.Read | FileAccess.Write, int bufferLength = -1) {
			// next, get the GUID from Windows that it uses to represent the HID USB interface
			Guid gHid = Win32Usb.HIDGuid;

			// this gets a list of all HID devices currently connected to the computer (InfoSet)
			IntPtr hInfoSet = Win32Usb.SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, Win32Usb.DIGCF_DEVICEINTERFACE | Win32Usb.DIGCF_PRESENT);
			try {
				// build up a device interface data block
				DeviceInterfaceData oInterface = new Win32Usb.DeviceInterfaceData();
				oInterface.Size = Marshal.SizeOf((object)oInterface);

				// Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs to get device details for each device connected
				for (int i = 0; Win32Usb.SetupDiEnumDeviceInterfaces(hInfoSet, 0u, ref gHid, (uint)i, ref oInterface); i++) {
					// get the device path (see helper method 'GetDevicePath')
					string strDevicePath = HIDDevice.GetDevicePath(hInfoSet, ref oInterface);

					// do a string search, if we find the VID/PID string then we found our device!
					if (strDevicePath.IndexOf(strSearch) >= 0) { return HIDDevice.NewHIDDevice(oType, strDevicePath, fileAccess, bufferLength); }
				} // if we get here, we didn't find our device. So move on to the next one.
			} catch (Exception ex) {
				throw HIDDeviceException.GenerateError(ex.ToString());
				//Console.WriteLine(ex.ToString());
			} finally {
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
				Win32Usb.SetupDiDestroyDeviceInfoList(hInfoSet);
			}

			// oops, didn't find our device
			return null;
		}

		/// <summary>
		/// Finds a device given its PID and VID
		/// </summary>
		/// <param name="nVid">Vendor id for device (VID)</param>
		/// <param name="nPid">Product id for device (PID)</param>
		/// <param name="oType">Type of device class to create</param>
		/// <returns>A new device class of the given type or null</returns>
		public static HIDDevice FindDevice(int nVid, int nPid, Type oType, FileAccess fileAccess = FileAccess.Read | FileAccess.Write, int bufferLength = -1) {
			// Find the path via the device manager, the HiD device that got added, the details tab, "Device instance path" variable
			// Also look it up in the regedit, Computer\HKEY_LOCAL_MACHINE\SYSTEM\Current\CurrentControlSet\Enum\USB\
			string strSearch = string.Format("VID_{0:x4}&PID_{1:x4}", nVid, nPid);

			// Call the sub worker now you have the search string
			return HIDDevice.FindDevice(strSearch, oType, fileAccess, bufferLength);
		}


		#region Publics
		private global::System.EventHandler OnDeviceRemoved = null;

		public int OutputReportLength {
			get { return this.m_nOutputReportLength; } }

		public int InputReportLength {
			get { return this.m_nInputReportLength; } }

		public virtual global::UsbLibrary.InputReport CreateInputReport() { return null; }
		#endregion
	}
}
