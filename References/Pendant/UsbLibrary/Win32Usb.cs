using System;
using System.Runtime.InteropServices;

namespace UsbLibrary {
	/// <summary>
	/// Class that wraps USB API calls and structures.
	/// </summary>
	public class Win32Usb {
		#region Structures
		/// <summary>
		/// An overlapped structure used for overlapped IO operations. The structure is
		/// only used by the OS to keep state on pending operations. You don't need to fill anything in if you
		/// unless you want a Windows event to fire when the operation is complete.
		/// </summary>
		[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
		protected struct Overlapped {
			public uint Internal;
			public uint InternalHigh;
			public uint Offset;
			public uint OffsetHigh;
			public global::System.IntPtr Event;
		}

		/// <summary>
		/// Provides details about a single USB device
		/// </summary>
		[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
		protected struct DeviceInterfaceData {
			public int Size;
			public global::System.Guid InterfaceClassGuid;
			public int Flags;
			public global::System.IntPtr Reserved;
		}

		/// <summary>
		/// Provides the capabilities of a HID device
		/// </summary>
		[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
		protected struct HidCaps {
			public short Usage;
			public short UsagePage;
			public short InputReportByteLength;
			public short OutputReportByteLength;
			public short FeatureReportByteLength;
			[global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] Reserved;
			public short NumberLinkCollectionNodes;
			public short NumberInputButtonCaps;
			public short NumberInputValueCaps;
			public short NumberInputDataIndices;
			public short NumberOutputButtonCaps;
			public short NumberOutputValueCaps;
			public short NumberOutputDataIndices;
			public short NumberFeatureButtonCaps;
			public short NumberFeatureValueCaps;
			public short NumberFeatureDataIndices;
		}

		/// <summary>
		/// Access to the path for a device
		/// </summary>
		[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
		public struct DeviceInterfaceDetailData {
			public int Size;

			[global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string DevicePath;
		}

		/// <summary>
		/// Used when registering a window to receive messages about devices added or removed from the system.
		/// </summary>
		[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = global::System.Runtime.InteropServices.CharSet.Unicode, Pack = 1)]
		public class DeviceBroadcastInterface{
			public int Size;
			public int DeviceType;
			public int Reserved;
			public global::System.Guid ClassGuid;
			[global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 256)]
			public string Name;

			// Token: 0x06000067 RID: 103
			public DeviceBroadcastInterface() : base() { }
		}
		#endregion

		#region Constants
		/// <summary>Windows message sent when a device is inserted or removed</summary>
		public const int WM_DEVICECHANGE = 537; //public const int WM_DEVICECHANGE = 0x0219;
		/// <summary>WParam for above : A device was inserted</summary>
		public const int DEVICE_ARRIVAL = 32768;  //public const int DEVICE_ARRIVAL = 0x8000;
		/// <summary>WParam for above : A device was removed</summary>
		public const int DEVICE_REMOVECOMPLETE = 32772;  //public const int DEVICE_REMOVECOMPLETE = 0x8004;
		/// <summary>Used in SetupDiClassDevs to get devices present in the system</summary>
		protected const int DIGCF_PRESENT = 2;  //protected const int DIGCF_PRESENT = 0x02;
		protected const int DIGCF_ALLCLASSES = 4;
		/// <summary>Used in SetupDiClassDevs to get device interface details</summary>
		protected const int DIGCF_DEVICEINTERFACE = 16; //protected const int DIGCF_DEVICEINTERFACE = 0x10;
		/// <summary>Used when registering for device insert/remove messages : specifies the type of device</summary>
		protected const int DEVTYP_DEVICEINTERFACE = 5; //protected const int DEVTYP_DEVICEINTERFACE = 0x05;
		/// <summary>Used when registering for device insert/remove messages : we're giving the API call a window handle</summary>
		protected const int DEVICE_NOTIFY_WINDOW_HANDLE = 0; //protected const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
		/// <summary>Purges Win32 transmit buffer by aborting the current transmission.</summary>
		protected const uint PURGE_TXABORT = 1u; //protected const uint PURGE_TXABORT = 0x01;
		/// <summary>Purges Win32 receive buffer by aborting the current receive.</summary>
		protected const uint PURGE_RXABORT = 2u; //protected const uint PURGE_RXABORT = 0x02;
		/// <summary>Purges Win32 transmit buffer by clearing it.</summary>
		protected const uint PURGE_TXCLEAR = 4u; //protected const uint PURGE_TXCLEAR = 0x04;
		/// <summary>Purges Win32 receive buffer by clearing it.</summary>
		protected const uint PURGE_RXCLEAR = 8u; //protected const uint PURGE_RXCLEAR = 0x08;
		/// <summary>CreateFile : Open file for read</summary>
		protected const uint GENERIC_READ = 2147483648u; //protected const uint GENERIC_READ = 0x80000000;
		/// <summary>CreateFile : Open file for write</summary>
		protected const uint GENERIC_WRITE = 1073741824u; //protected const uint GENERIC_WRITE = 0x40000000;
		/// <summary>CreateFile : file share for write</summary>
		protected const uint FILE_SHARE_WRITE = 2u; //protected const uint FILE_SHARE_WRITE = 0x2;
		/// <summary>CreateFile : file share for read</summary>
		protected const uint FILE_SHARE_READ = 1u; //protected const uint FILE_SHARE_READ = 0x1;
		/// <summary>CreateFile : Open handle for overlapped operations</summary>
		protected const uint FILE_FLAG_OVERLAPPED = 1073741824u;  //protected const uint FILE_FLAG_OVERLAPPED = 0x40000000;
		/// <summary>CreateFile : Resource to be "created" must exist</summary>
		protected const uint OPEN_EXISTING = 3u; //protected const uint OPEN_EXISTING = 3;
		/// <summary>CreateFile : Resource will be "created" or existing will be used</summary>
		protected const uint OPEN_ALWAYS = 4u; //protected const uint OPEN_ALWAYS = 4;
		/// <summary>ReadFile/WriteFile : Overlapped operation is incomplete.</summary>
		protected const uint ERROR_IO_PENDING = 997u; //protected const uint ERROR_IO_PENDING = 997;
		/// <summary>Infinite timeout</summary>
		protected const uint INFINITE = uint.MaxValue; //protected const uint INFINITE = 0xFFFFFFFF;
		/// <summary>Simple representation of a null handle : a closed stream will get this handle. Note it is public for comparison by higher level classes.</summary>
		public static IntPtr NullHandle; //public static IntPtr NullHandle = IntPtr.Zero;
		/// <summary>Simple representation of the handle returned when CreateFile fails.</summary>
		protected static IntPtr InvalidHandleValue; //protected static IntPtr InvalidHandleValue = new IntPtr(-1);
		#endregion

		#region P/Invoke
		/// <summary>
		/// Gets the GUID that Windows uses to represent HID class devices
		/// </summary>
		/// <param name="gHid">An out parameter to take the Guid</param>
		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		protected static extern void HidD_GetHidGuid(out global::System.Guid gHid);
		/// <summary>
		/// Allocates an InfoSet memory block within Windows that contains details of devices.
		/// </summary>
		/// <param name="gClass">Class guid (e.g. HID guid)</param>
		/// <param name="strEnumerator">Not used</param>
		/// <param name="hParent">Not used</param>
		/// <param name="nFlags">Type of device details required (DIGCF_ constants)</param>
		/// <returns>A reference to the InfoSet</returns>
		[global::System.Runtime.InteropServices.DllImport("setupapi.dll", SetLastError = true)]
		protected static extern global::System.IntPtr SetupDiGetClassDevs(ref global::System.Guid gClass, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strEnumerator, global::System.IntPtr hParent, uint nFlags);

		/// <summary>
		/// Frees InfoSet allocated in call to above.
		/// </summary>
		/// <param name="lpInfoSet">Reference to InfoSet</param>
		/// <returns>true if successful</returns>
		[global::System.Runtime.InteropServices.DllImport("setupapi.dll", SetLastError = true)]
		protected static extern int SetupDiDestroyDeviceInfoList(global::System.IntPtr lpInfoSet);

		/// <summary>
		/// Gets the DeviceInterfaceData for a device from an InfoSet.
		/// </summary>
		/// <param name="lpDeviceInfoSet">InfoSet to access</param>
		/// <param name="nDeviceInfoData">Not used</param>
		/// <param name="gClass">Device class guid</param>
		/// <param name="nIndex">Index into InfoSet for device</param>
		/// <param name="oInterfaceData">DeviceInterfaceData to fill with data</param>
		/// <returns>True if successful, false if not (e.g. when index is passed end of InfoSet)</returns>
		[global::System.Runtime.InteropServices.DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiEnumDeviceInterfaces(global::System.IntPtr lpDeviceInfoSet, uint nDeviceInfoData, ref global::System.Guid gClass, uint nIndex, ref global::UsbLibrary.Win32Usb.DeviceInterfaceData oInterfaceData);

		/// <summary>
		/// SetupDiGetDeviceInterfaceDetail
		/// Gets the interface detail from a DeviceInterfaceData. This is pretty much the device path.
		/// You call this twice, once to get the size of the struct you need to send (nDeviceInterfaceDetailDataSize=0)
		/// and once again when you've allocated the required space.
		/// </summary>
		/// <param name="lpDeviceInfoSet">InfoSet to access</param>
		/// <param name="oInterfaceData">DeviceInterfaceData to use</param>
		/// <param name="lpDeviceInterfaceDetailData">DeviceInterfaceDetailData to fill with data</param>
		/// <param name="nDeviceInterfaceDetailDataSize">The size of the above</param>
		/// <param name="nRequiredSize">The required size of the above when above is set as zero</param>
		/// <param name="lpDeviceInfoData">Not used</param>
		/// <returns></returns>
		[global::System.Runtime.InteropServices.DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiGetDeviceInterfaceDetail(global::System.IntPtr lpDeviceInfoSet, ref global::UsbLibrary.Win32Usb.DeviceInterfaceData oInterfaceData, global::System.IntPtr lpDeviceInterfaceDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, global::System.IntPtr lpDeviceInfoData);

		/// <summary>
		/// SetupDiGetDeviceInterfaceDetail
		/// Gets the interface detail from a DeviceInterfaceData. This is pretty much the device path.
		/// You call this twice, once to get the size of the struct you need to send (nDeviceInterfaceDetailDataSize=0)
		/// and once again when you've allocated the required space.
		/// </summary>
		/// <param name="lpDeviceInfoSet">InfoSet to access</param>
		/// <param name="oInterfaceData">DeviceInterfaceData to use</param>
		/// <param name="oDetailData">DeviceInterfaceDetailData to fill with data</param>
		/// <param name="nDeviceInterfaceDetailDataSize">The size of the above</param>
		/// <param name="nRequiredSize">The required size of the above when above is set as zero</param>
		/// <param name="lpDeviceInfoData">Not used</param>
		/// <returns></returns>
		[global::System.Runtime.InteropServices.DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiGetDeviceInterfaceDetail(global::System.IntPtr lpDeviceInfoSet, ref global::UsbLibrary.Win32Usb.DeviceInterfaceData oInterfaceData, ref global::UsbLibrary.Win32Usb.DeviceInterfaceDetailData oDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, global::System.IntPtr lpDeviceInfoData);

		/// <summary>
		/// Registers a window for device insert/remove messages
		/// </summary>
		/// <param name="hwnd">Handle to the window that will receive the messages</param>
		/// <param name="oInterface">DeviceBroadcastInterrface structure</param>
		/// <param name="nFlags">set to DEVICE_NOTIFY_WINDOW_HANDLE</param>
		/// <returns>A handle used when unregistering</returns>
		[global::System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		protected static extern global::System.IntPtr RegisterDeviceNotification(global::System.IntPtr hwnd, global::UsbLibrary.Win32Usb.DeviceBroadcastInterface oInterface, uint nFlags);
		/// <summary>
		/// Unregister from above.
		/// </summary>
		/// <param name="hHandle">Handle returned in call to RegisterDeviceNotification</param>
		/// <returns>True if success</returns>
		[global::System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		protected static extern bool UnregisterDeviceNotification(global::System.IntPtr hHandle);

		/// <summary>
		/// Gets details from an open device. Reserves a block of memory which must be freed.
		/// </summary>
		/// <param name="hFile">Device file handle</param>
		/// <param name="lpData">Reference to the preparsed data block</param>
		/// <returns></returns>
		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		protected static extern bool HidD_GetPreparsedData(global::System.IntPtr hFile, out global::System.IntPtr lpData);

		/// <summary>
		/// Frees the memory block reserved above.
		/// </summary>
		/// <param name="pData">Reference to preparsed data returned in call to GetPreparsedData</param>
		/// <returns></returns>
		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		protected static extern bool HidD_FreePreparsedData(ref global::System.IntPtr pData);

		/// <summary>
		/// Gets a device's capabilities from the preparsed data.
		/// </summary>
		/// <param name="lpData">Preparsed data reference</param>
		/// <param name="oCaps">HidCaps structure to receive the capabilities</param>
		/// <returns>True if successful</returns>
		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		protected static extern int HidP_GetCaps(global::System.IntPtr lpData, out global::UsbLibrary.Win32Usb.HidCaps oCaps);

		/// <summary>
		/// Creates/opens a file, serial port, USB device... etc
		/// </summary>
		/// <param name="strName">Path to object to open</param>
		/// <param name="nAccess">Access mode. e.g. Read, write</param>
		/// <param name="nShareMode">Sharing mode</param>
		/// <param name="lpSecurity">Security details (can be null)</param>
		/// <param name="nCreationFlags">Specifies if the file is created or opened</param>
		/// <param name="nAttributes">Any extra attributes? e.g. open overlapped</param>
		/// <param name="lpTemplate">Not used</param>
		/// <returns></returns>
		[global::System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
		protected static extern global::System.IntPtr CreateFile([global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string strName, uint nAccess, uint nShareMode, global::System.IntPtr lpSecurity, uint nCreationFlags, uint nAttributes, global::System.IntPtr lpTemplate);

		/// <summary>
		/// Closes a window handle. File handles, event handles, mutex handles... etc
		/// </summary>
		/// <param name="hFile">Handle to close</param>
		/// <returns>True if successful.</returns>
		//[DllImport("kernel32.dll", SetLastError = true)] protected static extern int CloseHandle(IntPtr hFile);
		[global::System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
		public static extern int CloseHandle(global::System.IntPtr hFile);

		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		internal static extern bool HidD_SetFeature(global::System.IntPtr HidDeviceObject, byte[] ReportBuffer, int ReportBufferLength);

		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		internal static extern bool HidD_GetFeature(global::System.IntPtr HidDeviceObject, byte[] ReportBuffer, int ReportBufferLength);

		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		internal static extern bool HidD_GetManufacturerString(global::System.IntPtr HidDeviceObject, byte[] Buffer, int BufferLength);

		[global::System.Runtime.InteropServices.DllImport("hid.dll", SetLastError = true)]
		internal static extern bool HidD_GetProductString(global::System.IntPtr HidDeviceObject, byte[] Buffer, int BufferLength);
		#endregion

		#region Public methods
		/// <summary>
		/// Registers a window to receive windows messages when a device is inserted/removed. Need to call this
		/// from a form when its handle has been created, not in the form constructor. Use form's OnHandleCreated override.
		/// </summary>
		/// <param name="hWnd">Handle to window that will receive messages</param>
		/// <param name="gClass">Class of devices to get messages for</param>
		/// <returns>A handle used when unregistering</returns>
		public static global::System.IntPtr RegisterForUsbEvents(global::System.IntPtr hWnd, global::System.Guid gClass)
		{
			global::UsbLibrary.Win32Usb.DeviceBroadcastInterface deviceBroadcastInterface = new global::UsbLibrary.Win32Usb.DeviceBroadcastInterface();
			deviceBroadcastInterface.Size = global::System.Runtime.InteropServices.Marshal.SizeOf((object)deviceBroadcastInterface);
			deviceBroadcastInterface.ClassGuid = gClass;
			deviceBroadcastInterface.DeviceType = 5;
			deviceBroadcastInterface.Reserved = 0;
			return global::UsbLibrary.Win32Usb.RegisterDeviceNotification(hWnd, deviceBroadcastInterface, 0U);
		}

		/// <summary>
		/// Unregisters notifications. Can be used in form dispose
		/// </summary>
		/// <param name="hHandle">Handle returned from RegisterForUSBEvents</param>
		/// <returns>True if successful</returns>
		public static bool UnregisterForUsbEvents(global::System.IntPtr hHandle) { return global::UsbLibrary.Win32Usb.UnregisterDeviceNotification(hHandle); }

		/// <summary>
		/// Helper to get the HID guid.
		/// </summary>
		public static global::System.Guid HIDGuid {
			get {
				global::System.Guid result;
				global::UsbLibrary.Win32Usb.HidD_GetHidGuid(out result);
				return result; } }
		#endregion

		public Win32Usb() : base() { }
		static Win32Usb() {
			global::UsbLibrary.Win32Usb.NullHandle = global::System.IntPtr.Zero;
			global::UsbLibrary.Win32Usb.InvalidHandleValue = new global::System.IntPtr(-1); }
	}
}
