using System;
using System.IO;

namespace DataRepositories {
	// Token: 0x0200003E RID: 62
	public class StreamBinaryReader {
		// Token: 0x04000934 RID: 2356
		BinaryReader binaryReader;

		// Token: 0x060005A8 RID: 1448
		public StreamBinaryReader(Stream streamIn) { this.binaryReader = new BinaryReader(streamIn); }

		// Token: 0x060005A9 RID: 1449
		internal Stream BaseStream() { return this.binaryReader.BaseStream; }

		// Token: 0x060005AA RID: 1450
		internal void Close() { this.binaryReader.Close(); }

		// Token: 0x06000736 RID: 1846
		internal static MemoryStream NewMemoryStream() { return new MemoryStream(); }

		// Token: 0x060005AB RID: 1451
		internal int Read(byte[] arrBuffer, int index, int count) { return this.binaryReader.Read(arrBuffer, index, count); }

		// Token: 0x060005AC RID: 1452
		internal byte[] ReadBytes(int count) { return this.binaryReader.ReadBytes(count); }

		// Token: 0x060005AD RID: 1453
		internal int ReadInt32() { return this.binaryReader.ReadInt32(); }
	}
}
