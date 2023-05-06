using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace UsbLibrary
{
	#region Custom exception
	public class HIDDeviceException : ApplicationException
	{
		public HIDDeviceException(string strMessage) : base(strMessage) { }

		public static HIDDeviceException GenerateWithWinError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", strMessage, Marshal.GetLastWin32Error()));
		}

		public static HIDDeviceException GenerateError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0}", strMessage));
		}
	}
	#endregion

	public abstract class HIDDevice : Win32Usb, IDisposable
	{
		#region Privates variables
		/// <summary>Filestream we can use to read/write from</summary>
		private FileStream m_oFile;
		/// <summary>Length of input report : device gives us this</summary>
		private int m_nInputReportLength;
		/// <summary>Length if output report : device gives us this</summary>
		private int m_nOutputReportLength;
		/// <summary>Handle to the device</summary>
		private IntPtr m_hHandle;
		#endregion

		#region IDisposable Members
		bool IsDisposing = false;

		public void Dispose()
		{
			IsDisposing = true;
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool bDisposing)
		{
			try
			{
				if (bDisposing)
				{
					if (m_oFile != null)
					{
						m_oFile.Close();
						m_oFile = null;
					}
				}
				if (m_hHandle != IntPtr.Zero)
				{
					CloseHandle(m_hHandle);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		#endregion

		#region Privates/protected
		void Initialise(string strPath)
		{
			// Create the file from the device path
			m_hHandle = CreateFile(strPath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);

			if (m_hHandle != InvalidHandleValue || m_hHandle == null)	// if the open worked...
			{
				IntPtr lpData;
				if (HidD_GetPreparsedData(m_hHandle, out lpData))	// get windows to read the device data into an internal buffer
				{
					try
					{
						HidCaps oCaps;
						HidP_GetCaps(lpData, out oCaps);	// extract the device capabilities from the internal buffer
						m_nInputReportLength = oCaps.InputReportByteLength;	// get the input...
						m_nOutputReportLength = oCaps.OutputReportByteLength;	// ... and output report lengths

						//m_oFile = new FileStream(m_hHandle, FileAccess.Read | FileAccess.Write, true, m_nInputReportLength, true);
						m_oFile = new FileStream(new SafeFileHandle(m_hHandle, false), FileAccess.Read | FileAccess.Write, m_nInputReportLength, true);

						BeginAsyncRead();	// kick off the first asynchronous read                              
					}
					catch (Exception ex)
					{
						throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
					}
					finally
					{
						HidD_FreePreparsedData(ref lpData);	// before we quit the funtion, we must free the internal buffer reserved in GetPreparsedData
					}
				}
				else	// GetPreparsedData failed? Chuck an exception
				{
					throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
				}
			}
			else	// File open failed? Chuck an exception
			{
				m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError("Failed to create device file");
			}
		}

		void BeginAsyncRead()
		{
			try
			{
				if (IsDisposing)
					return;

				byte[] arrInputReport = new byte[m_nInputReportLength];
				if (m_oFile != null)
				{
					m_oFile.BeginRead(arrInputReport, 0, m_nInputReportLength, new AsyncCallback(ReadCompleted), arrInputReport);
				}
			}
			catch (Exception e)
			{
				;
			}
		}

		protected void ReadCompleted(IAsyncResult iResult)
		{
			if (IsDisposing)
				return;

			byte[] arrBuff = (byte[])iResult.AsyncState;	// retrieve the read buffer
			try
			{
				if (m_oFile != null)
				{
					m_oFile.EndRead(iResult);	// call end read : this throws any exceptions that happened during the read
				}
				try
				{
					InputReport oInRep = CreateInputReport();	// Create the input report for the device
					oInRep.SetData(arrBuff);	// and set the data portion - this processes the data received into a more easily understood format depending upon the report type
					HandleDataReceived(oInRep);	// pass the new input report on to the higher level handler
				}
				finally
				{
					BeginAsyncRead();	// when all that is done, kick off another read for the next report
				}
			}
			catch (IOException ex)	// if we got an IO exception, the device was removed
			{
				HandleDeviceRemoved();
				if (OnDeviceRemoved != null)
				{
					OnDeviceRemoved(this, new EventArgs());
				}
				Dispose();
			}
		}

		protected void Write(OutputReport oOutRep)
		{
			try
			{
				if (!IsDisposing)
				{
					m_oFile.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
				}
			}
			catch (IOException ex)
			{
				throw new HIDDeviceException("Probbaly the device was removed");
			}
			catch (Exception exx)
			{
				Console.WriteLine(exx.ToString());
			}
		}

		protected virtual void HandleDataReceived(InputReport oInRep)
		{
		}

		protected virtual void HandleDeviceRemoved()
		{
		}
		/// <summary>
		/// Helper method to return the device path given a DeviceInterfaceData structure and an InfoSet handle.
		/// Used in 'FindDevice' so check that method out to see how to get an InfoSet handle and a DeviceInterfaceData.
		/// </summary>
		/// <param name="hInfoSet">Handle to the InfoSet</param>
		/// <param name="oInterface">DeviceInterfaceData structure</param>
		/// <returns>The device path or null if there was some problem</returns>
		static string GetDevicePath(IntPtr hInfoSet, ref DeviceInterfaceData oInterface)
		{
			uint nRequiredSize = 0;
			// Get the device interface details
			if (!SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0, ref nRequiredSize, IntPtr.Zero))
			{
				DeviceInterfaceDetailData oDetail = new DeviceInterfaceDetailData();
				oDetail.Size = 5;	// hardcoded to 5! Sorry, but this works and trying more future proof versions by setting the size to the struct sizeof failed miserably. If you manage to sort it, mail me! Thx
				if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetail, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
				{
					return oDetail.DevicePath;
				}
			}
			return null;
		}
		#endregion

		public static List<string> AddedDevices = new List<string>();

		#region Public static


		public static List<HIDDevice> FindAllDevice(int nVid, int nPid, Type oType)
		{
			var result = new List<HIDDevice>();
			var addedDevices = new List<string>();

			string strPath = string.Empty;
			string strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", nVid, nPid);
			Guid gHid = HIDGuid;
			IntPtr hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);	// this gets a list of all HID devices currently connected to the computer (InfoSet)
			try
			{
				DeviceInterfaceData oInterface = new DeviceInterfaceData();	// build up a device interface data block
				oInterface.Size = Marshal.SizeOf(oInterface);
				// Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs
				// to get device details for each device connected
				int nIndex = 0;
				while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))	// this gets the device interface information for a device at index 'nIndex' in the memory block
				{
					string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);	// get the device path (see helper method 'GetDevicePath')
					if (strDevicePath.IndexOf(strSearch) >= 0)	// do a string search, if we find the VID/PID string then we found our device!
					{
						if (!addedDevices.Contains(strDevicePath))
						{
							addedDevices.Add(strDevicePath);
							//Trace.WriteLine(strDevicePath);

							HIDDevice oNewDevice = (HIDDevice)Activator.CreateInstance(oType);	// create an instance of the class for this device
							oNewDevice.Initialise(strDevicePath);	// initialise it with the device path
							result.Add(oNewDevice);	// and return it
						}
					}
					nIndex++;	// if we get here, we didn't find our device. So move on to the next one.
				}
			}
			catch (Exception ex)
			{
				//throw HIDDeviceException.GenerateError(ex.ToString());
				//Console.WriteLine(ex.ToString());
			}
			finally
			{
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
				SetupDiDestroyDeviceInfoList(hInfoSet);
			}
			return result;
		}


		/// <summary>
		/// Finds a device given its PID and VID
		/// </summary>
		/// <param name="nVid">Vendor id for device (VID)</param>
		/// <param name="nPid">Product id for device (PID)</param>
		/// <param name="oType">Type of device class to create</param>
		/// <returns>A new device class of the given type or null</returns>
		public static HIDDevice FindDevice(int nVid, int nPid, Type oType)
		{
			string strPath = string.Empty;
			string strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", nVid, nPid); // first, build the path search string
			Guid gHid = HIDGuid;
			//HidD_GetHidGuid(out gHid);	// next, get the GUID from Windows that it uses to represent the HID USB interface
			IntPtr hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);	// this gets a list of all HID devices currently connected to the computer (InfoSet)
			try
			{
				DeviceInterfaceData oInterface = new DeviceInterfaceData();	// build up a device interface data block
				oInterface.Size = Marshal.SizeOf(oInterface);
				// Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs
				// to get device details for each device connected
				int nIndex = 0;
				while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))	// this gets the device interface information for a device at index 'nIndex' in the memory block
				{
					string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);	// get the device path (see helper method 'GetDevicePath')
					if (strDevicePath.IndexOf(strSearch) >= 0)	// do a string search, if we find the VID/PID string then we found our device!
					{
						if (!AddedDevices.Contains(strDevicePath))
						{
							AddedDevices.Add(strDevicePath);
							//Trace.WriteLine(strDevicePath);

							HIDDevice oNewDevice = (HIDDevice)Activator.CreateInstance(oType);	// create an instance of the class for this device
							oNewDevice.Initialise(strDevicePath);	// initialise it with the device path
							return oNewDevice;	// and return it
						}
					}
					nIndex++;	// if we get here, we didn't find our device. So move on to the next one.
				}
			}
			catch (Exception ex)
			{
				throw HIDDeviceException.GenerateError(ex.ToString());
				//Console.WriteLine(ex.ToString());
			}
			finally
			{
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
				SetupDiDestroyDeviceInfoList(hInfoSet);
			}
			return null;	// oops, didn't find our device
		}
		#endregion

		#region Publics
		public event EventHandler OnDeviceRemoved;

		public int OutputReportLength
		{
			get { return m_nOutputReportLength; }
		}

		public int InputReportLength
		{
			get { return m_nInputReportLength; }
		}

		public virtual InputReport CreateInputReport()
		{
			return null;
		}
		#endregion
	}
}