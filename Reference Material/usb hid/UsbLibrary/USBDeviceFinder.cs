using System.Collections.Generic;

namespace UsbLibrary
{
	public static class USBDeviceFinder
	{
		public static List<UsbHidPort> FindDevices(int nVid, int nPid)
		{
			var result = new List<UsbHidPort>();
			var usbHidDevices = HIDDevice.FindAllDevice(nVid, nPid, typeof(SpecifiedDevice));
			foreach (var usbHidDevice in usbHidDevices)
			{
				var usbHidPort = new UsbHidPort()
				{
					VendorId = 0xC251,
					ProductId = 0x1303
				};
				usbHidPort.SpecifiedDevice = (SpecifiedDevice)usbHidDevice;
				result.Add(usbHidPort);
				usbHidPort.SetSpecifiedDevice((SpecifiedDevice)usbHidDevice);
			}
			return result;
		}
	}
}