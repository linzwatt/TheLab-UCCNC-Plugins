using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using AjAhb4QLiU9IFaCBlx4;

namespace UsbLibrary
{
	public class UsbHidPort : Component
	{
		private int pqSfwFHjt;

		private int GAEMYmnv4;

		private Guid zDwpyIW4Q;

		private IntPtr n73yoG4i7;

		private SpecifiedDevice wNRRZk9Z7;

		private SpecifiedDevice N3X8pdNZe;

		private IntPtr l9RhPA1mQ;

		[CompilerGenerated]
		private EventHandler oyA79MNXw;

		[CompilerGenerated]
		private EventHandler Yj1GE4Cwv;

		[CompilerGenerated]
		private EventHandler YnxuMs0Hx;

		[CompilerGenerated]
		private EventHandler QAocMNmdV;

		[CompilerGenerated]
		private DataRecievedEventHandler AZZCY0NDH;

		[CompilerGenerated]
		private EventHandler o4HUfEL6m;

		private IContainer wqRlUwRxP;

		[Category("Embedded Details")]
		[DefaultValue("(none)")]
		[Description("The product id from the USB device you want to use")]
		public int ProductId
		{
			get
			{
				//Discarded unreachable code: IL_0002
				return pqSfwFHjt;
			}
			set
			{
				//Discarded unreachable code: IL_0002
				pqSfwFHjt = value;
			}
		}

		[Category("Embedded Details")]
		[Description("The vendor id from the USB device you want to use")]
		[DefaultValue("(none)")]
		public int VendorId
		{
			get
			{
				//Discarded unreachable code: IL_0002
				return GAEMYmnv4;
			}
			set
			{
				//Discarded unreachable code: IL_0002
				GAEMYmnv4 = value;
			}
		}

		[DefaultValue("(none)")]
		[Description("The Device Class the USB device belongs to")]
		[Category("Embedded Details")]
		public Guid DeviceClass => zDwpyIW4Q;

		[Category("Embedded Details")]
		[DefaultValue("(none)")]
		[Description("The Device witch applies to the specifications you set")]
		public SpecifiedDevice SpecifiedDeviceRead => wNRRZk9Z7;

		public SpecifiedDevice SpecifiedDeviceWrite => N3X8pdNZe;

		[Description("Событие, срабатывающее при подключении устройства с указанными PID, VID")]
		[Category("Embedded Event")]
		[DisplayName("OnSpecifiedDeviceArrived")]
		public event EventHandler OnSpecifiedDeviceArrived
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = oyA79MNXw;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref oyA79MNXw, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = oyA79MNXw;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref oyA79MNXw, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		[DisplayName("OnSpecifiedDeviceRemoved")]
		[Category("Embedded Event")]
		[Description("Событие, срабатывающее при отключении устройства с указанными PID, VID")]
		public event EventHandler OnSpecifiedDeviceRemoved
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = Yj1GE4Cwv;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref Yj1GE4Cwv, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = Yj1GE4Cwv;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref Yj1GE4Cwv, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		[DisplayName("OnDeviceArrived")]
		[Category("Embedded Event")]
		[Description("Событие, срабатывающее при подключении любого USB-устройства")]
		public event EventHandler OnDeviceArrived
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = YnxuMs0Hx;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref YnxuMs0Hx, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = YnxuMs0Hx;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref YnxuMs0Hx, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		[DisplayName("OnDeviceRemoved")]
		[Category("Embedded Event")]
		[Description("Событие, срабатывающее при отключении любого USB-устройства")]
		public event EventHandler OnDeviceRemoved
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = QAocMNmdV;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref QAocMNmdV, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = QAocMNmdV;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref QAocMNmdV, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		[Category("Embedded Event")]
		[DisplayName("OnDataRecieved")]
		[Description("Событие, срабатывающее при получении данных от выбранного USB-устройства")]
		public event DataRecievedEventHandler OnDataRecieved
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				DataRecievedEventHandler dataRecievedEventHandler = AZZCY0NDH;
				DataRecievedEventHandler dataRecievedEventHandler2;
				do
				{
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					dataRecievedEventHandler = Interlocked.CompareExchange(value: (DataRecievedEventHandler)Delegate.Combine(dataRecievedEventHandler2, value), location1: ref AZZCY0NDH, comparand: dataRecievedEventHandler2);
				}
				while ((object)dataRecievedEventHandler != dataRecievedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				DataRecievedEventHandler dataRecievedEventHandler = AZZCY0NDH;
				DataRecievedEventHandler dataRecievedEventHandler2;
				do
				{
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					dataRecievedEventHandler = Interlocked.CompareExchange(value: (DataRecievedEventHandler)Delegate.Remove(dataRecievedEventHandler2, value), location1: ref AZZCY0NDH, comparand: dataRecievedEventHandler2);
				}
				while ((object)dataRecievedEventHandler != dataRecievedEventHandler2);
			}
		}

