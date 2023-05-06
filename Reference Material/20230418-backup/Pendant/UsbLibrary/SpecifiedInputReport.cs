using AjAhb4QLiU9IFaCBlx4;

namespace UsbLibrary
{
	public class SpecifiedInputReport : InputReport
	{
		private byte[] dY2TIBTWN;

		public byte[] Data => dY2TIBTWN;

		public SpecifiedInputReport(HIDDevice oDev)
		{
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			base._002Ector(oDev);
		}

		public override void ProcessData()
		{
			//Discarded unreachable code: IL_0002
			dY2TIBTWN = base.Buffer;
		}
	}
}
