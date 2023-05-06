using AjAhb4QLiU9IFaCBlx4;

namespace UsbLibrary
{
	public abstract class InputReport : Report
	{
		public InputReport(HIDDevice oDev)
		{
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			base._002Ector(oDev);
		}

		public abstract void ProcessData();

		public void SetData(byte[] arrData)
		{
			//Discarded unreachable code: IL_0002
			SetBuffer(arrData);
			ProcessData();
		}
	}
}
