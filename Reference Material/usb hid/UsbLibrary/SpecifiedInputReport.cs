
namespace UsbLibrary
{
    public class SpecifiedInputReport : InputReport
    {
        private byte[] arrData;

        public SpecifiedInputReport(HIDDevice oDev) : base(oDev)
		{

		}

        public override void ProcessData()
        {
            this.arrData = Buffer;
        }

        public byte[] Data
        {
            get
            {
                return arrData;
            }
        }
    }
}
