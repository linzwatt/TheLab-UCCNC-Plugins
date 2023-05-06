using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using DecompilerArtifacts;

namespace MfKP42m2oa64TIB4sD0
{
	// Token: 0x02000021 RID: 33
	internal class DataRepository
	{
		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x060000F9 RID: 249
		private delegate void O5uUu9QT7RaaAlMf8q7(object o);

		// Token: 0x02000023 RID: 35
		internal class __G3ycxdQZ1KT9ALQ8cdt : Attribute
		{
			// Token: 0x02000024 RID: 36
			internal class __SxBa0QQ0Ag8jbNOa0fm<m1x0gvQ1qhGqDn8vw8J>
			{
				// Token: 0x060000FD RID: 253
				public __SxBa0QQ0Ag8jbNOa0fm()
				{
					feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
				}
			}

			// Token: 0x060000FC RID: 252
			public __G3ycxdQZ1KT9ALQ8cdt(object input)
			{
			}
		}

		// Token: 0x02000025 RID: 37
		internal class Encrypted
		{
			// Token: 0x060000FE RID: 254
			internal static string Write(string data, string initialisationVector)
			{
				byte[] array = Encoding.Unicode.GetBytes(data);
				byte[] key = new byte[]
				{
					0x52,
					0x66,
					0x68,
					0x6E,
					0x20,
					0x4D,
					0x18,
					0x22,
					0x76,
					0xB5,
					0x33,
					0x11,
					0x12,
					0x33,
					0xC,
					0x6D,
					0xA,
					0x20,
					0x4D,
					0x18,
					0x22,
					0x9E,
					0xA1,
					0x29,
					0x61,
					0x1C,
					0x76,
					0xB5,
					5,
					0x19,
					1,
					0x58
				};
				byte[] iv = DataRepository.InivialisationVector(Encoding.Unicode.GetBytes(initialisationVector));
				MemoryStream memoryStream = new MemoryStream();
				SymmetricAlgorithm symmetricAlgorithm = DataRepository.GetSymmetricAlgorithm();
				symmetricAlgorithm.Key = key;
				symmetricAlgorithm.IV = iv;
				CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.Close();
				return Convert.ToBase64String(memoryStream.ToArray());
			}