		[Description("Событие, срабатывающее при отправке данных к выбранному USB-устройству")]
		[DisplayName("OnDataSend")]
		[Category("Embedded Event")]
		public event EventHandler OnDataSend
		{
			[CompilerGenerated]
			add
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = o4HUfEL6m;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref o4HUfEL6m, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				//Discarded unreachable code: IL_0002
				EventHandler eventHandler = o4HUfEL6m;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref o4HUfEL6m, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public UsbHidPort() : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			pqSfwFHjt = 0;
			GAEMYmnv4 = 0;
			wNRRZk9Z7 = null;
			N3X8pdNZe = null;
			zDwpyIW4Q = Win32Usb.HIDGuid;
		}

		public UsbHidPort(IContainer container) : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			pqSfwFHjt = 0;
			GAEMYmnv4 = 0;
			wNRRZk9Z7 = null;
			N3X8pdNZe = null;
			zDwpyIW4Q = Win32Usb.HIDGuid;
			container.Add(this);
		}

		public void CheckDevicePresent()
		{
			try
			{
				bool flag = false;
				if (wNRRZk9Z7 != null && N3X8pdNZe != null)
				{
					flag = true;
				}
				wNRRZk9Z7 = SpecifiedDevice.FindSpecifiedDevice(GAEMYmnv4, pqSfwFHjt, 1);
				if (wNRRZk9Z7 == null)
				{
					if (Yj1GE4Cwv != null && flag)
					{
						Yj1GE4Cwv(this, new EventArgs());
					}
				}
				else if (oyA79MNXw != null)
				{
					oyA79MNXw(this, new EventArgs());
					wNRRZk9Z7.DataRecieved += AZZCY0NDH.Invoke;
				}
				N3X8pdNZe = SpecifiedDevice.FindSpecifiedDevice(GAEMYmnv4, pqSfwFHjt, 2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void nrCZ9SlXY(object _0020, DataRecievedEventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (AZZCY0NDH != null)
			{
				AZZCY0NDH(_0020, _0020);
			}
		}

		private void Qbr0spOc3(object _0020, DataSendEventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (o4HUfEL6m != null)
			{
				o4HUfEL6m(_0020, _0020);
			}
		}

		private void Oq91R0Wtu()
		{
			//Discarded unreachable code: IL_0002
			wqRlUwRxP = new Container();
		}

		public void ParseMessages(ref Message m)
		{
			//Discarded unreachable code: IL_0002
			if (m.Msg != 537)
			{
				return;
			}
			switch (m.WParam.ToInt32())
			{
			case 32768:
				if (YnxuMs0Hx != null)
				{
					YnxuMs0Hx(this, new EventArgs());
					CheckDevicePresent();
				}
				break;
			case 32772:
				if (QAocMNmdV != null)
				{
					QAocMNmdV(this, new EventArgs());
					CheckDevicePresent();
				}
				break;
			}
		}

		public void RegisterHandle(IntPtr Handle)
		{
			//Discarded unreachable code: IL_0002
			n73yoG4i7 = Win32Usb.RegisterForUsbEvents(Handle, zDwpyIW4Q);
			l9RhPA1mQ = Handle;
			CheckDevicePresent();
		}

		public bool UnregisterHandle()
		{
			//Discarded unreachable code: IL_0002
			return Win32Usb.UnregisterForUsbEvents(l9RhPA1mQ);
		}

		protected override void Dispose(bool disposing)
		{
			//Discarded unreachable code: IL_0002
			UnregisterHandle();
			if (disposing && wqRlUwRxP != null)
			{
				wqRlUwRxP.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
