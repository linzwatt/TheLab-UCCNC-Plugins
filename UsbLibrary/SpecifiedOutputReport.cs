namespace UsbLibrary {
	public class SpecifiedOutputReport : global::UsbLibrary.OutputReport {
		public SpecifiedOutputReport(global::UsbLibrary.HIDDevice oDev) : base(oDev) { }

		public bool SendData(byte[] data) {
			base.SetBuffer(data);
			byte[] buffer = base.Buffer;
			for (int i = 1; i < buffer.Length; i++) { buffer[i] = data[i]; }
			return buffer.Length >= data.Length;
		}
	}
}
