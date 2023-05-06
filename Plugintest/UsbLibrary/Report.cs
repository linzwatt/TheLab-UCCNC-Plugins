namespace UsbLibrary {
	/// <summary>
	/// Base class for report types. Simply wraps a byte buffer.
	/// </summary>
	public abstract class Report {
		#region Member variables
		/// <summary>Buffer for raw report bytes</summary>
		private byte[] buffer;
		/// <summary>Length of the report</summary>
		private int bufferLength;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="oDev">Constructing device</param>
		public Report(global::UsbLibrary.HIDDevice oDev) { }

		/// <summary>
		/// Sets the raw byte array.
		/// </summary>
		/// <param name="arrBytes">Raw report bytes</param>
		protected void SetBuffer(byte[] arrBytes) {
			this.buffer = arrBytes;
			this.bufferLength = this.buffer.Length; }

		/// <summary>
		/// Accessor for the raw byte buffer
		/// </summary>
		public byte[] Buffer { get { return this.buffer; } set { this.buffer = value; } }

		/// <summary>
		/// Accessor for the buffer length
		/// </summary>
		public int BufferLength { get { return this.bufferLength; } }
	}
}