			// Token: 0x060000FF RID: 255
			public Encrypted()
			{
			}
		}

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x06000101 RID: 257
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate uint qmDREFQp83LYtI4yaIG(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

		// Token: 0x02000028 RID: 40
		internal struct __tRccNmQRO7nnpmyPaO2
		{
			// Token: 0x0400012E RID: 302
			internal bool __D3aQ8Y0eVs;

			// Token: 0x0400012F RID: 303
			internal byte[] __B2cQhrDuuI;
		}

		// Token: 0x02000029 RID: 41
		internal class StreamHolder
		{
			// Token: 0x04000130 RID: 304
			private BinaryReader binaryReader;
			
			internal BinaryReader _BinaryReader(BinaryReader binaryReaderIn) {
				this.binaryReader = binaryReaderIn;
				this._Position(0L);
				return this.binaryReader; }
			internal BinaryReader _BinaryReader(Stream inputStream) { return this._BinaryReader(new BinaryReader(inputStream)); }
			internal BinaryReader _BinaryReader() { return this.binaryReader; }
			
			internal void _Initialise(BinaryReader binaryReaderIn) { this._BinaryReader(binaryReaderIn); }
			internal void _Initialise(Stream inputStream) { this._BinaryReader(inputStream); }
			internal void _Initialise(byte[] arrayIn) { this._BinaryReader(new global::System.IO.MemoryStream(arrayIn)); }
			internal void _Initialise(string resourceName) { this._BinaryReader(typeof(DataRepository).Assembly.GetManifestResourceStream(resourceName)); }


			// Token: 0x06000108 RID: 264
			public StreamHolder(BinaryReader binaryReaderIn) { this._Initialise(binaryReaderIn); }
			public StreamHolder(Stream inputStream) { this._Initialise(inputStream); }
			public StreamHolder(byte[] arrayIn) { this._Initialise(arrayIn); }
			public StreamHolder(string resourceName) { this._Initialise(resourceName); }
			public StreamHolder() { this.binaryReader = null; }

			// Token: 0x06000109 RID: 265
			internal Stream _GetBaseStream() { return this.binaryReader.BaseStream; }

			// Token: 0x0600010A RID: 266
			internal byte[] _ReadBytes(int count) { return this.binaryReader.ReadBytes(count); }
			internal byte[] _ReadBytes(long count) { return this._ReadBytes((int)count); }

			// Token: 0x0600010B RID: 267
			internal int _Read(byte[] buffer, int index, int count) { return this.binaryReader.Read(buffer, index, count); }

			// Token: 0x0600010C RID: 268
			internal int _ReadInt32() { return this.binaryReader.ReadInt32(); }
			internal uint _ReadUInt32() { return this.binaryReader.ReadUInt32(); }

			// Token: 0x0600010D RID: 269
			internal void _Close() { if (this.binaryReader != null) { this.binaryReader.Close(); } }

			// Token: 0x0600193E RID: 6462
			internal long _Position(long position) { this._GetBaseStream().Position = position; return this._GetBaseStream().Position; }
			internal long _Position() { return this._GetBaseStream().Position; }

			// Token: 0x06001A2B RID: 6699
			internal long _Length() { return this._GetBaseStream().Length; }

			// Token: 0x06001A2C RID: 6700
			internal byte[] _ReadAllBytes() {
				this._Position(0L);
				return this._ReadBytes(this._Length()); }

			internal void _Destroy() { this._Close(); this.binaryReader = null; }
		}

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x0600010F RID: 271
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private delegate IntPtr K32_Delegate_FindResourceA(IntPtr hModule, string lpName, uint lpType);

		// Token: 0x0200002B RID: 43
		// (Invoke) Token: 0x06000113 RID: 275
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr K32_Delegate_VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x0200002C RID: 44
		// (Invoke) Token: 0x06000117 RID: 279
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int K32_Delegate_WriteProcess(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x0200002D RID: 45
		// (Invoke) Token: 0x0600011B RID: 283
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int K32_Delegate_VirtualProtect(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

		// Token: 0x0200002E RID: 46
		// (Invoke) Token: 0x0600011F RID: 287
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr K32_Delegate_OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		// Token: 0x0200002F RID: 47
		// (Invoke) Token: 0x06000123 RID: 291
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int K32_Delegate_CloseHandle(IntPtr ptr);

		// Token: 0x02000030 RID: 48
		[Flags]
		private enum __InpDWYQvwkCXqYTaEnP
		{

		}

		// Token: 0x04000106 RID: 262
		internal static Assembly assembly = typeof(DataRepository).Assembly;

		// Token: 0x04000107 RID: 263
		private static uint[] _IncrementorRefference = new uint[]
		{
			0xD76AA478U,
			0xE8C7B756U,
			0x242070DBU,
			0xC1BDCEEEU,
			0xF57C0FAFU,
			0x4787C62AU,
			0xA8304613U,
			0xFD469501U,
			0x698098D8U,
			0x8B44F7AFU,
			0xFFFF5BB1U,
			0x895CD7BEU,
			0x6B901122U,
			0xFD987193U,
			0xA679438EU,
			0x49B40821U,
			0xF61E2562U,
			0xC040B340U,
			0x265E5A51U,
			0xE9B6C7AAU,
			0xD62F105DU,
			0x2441453U,
			0xD8A1E681U,
			0xE7D3FBC8U,
			0x21E1CDE6U,
			0xC33707D6U,
			0xF4D50D87U,
			0x455A14EDU,
			0xA9E3E905U,
			0xFCEFA3F8U,
			0x676F02D9U,
			0x8D2A4C8AU,
			0xFFFA3942U,
			0x8771F681U,
			0x6D9D6122U,
			0xFDE5380CU,
			0xA4BEEA44U,
			0x4BDECFA9U,
			0xF6BB4B60U,
			0xBEBFBC70U,
			0x289B7EC6U,
			0xEAA127FAU,
			0xD4EF3085U,
			0x4881D05U,
			0xD9D4D039U,
			0xE6DB99E5U,
			0x1FA27CF8U,
			0xC4AC5665U,
			0xF4292244U,
			0x432AFF97U,
			0xAB9423A7U,
			0xFC93A039U,
			0x655B59C3U,
			0x8F0CCC92U,
			0xFFEFF47DU,
			0x85845DD1U,
			0x6FA87E4FU,
			0xFE2CE6E0U,
			0xA3014314U,
			0x4E0811A1U,
			0xF7537E82U,
			0xBD3AF235U,
			0x2AD7D2BBU,
			0xEB86D391U
		};

		// Token: 0x04000108 RID: 264
		private static bool onlyFipsAlgorithmsChecked = false;

		// Token: 0x04000109 RID: 265
		private static bool onlyFipsAlgorithms = false;

		// Token: 0x0400010A RID: 266
		internal static RSACryptoServiceProvider rsaCryptoServiceProvider = null;

		// Token: 0x0400010B RID: 267
		private static List<string> resourceNames;

		// Token: 0x0400010C RID: 268
		private static List<int> resourceIndexes;

		// Token: 0x0400010D RID: 269
		private static object GrdOz8RkRK;

		// Token: 0x0400010E RID: 270
		private static SortedList sortedList;

		// Token: 0x0400010F RID: 271
		private static int b8kQQ9dxI9;

		// Token: 0x04000110 RID: 272
		private static long A5VQHGan76;

		// Token: 0x04000111 RID: 273
		private static IntPtr wrcQxpDMN9;

		// Token: 0x04000112 RID: 274
		internal static Hashtable hashTable;

		// Token: 0x04000113 RID: 275
		private static DataRepository.K32_Delegate_WriteProcess k32_WriteProcess;

		// Token: 0x04000114 RID: 276
		private static DataRepository.K32_Delegate_VirtualProtect k32_VirtualProtect;

		// Token: 0x04000115 RID: 277
		private static string messageStartConstant;

		// Token: 0x04000116 RID: 278
		private static int[] HyAQ54wiD1;

		// Token: 0x04000117 RID: 279
		private static long QF5QFLFrFE;

		// Token: 0x04000118 RID: 280
		internal static DataRepository.qmDREFQp83LYtI4yaIG aXfQnW3Dx6;

		// Token: 0x04000119 RID: 281
		private static object processThread;

		// Token: 0x0400011A RID: 282
		private static IntPtr k32_holder;

		// Token: 0x0400011B RID: 283
		private static int tjVOVVBTrG;

		// Token: 0x0400011C RID: 284
		private static DataRepository.K32_Delegate_FindResourceA k32_FindResourceA;

		// Token: 0x0400011D RID: 285
		private static IntPtr BGRO68o8XQ;

		// Token: 0x0400011E RID: 286
		private static DataRepository.K32_Delegate_OpenProcess k32_OpenProcess;

		// Token: 0x0400011F RID: 287
		private static bool lkcQ3ecCFq;

		// Token: 0x04000120 RID: 288
		private static Dictionary<int, int> metaTokenRefs = null;

		// Token: 0x04000121 RID: 289
		private static DataRepository.K32_Delegate_CloseHandle k32_CloseHandle;

		// Token: 0x04000122 RID: 290
		private static IntPtr m6ZOXBVv8J;

		// Token: 0x04000123 RID: 291
		private static int IyOQdivZQQ;

		// Token: 0x04000124 RID: 292
		private static bool lT4QmcaY24;

		// Token: 0x04000125 RID: 293
		private static bool vjWOBO9012;

		// Token: 0x04000126 RID: 294
		private static DataRepository.K32_Delegate_VirtualAlloc k32_VirtualAlloc;

		// Token: 0x04000127 RID: 295
		[DataRepository.__G3ycxdQZ1KT9ALQ8cdt(typeof(DataRepository.__G3ycxdQZ1KT9ALQ8cdt.__SxBa0QQ0Ag8jbNOa0fm<object>[]))]
		private static bool fXWQqdVJkf;

		// Token: 0x04000128 RID: 296
		private static int NCKQbbOa53;

		// Token: 0x04000129 RID: 297
		internal static DataRepository.qmDREFQp83LYtI4yaIG TYeQ4lgLQC;

		// Token: 0x0400012A RID: 298
		private static int AwTQSy7LA5;

		// Token: 0x0400012B RID: 299
		internal static byte[] NKlO2FpeaA;

		// Token: 0x0400012C RID: 300
		private static byte[] nD0OKHoXUk;

		// Token: 0x0400012D RID: 301
		private static bool OD5Qs0H9XP;

		// Token: 0x060000B1 RID: 177
		static DataRepository()
		{
			DataRepository.processThread = new object();
			DataRepository.tjVOVVBTrG = 0;
			DataRepository.resourceNames = null;
			DataRepository.resourceIndexes = null;
			DataRepository.NKlO2FpeaA = new byte[0];
			DataRepository.nD0OKHoXUk = new byte[0];
			DataRepository.BGRO68o8XQ = IntPtr.Zero;
			DataRepository.m6ZOXBVv8J = IntPtr.Zero;
			DataRepository.GrdOz8RkRK = new string[0];
			DataRepository.HyAQ54wiD1 = new int[0];
			DataRepository.NCKQbbOa53 = 1;
			DataRepository.lT4QmcaY24 = false;
			DataRepository.sortedList = new SortedList();
			DataRepository.b8kQQ9dxI9 = 0;
			DataRepository.A5VQHGan76 = 0L;
			DataRepository.aXfQnW3Dx6 = null;
			DataRepository.TYeQ4lgLQC = null;
			DataRepository.QF5QFLFrFE = 0L;
			DataRepository.AwTQSy7LA5 = 0;
			DataRepository.OD5Qs0H9XP = false;
			DataRepository.lkcQ3ecCFq = false;
			DataRepository.IyOQdivZQQ = 0;
			DataRepository.wrcQxpDMN9 = IntPtr.Zero;
			DataRepository.fXWQqdVJkf = false;
			DataRepository.hashTable = new Hashtable();
			DataRepository.k32_FindResourceA = null;
			DataRepository.k32_VirtualAlloc = null;
			DataRepository.k32_WriteProcess = null;
			DataRepository.k32_VirtualProtect = null;
			DataRepository.k32_OpenProcess = null;
			DataRepository.k32_CloseHandle = null;
			DataRepository.k32_holder = IntPtr.Zero;
			DataRepository.messageStartConstant = Encoding.Unicode.GetString(new byte[]
			{
				0x86,
				0x7B,
				0xF1,
				8,
				0x18,
				0x62,
				0x4D,
				0xC7
			});
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000B3 RID: 179
		internal static byte[] GetNonFipsInitialisationVector(byte[] bufferIn)
		{
			uint[] array = new uint[0x10];
			checked
			{
				uint num2 = (uint)((0x1C0 - bufferIn.Length * 8 % 0x200 + 0x200) % 0x200);
				if (num2 == 0U)
				{
					num2 = 0x200U;
				}
				uint num3 = (uint)(unchecked((long)bufferIn.Length) + (long)(unchecked((ulong)(num2 / 8U))) + 8L);
				ulong num4 = (ulong)(unchecked((long)bufferIn.Length) * 8L);
				byte[] array2 = new byte[num3];
				for (int i = 0; i < bufferIn.Length; i++)
				{
					array2[i] = bufferIn[i];
				}
				byte[] array4 = array2;
				int num5 = bufferIn.Length;
				int num18 = num5;
				array4[num18] |= 0x80;
				for (int j = 8; j > 0; j--)
				{
					array2[(int)((IntPtr)((long)(unchecked((ulong)num3 - (ulong)((long)j)))))] = (byte)(num4 >> (8 - j) * 8 & 0xFFUL);
				}
				uint num6 = (uint)(array2.Length * 8 / 0x20);
				uint num7 = 0x67452301U;
				uint num8 = 0xEFCDAB89U;
				uint num9 = 0x98BADCFEU;
				uint num10 = 0x10325476U;
				for (uint num11 = 0U; num11 < num6 / 0x10U; num11 += 1U)
				{
					uint num12 = num11 << 6;
					for (uint num13 = 0U; num13 < 0x3DU; num13 += 4U)
					{
						array[(int)((uint)((UIntPtr)(num13 >> 2)))] = (uint)((int)array2[(int)((uint)((UIntPtr)(num12 + (num13 + 3U))))] << 0x18 | (int)array2[(int)((uint)((UIntPtr)(num12 + (num13 + 2U))))] << 0x10 | (int)array2[(int)((uint)((UIntPtr)(num12 + (num13 + 1U))))] << 8 | (int)array2[(int)((uint)((UIntPtr)(num12 + num13)))]);
					}
					uint num14 = num7;
					uint num15 = num8;
					uint num16 = num9;
					uint num17 = num10;
					DataRepository._Incrementor01(ref num7, num8, num9, num10, 0U, 7, 1U, array);
					DataRepository._Incrementor01(ref num10, num7, num8, num9, 1U, 0xC, 2U, array);
					DataRepository._Incrementor01(ref num9, num10, num7, num8, 2U, 0x11, 3U, array);
					DataRepository._Incrementor01(ref num8, num9, num10, num7, 3U, 0x16, 4U, array);
					DataRepository._Incrementor01(ref num7, num8, num9, num10, 4U, 7, 5U, array);
					DataRepository._Incrementor01(ref num10, num7, num8, num9, 5U, 0xC, 6U, array);
					DataRepository._Incrementor01(ref num9, num10, num7, num8, 6U, 0x11, 7U, array);
					DataRepository._Incrementor01(ref num8, num9, num10, num7, 7U, 0x16, 8U, array);
					DataRepository._Incrementor01(ref num7, num8, num9, num10, 8U, 7, 9U, array);
					DataRepository._Incrementor01(ref num10, num7, num8, num9, 9U, 0xC, 0xAU, array);
					DataRepository._Incrementor01(ref num9, num10, num7, num8, 0xAU, 0x11, 0xBU, array);
					DataRepository._Incrementor01(ref num8, num9, num10, num7, 0xBU, 0x16, 0xCU, array);
					DataRepository._Incrementor01(ref num7, num8, num9, num10, 0xCU, 7, 0xDU, array);
					DataRepository._Incrementor01(ref num10, num7, num8, num9, 0xDU, 0xC, 0xEU, array);
					DataRepository._Incrementor01(ref num9, num10, num7, num8, 0xEU, 0x11, 0xFU, array);
					DataRepository._Incrementor01(ref num8, num9, num10, num7, 0xFU, 0x16, 0x10U, array);
					DataRepository._Incrementor04(ref num7, num8, num9, num10, 1U, 5, 0x11U, array);
					DataRepository._Incrementor04(ref num10, num7, num8, num9, 6U, 9, 0x12U, array);
					DataRepository._Incrementor04(ref num9, num10, num7, num8, 0xBU, 0xE, 0x13U, array);
					DataRepository._Incrementor04(ref num8, num9, num10, num7, 0U, 0x14, 0x14U, array);
					DataRepository._Incrementor04(ref num7, num8, num9, num10, 5U, 5, 0x15U, array);
					DataRepository._Incrementor04(ref num10, num7, num8, num9, 0xAU, 9, 0x16U, array);
					DataRepository._Incrementor04(ref num9, num10, num7, num8, 0xFU, 0xE, 0x17U, array);
					DataRepository._Incrementor04(ref num8, num9, num10, num7, 4U, 0x14, 0x18U, array);
					DataRepository._Incrementor04(ref num7, num8, num9, num10, 9U, 5, 0x19U, array);
					DataRepository._Incrementor04(ref num10, num7, num8, num9, 0xEU, 9, 0x1AU, array);
					DataRepository._Incrementor04(ref num9, num10, num7, num8, 3U, 0xE, 0x1BU, array);
					DataRepository._Incrementor04(ref num8, num9, num10, num7, 8U, 0x14, 0x1CU, array);
					DataRepository._Incrementor04(ref num7, num8, num9, num10, 0xDU, 5, 0x1DU, array);
					DataRepository._Incrementor04(ref num10, num7, num8, num9, 2U, 9, 0x1EU, array);
					DataRepository._Incrementor04(ref num9, num10, num7, num8, 7U, 0xE, 0x1FU, array);
					DataRepository._Incrementor04(ref num8, num9, num10, num7, 0xCU, 0x14, 0x20U, array);
					DataRepository._Incrementor03(ref num7, num8, num9, num10, 5U, 4, 0x21U, array);
					DataRepository._Incrementor03(ref num10, num7, num8, num9, 8U, 0xB, 0x22U, array);
					DataRepository._Incrementor03(ref num9, num10, num7, num8, 0xBU, 0x10, 0x23U, array);
					DataRepository._Incrementor03(ref num8, num9, num10, num7, 0xEU, 0x17, 0x24U, array);
					DataRepository._Incrementor03(ref num7, num8, num9, num10, 1U, 4, 0x25U, array);
					DataRepository._Incrementor03(ref num10, num7, num8, num9, 4U, 0xB, 0x26U, array);
					DataRepository._Incrementor03(ref num9, num10, num7, num8, 7U, 0x10, 0x27U, array);
					DataRepository._Incrementor03(ref num8, num9, num10, num7, 0xAU, 0x17, 0x28U, array);
					DataRepository._Incrementor03(ref num7, num8, num9, num10, 0xDU, 4, 0x29U, array);
					DataRepository._Incrementor03(ref num10, num7, num8, num9, 0U, 0xB, 0x2AU, array);
					DataRepository._Incrementor03(ref num9, num10, num7, num8, 3U, 0x10, 0x2BU, array);
					DataRepository._Incrementor03(ref num8, num9, num10, num7, 6U, 0x17, 0x2CU, array);
					DataRepository._Incrementor03(ref num7, num8, num9, num10, 9U, 4, 0x2DU, array);
					DataRepository._Incrementor03(ref num10, num7, num8, num9, 0xCU, 0xB, 0x2EU, array);
					DataRepository._Incrementor03(ref num9, num10, num7, num8, 0xFU, 0x10, 0x2FU, array);
					DataRepository._Incrementor03(ref num8, num9, num10, num7, 2U, 0x17, 0x30U, array);
					DataRepository._Incrementor02(ref num7, num8, num9, num10, 0U, 6, 0x31U, array);
					DataRepository._Incrementor02(ref num10, num7, num8, num9, 7U, 0xA, 0x32U, array);
					DataRepository._Incrementor02(ref num9, num10, num7, num8, 0xEU, 0xF, 0x33U, array);
					DataRepository._Incrementor02(ref num8, num9, num10, num7, 5U, 0x15, 0x34U, array);
					DataRepository._Incrementor02(ref num7, num8, num9, num10, 0xCU, 6, 0x35U, array);
					DataRepository._Incrementor02(ref num10, num7, num8, num9, 3U, 0xA, 0x36U, array);
					DataRepository._Incrementor02(ref num9, num10, num7, num8, 0xAU, 0xF, 0x37U, array);
					DataRepository._Incrementor02(ref num8, num9, num10, num7, 1U, 0x15, 0x38U, array);
					DataRepository._Incrementor02(ref num7, num8, num9, num10, 8U, 6, 0x39U, array);
					DataRepository._Incrementor02(ref num10, num7, num8, num9, 0xFU, 0xA, 0x3AU, array);
					DataRepository._Incrementor02(ref num9, num10, num7, num8, 6U, 0xF, 0x3BU, array);
					DataRepository._Incrementor02(ref num8, num9, num10, num7, 0xDU, 0x15, 0x3CU, array);
					DataRepository._Incrementor02(ref num7, num8, num9, num10, 4U, 6, 0x3DU, array);
					DataRepository._Incrementor02(ref num10, num7, num8, num9, 0xBU, 0xA, 0x3EU, array);
					DataRepository._Incrementor02(ref num9, num10, num7, num8, 2U, 0xF, 0x3FU, array);
					DataRepository._Incrementor02(ref num8, num9, num10, num7, 9U, 0x15, 0x40U, array);
					num7 += num14;
					num8 += num15;
					num9 += num16;
					num10 += num17;
				}
				byte[] array3 = new byte[0x10];
				Array.Copy(BitConverter.GetBytes(num7), 0, array3, 0, 4);
				Array.Copy(BitConverter.GetBytes(num8), 0, array3, 4, 4);
				Array.Copy(BitConverter.GetBytes(num9), 0, array3, 8, 4);
				Array.Copy(BitConverter.GetBytes(num10), 0, array3, 0xC, 4);
				return array3;
			}
		}

		// Token: 0x060000B4 RID: 180
		private static void _Incrementor01(ref uint value, uint input01, uint input02, uint input03, uint arrayIndex, ushort input05, uint input06, uint[] arrayIn)
		{
			value = checked(input01 + DataRepository._IncrementorBitwise(value + ((input01 & input02) | (~input01 & input03)) + arrayIn[(int)((uint)((UIntPtr)arrayIndex))] + DataRepository._IncrementorRefference[(int)((uint)((UIntPtr)(input06 - 1U)))], input05));
		}

		// Token: 0x060000B5 RID: 181
		private static void _Incrementor04(ref uint value, uint input01, uint input02, uint input03, uint arrayIndex, ushort input05, uint input06, uint[] arrayIn)
		{
			value = checked(input01 + DataRepository._IncrementorBitwise(value + ((input01 & input03) | (input02 & ~input03)) + arrayIn[(int)((uint)((UIntPtr)arrayIndex))] + DataRepository._IncrementorRefference[(int)((uint)((UIntPtr)(input06 - 1U)))], input05));
		}

		// Token: 0x060000B6 RID: 182
		private static void _Incrementor03(ref uint value, uint input01, uint input02, uint input03, uint arrayIndex, ushort input05, uint input06, uint[] arrayIn)
		{
			value = checked(input01 + DataRepository._IncrementorBitwise(value + (input01 ^ input02 ^ input03) + arrayIn[(int)((uint)((UIntPtr)arrayIndex))] + DataRepository._IncrementorRefference[(int)((uint)((UIntPtr)(input06 - 1U)))], input05));
		}

		// Token: 0x060000B7 RID: 183
		private static void _Incrementor02(ref uint value, uint input01, uint input02, uint input03, uint arrayIndex, ushort input05, uint input06, uint[] arrayIn)
		{
			value = checked(input01 + DataRepository._IncrementorBitwise(value + (input02 ^ (input01 | ~input03)) + arrayIn[(int)((uint)((UIntPtr)arrayIndex))] + DataRepository._IncrementorRefference[(int)((uint)((UIntPtr)(input06 - 1U)))], input05));
		}

		// Token: 0x060000B8 RID: 184
		private static uint _IncrementorBitwise(uint input01, ushort input02)
		{
			return input01 >> (int)(checked(0x20 - input02)) | input01 << (int)input02;
		}

		// Token: 0x060000B9 RID: 185
		internal static bool OnlyFipsAlgorithms()
		{
			if (!DataRepository.onlyFipsAlgorithmsChecked)
			{
				DataRepository.CheckOnlyFipsAlgorithms();
				DataRepository.onlyFipsAlgorithmsChecked = true;
			}
			return DataRepository.onlyFipsAlgorithms;
		}

		// Token: 0x060000BA RID: 186
		internal DataRepository()
		{
		}

		// Token: 0x060000BB RID: 187
		private void DeObfuscator03(byte[] rgbKey, byte[] rgbIV, byte[] streamData)
		{
			this.DeObfuscator03(rgbKey, streamData);
		}

		// Token: 0x060000BC RID: 188
		internal static SymmetricAlgorithm GetSymmetricAlgorithm()
		{
			SymmetricAlgorithm result = null;
			if (DataRepository.OnlyFipsAlgorithms())
			{
				result = new AesCryptoServiceProvider();
			}
			else
			{
				try
				{
					result = new RijndaelManaged();
				}
				catch
				{
					result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
			return result;
		}

		// Token: 0x060000BD RID: 189
		internal static void CheckOnlyFipsAlgorithms()
		{
			try
			{
				DataRepository.onlyFipsAlgorithms = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x060000BE RID: 190
		internal static byte[] InivialisationVector(byte[] bufferIn)
		{
			if (!DataRepository.OnlyFipsAlgorithms())
			{
				return new MD5CryptoServiceProvider().ComputeHash(bufferIn);
			}
			return DataRepository.GetNonFipsInitialisationVector(bufferIn);
		}

		// Token: 0x060000BF RID: 191
		internal static void ReadStream(HashAlgorithm hashAlgorithmIn, Stream inputStream, uint count, byte[] bufferIn)
		{
			checked
			{
				while (count > 0U)
				{
					int num = (count > (uint)bufferIn.Length) ? bufferIn.Length : ((int)count);
					inputStream.Read(bufferIn, 0, num);
					DataRepository.TransformHashAlgorithm(hashAlgorithmIn, bufferIn, 0, num);
					count -= (uint)num;
				}
			}
		}

		// Token: 0x060000C0 RID: 192
		internal static void TransformHashAlgorithm(HashAlgorithm hashAlgorithmIn, byte[] bufferIn, int offSet, int count)
		{
			hashAlgorithmIn.TransformBlock(bufferIn, offSet, count, bufferIn, offSet);
		}

		// Token: 0x060000C1 RID: 193
		internal static uint _ReadBinaryReader(uint check, int count, long position, BinaryReader binaryReaderIn)
		{
			DataRepository.StreamHolder streamHolder = new DataRepository.StreamHolder(binaryReaderIn); 
			// StreamHolder(BinaryReader binaryReaderIn)
			checked
			{
				for (int i = 0; i < count; i++)
				{
					streamHolder._Position(position + unchecked((long)(checked(i * 0x28 + 8))));
					uint num1 = streamHolder._ReadUInt32();
					uint num2 = streamHolder._ReadUInt32();
					streamHolder._ReadUInt32();
					uint num4 = streamHolder._ReadUInt32();
					if (num2 <= check && check < num2 + num1) {
						return num4 + check - num2; }
				}
				return 0U;
			}
		}

		// Token: 0x060000C2 RID: 194
		public static void Initialise(RuntimeTypeHandle runtimeTypeHandle) {
			checked {
				DataRepository.StreamHolder streamHolder = new DataRepository.StreamHolder(); 
				try
				{
					Type typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandle);
					if (DataRepository.metaTokenRefs == null)
					{
						object obj = DataRepository.processThread;
						lock (obj)
						{
							Dictionary<int, int> dictionary = new Dictionary<int, int>();

							streamHolder._Initialise("mWQc273Qn08NsHVFXQ.CbAK6EdZ9Hptaso6Je");

							byte[] array = streamHolder._ReadAllBytes();

							streamHolder._Close();

							if (array.Length != 0)
							{
								int num = array.Length % 4;
								int num2 = array.Length / 4;
								byte[] array2 = new byte[array.Length];
								uint num3 = 0U;
								if (num > 0)
								{
									num2++;
								}
								for (int i = 0; i < num2; i++)
								{
									int num4 = i * 4;
									uint num5 = 0xFFU;
									int num6 = 0;
									uint num7;
									if (i == num2 - 1 && num > 0)
									{
										num7 = 0U;
										for (int j = 0; j < num; j++)
										{
											if (j > 0)
											{
												num7 <<= 8;
											}
											num7 |= (uint)array[array.Length - (1 + j)];
										}
									}
									else
									{
										uint num8 = (uint)num4;
										num7 = (uint)((int)array[(int)((uint)((UIntPtr)(num8 + 3U)))] << 0x18 | (int)array[(int)((uint)((UIntPtr)(num8 + 2U)))] << 0x10 | (int)array[(int)((uint)((UIntPtr)(num8 + 1U)))] << 8 | (int)array[(int)((uint)((UIntPtr)num8))]);
									}
									if (i == num2 - 1 && num > 0)
									{
										uint num9 = num3 ^ num7;
										for (int k = 0; k < num; k++)
										{
											if (k > 0)
											{
												num5 <<= 8;
												num6 += 8;
											}
											array2[num4 + k] = (byte)((num9 & num5) >> num6);
										}
									}
									else
									{
										uint num10 = num3 ^ num7;
										array2[num4] = (byte)(num10 & 0xFFU);
										array2[num4 + 1] = (byte)((num10 & 0xFF00U) >> 8);
										array2[num4 + 2] = (byte)((num10 & 0xFF0000U) >> 0x10);
										array2[num4 + 3] = (byte)((num10 & 0xFF000000U) >> 0x18);
									}
								}
								array = array2;
								int num11 = array.Length / 8;
								streamHolder._Initialise(array);
								for (int l = 0; l < num11; l++)
								{
									int key = streamHolder._ReadInt32();
									int value = streamHolder._ReadInt32();
									dictionary.Add(key, value);
								}
								streamHolder._Close();
							}
							DataRepository.metaTokenRefs = dictionary;
						}
					}
					foreach (FieldInfo fieldInfo in typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField))
					{
						int metadataToken = fieldInfo.MetadataToken;
						int num12 = DataRepository.metaTokenRefs[metadataToken];
						bool flag2 = (num12 & 0x40000000) > 0;
						num12 &= 0x3FFFFFFF;
						MethodInfo methodInfo = (MethodInfo)typeof(DataRepository).Module.ResolveMethod(num12, typeFromHandle.GetGenericArguments(), new Type[0]);
						if (methodInfo.IsStatic)
						{
							fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						}
						else
						{
							ParameterInfo[] parameters = methodInfo.GetParameters();
							int num13 = parameters.Length + 1;
							Type[] array3 = new Type[num13];
							if (methodInfo.DeclaringType.IsValueType)
							{
								array3[0] = methodInfo.DeclaringType.MakeByRefType();
							}
							else
							{
								array3[0] = typeof(object);
							}
							for (int m = 0; m < parameters.Length; m++)
							{
								array3[m + 1] = parameters[m].ParameterType;
							}
							DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, true);
							ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
							for (int num14 = 0; num14 < num13; num14++)
							{
								switch (num14)
								{
								case 0:
									ilgenerator.Emit(OpCodes.Ldarg_0);
									break;
								case 1:
									ilgenerator.Emit(OpCodes.Ldarg_1);
									break;
								case 2:
									ilgenerator.Emit(OpCodes.Ldarg_2);
									break;
								case 3:
									ilgenerator.Emit(OpCodes.Ldarg_3);
									break;
								default:
									ilgenerator.Emit(OpCodes.Ldarg_S, num14);
									break;
								}
							}
							ilgenerator.Emit(OpCodes.Tailcall);
							ilgenerator.Emit(flag2 ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
							ilgenerator.Emit(OpCodes.Ret);
							fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
						}
					}
				}
				catch (Exception)
				{
				}
				streamHolder._Destroy();
			}
		}

		// Token: 0x060000C3 RID: 195
		private static uint _ReturnUint(uint input)
		{
			return checked((uint)"{11111-22222-10009-11112}".Length);
		}

		// Token: 0x060000C4 RID: 196
		private static uint _ReturnZero(uint input)
		{
			return 0U;
		}

		// Token: 0x060000C5 RID: 197
		internal static void _ReturnVoid01()
		{
		}

		// Token: 0x060000C6 RID: 198
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void DeObfuscator02(Stream inputStream, int index)
		{
			DataRepository.StreamHolder streamHolder = new DataRepository.StreamHolder(inputStream);
			byte[] streamData = streamHolder._ReadAllBytes();
			streamHolder._Close();
			byte[] rgbKey = new byte[]
			{
				0xA7,
				0xAD,
				0xE6,
				0x5D,
				0x97,
				0x76,
				0x3E,
				0x1E,
				0x28,
				0x90,
				0x61,
				0xE3,
				0xF3,
				0x94,
				0xB1,
				0x76,
				0x54,
				0x7F,
				0xA7,
				0x70,
				0x1E,
				0xF2,
				0xA,
				0x55,
				0xF1,
				0xB9,
				0xF7,
				0x2F,
				0x94,
				0xE0,
				0xCB,
				0x2B
			};
			byte[] rgbIV = new byte[]
			{
				0xB9,
				0xB2,
				0x79,
				0x9D,
				0xA,
				0xC9,
				0x7E,
				0x48,
				0x70,
				0xD5,
				0x4F,
				0x77,
				0x37,
				0x1E,
				0x49,
				0xB
			};
			DataRepository.ReverseArray(rgbIV);
			byte[] assemblyKey = DataRepository.GetAssemblyKey();
			if (assemblyKey != null && assemblyKey.Length != 0)
			{
				rgbIV[1] = assemblyKey[0];
				rgbIV[3] = assemblyKey[1];
				rgbIV[5] = assemblyKey[2];
				rgbIV[7] = assemblyKey[3];
				rgbIV[9] = assemblyKey[4];
				rgbIV[0xB] = assemblyKey[5];
				rgbIV[0xD] = assemblyKey[6];
				rgbIV[0xF] = assemblyKey[7];
			}
			checked
			{
				for (int int3 = 0; int3 < rgbIV.Length; int3++)
				{
					byte[] array = rgbKey;
					int num7 = int3;
					int num8 = num7;
					array[num8] ^= rgbIV[int3];
				}
				if (index == -1)
				{
					SymmetricAlgorithm symmetricAlgorithmIn = (SymmetricAlgorithm)DataRepository.GetSymmetricAlgorithm02();
					DataRepository.SetCipherMode(symmetricAlgorithmIn, CipherMode.CBC);
					ICryptoTransform transform = (ICryptoTransform)DataRepository.CreateDecryptor(symmetricAlgorithmIn, rgbKey, rgbIV);
					Stream stream = (Stream)DataRepository.NewMemoryStream02();
					CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
					DataRepository.WriteToStream(cryptoStream, streamData, 0, streamData.Length);
					DataRepository.FlushCryptoStream(cryptoStream);
					DataRepository.NKlO2FpeaA = (byte[])DataRepository.StreamToArray02(stream);
					DataRepository.CloseStream(stream);
					DataRepository.CloseStream(cryptoStream);
					streamData = DataRepository.NKlO2FpeaA;
				}
				new DataRepository().DeObfuscator03(rgbKey, streamData);
			}
		}

		// Token: 0x060000C7 RID: 199
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string DeObfuscator(int manifestIndex)
		{
			if (DataRepository.NKlO2FpeaA.Length == 0)
			{
				DataRepository.resourceNames = new List<string>();
				DataRepository.resourceIndexes = new List<int>();
				DataRepository.DeObfuscator02(DataRepository.assembly.GetManifestResourceStream("NYVZ5QbAorSWyluZxn.uNGIFdm1vqy5NYiSby"), manifestIndex);
			}
			checked
			{
				if (DataRepository.tjVOVVBTrG < 0x4B)
				{
					if (DataRepository.assembly != new StackFrame(1).GetMethod().DeclaringType.Assembly)
					{
						throw new Exception();
					}
					DataRepository.tjVOVVBTrG++;
				}
				int num = BitConverter.ToInt32(DataRepository.NKlO2FpeaA, manifestIndex);
				if (num < DataRepository.resourceIndexes.Count && DataRepository.resourceIndexes[num] == manifestIndex)
				{
					return DataRepository.resourceNames[num];
				}
				try
				{
					feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
					byte[] array = new byte[num];
					Array.Copy(DataRepository.NKlO2FpeaA, manifestIndex + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					DataRepository.resourceNames.Add(@string);
					DataRepository.resourceIndexes.Add(manifestIndex);
					Array.Copy(BitConverter.GetBytes(DataRepository.resourceNames.Count - 1), 0, DataRepository.NKlO2FpeaA, manifestIndex, 4);
					return @string;
				}
				catch
				{
				}
				return "";
			}
		}

		// Token: 0x060000C8 RID: 200
		internal static string StringToBase64(string inputString)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(inputString);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x060000C9 RID: 201
		private static int _ReturnFive()
		{
			return 5;
		}

		// Token: 0x060000CA RID: 202
		private static void UseMachineKeyStore()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000CB RID: 203
		private static Delegate GetDelegateForFunction(IntPtr ptr, Type typeIn)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[]
			{
				ptr,
				typeIn
			});
		}

		// Token: 0x060000CC RID: 204
		internal static object GetAssemblyCodeBase(object assemblyIn)
		{
			try
			{
				if (File.Exists(((Assembly)assemblyIn).Location))
				{
					return ((Assembly)assemblyIn).Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(((Assembly)assemblyIn).GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return ((Assembly)assemblyIn).GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(assemblyIn.GetType().GetProperty("Location").GetValue(assemblyIn, new object[0]).ToString()))
				{
					return assemblyIn.GetType().GetProperty("Location").GetValue(assemblyIn, new object[0]).ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x060000CD RID: 205
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr K32_LoadLibrary(string lpLibFileName);

		// Token: 0x060000CE RID: 206
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr K32_GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x060000CF RID: 207
		private static IntPtr K32_FindResourceA(IntPtr hModule, string lpName, uint lpType)
		{
			if (DataRepository.k32_FindResourceA == null)
			{
				DataRepository.k32_FindResourceA = (DataRepository.K32_Delegate_FindResourceA)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Find ".Trim() + "ResourceA"), typeof(DataRepository.K32_Delegate_FindResourceA));
			}
			return DataRepository.k32_FindResourceA(hModule, lpName, lpType);
		}

		// Token: 0x060000D0 RID: 208
		private static IntPtr K32_VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect)
		{
			if (DataRepository.k32_VirtualAlloc == null)
			{
				DataRepository.k32_VirtualAlloc = (DataRepository.K32_Delegate_VirtualAlloc)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Virtual ".Trim() + "Alloc"), typeof(DataRepository.K32_Delegate_VirtualAlloc));
			}
			return DataRepository.k32_VirtualAlloc(lpAddress, dwSize, flAllocationType, flProtect);
		}

		// Token: 0x060000D1 RID: 209
		private static int K32_WriteProcess(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten)
		{
			if (DataRepository.k32_WriteProcess == null)
			{
				DataRepository.k32_WriteProcess = (DataRepository.K32_Delegate_WriteProcess)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(DataRepository.K32_Delegate_WriteProcess));
			}
			return DataRepository.k32_WriteProcess(hProcess, lpBaseAddress, buffer, size, out lpNumberOfBytesWritten);
		}

		// Token: 0x060000D2 RID: 210
		private static int K32_VirtualProtect(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect)
		{
			if (DataRepository.k32_VirtualProtect == null)
			{
				DataRepository.k32_VirtualProtect = (DataRepository.K32_Delegate_VirtualProtect)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Virtual ".Trim() + "Protect"), typeof(DataRepository.K32_Delegate_VirtualProtect));
			}
			return DataRepository.k32_VirtualProtect(lpAddress, dwSize, flNewProtect, ref lpflOldProtect);
		}

		// Token: 0x060000D3 RID: 211
		private static IntPtr K32_OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId)
		{
			if (DataRepository.k32_OpenProcess == null)
			{
				DataRepository.k32_OpenProcess = (DataRepository.K32_Delegate_OpenProcess)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Open ".Trim() + "Process"), typeof(DataRepository.K32_Delegate_OpenProcess));
			}
			return DataRepository.k32_OpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);
		}

		// Token: 0x060000D4 RID: 212
		private static int K32_CloseHandle(IntPtr ptr)
		{
			if (DataRepository.k32_CloseHandle == null)
			{
				DataRepository.k32_CloseHandle = (DataRepository.K32_Delegate_CloseHandle)Marshal.GetDelegateForFunctionPointer(DataRepository.K32_GetProcAddress(DataRepository.K32_Get(), "Close ".Trim() + "Handle"), typeof(DataRepository.K32_Delegate_CloseHandle));
			}
			return DataRepository.k32_CloseHandle(ptr);
		}

		// Token: 0x060000D5 RID: 213
		private static IntPtr K32_Get()
		{
			if (DataRepository.k32_holder == IntPtr.Zero)
			{
				DataRepository.k32_holder = DataRepository.K32_LoadLibrary("kernel ".Trim() + "32.dll");
			}
			return DataRepository.k32_holder;
		}

		// Token: 0x060000D6 RID: 214
		private static byte[] ReadFileToByteArray(string filePath)
		{
			checked
			{
				byte[] array;
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					int num = 0;
					int i = (int)fileStream.Length;
					array = new byte[i];
					while (i > 0)
					{
						int num2 = fileStream.Read(array, num, i);
						num += num2;
						i -= num2;
					}
				}
				return array;
			}
		}

		// Token: 0x060000D7 RID: 215
		internal static Stream NewMemoryStream()
		{
			return new MemoryStream();
		}

		// Token: 0x060000D8 RID: 216
		internal static byte[] StreamToArray(Stream inputStream)
		{
			return ((MemoryStream)inputStream).ToArray();
		}

		// Token: 0x060000D9 RID: 217
		private static byte[] EncryptData(byte[] dataIn)
		{
			Stream stream = DataRepository.NewMemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = DataRepository.GetSymmetricAlgorithm();
			symmetricAlgorithm.Key = new byte[]
			{
				0x90,
				0x1E,
				0x46,
				0xB7,
				0xD3,
				0x4F,
				0xC6,
				0xB8,
				0x20,
				0xBC,
				0x1A,
				0x13,
				0x8C,
				0xA9,
				0x90,
				0x51,
				0x1F,
				0xA7,
				0xBA,
				0x83,
				0xE0,
				0x3B,
				0x6C,
				0xE8,
				0x7B,
				0x24,
				0x21,
				0x71,
				0xD8,
				0x22,
				0xE1,
				0x46
			};
			symmetricAlgorithm.IV = new byte[]
			{
				0xDE,
				0xC2,
				0x8F,
				0x1A,
				0xF3,
				0x79,
				0x7A,
				0xD9,
				0xF5,
				0x9B,
				0x6F,
				0x25,
				0x3F,
				0xFD,
				0xB4,
				0xE6
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(dataIn, 0, dataIn.Length);
			cryptoStream.Close();
			return DataRepository.StreamToArray(stream);
		}

		// Token: 0x060000DA RID: 218
		private unsafe static int ___GetMessageCode(string messageIn) {
			fixed (char* ptr = messageIn) {
				int constant = 0x1505;
				int num2 = constant;
				char* ptr2 = ptr;
				int num3;
				while ((num3 = *ptr2) != 0) {
					constant = ((constant << 5) + constant) ^ num3;
					num3 = ptr2[1];
					if (num3 == 0)
					{
						break;
					}
					num2 = ((num2 << 5) + num2) ^ num3;
					ptr2 += 2;
				}
				return constant + num2 * 0x5D588B65;
			}
		}

		// Token: 0x060000DB RID: 219
		internal static bool CompareMessages(string message01, string message02)
		{
			if (message01 == message02)
			{
				return true;
			}
			if (message01 == null || message02 == null)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			int num2 = 0;
			if (message01.StartsWith(DataRepository.messageStartConstant))
			{
				flag = true;
				num = (int)(message01[4] | (int)message01[5] << 8 | (int)message01[6] << 0x10 | (int)message01[7] << 0x18);
			}
			if (message02.StartsWith(DataRepository.messageStartConstant))
			{
				flag2 = true;
				num2 = (int)(message02[4] | (int)message02[5] << 8 | (int)message02[6] << 0x10 | (int)message02[7] << 0x18);
			}
			if (!flag && !flag2)
			{
				return false;
			}
			if (!flag)
			{
				num = DataRepository.___GetMessageCode(message01);
			}
			if (!flag2)
			{
				num2 = DataRepository.___GetMessageCode(message02);
			}
			return num == num2;
		}

		// Token: 0x060000DC RID: 220
		private byte[] _ReturnNull02()
		{
			return null;
		}

		// Token: 0x060000DD RID: 221
		private byte[] _ReturnNull01()
		{
			return null;
		}

		// Token: 0x060000DE RID: 222
		private byte[] _ReturnArray03()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000DF RID: 223
		private byte[] _ReturnArray04()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E0 RID: 224
		private byte[] _ReturnArray05()
		{
			int length = "{11111-22222-30001-00001}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E1 RID: 225
		private byte[] _ReturnArray02()
		{
			int length = "{11111-22222-30001-00002}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E2 RID: 226
		internal byte[] _ReturnArray06()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E3 RID: 227
		internal byte[] _ReturnArray01()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E4 RID: 228
		internal byte[] _ReturnArray07()
		{
			int length = "{11111-22222-50001-00001}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E5 RID: 229
		internal byte[] _ReturnArray08()
		{
			int length = "{11111-22222-50001-00002}".Length;
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E6 RID: 230
		internal static object StreamHolderBaseStream(object streamHolderIn)
		{
			return ((DataRepository.StreamHolder)streamHolderIn)._GetBaseStream();
		}

		// Token: 0x060000E7 RID: 231
		internal static void SetStreamPosition(object streamInput, long position)
		{
			((Stream)streamInput).Position = position;
		}

		// Token: 0x060000E8 RID: 232
		internal static long GetStreamLength(object streamInput)
		{
			return ((Stream)streamInput).Length;
		}

		// Token: 0x060000E9 RID: 233
		internal static object StreamHolderReadBytes(object streamHolderIn, int count)
		{
			return ((DataRepository.StreamHolder)streamHolderIn)._ReadBytes(count);
		}

		// Token: 0x060000EA RID: 234
		internal static void StreamHolderClose(object streamHolderIn)
		{
			((DataRepository.StreamHolder)streamHolderIn)._Close();
		}

		// Token: 0x060000EB RID: 235
		internal static void ReverseArray(object arrayIn)
		{
			Array.Reverse((Array)arrayIn);
		}

		// Token: 0x060000EE RID: 238
		internal static object GetSymmetricAlgorithm02()
		{
			return DataRepository.GetSymmetricAlgorithm();
		}

		// Token: 0x060000EF RID: 239
		internal static void SetCipherMode(object symmetricAlgorithmIn, CipherMode cipherModeIn)
		{
			((SymmetricAlgorithm)symmetricAlgorithmIn).Mode = cipherModeIn;
		}

		// Token: 0x060000F0 RID: 240
		internal static object CreateDecryptor(object symmetricAlgorithmIn, object rgbKey, object rgbIV)
		{
			return ((SymmetricAlgorithm)symmetricAlgorithmIn).CreateDecryptor((byte[])rgbKey, (byte[])rgbIV);
		}

		// Token: 0x060000F1 RID: 241
		internal static object NewMemoryStream02()
		{
			return new MemoryStream();
		}

		// Token: 0x060000F2 RID: 242
		internal static void WriteToStream(object inputStream, object buffer, int offSet, int count)
		{
			((Stream)inputStream).Write((byte[])buffer, offSet, count);
		}

		// Token: 0x060000F3 RID: 243
		internal static void FlushCryptoStream(object cryptoStreamIn)
		{
			((CryptoStream)cryptoStreamIn).FlushFinalBlock();
		}

		// Token: 0x060000F4 RID: 244
		internal static object StreamToArray02(object inputStream)
		{
			return ((MemoryStream)inputStream).ToArray();
		}

		// Token: 0x060000F5 RID: 245
		internal static void CloseStream(object inputStream)
		{
			((Stream)inputStream).Close();
		}

		// Token: 0x060000F6 RID: 246
		internal static bool _ReturnTrue()
		{
			return true;
		}

		// Token: 0x060000F7 RID: 247
		internal static object _ReturnNull03()
		{
			return null;
		}

		// Token: 0x06001A80 RID: 6784
		internal static AssemblyName GetAssemblyName(Assembly assemblyIn)
		{
			return assemblyIn.GetName();
		}

		// Token: 0x06001A81 RID: 6785
		internal static AssemblyName GetAssemblyName()
		{
			return DataRepository.GetAssemblyName(DataRepository.assembly);
		}

		// Token: 0x06001A82 RID: 6786
		internal static byte[] GetAssemblyKey(AssemblyName assemblyNameIn)
		{
			return assemblyNameIn.GetPublicKeyToken();
		}

		// Token: 0x06001A83 RID: 6787
		internal static byte[] GetAssemblyKey()
		{
			return DataRepository.GetAssemblyName().GetPublicKeyToken();
		}

		// Token: 0x06001B44 RID: 6980
		private void DeObfuscator03(byte[] rgbKey, byte[] streamData)
		{
			int extraBytes = streamData.Length % 4;
			int totalPacketCount = streamData.Length / 4;
			byte[] returnValue = new byte[streamData.Length];
			int packetCount = rgbKey.Length / 4;
			uint num4 = 0U;
			checked
			{
				if (extraBytes > 0)
				{
					totalPacketCount++;
				}
				for (int i = 0; i < totalPacketCount; i++)
				{
					int num5 = i % packetCount;
					int num6 = i * 4;
					uint num7 = (uint)(num5 * 4);
					uint num8 = (uint)((int)rgbKey[(int)((uint)((UIntPtr)(num7 + 3U)))] << 0x18 | (int)rgbKey[(int)((uint)((UIntPtr)(num7 + 2U)))] << 0x10 | (int)rgbKey[(int)((uint)((UIntPtr)(num7 + 1U)))] << 8 | (int)rgbKey[(int)((uint)((UIntPtr)num7))]);
					uint num9 = 0xFFU;
					int num10 = 0;
					uint num11;
					if (i == totalPacketCount - 1 && extraBytes > 0)
					{
						num11 = 0U;
						num4 += num8;
						for (int j = 0; j < extraBytes; j++)
						{
							if (j > 0)
							{
								num11 <<= 8;
							}
							num11 |= (uint)streamData[streamData.Length - (1 + j)];
						}
					}
					else
					{
						num4 += num8;
						num7 = (uint)num6;
						num11 = (uint)((int)streamData[(int)((uint)((UIntPtr)(num7 + 3U)))] << 0x18 | (int)streamData[(int)((uint)((UIntPtr)(num7 + 2U)))] << 0x10 | (int)streamData[(int)((uint)((UIntPtr)(num7 + 1U)))] << 8 | (int)streamData[(int)((uint)((UIntPtr)num7))]);
					}
					uint num23 = num4;
					uint num12 = 0x6DB6EF73U;
					uint num13 = 0x3EED935DU;
					uint num14 = 0x41018030U;
					uint num15 = num23;
					uint num16 = 0x4BF04A05U;
					uint num17 = 0x33B5E528U;
					uint num24 = num13 & 0xF0F0F0FU;
					uint num18 = num13 & 0xF0F0F0F0U;
					uint num25 = (num24 >> 4 | num18 << 4) + num12;
					num13 = (num13 << 6 | num13 >> 0x1A);
					if (num14 == 0.0)
					{
						num14 -= 1U;
					}
					uint num19 = num12 / num14 + num14;
					num14 = ((uint)((ushort)num12) - 0x60039FA7U) * num19 + (uint)((ushort)num12);
					num12 = (num13 ^ num13 ^ 0x7F4AF7EU);
					num16 -= num13;
					uint num26 = (num17 >> 0xD | num17 << 0x13) ^ num13;
					uint num20 = num26 & 0xF0F0F0FU;
					num17 = ((num26 & 0xF0F0F0F0U) >> 4 | num20 << 4);
					num15 ^= num15 << 0xD;
					num15 += num12;
					num15 ^= num15 << 0x1B;
					num15 += num16;
					num15 ^= num15 >> 3;
					num15 += num17;
					num15 = ((num13 << 0x15) + num16 ^ num12) - num15;
					num4 = num23 + num15;
					if (i == totalPacketCount - 1 && extraBytes > 0)
					{
						uint num21 = num4 ^ num11;
						for (int k = 0; k < extraBytes; k++)
						{
							if (k > 0)
							{
								num9 <<= 8;
								num10 += 8;
							}
							returnValue[num6 + k] = (byte)((num21 & num9) >> num10);
						}
					}
					else
					{
						uint num22 = num4 ^ num11;
						returnValue[num6] = (byte)(num22 & 0xFFU);
						returnValue[num6 + 1] = (byte)((num22 & 0xFF00U) >> 8);
						returnValue[num6 + 2] = (byte)((num22 & 0xFF0000U) >> 0x10);
						returnValue[num6 + 3] = (byte)((num22 & 0xFF000000U) >> 0x18);
					}
				}
				DataRepository.NKlO2FpeaA = returnValue;
			}
		}
	}
}
