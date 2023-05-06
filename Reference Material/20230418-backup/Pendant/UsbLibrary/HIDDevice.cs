using System;
using System.IO;
using System.Runtime.InteropServices;
using AjAhb4QLiU9IFaCBlx4;
using MfKP42m2oa64TIB4sD0;
using Microsoft.Win32.SafeHandles;

namespace UsbLibrary
{
	public abstract class HIDDevice : Win32Usb, IDisposable
	{
		private FileStream S3yeKFKlR;

		private int pE9E43eB7;

		private int gKpNW0e68;

		public IntPtr m_hHandle;

		private EventHandler MRCip28Mw;

		public int OutputReportLength => gKpNW0e68;

		public int InputReportLength => pE9E43eB7;

		protected HIDDevice() : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
		}

		private void bDsxNIe7H()
		{
			//Discarded unreachable code: IL_0002
			byte[] array = new byte[pE9E43eB7];
			S3yeKFKlR.BeginRead(array, 0, pE9E43eB7, ReadCompleted, array);
		}

		public virtual InputReport CreateInputReport()
		{
			//Discarded unreachable code: IL_0002
			return null;
		}

		public void Dispose()
		{
			//Discarded unreachable code: IL_0002
			Dispose(bDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool bDisposing)
		{
			try
			{
				if (bDisposing && S3yeKFKlR != null)
				{
					S3yeKFKlR.Close();
					S3yeKFKlR = null;
				}
				if (m_hHandle != IntPtr.Zero)
				{
					Win32Usb.CloseHandle(m_hHandle);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public static HIDDevice FindDevice(int nVid, int nPid, Type oType, int col)
		{
			//Discarded unreachable code: IL_0002
			string value = string.Format(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1394683286 ^ -1394683308), nVid, nPid, col);
			Guid gClass = Win32Usb.HIDGuid;
			IntPtr intPtr = Win32Usb.SetupDiGetClassDevs(ref gClass, null, IntPtr.Zero, 18u);
			try
			{
				DeviceInterfaceData oInterfaceData = default(DeviceInterfaceData);
				oInterfaceData.Size = Marshal.SizeOf((object)oInterfaceData);
				for (int i = 0; Win32Usb.SetupDiEnumDeviceInterfaces(intPtr, 0u, ref gClass, (uint)i, ref oInterfaceData); i++)
				{
					string text = x86qKmn5G(intPtr, ref oInterfaceData);
					if (text.IndexOf(value) >= 0)
					{
						HIDDevice obj = (HIDDevice)Activator.CreateInstance(oType);
						obj.zdiYA28cf(text, col);
						return obj;
					}
				}
			}
			catch (Exception ex)
			{
				throw HIDDeviceException.GenerateError(ex.ToString());
			}
			finally
			{
				Win32Usb.SetupDiDestroyDeviceInfoList(intPtr);
			}
			return null;
		}

		private static string x86qKmn5G(IntPtr _0020, ref DeviceInterfaceData _0020)
		{
			//Discarded unreachable code: IL_0002
			uint nRequiredSize = 0u;
			if (!Win32Usb.SetupDiGetDeviceInterfaceDetail(_0020, ref _0020, IntPtr.Zero, 0u, ref nRequiredSize, IntPtr.Zero))
			{
				int num = 4;
				num = ((IntPtr.Size != 4) ? 8 : 5);
				DeviceInterfaceDetailData deviceInterfaceDetailData = default(DeviceInterfaceDetailData);
				deviceInterfaceDetailData.Size = num;
				DeviceInterfaceDetailData oDetailData = deviceInterfaceDetailData;
				if (Win32Usb.SetupDiGetDeviceInterfaceDetail(_0020, ref _0020, ref oDetailData, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
				{
					return oDetailData.DevicePath;
				}
			}
			return null;
		}

		protected virtual void HandleDataReceived(InputReport oInRep)
		{
		}//Discarded unreachable code: IL_0002


		protected virtual void HandleDeviceRemoved()
		{
		}//Discarded unreachable code: IL_0002


		private void zdiYA28cf(string _0020, int _0020)
		{
			//Discarded unreachable code: IL_0002
			m_hHandle = Win32Usb.CreateFile(_0020, 3221225472u, 0u, IntPtr.Zero, 3u, 1073741824u, IntPtr.Zero);
			if (!(m_hHandle != Win32Usb.InvalidHandleValue))
			{
				m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1139029737 ^ -1139029611));
			}
			if (!Win32Usb.HidD_GetPreparsedData(m_hHandle, out var lpData))
			{
				throw HIDDeviceException.GenerateWithWinError(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1301707872 ^ -1301708002));
			}
			try
			{
				Win32Usb.HidP_GetCaps(lpData, out var oCaps);
				pE9E43eB7 = oCaps.InputReportByteLength;
				gKpNW0e68 = oCaps.OutputReportByteLength;
				if (_0020 == 2)
				{
					S3yeKFKlR = new FileStream(new SafeFileHandle(m_hHandle, ownsHandle: false), FileAccess.Write, 8, isAsync: true);
					return;
				}
				S3yeKFKlR = new FileStream(new SafeFileHandle(m_hHandle, ownsHandle: false), FileAccess.ReadWrite, pE9E43eB7, isAsync: true);
				bDsxNIe7H();
			}
			catch
			{
				throw HIDDeviceException.GenerateWithWinError(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476990197));
			}
			finally
			{
				Win32Usb.HidD_FreePreparsedData(ref lpData);
			}
		}

		protected void ReadCompleted(IAsyncResult iResult)
		{
			//Discarded unreachable code: IL_0002
			byte[] data = (byte[])iResult.AsyncState;
			try
			{
				S3yeKFKlR.EndRead(iResult);
				try
				{
					InputReport inputReport = CreateInputReport();
					inputReport.SetData(data);
					HandleDataReceived(inputReport);
				}
				finally
				{
					bDsxNIe7H();
				}
			}
			catch (IOException)
			{
				HandleDeviceRemoved();
				if (MRCip28Mw != null)
				{
					MRCip28Mw(this, new EventArgs());
				}
				Dispose();
			}
		}

		protected void Write(OutputReport oOutRep)
		{
			try
			{
				S3yeKFKlR.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
			}
			catch (IOException)
			{
				throw new HIDDeviceException(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2EE19E9B ^ 0x2EE19FD5));
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}
	}
}
