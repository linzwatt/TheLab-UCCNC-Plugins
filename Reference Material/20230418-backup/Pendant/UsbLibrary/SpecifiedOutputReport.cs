using AjAhb4QLiU9IFaCBlx4;

namespace UsbLibrary
{
	public class SpecifiedOutputReport : OutputReport
	{
		public SpecifiedOutputReport(HIDDevice oDev)
		{
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			base._002Ector(oDev);
		}

		public bool SendData(byte[] data)
		{
			//Discarded unreachable code: IL_0002
			SetBuffer(data);
			byte[] buffer = base.Buffer;
			for (int i = 1; i < buffer.Length; i++)
			{
				buffer[i] = data[i];
			}
			return buffer.Length >= data.Length;
		}
	}
}
