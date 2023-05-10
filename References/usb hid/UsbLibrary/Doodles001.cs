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
using AjAhb4QLiU9IFaCBlx4;

namespace DataRepositories
{
	// Token: 0x02000021 RID: 33
	class DataRepository
	{
		// Token: 0x0200002F RID: 47
		// (Invoke) Token: 0x06000123 RID: 291
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		delegate int DelegateCloseHandle(IntPtr ptr);

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x0600010F RID: 271
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		delegate IntPtr DelegateFindResourceA(IntPtr hModule, string lpName, uint lpType);

		// Token: 0x0200002E RID: 46
		// (Invoke) Token: 0x0600011F RID: 287
		[UnmanagedFunctionPointer(3)]
		delegate IntPtr DelegateOpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		// Token: 0x0200002B RID: 43
		// (Invoke) Token: 0x06000113 RID: 275
		[UnmanagedFunctionPointer(3)]
		delegate IntPtr DelegateVirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x0200002D RID: 45
		// (Invoke) Token: 0x0600011B RID: 283
		[UnmanagedFunctionPointer(3)]
		delegate int DelegateVirtualProtect(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

		// Token: 0x0200002C RID: 44
		// (Invoke) Token: 0x06000117 RID: 279
		[UnmanagedFunctionPointer(3)]
		delegate int DelegateWriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x02000023 RID: 35
		internal class DRattribute : Attribute
		{
			// Token: 0x02000024 RID: 36
			internal class DRfield<m1x0gvQ1qhGqDn8vw8J>
			{
				// Token: 0x060000FD RID: 253 RVA: 0x00010458 File Offset: 0x0000E658
				public DRfield()
				{
					feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
					base..ctor();
				}
			}

			// Token: 0x0200003A RID: 58
			internal class ___DRfield<m1x0gvQ1qhGqDn8vw8J>
			{
				// Token: 0x06000129 RID: 297
				public ___DRfield()
				{
				}
			}

			// Token: 0x060000FC RID: 252
			public DRattribute(object sender)
			{
			}
		}

		// Token: 0x02000025 RID: 37
		internal class EncryptedStream
		{
			// Token: 0x060000FF RID: 255 RVA: 0x00010500 File Offset: 0x0000E700
			public EncryptedStream()
			{
			}

			// Token: 0x060000FE RID: 254
			internal static string Write(string message, string initialisationVector)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(message);
				byte[] array = bytes;
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
				byte[] initialisationVector2 = DataRepository.GetInitialisationVector(Encoding.Unicode.GetBytes(initialisationVector));
				MemoryStream memoryStream = new MemoryStream();
				SymmetricAlgorithm symmetricAlgorithm = DataRepository.GetSymmetricAlgorithm();
				symmetricAlgorithm.Key = key;
				symmetricAlgorithm.IV = initialisationVector2;
				CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.Close();
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		// Token: 0x02000029 RID: 41
		internal class StreamHolder
		{
			// Token: 0x04000130 RID: 304
			BinaryReader binaryReader;

			// Token: 0x06000108 RID: 264
			public StreamHolder(Stream streamIn)
			{
				this.binaryReader = new BinaryReader(streamIn);
			}

			// Token: 0x06000109 RID: 265
			internal Stream BaseStream()
			{
				return this.binaryReader.BaseStream;
			}

			// Token: 0x0600010D RID: 269
			internal void Close()
			{
				this.binaryReader.Close();
			}

			// Token: 0x0600010B RID: 267
			internal int Read(byte[] arrBuffer, int index, int count)
			{
				return this.binaryReader.Read(arrBuffer, index, count);
			}

			// Token: 0x0600010A RID: 266
			internal byte[] ReadBytes(int count)
			{
				return this.binaryReader.ReadBytes(count);
			}

			// Token: 0x0600010C RID: 268
			internal int ReadInt32()
			{
				return this.binaryReader.ReadInt32();
			}
		}

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x06000101 RID: 257
		[UnmanagedFunctionPointer(3)]
		internal delegate uint _UnknownDelegate_01(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

		// Token: 0x02000030 RID: 48
		[Flags]
		enum _UnknownEnum01
		{

		}

		// Token: 0x02000028 RID: 40
		internal struct _UnknownStruct01
		{
			// Token: 0x0400012E RID: 302
			internal bool ready;

			// Token: 0x0400012F RID: 303
			internal byte[] buffer;
		}

		// Token: 0x02000027 RID: 39
		// (Invoke) Token: 0x06000105 RID: 261
		[UnmanagedFunctionPointer(3)]
		delegate IntPtr _UnusedDelegate_01();

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x060000F9 RID: 249
		delegate void _UnusedDelegate_02(object o);

		// Token: 0x04000109 RID: 265
		static bool allowOnlyFipsAlgorithms;

		// Token: 0x04000106 RID: 262
		internal static Assembly assembly;

		// Token: 0x04000121 RID: 289
		static DataRepository.DelegateCloseHandle delegateCloseHandle;

		// Token: 0x0400011C RID: 284
		static DataRepository.DelegateFindResourceA delegateFindResourceA;

		// Token: 0x0400011E RID: 286
		static DataRepository.DelegateOpenProcess delegateOpenProcess;

		// Token: 0x04000126 RID: 294
		static DataRepository.DelegateVirtualAlloc delegateVirtualAlloc;

		// Token: 0x04000114 RID: 276
		static DataRepository.DelegateVirtualProtect delegateVirtualProtect;

		// Token: 0x04000113 RID: 275
		static DataRepository.DelegateWriteProcessMemory delegateWriteProcessMemory;

		// Token: 0x04000108 RID: 264
		static bool fipsAlgorithmsChecked;

		// Token: 0x04000107 RID: 263
		static uint[] incrementorRef01;

		// Token: 0x0400011A RID: 282
		static IntPtr kernel32Ptr;

		// Token: 0x0400011B RID: 283
		static int manifestReadCount;

		// Token: 0x04000120 RID: 288
		static Dictionary<int, int> metaTokenRefs;

		// Token: 0x04000115 RID: 277
		static string pendantMessageStartConstant;

		// Token: 0x0400010C RID: 268
		static List<int> resourceIndexes;

		// Token: 0x0400012B RID: 299
		static byte[] resourceNameBytes;

		// Token: 0x0400010B RID: 267
		static List<string> resourceNames;

		// Token: 0x0400010A RID: 266
		internal static RSACryptoServiceProvider rsaCryptoServiceProvider;

		// Token: 0x04000125 RID: 293
		static bool _booleanFalse01 = false;

		// Token: 0x0400012D RID: 301
		static bool _booleanFalse02;

		// Token: 0x04000111 RID: 273
		static IntPtr _pointerZero01;

		// Token: 0x0400011D RID: 285
		static IntPtr _pointerZero02;

		// Token: 0x04000122 RID: 290
		static IntPtr _pointerZero03;

		// Token: 0x04000119 RID: 281
		static object _processThread;

		// Token: 0x0400010E RID: 270
		static SortedList _sortedList;

		// Token: 0x04000118 RID: 280
		internal static DataRepository._UnknownDelegate_01 _unknownDelegate_01_01;

		// Token: 0x04000129 RID: 297
		internal static DataRepository._UnknownDelegate_01 _unknownDelegate_01_02;

		// Token: 0x04000110 RID: 272
		static long __A5VQHGan76;

		// Token: 0x0400012A RID: 298
		static int __AwTQSy7LA5;

		// Token: 0x0400010F RID: 271
		static int __b8kQQ9dxI9;

		// Token: 0x04000112 RID: 274
		internal static Hashtable __EerQY3Qjti;

		// Token: 0x04000127 RID: 295
		static bool __fXWQqdVJkf;

		// Token: 0x0400010D RID: 269
		static object __GrdOz8RkRK;

		// Token: 0x04000116 RID: 278
		static int[] __HyAQ54wiD1;

		// Token: 0x04000123 RID: 291
		static int __IyOQdivZQQ;

		// Token: 0x0400011F RID: 287
		static bool __lkcQ3ecCFq;

		// Token: 0x04000124 RID: 292
		static bool __lT4QmcaY24;

		// Token: 0x04000128 RID: 296
		static int __NCKQbbOa53;

		// Token: 0x0400012C RID: 300
		static byte[] __nD0OKHoXUk;

		// Token: 0x04000117 RID: 279
		static long __QF5QFLFrFE;

		// Token: 0x060000B1 RID: 177 RVA: 0x0000B328 File Offset: 0x00009528
		static DataRepository()
		{
			DataRepository.assembly = typeof(DataRepository).Assembly;
			DataRepository.incrementorRef01 = new uint[]
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
			DataRepository.fipsAlgorithmsChecked = false;
			DataRepository.allowOnlyFipsAlgorithms = false;
			DataRepository.rsaCryptoServiceProvider = null;
			DataRepository.metaTokenRefs = null;
			DataRepository._processThread = new object();
			DataRepository.manifestReadCount = 0;
			DataRepository.resourceNames = null;
			DataRepository.resourceIndexes = null;
			DataRepository.resourceNameBytes = new byte[0];
			DataRepository.__nD0OKHoXUk = new byte[0];
			DataRepository._pointerZero02 = IntPtr.Zero;
			DataRepository._pointerZero03 = IntPtr.Zero;
			DataRepository.__GrdOz8RkRK = new string[0];
			DataRepository.__HyAQ54wiD1 = new int[0];
			DataRepository.__NCKQbbOa53 = 1;
			DataRepository.__lT4QmcaY24 = false;
			DataRepository._sortedList = new SortedList();
			DataRepository.__b8kQQ9dxI9 = 0;
			DataRepository.__A5VQHGan76 = 0L;
			DataRepository._unknownDelegate_01_01 = null;
			DataRepository._unknownDelegate_01_02 = null;
			DataRepository.__QF5QFLFrFE = 0L;
			DataRepository.__AwTQSy7LA5 = 0;
			DataRepository._booleanFalse02 = false;
			DataRepository.__lkcQ3ecCFq = false;
			DataRepository.__IyOQdivZQQ = 0;
			DataRepository._pointerZero01 = IntPtr.Zero;
			DataRepository.__fXWQqdVJkf = false;
			DataRepository.__EerQY3Qjti = new Hashtable();
			DataRepository.delegateFindResourceA = null;
			DataRepository.delegateVirtualAlloc = null;
			DataRepository.delegateWriteProcessMemory = null;
			DataRepository.delegateVirtualProtect = null;
			DataRepository.delegateOpenProcess = null;
			DataRepository.delegateCloseHandle = null;
			DataRepository.kernel32Ptr = IntPtr.Zero;
			DataRepository.pendantMessageStartConstant = Encoding.Unicode.GetString(new byte[]
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

		// Token: 0x060000BA RID: 186 RVA: 0x0000BC3C File Offset: 0x00009E3C
		internal DataRepository()
		{
		}

		// Token: 0x060000F5 RID: 245
		internal static void CloseStream(object streamIn)
		{
			streamIn.Close();
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
			if (message01.StartsWith(DataRepository.pendantMessageStartConstant))
			{
				flag = true;
				num = (int)(message01[4] | (int)message01[5] << 8 | (int)message01[6] << 0x10 | (int)message01[7] << 0x18);
			}
			if (message02.StartsWith(DataRepository.pendantMessageStartConstant))
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
				num = DataRepository.GetMessageCode(message01);
			}
			if (!flag2)
			{
				num2 = DataRepository.GetMessageCode(message02);
			}
			return num == num2;
		}

		// Token: 0x060000C6 RID: 198
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void DecodeManifestResource(Stream streamIn, int index)
		{
			int num = 0x7D;
			for (;;)
			{
				int num2 = num;
				int num3;
				byte[] array;
				int num4;
				byte[] array2;
				byte[] array3;
				byte[] assemblyKey;
				Stream stream;
				int num5;
				for (;;)
				{
					byte[] array4;
					byte[] array5;
					switch (num2)
					{
					case 1:
						num3 = 0x9C - 0x74;
						num2 = 0x44;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_51;
						}
						continue;
					case 2:
						array[8] = (byte)num4;
						num2 = 0x64;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_48;
						}
						continue;
					case 3:
						array2[0x16] = (byte)num3;
						num2 = 0x14;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_62;
						}
						continue;
					case 4:
						array[0xA] = (byte)num4;
						num2 = 0x138;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_88;
						}
						continue;
					case 5:
						array2[0x16] = 0xCE - 0x44;
						num2 = 0xB9;
						continue;
					case 6:
						array2[0xA] = 0x12 + 0x11;
						num2 = 0xEE;
						continue;
					case 7:
						array2[0xE] = (byte)num3;
						num2 = 0x11D;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_8;
						}
						continue;
					case 8:
						num3 = 0x8A - 0x1A;
						num2 = 0x151;
						continue;
					case 9:
						array2[0x18] = (byte)num3;
						num2 = 0x114;
						continue;
					case 0xA:
						array3[5] = assemblyKey[2];
						num2 = 0xF4;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x9C;
							continue;
						}
						continue;
					case 0xB:
						array[1] = 0x27 + 0x26;
						num2 = 0xC1;
						continue;
					case 0xC:
						num3 = 0x50 + 0x64;
						num2 = 0x23;
						continue;
					case 0xD:
						num3 = 7 + 0x5E;
						num2 = 0xA8;
						continue;
					case 0xE:
						goto IL_2437;
					case 0xF:
						num3 = 0x7B - 0x4C;
						num2 = 0x4F;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xC7;
							continue;
						}
						continue;
					case 0x10:
						array[1] = (byte)num4;
						num2 = 0xE;
						continue;
					case 0x11:
						num4 = 0x4F + 0x2F;
						num2 = 0xEC;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_126;
						}
						continue;
					case 0x12:
						array2[0x18] = (byte)num3;
						num2 = 0x79;
						continue;
					case 0x13:
						goto IL_24CF;
					case 0x14:
						array2[0x16] = 0xE7 - 0x4D;
						num2 = 0xCB;
						continue;
					case 0x15:
						num3 = 0x72 + 0x35;
						num2 = 0x49;
						continue;
					case 0x16:
						array[0xD] = (byte)num4;
						num2 = 0x10F;
						continue;
					case 0x17:
						if (index == -1)
						{
							num2 = 0x128;
							continue;
						}
						goto IL_20AD;
					case 0x18:
						num3 = 0xBE + 0x28;
						num2 = 0xA6;
						continue;
					case 0x19:
						array2[0x15] = 0x1E + 0x51;
						num2 = 0x122;
						continue;
					case 0x1A:
						array2[0x1D] = (byte)num3;
						num2 = 0x65;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xF;
							continue;
						}
						continue;
					case 0x1B:
						array2[0x12] = (byte)num3;
						num2 = 0xB4;
						continue;
					case 0x1C:
						array2[0x1E] = 0x5F + 0x6C;
						num2 = 0xE3;
						continue;
					case 0x1D:
						num3 = 0xB6 + 0x2D;
						num2 = 0xF0;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_16;
						}
						continue;
					case 0x1E:
						num3 = 0xED - 0x4F;
						num2 = 0xE4;
						continue;
					case 0x1F:
						num3 = 0x74 + 0x61;
						num2 = 0xE5;
						continue;
					case 0x20:
						num4 = 0x6F + 0x5A;
						num2 = 0x6E;
						continue;
					case 0x21:
						array2[0x1C] = (byte)num3;
						num2 = 0xC8;
						continue;
					case 0x22:
						num3 = 0x48 + 0x64;
						num2 = 0x8F;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_90;
						}
						continue;
					case 0x23:
						array2[0xC] = (byte)num3;
						num2 = 0xDB;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_10;
						}
						continue;
					case 0x24:
						num3 = 0x8A - 0x2E;
						num2 = 0x163;
						continue;
					case 0x25:
						array2[0x1F] = 0x70 - 0x45;
						num2 = 0x16C;
						continue;
					case 0x26:
						num3 = 0x9E + 0x53;
						num2 = 0x80;
						continue;
					case 0x27:
					{
						ICryptoTransform cryptoTransform;
						CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
						num2 = 0x5D;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x69;
							continue;
						}
						continue;
					}
					case 0x28:
						num3 = 0x58 + 0x16;
						num2 = 0xE7;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_60;
						}
						continue;
					case 0x29:
						array2[0x1B] = 9 + 0x72;
						num2 = 0xF;
						continue;
					case 0x2A:
						array2[0x13] = (byte)num3;
						num2 = 0x5E;
						continue;
					case 0x2B:
						array[0xE] = 0x26 + 0x4A;
						num2 = 0xE9;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_111;
						}
						continue;
					case 0x2C:
						num4 = 0xC1 - 0x40;
						num2 = 0x16;
						continue;
					case 0x2D:
						array[0xC] = (byte)num4;
						num2 = 0x9B;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xF1;
							continue;
						}
						continue;
					case 0x2E:
						num4 = 0xEB - 0x4E;
						num2 = 0x148;
						continue;
					case 0x2F:
						array2[9] = (byte)num3;
						num2 = 0xFC;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0xF4;
							continue;
						}
						continue;
					case 0x30:
						array[4] = (byte)num4;
						num2 = 0x157;
						continue;
					case 0x31:
						array2[0xF] = (byte)num3;
						num2 = 0x77;
						continue;
					case 0x32:
						num3 = 0x4A - 0x40;
						num2 = 0x124;
						continue;
					case 0x33:
						num4 = 0xD - 2;
						num2 = 0x13F;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_17;
						}
						continue;
					case 0x34:
						if (assemblyKey.Length > 0)
						{
							num2 = 0x48;
							continue;
						}
						goto IL_2360;
					case 0x35:
						num3 = 0x80 - 0x2A;
						num2 = 0xAB;
						continue;
					case 0x36:
						num3 = 0x58 + 0x26;
						num2 = 0x90;
						continue;
					case 0x37:
						array2[5] = 0xC9 - 0x53;
						num2 = 0xC9;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_151;
						}
						continue;
					case 0x38:
						num4 = 0x6B + 0x60;
						num2 = 0x8E;
						continue;
					case 0x39:
						num3 = 0x50 + 0x50;
						num2 = 0x1B;
						continue;
					case 0x3A:
						array2[3] = (byte)num3;
						num2 = 0x158;
						continue;
					case 0x3B:
						array[0xF] = (byte)num4;
						num2 = 0x38;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_95;
						}
						continue;
					case 0x3C:
						num3 = 0x54 + 0x53;
						num2 = 0xF2;
						continue;
					case 0x3D:
						array2[0x11] = 0xD5 - 0x47;
						num2 = 2;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xAF;
							continue;
						}
						continue;
					case 0x3E:
						num3 = 0xF + 0x5C;
						num2 = 0x67;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_12;
						}
						continue;
					case 0x3F:
						array2[0x1F] = 0xFC - 0x54;
						num2 = 0x94;
						continue;
					case 0x40:
						num3 = 0xB9 - 0x3D;
						num2 = 0x116;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x1E;
							continue;
						}
						continue;
					case 0x41:
						array2[0xC] = (byte)num3;
						num2 = 0x7F;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x8A;
							continue;
						}
						continue;
					case 0x42:
						array2[0x1B] = 0xB4 - 0x3C;
						num2 = 0x29;
						continue;
					case 0x43:
						array3[3] = assemblyKey[1];
						num2 = 0xA;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 5;
							continue;
						}
						continue;
					case 0x44:
						array2[8] = (byte)num3;
						num2 = 0xCD;
						continue;
					case 0x45:
						array2[0xE] = 0x76 + 0x7B;
						num2 = 0x28;
						continue;
					case 0x46:
						goto IL_29F6;
					case 0x47:
						array2[0x14] = 0x63 - 0x45;
						num2 = 0x22;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_43;
						}
						continue;
					case 0x48:
						array3[1] = assemblyKey[0];
						num2 = 0x2F;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x43;
							continue;
						}
						continue;
					case 0x49:
						array2[0] = (byte)num3;
						num2 = 0x137;
						continue;
					case 0x4A:
						array[6] = (byte)num4;
						num2 = 0x56;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x3F;
							continue;
						}
						continue;
					case 0x4B:
						if (assemblyKey != null)
						{
							num2 = 0x34;
							continue;
						}
						goto IL_2360;
					case 0x4C:
						num3 = 0x34 + 0x4B;
						num2 = 0x84;
						continue;
					case 0x4D:
						array2[0x13] = (byte)num3;
						num2 = 0xEB;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_13;
						}
						continue;
					case 0x4E:
						array2[5] = 0x99 - 0x33;
						num2 = 0x24;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x37;
							continue;
						}
						continue;
					case 0x4F:
						array2[0x1C] = (byte)num3;
						num2 = 0x12A;
						continue;
					case 0x50:
						num4 = 0xA4 - 0x36;
						num2 = 0xCD;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x164;
							continue;
						}
						continue;
					case 0x51:
						array[0xC] = 0x48 + 0x45;
						num2 = 0xD8;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x3D;
							continue;
						}
						continue;
					case 0x52:
						array4 = DataRepository.resourceNameBytes;
						num2 = 0x113;
						continue;
					case 0x53:
						num3 = 0x68 + 0x24;
						num2 = 0x12;
						continue;
					case 0x54:
						num3 = 0x87 + 0x6C;
						num2 = 0x7F;
						continue;
					case 0x55:
						array2[0x1C] = 0x16 + 0x37;
						num2 = 0x8B;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_137;
						}
						continue;
					case 0x56:
						goto IL_23B3;
					case 0x57:
						DataRepository.resourceNameBytes = DataRepository.___MemoryStreamToArray(stream);
						num2 = 0x98;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x61;
							continue;
						}
						continue;
					case 0x58:
						goto IL_1ABE;
					case 0x59:
						goto IL_7A3;
					case 0x5A:
						num3 = 0x93 - 0x31;
						num2 = 0x118;
						continue;
					case 0x5B:
						goto IL_1F37;
					case 0x5C:
						num3 = 0xA2 - 0x36;
						num2 = 0x165;
						continue;
					case 0x5D:
						array[3] = (byte)num4;
						num2 = 0x129;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_11;
						}
						continue;
					case 0x5E:
						array2[0x13] = 0x63 + 0xE;
						num2 = 8;
						continue;
					case 0x5F:
						array[1] = (byte)num4;
						num2 = 0x1A;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x139;
							continue;
						}
						continue;
					case 0x60:
						num4 = 0x46 + 0x57;
						num2 = 0x5D;
						continue;
					case 0x61:
						goto IL_DBE;
					case 0x62:
						goto IL_FC9;
					case 0x63:
						array2[0x1F] = 0x36 + 0x15;
						num2 = 0x5A;
						continue;
					case 0x64:
						num4 = 0xA1 - 0x31;
						num2 = 0x8C;
						continue;
					case 0x65:
						array2[0x1D] = 0xA + 7;
						num2 = 0x78;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_67;
						}
						continue;
					case 0x66:
						array2[3] = 0xCD - 0x44;
						num2 = 0x14F;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_19;
						}
						continue;
					case 0x67:
						array2[1] = (byte)num3;
						num2 = 0x141;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_35;
						}
						continue;
					case 0x68:
						array[0] = (byte)num4;
						num2 = 0x115;
						continue;
					case 0x69:
					{
						CryptoStream cryptoStream;
						DataRepository.WriteStream(cryptoStream, array4, 0, array4.Length);
						num2 = 0xBF;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x16E;
							continue;
						}
						continue;
					}
					case 0x6A:
						num3 = 0x30 + 0xB;
						num2 = 0x13;
						continue;
					case 0x6B:
						goto IL_2DC1;
					case 0x6C:
						array2[0] = 0x78 + 0x75;
						num2 = 0x15;
						continue;
					case 0x6D:
						array2[0x17] = 0xA7 - 0x37;
						num2 = 0xE0;
						continue;
					case 0x6E:
						array[5] = (byte)num4;
						num2 = 0x154;
						continue;
					case 0x6F:
						num4 = 0x8D - 0x2F;
						num2 = 0x82;
						continue;
					case 0x70:
						array[0] = (byte)num4;
						num2 = 0xB3;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_135;
						}
						continue;
					case 0x71:
						num3 = 0xAA + 0xF;
						num2 = 0xE8;
						continue;
					case 0x72:
						num3 = 0x45 + 0x2F;
						num2 = 0x41;
						continue;
					case 0x73:
						array = new byte[0x10];
						num2 = 0x6F;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_18;
						}
						continue;
					case 0x74:
						array2[0x1B] = (byte)num3;
						num2 = 0x2F;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x155;
							continue;
						}
						continue;
					case 0x75:
						array2[9] = (byte)num3;
						num2 = 0x123;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xD2;
							continue;
						}
						continue;
					case 0x76:
						num3 = 0x76 + 0x3F;
						num2 = 0x15E;
						continue;
					case 0x77:
						num3 = 0xEC - 0x4E;
						num2 = 0x104;
						continue;
					case 0x78:
						array2[0x1D] = 0xCA + 0x16;
						num2 = 0xD0;
						continue;
					case 0x79:
						num3 = 0xF4 - 0x51;
						num2 = 9;
						continue;
					case 0x7A:
						array2[8] = 0xE1 - 0x4B;
						num2 = 0x13C;
						continue;
					case 0x7B:
						num4 = 0x12 + 0x11;
						num2 = 4;
						continue;
					case 0x7C:
					{
						DataRepository.StreamHolder streamHolder;
						DataRepository.SetStreamPosition(DataRepository.StreamHolderBase(streamHolder), 0L);
						num2 = 0x8D;
						continue;
					}
					case 0x7D:
					{
						DataRepository.StreamHolder streamHolder = new DataRepository.StreamHolder(streamIn);
						num2 = 0x7C;
						continue;
					}
					case 0x7E:
						goto IL_2D1F;
					case 0x7F:
						array2[0xC] = (byte)num3;
						num2 = 0xB6;
						continue;
					case 0x80:
						array2[0x18] = (byte)num3;
						num2 = 0x36;
						continue;
					case 0x81:
						array2[0x1A] = 0x99 - 0x33;
						num2 = 0x1F;
						continue;
					case 0x82:
						array[0] = (byte)num4;
						num2 = 0xE6;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_61;
						}
						continue;
					case 0x83:
						array[2] = (byte)num4;
						num2 = 0x160;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xFE;
							continue;
						}
						continue;
					case 0x84:
						array2[0x11] = (byte)num3;
						num2 = 0x96;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x120;
							continue;
						}
						continue;
					case 0x85:
						array2[0x10] = (byte)num3;
						num2 = 0xB8;
						continue;
					case 0x86:
						array[5] = (byte)num4;
						num2 = 0x20;
						continue;
					case 0x87:
						array2[0x1C] = 0xB2 - 0x3B;
						num2 = 0xE1;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_136;
						}
						continue;
					case 0x88:
						array[5] = 0xC1 - 0x40;
						num2 = 0xC6;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_2;
						}
						continue;
					case 0x89:
						array[4] = 0x47 - 0x3D;
						num2 = 0x4B;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0xC2;
							continue;
						}
						continue;
					case 0x8A:
						array2[0xC] = 3 + 0x4E;
						num2 = 0x54;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_98;
						}
						continue;
					case 0x8B:
						num3 = 0x76 + 0x1E;
						num2 = 0x21;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_86;
						}
						continue;
					case 0x8C:
						array[8] = (byte)num4;
						num2 = 0xDD;
						continue;
					case 0x8D:
					{
						DataRepository.StreamHolder streamHolder;
						array4 = DataRepository.StreamHolderReadBytes(streamHolder, (int)DataRepository.GetStreamLength(DataRepository.StreamHolderBase(streamHolder)));
						num2 = 0xD1;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x149;
							continue;
						}
						continue;
					}
					case 0x8E:
						array[0xF] = (byte)num4;
						num2 = 0x33;
						continue;
					case 0x8F:
						array2[0x15] = (byte)num3;
						num2 = 0x19;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_113;
						}
						continue;
					case 0x90:
						array2[0x19] = (byte)num3;
						num2 = 0xBF;
						continue;
					case 0x91:
						array[0xB] = 0x1C + 0xF;
						num2 = 0xCF;
						continue;
					case 0x92:
						array[2] = (byte)num4;
						num2 = 0xA9;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_77;
						}
						continue;
					case 0x93:
						array2[6] = 0x5A + 0x48;
						num2 = 0x121;
						continue;
					case 0x94:
						array2[0x1F] = 0x64 + 0x6D;
						num2 = 0x25;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x1B;
							continue;
						}
						continue;
					case 0x95:
						num3 = 0xEE - 0x4F;
						num2 = 0x31;
						continue;
					case 0x96:
						array2[0x1C] = (byte)num3;
						num2 = 0x55;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x36;
							continue;
						}
						continue;
					case 0x97:
						array2[0x17] = 0x8C - 0x37;
						num2 = 0x12B;
						continue;
					case 0x98:
						goto IL_1095;
					case 0x99:
						array2[0xB] = 0x20 + 0x1C;
						num2 = 0x35;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x2B;
							continue;
						}
						continue;
					case 0x9A:
						array[3] = 0x27 + 0x17;
						num2 = 0x2E;
						continue;
					case 0x9B:
						num3 = 0x65 + 2;
						num2 = 0xCC;
						continue;
					case 0x9C:
						array2[7] = 0x5D + 0x6A;
						num2 = 0xA;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x132;
							continue;
						}
						continue;
					case 0x9D:
						goto IL_2360;
					case 0x9E:
						array2[3] = 0x8D - 0x2F;
						num2 = 0x66;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_100;
						}
						continue;
					case 0x9F:
						array3[9] = assemblyKey[4];
						num2 = 0xD3;
						continue;
					case 0xA0:
						array2[0x14] = 0x74 + 0x50;
						num2 = 0x47;
						continue;
					case 0xA1:
						goto IL_2AC6;
					case 0xA2:
						array[8] = 0x86 - 0x2C;
						num2 = 0x108;
						continue;
					case 0xA3:
						array2[0x1D] = (byte)num3;
						num2 = 0x150;
						continue;
					case 0xA4:
						array2 = new byte[0x20];
						num2 = 0x169;
						continue;
					case 0xA5:
						num5++;
						num2 = 0x91;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xD4;
							continue;
						}
						continue;
					case 0xA6:
						array2[2] = (byte)num3;
						num2 = 0xBA;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_124;
						}
						continue;
					case 0xA7:
						num3 = 0x4A + 0x1C;
						num2 = 0x10A;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0x67;
							continue;
						}
						continue;
					case 0xA8:
						array2[0x14] = (byte)num3;
						num2 = 0xA0;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_84;
						}
						continue;
					case 0xA9:
						array[3] = 0xC6 - 0x42;
						num2 = 0x9A;
						continue;
					case 0xAA:
						num3 = 0x7B + 0x1C;
						num2 = 0x135;
						continue;
					case 0xAB:
						array2[0xB] = (byte)num3;
						num2 = 0x1D;
						continue;
					case 0xAC:
						num3 = 0x34 + 0x70;
						num2 = 0xF5;
						continue;
					case 0xAD:
						array2[4] = 0x8F - 0x2F;
						num2 = 0xAA;
						continue;
					case 0xAE:
						array2[9] = 0x71 + 0x19;
						num2 = 0xA7;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_21;
						}
						continue;
					case 0xAF:
						array2[0x11] = 0xB + 0x33;
						num2 = 0xFF;
						continue;
					case 0xB0:
						array2[0xC] = (byte)num3;
						num2 = 0xC;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_152;
						}
						continue;
					case 0xB1:
						num3 = 0x5A - 6;
						num2 = 0x5B;
						continue;
					case 0xB2:
						goto IL_2E5B;
					case 0xB3:
						array[1] = 0x53 + 0x27;
						num2 = 0x50;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_133;
						}
						continue;
					case 0xB4:
						array2[0x12] = 0x59 + 0x2E;
						num2 = 0x3C;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xF;
							continue;
						}
						continue;
					case 0xB5:
						array[8] = 0x55 + 0x46;
						num2 = 0xA2;
						continue;
					case 0xB6:
						array2[0xD] = 0xAE - 0x3A;
						num2 = 0x25;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0xF3;
							continue;
						}
						continue;
					case 0xB7:
						num4 = 0x66 + 0x46;
						num2 = 0xB8;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x126;
							continue;
						}
						continue;
					case 0xB8:
						goto IL_1DE1;
					case 0xB9:
						num3 = 0x29 + 0x56;
						num2 = 3;
						continue;
					case 0xBA:
						array2[3] = 0xD4 - 0x46;
						num2 = 0x9E;
						continue;
					case 0xBB:
						array[0xC] = 0x7E - 0x2A;
						num2 = 0x51;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_147;
						}
						continue;
					case 0xBC:
						num3 = 0xBE - 0x3F;
						num2 = 0xD1;
						continue;
					case 0xBD:
						array2[3] = (byte)num3;
						num2 = 0xEA;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_58;
						}
						continue;
					case 0xBE:
						array[4] = (byte)num4;
						num2 = 0x89;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_83;
						}
						continue;
					case 0xBF:
						array2[0x19] = 0xF6 - 0x52;
						num2 = 0x71;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_138;
						}
						continue;
					case 0xC0:
						array2[0x14] = (byte)num3;
						num2 = 0xD;
						continue;
					case 0xC1:
						goto IL_12EA;
					case 0xC2:
						num4 = 0x3B + 0x15;
						num2 = 0xC1;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x15D;
							continue;
						}
						continue;
					case 0xC3:
						num3 = 0x4F + 0x17;
						num2 = 0x134;
						continue;
					case 0xC4:
						array[7] = 0xD6 - 0x47;
						num2 = 0x110;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x10;
							continue;
						}
						continue;
					case 0xC5:
						array2[9] = 0x2A + 0x66;
						num2 = 0xDF;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0xD8;
							continue;
						}
						continue;
					case 0xC6:
						num4 = 0x34 + 0x70;
						num2 = 0x4A;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x86;
							continue;
						}
						continue;
					case 0xC7:
						array2[0x1B] = (byte)num3;
						num2 = 0x87;
						continue;
					case 0xC8:
						num3 = 0x2D + 0x19;
						num2 = 0xA3;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_3;
						}
						continue;
					case 0xC9:
						array2[6] = 0xC1 - 0x40;
						num2 = 0xAC;
						continue;
					case 0xCA:
						num4 = 0x84 - 0x2C;
						num2 = 0x10E;
						continue;
					case 0xCB:
						goto IL_18A0;
					case 0xCC:
						array2[0x1A] = (byte)num3;
						num2 = 0x127;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_115;
						}
						continue;
					case 0xCD:
						num3 = 0xC6 - 0x42;
						num2 = 0x75;
						continue;
					case 0xCE:
						array2[7] = (byte)num3;
						num2 = 0x7A;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_73;
						}
						continue;
					case 0xCF:
						num4 = 0x89 - 0x2D;
						num2 = 0x59;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x161;
							continue;
						}
						continue;
					case 0xD0:
						num3 = 0xA + 0x77;
						num2 = 0xF;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x61;
							continue;
						}
						continue;
					case 0xD1:
						goto IL_2783;
					case 0xD2:
						array[0xB] = (byte)num4;
						num2 = 0x10D;
						continue;
					case 0xD3:
						goto IL_2F73;
					case 0xD4:
						goto IL_1ABE;
					case 0xD5:
						array2[0x18] = (byte)num3;
						num2 = 0x107;
						continue;
					case 0xD6:
						num4 = 0xC6 - 0x42;
						num2 = 0x145;
						continue;
					case 0xD7:
						array2[0xE] = 0xFA - 0x53;
						num2 = 0x109;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_56;
						}
						continue;
					case 0xD8:
						array[0xC] = 0x7D - 0x29;
						num2 = 0xF7;
						continue;
					case 0xD9:
						array2[0xE] = 0x52 + 0x45;
						num2 = 0x7E;
						continue;
					case 0xDA:
						array[0xE] = (byte)num4;
						num2 = 0x2B;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_52;
						}
						continue;
					case 0xDB:
						num3 = 0xF0 - 0x50;
						num2 = 0x130;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_141;
						}
						continue;
					case 0xDC:
						num3 = 0x57 + 0x3D;
						num2 = 0x47;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x11A;
							continue;
						}
						continue;
					case 0xDD:
						array[9] = 0x97 - 0x32;
						num2 = 0x143;
						continue;
					case 0xDE:
						num4 = 6 + 0x6C;
						num2 = 0x3B;
						continue;
					case 0xDF:
						array2[0xA] = 0xA2 - 0x36;
						num2 = 6;
						continue;
					case 0xE0:
						array2[0x17] = 0x4D + 0x4F;
						num2 = 0x97;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_101;
						}
						continue;
					case 0xE1:
						num3 = 0xCB - 0x43;
						num2 = 0x4F;
						continue;
					case 0xE2:
						num4 = 0x18 + 0x60;
						num2 = 0x64;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x14C;
							continue;
						}
						continue;
					case 0xE3:
						array2[0x1F] = 0x7E - 0x2A;
						num2 = 0x63;
						continue;
					case 0xE4:
						array2[5] = (byte)num3;
						num2 = 0x111;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0xBD;
							continue;
						}
						continue;
					case 0xE5:
						goto IL_21F2;
					case 0xE6:
						goto IL_27B7;
					case 0xE7:
						array2[0xE] = (byte)num3;
						num2 = 0xD7;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_117;
						}
						continue;
					case 0xE8:
						array2[0x19] = (byte)num3;
						num2 = 0x81;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_74;
						}
						continue;
					case 0xE9:
						array[0xE] = 0xC1 - 0x78;
						num2 = 0x13A;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_145;
						}
						continue;
					case 0xEA:
						num3 = 0x9B - 0x3E;
						num2 = 0x152;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_132;
						}
						continue;
					case 0xEB:
						num3 = 0x78 + 0x76;
						num2 = 0x2A;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_7;
						}
						continue;
					case 0xEC:
						array[6] = (byte)num4;
						num2 = 0x12C;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_119;
						}
						continue;
					case 0xED:
						num4 = 0xE4 - 0x4C;
						num2 = 0x83;
						continue;
					case 0xEE:
						array2[0xA] = 0x2C + 0x4D;
						num2 = 0x105;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_65;
						}
						continue;
					case 0xEF:
						goto IL_252C;
					case 0xF0:
						array2[0xB] = (byte)num3;
						num2 = 0x168;
						continue;
					case 0xF1:
						array[0xD] = 0xCD - 0x44;
						num2 = 0x2C;
						continue;
					case 0xF2:
						goto IL_2F8A;
					case 0xF3:
						array2[0xD] = 0x62 + 0x41;
						num2 = 0x62;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0xDC;
							continue;
						}
						continue;
					case 0xF4:
						goto IL_1A59;
					case 0xF5:
						array2[6] = (byte)num3;
						num2 = 0x93;
						continue;
					case 0xF6:
						array[6] = 0x6A + 0x4D;
						num2 = 0x142;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_33;
						}
						continue;
					case 0xF7:
						array[0xC] = 0x4E + 0x3F;
						num2 = 0x131;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_23;
						}
						continue;
					case 0xF8:
						array[7] = (byte)num4;
						num2 = 0x59;
						continue;
					case 0xF9:
						array2[5] = 0xBA - 0x3E;
						num2 = 0x4E;
						continue;
					case 0xFA:
						num3 = 0xE0 - 0x4A;
						num2 = 0x15B;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_66;
						}
						continue;
					case 0xFB:
						array2[0x18] = (byte)num3;
						num2 = 0x34;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x53;
							continue;
						}
						continue;
					case 0xFC:
						num3 = 0x70 + 0x35;
						num2 = 0x14E;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_139;
						}
						continue;
					case 0xFD:
						array2[0xF] = 0xD6 - 0x60;
						num2 = 0x11B;
						continue;
					case 0xFE:
						num3 = 0xB0 + 0x47;
						num2 = 0x12E;
						continue;
					case 0xFF:
						array2[0x11] = 0x18 + 0x62;
						num2 = 0x4C;
						continue;
					case 0x100:
						array[0xD] = 0xFD - 0x54;
						num2 = 0x166;
						continue;
					case 0x101:
						num4 = 0x98 - 0x49;
						num2 = 0;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 0x102:
						stream = DataRepository.NewMemoryStream01();
						num2 = 0x27;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xC;
							continue;
						}
						continue;
					case 0x103:
						goto IL_63E;
					case 0x104:
						array2[0xF] = (byte)num3;
						num2 = 0xFD;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0xE6;
							continue;
						}
						continue;
					case 0x105:
						array2[0xA] = 0x97 - 0x36;
						num2 = 0x146;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_45;
						}
						continue;
					case 0x106:
						assemblyKey = DataRepository.GetAssemblyKey(DataRepository.GetAssemblyName(DataRepository.assembly));
						num2 = 0x4B;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x4A;
							continue;
						}
						continue;
					case 0x107:
						array2[0x18] = 0x60 + 0x60;
						num2 = 0x26;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_122;
						}
						continue;
					case 0x108:
						num4 = 0xF2 - 0x50;
						num2 = 2;
						continue;
					case 0x109:
						array2[0xE] = 0xCA - 0x43;
						num2 = 0xD9;
						continue;
					case 0x10A:
						array2[9] = (byte)num3;
						num2 = 0xC5;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_69;
						}
						continue;
					case 0x10B:
					{
						SymmetricAlgorithm symmetricAlgorithm;
						ICryptoTransform cryptoTransform = DataRepository.GetCryptoTransform(symmetricAlgorithm, array5, array3);
						num2 = 0x8B;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x102;
							continue;
						}
						continue;
					}
					case 0x10C:
						return;
					case 0x10D:
						array[0xB] = 0xC7 - 0x50;
						num2 = 0x48;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0xBB;
							continue;
						}
						continue;
					case 0x10E:
						array[0xB] = (byte)num4;
						num2 = 0x13B;
						continue;
					case 0x10F:
						array[0xD] = 0x3D + 0x11;
						num2 = 0xE4;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0x100;
							continue;
						}
						continue;
					case 0x110:
						num4 = 0x76 + 0x3F;
						num2 = 0xF8;
						continue;
					case 0x111:
						array2[5] = 0xBC - 0x3E;
						num2 = 0xF9;
						continue;
					case 0x112:
						array[0xA] = 0x94 - 0x31;
						num2 = 0x101;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_28;
						}
						continue;
					case 0x113:
						goto IL_20AD;
					case 0x114:
						num3 = 0x64 + 0x3A;
						num2 = 0x9D;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xD5;
							continue;
						}
						continue;
					case 0x115:
						num4 = 0x7E + 0x3B;
						num2 = 0x70;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 6;
							continue;
						}
						continue;
					case 0x116:
						array2[0x12] = (byte)num3;
						num2 = 0x39;
						continue;
					case 0x117:
						num3 = 0xDF - 0x4A;
						num2 = 0x74;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_46;
						}
						continue;
					case 0x118:
						array2[0x1F] = (byte)num3;
						num2 = 0x3F;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_29;
						}
						continue;
					case 0x119:
						array2[1] = 0xB5 - 0x3C;
						num2 = 0x3E;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_89;
						}
						continue;
					case 0x11A:
						array2[0xD] = (byte)num3;
						num2 = 0x45;
						continue;
					case 0x11B:
						goto IL_F41;
					case 0x11C:
						array[0xF] = 0x65 + 0x43;
						num2 = 0xDE;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xBB;
							continue;
						}
						continue;
					case 0x11D:
						array2[0xF] = 0x43 + 6;
						num2 = 0x95;
						continue;
					case 0x11E:
						array2[0x15] = 0xF1 + 1;
						num2 = 5;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_34;
						}
						continue;
					case 0x11F:
						num4 = 0x16 + 0x2B;
						num2 = 0xDA;
						continue;
					case 0x120:
						array2[0x12] = 0x72 + 1;
						num2 = 0x16A;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_103;
						}
						continue;
					case 0x121:
						num3 = 0x61 - 0x23;
						num2 = 0x125;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_128;
						}
						continue;
					case 0x122:
						array2[0x15] = 0x48 + 0x5C;
						num2 = 0x11E;
						continue;
					case 0x123:
						num3 = 0x86 - 0x2C;
						num2 = 0x2F;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_131;
						}
						continue;
					case 0x124:
						array2[0x16] = (byte)num3;
						num2 = 0x6D;
						continue;
					case 0x125:
						array2[6] = (byte)num3;
						num2 = 0x9C;
						continue;
					case 0x126:
						array[9] = (byte)num4;
						num2 = 0x162;
						continue;
					case 0x127:
						num3 = 0xF + 0x6A;
						num2 = 0x12D;
						continue;
					case 0x128:
					{
						SymmetricAlgorithm symmetricAlgorithm = DataRepository.GetSymmetricAlgorithm01();
						num2 = 0x14B;
						continue;
					}
					case 0x129:
						num4 = 0xBC - 0x3E;
						num2 = 0x30;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_31;
						}
						continue;
					case 0x12A:
						num3 = 0x16 + 0x48;
						num2 = 0x96;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_118;
						}
						continue;
					case 0x12B:
						num3 = 2 + 0x3A;
						num2 = 0xFB;
						continue;
					case 0x12C:
						array[7] = 0x17 + 0x3C;
						num2 = 0xE2;
						continue;
					case 0x12D:
						array2[0x1A] = (byte)num3;
						num2 = 0xCE;
						if (DataRepository._ReturnNull02() == null)
						{
							num2 = 0xFE;
							continue;
						}
						continue;
					case 0x12E:
						array2[0x1A] = (byte)num3;
						num2 = 0x117;
						continue;
					case 0x12F:
						num4 = 0x8A - 0x11;
						num2 = 0x92;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x2C;
							continue;
						}
						continue;
					case 0x130:
						array2[0xC] = (byte)num3;
						num2 = 0x72;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_154;
						}
						continue;
					case 0x131:
						num4 = 0x5A - 0x23;
						num2 = 0x2D;
						continue;
					case 0x132:
						array2[7] = 0x80 - 0x2A;
						num2 = 0x159;
						continue;
					case 0x133:
						num3 = 0x61 + 0x3D;
						num2 = 0x4D;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_142;
						}
						continue;
					case 0x134:
						array2[7] = (byte)num3;
						num2 = 0x62;
						continue;
					case 0x135:
						array2[4] = (byte)num3;
						num2 = 0x1E;
						continue;
					case 0x136:
						array[1] = (byte)num4;
						num2 = 0xB;
						continue;
					case 0x137:
						array2[1] = 0x6F + 0x53;
						num2 = 0x119;
						continue;
					case 0x138:
						goto IL_949;
					case 0x139:
						num4 = 0x96 - 0x32;
						num2 = 0x136;
						continue;
					case 0x13A:
						array[0xF] = 0x45 + 0x29;
						num2 = 0x1F;
						if (DataRepository._ReturnTrue01())
						{
							num2 = 0x11C;
							continue;
						}
						continue;
					case 0x13B:
						num4 = 0x6C + 0x20;
						num2 = 0xD2;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_123;
						}
						continue;
					case 0x13C:
						array2[8] = 0xD6 - 0x47;
						num2 = 0x76;
						continue;
					case 0x13D:
						goto IL_20C7;
					case 0x13E:
					{
						CryptoStream cryptoStream;
						DataRepository.CloseStream(cryptoStream);
						num2 = 0x52;
						continue;
					}
					case 0x13F:
						array[0xF] = (byte)num4;
						num2 = 0xEF;
						continue;
					case 0x140:
						goto IL_2E38;
					case 0x141:
						num3 = 0x95 + 0x18;
						num2 = 0x16D;
						continue;
					case 0x142:
						array[6] = 0x71 + 0x1B;
						num2 = 0x11;
						continue;
					case 0x143:
						array[9] = 0xCA - 0x43;
						num2 = 0xB7;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x87;
							continue;
						}
						continue;
					case 0x144:
						array3[0xD] = assemblyKey[6];
						num2 = 0x147;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x47;
							continue;
						}
						continue;
					case 0x145:
						array[3] = (byte)num4;
						num2 = 0x103;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_37;
						}
						continue;
					case 0x146:
						array2[0xB] = 0xA1 - 0x35;
						num2 = 0xBC;
						continue;
					case 0x147:
						array3[0xF] = assemblyKey[7];
						num2 = 0x9D;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_93;
						}
						continue;
					case 0x148:
						array[3] = (byte)num4;
						num2 = 0xD6;
						if (DataRepository._ReturnNull02() != null)
						{
							goto Block_91;
						}
						continue;
					case 0x149:
					{
						DataRepository.StreamHolder streamHolder;
						DataRepository.StreamHolderClose(streamHolder);
						num2 = 0xA4;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_92;
						}
						continue;
					}
					case 0x14A:
						array2[0x1E] = 0x1D + 0x77;
						num2 = 0x5C;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x53;
							continue;
						}
						continue;
					case 0x14B:
					{
						SymmetricAlgorithm symmetricAlgorithm;
						DataRepository.SetCypherMode(symmetricAlgorithm, CipherMode.CBC);
						num2 = 0x10B;
						continue;
					}
					case 0x14C:
						array[7] = (byte)num4;
						num2 = 0xC4;
						continue;
					case 0x14D:
						array2[0x16] = (byte)num3;
						num2 = 0x24;
						continue;
					case 0x14E:
						array2[9] = (byte)num3;
						num2 = 0xAE;
						continue;
					case 0x14F:
						num3 = 0xC3 - 0x41;
						num2 = 0x3A;
						continue;
					case 0x150:
						num3 = 7 + 0x3E;
						num2 = 0x15F;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x37;
							continue;
						}
						continue;
					case 0x151:
						array2[0x13] = (byte)num3;
						num2 = 0x167;
						if (!DataRepository._ReturnTrue01())
						{
							num2 = 0xAE;
							continue;
						}
						continue;
					case 0x152:
						array2[3] = (byte)num3;
						num2 = 0xFA;
						continue;
					case 0x153:
						num4 = 0x75 + 0x29;
						num2 = 0x68;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_140;
						}
						continue;
					case 0x154:
						num4 = 0xE5 - 0x4C;
						num2 = 0x4A;
						continue;
					case 0x155:
						array2[0x1B] = 0x1F + 4;
						num2 = 0x42;
						continue;
					case 0x156:
						num3 = 0x81 - 0x2B;
						num2 = 0x1A;
						continue;
					case 0x157:
						num4 = 0x81 - 0x2B;
						num2 = 0xBE;
						continue;
					case 0x158:
						num3 = 0x17 + 0x73;
						num2 = 0xBD;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_70;
						}
						continue;
					case 0x159:
						array2[7] = 0x1B + 0x71;
						num2 = 0xC3;
						continue;
					case 0x15A:
						num4 = 0xDD - 0x49;
						num2 = 0x5F;
						continue;
					case 0x15B:
						array2[4] = (byte)num3;
						num2 = 0xAD;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_27;
						}
						continue;
					case 0x15C:
						array[0xA] = (byte)num4;
						num2 = 0x13D;
						continue;
					case 0x15D:
						array[5] = (byte)num4;
						num2 = 0xB2;
						continue;
					case 0x15E:
						array2[8] = (byte)num3;
						num2 = 1;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 0x15F:
						array2[0x1D] = (byte)num3;
						num2 = 0x156;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_40;
						}
						continue;
					case 0x160:
						array[2] = 0xDB - 0x49;
						num2 = 0x12F;
						continue;
					case 0x161:
						array[0xB] = (byte)num4;
						num2 = 0xCA;
						continue;
					case 0x162:
						array[9] = 0xB1 + 0x24;
						num2 = 0x7B;
						continue;
					case 0x163:
						array2[0x16] = (byte)num3;
						num2 = 0x32;
						continue;
					case 0x164:
						array[1] = (byte)num4;
						num2 = 0x15A;
						continue;
					case 0x165:
						array2[0x1E] = (byte)num3;
						num2 = 0x1C;
						continue;
					case 0x166:
						array[0xD] = 0x24 - 6;
						num2 = 0x11F;
						if (!DataRepository._ReturnTrue01())
						{
							goto Block_4;
						}
						continue;
					case 0x167:
						num3 = 0x26 + 0x42;
						num2 = 0xC0;
						continue;
					case 0x168:
						num3 = 0x4A + 0x6C;
						num2 = 0xB0;
						continue;
					case 0x169:
						array2[0] = 0xF + 0x49;
						num2 = 0x6C;
						continue;
					case 0x16A:
						array2[0x12] = 0xC8 - 0x42;
						num2 = 0x40;
						continue;
					case 0x16B:
						goto IL_100E;
					case 0x16C:
						array5 = array2;
						num2 = 0x73;
						continue;
					case 0x16D:
						array2[1] = (byte)num3;
						num2 = 0x16B;
						if (DataRepository._ReturnNull02() != null)
						{
							num2 = 0x83;
							continue;
						}
						continue;
					case 0x16E:
					{
						CryptoStream cryptoStream;
						DataRepository.FlushCryptoStream(cryptoStream);
						num2 = 0x57;
						continue;
					}
					}
					goto Block_1;
					IL_1ABE:
					if (num5 < array3.Length)
					{
						goto IL_29F6;
					}
					num2 = 0x17;
					if (!DataRepository._ReturnTrue01())
					{
						break;
					}
					continue;
					IL_20AD:
					new DataRepository().__rB5OOrvaPT(array5, array3, array4);
					num2 = 0x10C;
					continue;
					IL_29F6:
					array5[num5] ^= array3[num5];
					num2 = 0xA5;
				}
				Block_2:
				Block_3:
				continue;
				IL_63E:
				array[3] = 0xC9 - 0x43;
				num = 0x60;
				Block_4:
				Block_7:
				Block_8:
				continue;
				IL_7A3:
				array[7] = 0xB2 - 0x6A;
				num = 0xB5;
				Block_10:
				Block_11:
				Block_12:
				Block_13:
				continue;
				IL_949:
				num4 = 0xAB - 0x39;
				num = 0x15C;
				Block_16:
				Block_17:
				Block_18:
				Block_19:
				Block_21:
				Block_23:
				Block_27:
				Block_28:
				Block_29:
				continue;
				IL_DBE:
				array2[0x1E] = (byte)num3;
				num = 0x14A;
				Block_31:
				Block_33:
				Block_34:
				Block_35:
				continue;
				IL_F41:
				num3 = 2 + 0x1A;
				num = 0x85;
				Block_37:
				continue;
				IL_FC9:
				num3 = 0x7C - 0x5E;
				num = 0xCE;
				continue;
				IL_100E:
				array2[2] = 0x27 + 0x26;
				num = 0x6A;
				Block_40:
				continue;
				IL_1095:
				DataRepository.CloseStream(stream);
				num = 0x13E;
				Block_43:
				Block_45:
				Block_46:
				Block_48:
				Block_51:
				continue;
				IL_12EA:
				num4 = 0x82 + 0x30;
				num = 0x10;
				Block_52:
				Block_56:
				Block_58:
				Block_60:
				Block_61:
				Block_62:
				Block_65:
				Block_66:
				Block_67:
				Block_69:
				Block_70:
				continue;
				IL_18A0:
				num3 = 0x6A + 0x22;
				num = 0x14D;
				Block_73:
				continue;
				IL_1A59:
				array3[7] = assemblyKey[3];
				num = 0x9F;
				Block_74:
				Block_77:
				continue;
				IL_1C83:
				array[0xA] = (byte)num4;
				num = 0x91;
				continue;
				Block_1:
				goto IL_1C83;
				Block_83:
				Block_84:
				Block_86:
				Block_88:
				continue;
				IL_1DE1:
				array2[0x10] = 0x31 + 0x34;
				num = 0x140;
				Block_89:
				Block_90:
				continue;
				IL_1F37:
				array2[0x10] = (byte)num3;
				num = 0x3D;
				Block_91:
				Block_92:
				Block_93:
				Block_95:
				continue;
				IL_20C7:
				array[0xA] = 0x36 + 4;
				num = 0x112;
				Block_98:
				continue;
				IL_21F2:
				array2[0x1A] = (byte)num3;
				num = 0x9B;
				Block_100:
				Block_101:
				continue;
				IL_2360:
				num5 = 0;
				num = 0x58;
				Block_103:
				continue;
				IL_23B3:
				array[6] = 0xB6 - 0x3C;
				num = 0xF6;
				continue;
				IL_2437:
				num4 = 0xB1 - 0x3B;
				num = 0xA1;
				continue;
				IL_24CF:
				array2[2] = (byte)num3;
				num = 0x18;
				continue;
				IL_252C:
				array3 = array;
				num = 0x6B;
				Block_111:
				Block_113:
				Block_115:
				continue;
				IL_2783:
				array2[0xB] = (byte)num3;
				num = 0x99;
				continue;
				IL_27B7:
				array[0] = 0xBD - 0x3F;
				num = 0x153;
				Block_117:
				Block_118:
				Block_119:
				Block_122:
				Block_123:
				Block_124:
				Block_126:
				Block_128:
				continue;
				IL_2AC6:
				array[2] = (byte)num4;
				num = 0xED;
				Block_131:
				Block_132:
				Block_133:
				Block_135:
				continue;
				IL_2D1F:
				num3 = 0x5E + 0x53;
				num = 7;
				Block_136:
				Block_137:
				continue;
				IL_2DC1:
				DataRepository.ReverseArray(array3);
				num = 0x106;
				Block_138:
				continue;
				IL_2E38:
				array2[0x10] = 0xAC - 0x39;
				num = 0xB1;
				continue;
				IL_2E5B:
				array[5] = 0xD3 - 0x46;
				num = 0x88;
				Block_139:
				Block_140:
				continue;
				IL_2F73:
				array3[0xB] = assemblyKey[5];
				num = 0x144;
				continue;
				IL_2F8A:
				array2[0x12] = (byte)num3;
				num = 0x133;
				Block_141:
				Block_142:
				Block_145:
				Block_147:
				Block_151:
				Block_152:
				Block_154:;
			}
		}

		// Token: 0x060000C8 RID: 200
		internal static string EncodeStringBase64(string stringIn)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(stringIn);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x060000D9 RID: 217
		static byte[] EncryptBytes(byte[] arrBuffer)
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
			cryptoStream.Write(arrBuffer, 0, arrBuffer.Length);
			cryptoStream.Close();
			byte[] result = DataRepository.MemoryStreamToArray(stream);
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			return result;
		}

		// Token: 0x060000CF RID: 207
		static IntPtr FindResourceA(IntPtr hModule, string lpName, uint lpType)
		{
			if (DataRepository.delegateFindResourceA == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Find ".Trim() + "ResourceA");
				DataRepository.delegateFindResourceA = (DataRepository.DelegateFindResourceA)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateFindResourceA));
			}
			return DataRepository.delegateFindResourceA(hModule, lpName, lpType);
		}

		// Token: 0x060000F3 RID: 243
		internal static void FlushCryptoStream(CryptoStream cryptoStream)
		{
			cryptoStream.FlushFinalBlock();
		}

		// Token: 0x060000CC RID: 204
		internal static string GetAssemblyCodeBase(Assembly assemblyIn)
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

		// Token: 0x060000ED RID: 237
		internal static byte[] GetAssemblyKey(AssemblyName assemblyName)
		{
			return assemblyName.GetPublicKeyToken();
		}

		// Token: 0x060000EC RID: 236
		internal static AssemblyName GetAssemblyName(Assembly assemblyIn)
		{
			return assemblyIn.GetName();
		}

		// Token: 0x060000F0 RID: 240
		internal static ICryptoTransform GetCryptoTransform(SymmetricAlgorithm symmetricAlgorithm, byte[] rgbKey, byte[] rgbIV)
		{
			return symmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);
		}

		// Token: 0x060000BE RID: 190
		internal static byte[] GetInitialisationVector(byte[] arrBuffer)
		{
			if (!DataRepository.GetOnlyFipsAlgorithms())
			{
				return new MD5CryptoServiceProvider().ComputeHash(arrBuffer);
			}
			return DataRepository.GetNonFipsInitialisationVector(arrBuffer);
		}

		// Token: 0x060000C7 RID: 199
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string GetManifestString(int manifestIndex)
		{
			if (DataRepository.resourceNameBytes.Length == 0)
			{
				DataRepository.resourceNames = new List<string>();
				DataRepository.resourceIndexes = new List<int>();
				DataRepository.DecodeManifestResource(DataRepository.assembly.GetManifestResourceStream("NYVZ5QbAorSWyluZxn.uNGIFdm1vqy5NYiSby"), manifestIndex);
			}
			if (DataRepository.manifestReadCount < 0x4B)
			{
				if (DataRepository.assembly != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				DataRepository.manifestReadCount++;
			}
			int num = BitConverter.ToInt32(DataRepository.resourceNameBytes, manifestIndex);
			if (num < DataRepository.resourceIndexes.Count && DataRepository.resourceIndexes[num] == manifestIndex)
			{
				return DataRepository.resourceNames[num];
			}
			try
			{
				feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
				byte[] array = new byte[num];
				Array.Copy(DataRepository.resourceNameBytes, manifestIndex + 4, array, 0, num);
				string @string = Encoding.Unicode.GetString(array, 0, array.Length);
				DataRepository.resourceNames.Add(@string);
				DataRepository.resourceIndexes.Add(manifestIndex);
				Array.Copy(BitConverter.GetBytes(DataRepository.resourceNames.Count - 1), 0, DataRepository.resourceNameBytes, manifestIndex, 4);
				return @string;
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x060000DA RID: 218
		unsafe static int GetMessageCode(string messageIn)
		{
			IntPtr intPtr2;
			IntPtr intPtr = intPtr2 = messageIn;
			if (intPtr != 0)
			{
				intPtr2 = (IntPtr)((int)intPtr + RuntimeHelpers.OffsetToStringData);
			}
			char* ptr = intPtr2;
			int num = 0x1505;
			int num2 = num;
			char* ptr2 = ptr;
			int num3;
			while ((num3 = (int)(*ptr2)) != 0)
			{
				num = ((num << 5) + num ^ num3);
				num3 = (int)ptr2[1];
				if (num3 == 0)
				{
					break;
				}
				num2 = ((num2 << 5) + num2 ^ num3);
				ptr2 += 2;
			}
			return num + num2 * 0x5D588B65;
		}

		// Token: 0x060000B3 RID: 179
		internal static byte[] GetNonFipsInitialisationVector(byte[] arrBuffer)
		{
			uint[] array = new uint[0x10];
			int num = 0x1C0 - arrBuffer.Length * 8 % 0x200;
			uint num2 = (uint)((num + 0x200) % 0x200);
			if (num2 == 0U)
			{
				num2 = 0x200U;
			}
			uint num3 = (uint)((long)arrBuffer.Length + (long)((ulong)(num2 / 8U)) + 8L);
			ulong num4 = (ulong)((long)arrBuffer.Length * 8L);
			byte[] array2 = new byte[num3];
			for (int i = 0; i < arrBuffer.Length; i++)
			{
				array2[i] = arrBuffer[i];
			}
			byte[] array3 = array2;
			int num5 = arrBuffer.Length;
			array3[num5] |= 0x80;
			for (int j = 8; j > 0; j--)
			{
				array2[(int)(checked((IntPtr)(unchecked((ulong)num3 - (ulong)((long)j)))))] = (byte)(num4 >> (8 - j) * 8 & 0xFFUL);
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
					array[(int)((UIntPtr)(num13 >> 2))] = (uint)((int)array2[(int)((UIntPtr)(num12 + (num13 + 3U)))] << 0x18 | (int)array2[(int)((UIntPtr)(num12 + (num13 + 2U)))] << 0x10 | (int)array2[(int)((UIntPtr)(num12 + (num13 + 1U)))] << 8 | (int)array2[(int)((UIntPtr)(num12 + num13))]);
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
				DataRepository._Incrementor03(ref num7, num8, num9, num10, 1U, 5, 0x11U, array);
				DataRepository._Incrementor03(ref num10, num7, num8, num9, 6U, 9, 0x12U, array);
				DataRepository._Incrementor03(ref num9, num10, num7, num8, 0xBU, 0xE, 0x13U, array);
				DataRepository._Incrementor03(ref num8, num9, num10, num7, 0U, 0x14, 0x14U, array);
				DataRepository._Incrementor03(ref num7, num8, num9, num10, 5U, 5, 0x15U, array);
				DataRepository._Incrementor03(ref num10, num7, num8, num9, 0xAU, 9, 0x16U, array);
				DataRepository._Incrementor03(ref num9, num10, num7, num8, 0xFU, 0xE, 0x17U, array);
				DataRepository._Incrementor03(ref num8, num9, num10, num7, 4U, 0x14, 0x18U, array);
				DataRepository._Incrementor03(ref num7, num8, num9, num10, 9U, 5, 0x19U, array);
				DataRepository._Incrementor03(ref num10, num7, num8, num9, 0xEU, 9, 0x1AU, array);
				DataRepository._Incrementor03(ref num9, num10, num7, num8, 3U, 0xE, 0x1BU, array);
				DataRepository._Incrementor03(ref num8, num9, num10, num7, 8U, 0x14, 0x1CU, array);
				DataRepository._Incrementor03(ref num7, num8, num9, num10, 0xDU, 5, 0x1DU, array);
				DataRepository._Incrementor03(ref num10, num7, num8, num9, 2U, 9, 0x1EU, array);
				DataRepository._Incrementor03(ref num9, num10, num7, num8, 7U, 0xE, 0x1FU, array);
				DataRepository._Incrementor03(ref num8, num9, num10, num7, 0xCU, 0x14, 0x20U, array);
				DataRepository._Incrementor02(ref num7, num8, num9, num10, 5U, 4, 0x21U, array);
				DataRepository._Incrementor02(ref num10, num7, num8, num9, 8U, 0xB, 0x22U, array);
				DataRepository._Incrementor02(ref num9, num10, num7, num8, 0xBU, 0x10, 0x23U, array);
				DataRepository._Incrementor02(ref num8, num9, num10, num7, 0xEU, 0x17, 0x24U, array);
				DataRepository._Incrementor02(ref num7, num8, num9, num10, 1U, 4, 0x25U, array);
				DataRepository._Incrementor02(ref num10, num7, num8, num9, 4U, 0xB, 0x26U, array);
				DataRepository._Incrementor02(ref num9, num10, num7, num8, 7U, 0x10, 0x27U, array);
				DataRepository._Incrementor02(ref num8, num9, num10, num7, 0xAU, 0x17, 0x28U, array);
				DataRepository._Incrementor02(ref num7, num8, num9, num10, 0xDU, 4, 0x29U, array);
				DataRepository._Incrementor02(ref num10, num7, num8, num9, 0U, 0xB, 0x2AU, array);
				DataRepository._Incrementor02(ref num9, num10, num7, num8, 3U, 0x10, 0x2BU, array);
				DataRepository._Incrementor02(ref num8, num9, num10, num7, 6U, 0x17, 0x2CU, array);
				DataRepository._Incrementor02(ref num7, num8, num9, num10, 9U, 4, 0x2DU, array);
				DataRepository._Incrementor02(ref num10, num7, num8, num9, 0xCU, 0xB, 0x2EU, array);
				DataRepository._Incrementor02(ref num9, num10, num7, num8, 0xFU, 0x10, 0x2FU, array);
				DataRepository._Incrementor02(ref num8, num9, num10, num7, 2U, 0x17, 0x30U, array);
				DataRepository._Incrementor04(ref num7, num8, num9, num10, 0U, 6, 0x31U, array);
				DataRepository._Incrementor04(ref num10, num7, num8, num9, 7U, 0xA, 0x32U, array);
				DataRepository._Incrementor04(ref num9, num10, num7, num8, 0xEU, 0xF, 0x33U, array);
				DataRepository._Incrementor04(ref num8, num9, num10, num7, 5U, 0x15, 0x34U, array);
				DataRepository._Incrementor04(ref num7, num8, num9, num10, 0xCU, 6, 0x35U, array);
				DataRepository._Incrementor04(ref num10, num7, num8, num9, 3U, 0xA, 0x36U, array);
				DataRepository._Incrementor04(ref num9, num10, num7, num8, 0xAU, 0xF, 0x37U, array);
				DataRepository._Incrementor04(ref num8, num9, num10, num7, 1U, 0x15, 0x38U, array);
				DataRepository._Incrementor04(ref num7, num8, num9, num10, 8U, 6, 0x39U, array);
				DataRepository._Incrementor04(ref num10, num7, num8, num9, 0xFU, 0xA, 0x3AU, array);
				DataRepository._Incrementor04(ref num9, num10, num7, num8, 6U, 0xF, 0x3BU, array);
				DataRepository._Incrementor04(ref num8, num9, num10, num7, 0xDU, 0x15, 0x3CU, array);
				DataRepository._Incrementor04(ref num7, num8, num9, num10, 4U, 6, 0x3DU, array);
				DataRepository._Incrementor04(ref num10, num7, num8, num9, 0xBU, 0xA, 0x3EU, array);
				DataRepository._Incrementor04(ref num9, num10, num7, num8, 2U, 0xF, 0x3FU, array);
				DataRepository._Incrementor04(ref num8, num9, num10, num7, 9U, 0x15, 0x40U, array);
				num7 += num14;
				num8 += num15;
				num9 += num16;
				num10 += num17;
			}
			byte[] array4 = new byte[0x10];
			Array.Copy(BitConverter.GetBytes(num7), 0, array4, 0, 4);
			Array.Copy(BitConverter.GetBytes(num8), 0, array4, 4, 4);
			Array.Copy(BitConverter.GetBytes(num9), 0, array4, 8, 4);
			Array.Copy(BitConverter.GetBytes(num10), 0, array4, 0xC, 4);
			return array4;
		}

		// Token: 0x060000B9 RID: 185
		internal static bool GetOnlyFipsAlgorithms()
		{
			if (!DataRepository.fipsAlgorithmsChecked)
			{
				DataRepository.GetOnlyFipsAlgorithms01();
				DataRepository.fipsAlgorithmsChecked = true;
			}
			return DataRepository.allowOnlyFipsAlgorithms;
		}

		// Token: 0x060000BD RID: 189
		internal static void GetOnlyFipsAlgorithms01()
		{
			try
			{
				DataRepository.allowOnlyFipsAlgorithms = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x060000CE RID: 206
		[DllImport("kernel32", CharSet = CharSet.Ansi)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x060000E8 RID: 232
		internal static long GetStreamLength(Stream streamIn)
		{
			return streamIn.Length;
		}

		// Token: 0x060000BC RID: 188
		internal static SymmetricAlgorithm GetSymmetricAlgorithm()
		{
			SymmetricAlgorithm result = null;
			if (DataRepository.GetOnlyFipsAlgorithms())
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

		// Token: 0x060000EE RID: 238
		internal static object GetSymmetricAlgorithm01()
		{
			return DataRepository.GetSymmetricAlgorithm();
		}

		// Token: 0x060000D4 RID: 212
		static int K32_CloseHandle(IntPtr ptr)
		{
			if (DataRepository.delegateCloseHandle == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Close ".Trim() + "Handle");
				DataRepository.delegateCloseHandle = (DataRepository.DelegateCloseHandle)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateCloseHandle));
			}
			return DataRepository.delegateCloseHandle(ptr);
		}

		// Token: 0x060000CD RID: 205
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr K32_LoadLibrary(string lpFileName);

		// Token: 0x060000D3 RID: 211
		static IntPtr K32_OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId)
		{
			if (DataRepository.delegateOpenProcess == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Open ".Trim() + "Process");
				DataRepository.delegateOpenProcess = (DataRepository.DelegateOpenProcess)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateOpenProcess));
			}
			return DataRepository.delegateOpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);
		}

		// Token: 0x060000D0 RID: 208
		static IntPtr K32_VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect)
		{
			if (DataRepository.delegateVirtualAlloc == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Virtual ".Trim() + "Alloc");
				DataRepository.delegateVirtualAlloc = (DataRepository.DelegateVirtualAlloc)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateVirtualAlloc));
			}
			return DataRepository.delegateVirtualAlloc(lpAddress, dwSize, flAllocationType, flProtect);
		}

		// Token: 0x060000D2 RID: 210
		static int K32_VirtualProtect(IntPtr lpAddress, int dwsize, int flNewProtect, ref int lpflOldProtect)
		{
			if (DataRepository.delegateVirtualProtect == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Virtual ".Trim() + "Protect");
				DataRepository.delegateVirtualProtect = (DataRepository.DelegateVirtualProtect)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateVirtualProtect));
			}
			return DataRepository.delegateVirtualProtect(lpAddress, dwsize, flNewProtect, ref lpflOldProtect);
		}

		// Token: 0x060000D5 RID: 213
		static IntPtr Kernel32Ptr()
		{
			if (DataRepository.kernel32Ptr == IntPtr.Zero)
			{
				DataRepository.kernel32Ptr = DataRepository.K32_LoadLibrary("kernel ".Trim() + "32.dll");
			}
			return DataRepository.kernel32Ptr;
		}

		// Token: 0x060000D8 RID: 216
		internal static byte[] MemoryStreamToArray(MemoryStream memoryStream)
		{
			return ((MemoryStream)memoryStream).ToArray();
		}

		// Token: 0x060000D7 RID: 215
		internal static MemoryStream NewMemoryStream()
		{
			return new MemoryStream();
		}

		// Token: 0x060000F1 RID: 241
		internal static MemoryStream NewMemoryStream01()
		{
			return DataRepository.NewMemoryStream();
		}

		// Token: 0x060000C1 RID: 193
		internal static uint ReadBinaryReader(uint index, int count, long offSet, BinaryReader binaryReaderIn)
		{
			for (int i = 0; i < count; i++)
			{
				binaryReaderIn.BaseStream.Position = offSet + (long)(i * 0x28 + 8);
				uint num = binaryReaderIn.ReadUInt32();
				uint num2 = binaryReaderIn.ReadUInt32();
				binaryReaderIn.ReadUInt32();
				uint num3 = binaryReaderIn.ReadUInt32();
				if (num2 <= index && index < num2 + num)
				{
					return num3 + index - num2;
				}
			}
			return 0U;
		}

		// Token: 0x060000D6 RID: 214
		static byte[] ReadFileBytes(string filePath)
		{
			byte[] array;
			using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				int num = 0;
				long length = fileStream.Length;
				int i = (int)length;
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

		// Token: 0x060000C2 RID: 194
		public static void RegisterHandle(RuntimeTypeHandle runtimeTypeHandleIn)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandleIn);
				if (DataRepository.metaTokenRefs == null)
				{
					lock (DataRepository._processThread)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(DataRepository).Assembly.GetManifestResourceStream("mWQc273Qn08NsHVFXQ.CbAK6EdZ9Hptaso6Je"));
						binaryReader.BaseStream.Position = 0L;
						byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						binaryReader.Close();
						if (array.Length > 0)
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
									num7 = (uint)((int)array[(int)((UIntPtr)(num8 + 3U))] << 0x18 | (int)array[(int)((UIntPtr)(num8 + 2U))] << 0x10 | (int)array[(int)((UIntPtr)(num8 + 1U))] << 8 | (int)array[(int)((UIntPtr)num8)]);
								}
								num3 = num3;
								num3 += DataRepository._ReturnZero01(num3);
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
							DataRepository.StreamHolder streamHolder = new DataRepository.StreamHolder(new MemoryStream(array));
							for (int l = 0; l < num11; l++)
							{
								int key = streamHolder.ReadInt32();
								int value = streamHolder.ReadInt32();
								dictionary.Add(key, value);
							}
							streamHolder.Close();
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
						for (int n = 0; n < parameters.Length; n++)
						{
							array3[n + 1] = parameters[n].ParameterType;
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
		}

		// Token: 0x060000EB RID: 235
		internal static void ReverseArray(Array arrayIn)
		{
			Array.Reverse(arrayIn);
		}

		// Token: 0x060000EF RID: 239
		internal static void SetCypherMode(SymmetricAlgorithm symmetricAlgorithm, CipherMode cipherMode)
		{
			symmetricAlgorithm.Mode = cipherMode;
		}

		// Token: 0x060000E7 RID: 231
		internal static void SetStreamPosition(Stream streamIn, long positionIn)
		{
			streamIn.Position = positionIn;
		}

		// Token: 0x060000CA RID: 202
		static void SetUseMachineKeyStore()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000E6 RID: 230
		internal static Stream StreamHolderBase(DataRepository.StreamHolder streamHolderIn)
		{
			return streamHolderIn.BaseStream();
		}

		// Token: 0x060000EA RID: 234
		internal static void StreamHolderClose(DataRepository.StreamHolder streamHolderIn)
		{
			streamHolderIn.Close();
		}

		// Token: 0x060000E9 RID: 233
		internal static object StreamHolderReadBytes(DataRepository.StreamHolder streamHolder, int count)
		{
			return streamHolder.ReadBytes(count);
		}

		// Token: 0x060000C0 RID: 192
		internal static void TransformAlgorithm(HashAlgorithm hashAlgorithm, byte[] arrBuffer, int offSet, int count)
		{
			hashAlgorithm.TransformBlock(arrBuffer, offSet, count, arrBuffer, offSet);
		}

		// Token: 0x060000BF RID: 191
		internal static void TransformBuffer(HashAlgorithm hashAlgorithm, Stream streamIn, uint count, byte[] arrBuffer)
		{
			while (count > 0U)
			{
				int num = (count > (uint)arrBuffer.Length) ? arrBuffer.Length : ((int)count);
				streamIn.Read(arrBuffer, 0, num);
				DataRepository.TransformAlgorithm(hashAlgorithm, arrBuffer, 0, num);
				count -= (uint)num;
			}
		}

		// Token: 0x060000D1 RID: 209
		static int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten)
		{
			if (DataRepository.delegateWriteProcessMemory == null)
			{
				IntPtr procAddress = DataRepository.GetProcAddress(DataRepository.Kernel32Ptr(), "Write ".Trim() + "Process ".Trim() + "Memory");
				DataRepository.delegateWriteProcessMemory = (DataRepository.DelegateWriteProcessMemory)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DataRepository.DelegateWriteProcessMemory));
			}
			return DataRepository.delegateWriteProcessMemory(hProcess, lpBaseAddress, buffer, size, out lpNumberOfBytesWritten);
		}

		// Token: 0x060000F2 RID: 242
		internal static void WriteStream(Stream streamIn, byte[] arrBuffer, int offSet, int count)
		{
			streamIn.Write(arrBuffer, offSet, count);
		}

		// Token: 0x060000B8 RID: 184
		static uint _BitWise01(uint value, ushort modifier)
		{
			return value >> (int)(0x20 - modifier) | value << (int)modifier;
		}

		// Token: 0x060000CB RID: 203
		static Delegate _GetDelegateForFunctionPointer(IntPtr sender, Type args)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[]
			{
				sender,
				args
			});
		}

		// Token: 0x060000B4 RID: 180
		static void _Incrementor01(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07)
		{
			value = input01 + DataRepository._BitWise01(value + ((input01 & input02) | (~input01 & input03)) + input07[(int)((UIntPtr)input04)] + DataRepository.incrementorRef01[(int)((UIntPtr)(input06 - 1U))], input05);
		}

		// Token: 0x060000B6 RID: 182
		static void _Incrementor02(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07)
		{
			value = input01 + DataRepository._BitWise01(value + (input01 ^ input02 ^ input03) + input07[(int)((UIntPtr)input04)] + DataRepository.incrementorRef01[(int)((UIntPtr)(input06 - 1U))], input05);
		}

		// Token: 0x060000B5 RID: 181
		static void _Incrementor03(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07)
		{
			value = input01 + DataRepository._BitWise01(value + ((input01 & input03) | (input02 & ~input03)) + input07[(int)((UIntPtr)input04)] + DataRepository.incrementorRef01[(int)((UIntPtr)(input06 - 1U))], input05);
		}

		// Token: 0x060000B7 RID: 183
		static void _Incrementor04(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07)
		{
			value = input01 + DataRepository._BitWise01(value + (input02 ^ (input01 | ~input03)) + input07[(int)((UIntPtr)input04)] + DataRepository.incrementorRef01[(int)((UIntPtr)(input06 - 1U))], input05);
		}

		// Token: 0x060000E0 RID: 224
		byte[] _ReturnArray01()
		{
			string text = "{11111-22222-30001-00001}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000DE RID: 222
		byte[] _ReturnArray02()
		{
			string text = "{11111-22222-20001-00001}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E3 RID: 227
		internal byte[] _ReturnArray03()
		{
			string text = "{11111-22222-40001-00002}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E2 RID: 226
		internal byte[] _ReturnArray04()
		{
			string text = "{11111-22222-40001-00001}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000DF RID: 223
		byte[] _ReturnArray05()
		{
			string text = "{11111-22222-20001-00002}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E1 RID: 225
		byte[] _ReturnArray06()
		{
			string text = "{11111-22222-30001-00002}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E4 RID: 228
		internal byte[] _ReturnArray07()
		{
			string text = "{11111-22222-50001-00001}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000E5 RID: 229
		internal byte[] _ReturnArray08()
		{
			string text = "{11111-22222-50001-00002}";
			if (text.Length > 0)
			{
				return new byte[]
				{
					1,
					2
				};
			}
			return new byte[]
			{
				1,
				2
			};
		}

		// Token: 0x060000C9 RID: 201
		static int _ReturnFive01()
		{
			return 5;
		}

		// Token: 0x060000DD RID: 221
		byte[] _ReturnNull01()
		{
			return null;
		}

		// Token: 0x060000F7 RID: 247
		internal static object _ReturnNull02()
		{
			return null;
		}

		// Token: 0x060000DC RID: 220
		byte[] _ReturnNull03()
		{
			return null;
		}

		// Token: 0x060000F6 RID: 246
		internal static bool _ReturnTrue01()
		{
			return null == null;
		}

		// Token: 0x060000C3 RID: 195
		static uint _ReturnUint01(uint input)
		{
			return (uint)"{11111-22222-10009-11112}".Length;
		}

		// Token: 0x060000C5 RID: 197
		internal static void _ReturnVoid01()
		{
		}

		// Token: 0x060000B2 RID: 178
		void _ReturnVoid02()
		{
		}

		// Token: 0x060000C4 RID: 196
		static uint _ReturnZero01(uint input)
		{
			return 0U;
		}

		// Token: 0x060000BB RID: 187
		void __rB5OOrvaPT(byte[] arrBuffer01, byte[] unUsed, byte[] arrBuffer02)
		{
			int num = arrBuffer02.Length % 4;
			int num2 = arrBuffer02.Length / 4;
			byte[] array = new byte[arrBuffer02.Length];
			int num3 = arrBuffer01.Length / 4;
			uint num4 = 0U;
			if (num > 0)
			{
				num2++;
			}
			for (int i = 0; i < num2; i++)
			{
				int num5 = i % num3;
				int num6 = i * 4;
				uint num7 = (uint)(num5 * 4);
				uint num8 = (uint)((int)arrBuffer01[(int)((UIntPtr)(num7 + 3U))] << 0x18 | (int)arrBuffer01[(int)((UIntPtr)(num7 + 2U))] << 0x10 | (int)arrBuffer01[(int)((UIntPtr)(num7 + 1U))] << 8 | (int)arrBuffer01[(int)((UIntPtr)num7)]);
				uint num9 = 0xFFU;
				int num10 = 0;
				uint num11;
				if (i == num2 - 1 && num > 0)
				{
					num11 = 0U;
					num4 += num8;
					for (int j = 0; j < num; j++)
					{
						if (j > 0)
						{
							num11 <<= 8;
						}
						num11 |= (uint)arrBuffer02[arrBuffer02.Length - (1 + j)];
					}
				}
				else
				{
					num4 += num8;
					num7 = (uint)num6;
					num11 = (uint)((int)arrBuffer02[(int)((UIntPtr)(num7 + 3U))] << 0x18 | (int)arrBuffer02[(int)((UIntPtr)(num7 + 2U))] << 0x10 | (int)arrBuffer02[(int)((UIntPtr)(num7 + 1U))] << 8 | (int)arrBuffer02[(int)((UIntPtr)num7)]);
				}
				uint num12 = num4;
				uint num13 = num12;
				uint num14 = num12;
				uint num15 = 0x6DB6EF73U;
				uint num16 = 0x3EED935DU;
				uint num17 = 0x41018030U;
				uint num18 = num14;
				uint num19 = 0x4BF04A05U;
				uint num20 = 0x33B5E528U;
				uint num21 = num16 & 0xF0F0F0FU;
				uint num22 = num16 & 0xF0F0F0F0U;
				num21 = (num21 >> 4 | num22 << 4) + num15;
				num16 = (num16 << 6 | num16 >> 0x1A);
				if (num17 == 0.0)
				{
					num17 -= 1U;
				}
				uint num23 = (uint)(num15 / num17 + num17);
				num17 = ((uint)((ushort)num15) - 0x60039FA7U) * num23 + (uint)((ushort)num15);
				num15 = (num16 ^ num16 ^ 0x7F4AF7EU);
				num19 -= num16;
				uint num24 = (num20 >> 0xD | num20 << 0x13) ^ num16;
				uint num25 = num24 & 0xF0F0F0FU;
				num24 &= 0xF0F0F0F0U;
				num20 = (num24 >> 4 | num25 << 4);
				num18 ^= num18 << 0xD;
				num18 += num15;
				num18 ^= num18 << 0x1B;
				num18 += num19;
				num18 ^= num18 >> 3;
				num18 += num20;
				num18 = ((num16 << 0x15) + num19 ^ num15) - num18;
				num12 = num13 + (uint)num18;
				num4 = num12;
				if (i == num2 - 1 && num > 0)
				{
					uint num26 = num4 ^ num11;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num9 <<= 8;
							num10 += 8;
						}
						array[num6 + k] = (byte)((num26 & num9) >> num10);
					}
				}
				else
				{
					uint num27 = num4 ^ num11;
					array[num6] = (byte)(num27 & 0xFFU);
					array[num6 + 1] = (byte)((num27 & 0xFF00U) >> 8);
					array[num6 + 2] = (byte)((num27 & 0xFF0000U) >> 0x10);
					array[num6 + 3] = (byte)((num27 & 0xFF000000U) >> 0x18);
				}
			}
			DataRepository.resourceNameBytes = array;
		}

		// Token: 0x06000135 RID: 309
		internal static byte[] ___GetAssemblyKey(AssemblyName assemblyName)
		{
			return null;
		}

		// Token: 0x06000137 RID: 311
		internal static ICryptoTransform ___GetCryptoTransform(SymmetricAlgorithm symmetricAlgorithm, byte[] rgbKey, byte[] rgbIV)
		{
			return null;
		}

		// Token: 0x060000F4 RID: 244
		internal static byte[] ___MemoryStreamToArray(MemoryStream memoryStreamIn)
		{
			return DataRepository.MemoryStreamToArray(memoryStreamIn);
		}

		// Token: 0x06000159 RID: 345
		internal static void ___WriteStream(Stream streamIn, byte[] arrBuffer, int offSet, int count)
		{
		}

		// Token: 0x06000147 RID: 327
		internal static byte[] ____MemoryStreamToArray(MemoryStream memoryStreamIn)
		{
			return null;
		}
	}
}
