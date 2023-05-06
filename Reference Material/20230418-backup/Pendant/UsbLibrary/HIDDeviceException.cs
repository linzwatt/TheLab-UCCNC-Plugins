using System;
using System.Runtime.InteropServices;
using AjAhb4QLiU9IFaCBlx4;
using MfKP42m2oa64TIB4sD0;

namespace UsbLibrary
{
	public class HIDDeviceException : ApplicationException
	{
		public HIDDeviceException(string strMessage)
		{
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			base._002Ector(strMessage);
		}

		public static HIDDeviceException GenerateWithWinError(string strMessage)
		{
			//Discarded unreachable code: IL_0002
			return new HIDDeviceException(string.Format(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2944AFE7 ^ 0x2944AFE7), strMessage, Marshal.GetLastWin32Error()));
		}

		public static HIDDeviceException GenerateError(string strMessage)
		{
			//Discarded unreachable code: IL_0002
			return new HIDDeviceException(string.Format(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x58864335 ^ 0x58864319), strMessage));
		}
	}
}
