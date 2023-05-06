using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AjAhb4QLiU9IFaCBlx4;

namespace UsbLibrary
{
	public class SpecifiedDevice : HIDDevice
	{
		[CompilerGenerated]
		private DataRecievedEventHandler yOiwte4ay;

		[CompilerGenerated]
		private DataSendEventHandler lJwWWndvZ;

		public event DataRecievedEventHandler DataRecieved
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				DataRecievedEventHandler dataRecievedEventHandler = yOiwte4ay;
				DataRecievedEventHandler dataRecievedEventHandler2;
				do
				{
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					dataRecievedEventHandler = Interlocked.CompareExchange(value: (DataRecievedEventHandler)Delegate.Combine(dataRecievedEventHandler2, value), location1: ref yOiwte4ay, comparand: dataRecievedEventHandler2);
				}
				while ((object)dataRecievedEventHandler != dataRecievedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				DataRecievedEventHandler dataRecievedEventHandler = yOiwte4ay;
				DataRecievedEventHandler dataRecievedEventHandler2;
				do
				{
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					dataRecievedEventHandler = Interlocked.CompareExchange(value: (DataRecievedEventHandler)Delegate.Remove(dataRecievedEventHandler2, value), location1: ref yOiwte4ay, comparand: dataRecievedEventHandler2);
				}
				while ((object)dataRecievedEventHandler != dataRecievedEventHandler2);
			}
		}

		public event DataSendEventHandler DataSend
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				DataSendEventHandler dataSendEventHandler = lJwWWndvZ;
				DataSendEventHandler dataSendEventHandler2;
				do
				{
					dataSendEventHandler2 = dataSendEventHandler;
					dataSendEventHandler = Interlocked.CompareExchange(value: (DataSendEventHandler)Delegate.Combine(dataSendEventHandler2, value), location1: ref lJwWWndvZ, comparand: dataSendEventHandler2);
				}
				while ((object)dataSendEventHandler != dataSendEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				DataSendEventHandler dataSendEventHandler = lJwWWndvZ;
				DataSendEventHandler dataSendEventHandler2;
				do
				{
					dataSendEventHandler2 = dataSendEventHandler;
					dataSendEventHandler = Interlocked.CompareExchange(value: (DataSendEventHandler)Delegate.Remove(dataSendEventHandler2, value), location1: ref lJwWWndvZ, comparand: dataSendEventHandler2);
				}
				while ((object)dataSendEventHandler != dataSendEventHandler2);
			}
		}

		public override InputReport CreateInputReport()
		{
			//Discarded unreachable code: IL_0002
			return new SpecifiedInputReport(this);
		}

		protected override void Dispose(bool bDisposing)
		{
			//Discarded unreachable code: IL_0002
			base.Dispose(bDisposing);
		}

		public static SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id, int col)
		{
			//Discarded unreachable code: IL_0002
			return (SpecifiedDevice)HIDDevice.FindDevice(vendor_id, product_id, typeof(SpecifiedDevice), col);
		}

		protected override void HandleDataReceived(InputReport oInRep)
		{
			//Discarded unreachable code: IL_0002
			if (yOiwte4ay != null)
			{
				SpecifiedInputReport obj = (SpecifiedInputReport)oInRep;
				yOiwte4ay(this, new DataRecievedEventArgs(obj.Data));
			}
		}

		public void SendData(byte[] data)
		{
			//Discarded unreachable code: IL_0002
			byte[] array = new byte[8];
			if ((array = data) != null && array.Length != 0)
			{
				_ = array[0];
			}
			else
			{
				_ = 0u;
			}
			Win32Usb.JFUrhoPvo(m_hHandle, array, data.Length);
		}

		public SpecifiedDevice() : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
		}
	}
}
