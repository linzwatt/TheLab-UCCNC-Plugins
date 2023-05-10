using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace DataRepositories
{
	// Token: 0x0200003F RID: 63
	public class EncryptionStuff
	{
		// Token: 0x04000937 RID: 2359
		static bool allowOnlyFipsAlgorithms;

		// Token: 0x04000935 RID: 2357
		static bool fipsAlgorithmsChecked;

		// Token: 0x04000940 RID: 2368
		static uint[] incrementorRef01;

		// Token: 0x04000999 RID: 2457
		static string pendantMessageStartConstant;

		// Token: 0x04000973 RID: 2419
		internal static RSACryptoServiceProvider rsaCryptoServiceProvider;

		// Token: 0x060005AE RID: 1454
		public EncryptionStuff()
		{
			EncryptionStuff.incrementorRef01 = new uint[]
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
			EncryptionStuff.fipsAlgorithmsChecked = false;
			EncryptionStuff.allowOnlyFipsAlgorithms = false;
			EncryptionStuff.rsaCryptoServiceProvider = null;
			EncryptionStuff.pendantMessageStartConstant = Encoding.Unicode.GetString(new byte[]
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

		// Token: 0x060005D4 RID: 1492
		internal static byte[] GetInitialisationVector(byte[] arrBuffer)
		{
			if (!EncryptionStuff.GetOnlyFipsAlgorithms())
			{
				return new MD5CryptoServiceProvider().ComputeHash(arrBuffer);
			}
			return EncryptionStuff.GetNonFipsInitialisationVector(arrBuffer);
		}

		// Token: 0x0600079B RID: 1947
		public unsafe static int GetMessageCode(string messageIn)
		{
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

		internal static bool CompareMessages(string message01, string message02) {
			// Early Short Circuits
			if (message01 == message02) { return true; }
			if (message01 == null || message02 == null) { return false; }

			// Work out if the first message is even valid
			bool flag = message01.StartsWith(EncryptionStuff.pendantMessageStartConstant);

			// Get the message code number
			int num = 0;
			if (flag) { num = (int)(message01[4] | (int)message01[5] << 8 | (int)message01[6] << 0x10 | (int)message01[7] << 0x18); }

			// Work out if the second message is even valid
			bool flag2 = message02.StartsWith(EncryptionStuff.pendantMessageStartConstant);

			// Get the message code number
			int num2 = 0;
			if (flag2) { num2 = (int)(message02[4] | (int)message02[5] << 8 | (int)message02[6] << 0x10 | (int)message02[7] << 0x18); }

			// Late short circuit
			if (!flag && !flag2) { return false; }

			// Late Modifications
			if (!flag) { num = EncryptionStuff.GetMessageCode(message01); }
			if (!flag2) { num2 = EncryptionStuff.GetMessageCode(message02); }

			return num == num2;
		}

		// Token: 0x060005CB RID: 1483
		internal static byte[] GetNonFipsInitialisationVector(byte[] arrBuffer) {
			uint[] array = new uint[0x10];
			uint num2 = (uint)((0x1C0 - arrBuffer.Length * 8 % 0x200 + 0x200) % 0x200);
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
			byte[] array4 = array2;
			int num5 = arrBuffer.Length;
			int num18 = num5;
			array4[num18] |= 0x80;
			for (int j = 8; j > 0; j--)
			{
				array2[(int)((IntPtr)(checked((long)(unchecked((ulong)num3 - (ulong)((long)j))))))] = (byte)(num4 >> (8 - j) * 8 & 0xFFUL);
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
				EncryptionStuff._Incrementor01(ref num7, num8, num9, num10, 0U, 7, 1U, array);
				EncryptionStuff._Incrementor01(ref num10, num7, num8, num9, 1U, 0xC, 2U, array);
				EncryptionStuff._Incrementor01(ref num9, num10, num7, num8, 2U, 0x11, 3U, array);
				EncryptionStuff._Incrementor01(ref num8, num9, num10, num7, 3U, 0x16, 4U, array);
				EncryptionStuff._Incrementor01(ref num7, num8, num9, num10, 4U, 7, 5U, array);
				EncryptionStuff._Incrementor01(ref num10, num7, num8, num9, 5U, 0xC, 6U, array);
				EncryptionStuff._Incrementor01(ref num9, num10, num7, num8, 6U, 0x11, 7U, array);
				EncryptionStuff._Incrementor01(ref num8, num9, num10, num7, 7U, 0x16, 8U, array);
				EncryptionStuff._Incrementor01(ref num7, num8, num9, num10, 8U, 7, 9U, array);
				EncryptionStuff._Incrementor01(ref num10, num7, num8, num9, 9U, 0xC, 0xAU, array);
				EncryptionStuff._Incrementor01(ref num9, num10, num7, num8, 0xAU, 0x11, 0xBU, array);
				EncryptionStuff._Incrementor01(ref num8, num9, num10, num7, 0xBU, 0x16, 0xCU, array);
				EncryptionStuff._Incrementor01(ref num7, num8, num9, num10, 0xCU, 7, 0xDU, array);
				EncryptionStuff._Incrementor01(ref num10, num7, num8, num9, 0xDU, 0xC, 0xEU, array);
				EncryptionStuff._Incrementor01(ref num9, num10, num7, num8, 0xEU, 0x11, 0xFU, array);
				EncryptionStuff._Incrementor01(ref num8, num9, num10, num7, 0xFU, 0x16, 0x10U, array);
				EncryptionStuff._Incrementor03(ref num7, num8, num9, num10, 1U, 5, 0x11U, array);
				EncryptionStuff._Incrementor03(ref num10, num7, num8, num9, 6U, 9, 0x12U, array);
				EncryptionStuff._Incrementor03(ref num9, num10, num7, num8, 0xBU, 0xE, 0x13U, array);
				EncryptionStuff._Incrementor03(ref num8, num9, num10, num7, 0U, 0x14, 0x14U, array);
				EncryptionStuff._Incrementor03(ref num7, num8, num9, num10, 5U, 5, 0x15U, array);
				EncryptionStuff._Incrementor03(ref num10, num7, num8, num9, 0xAU, 9, 0x16U, array);
				EncryptionStuff._Incrementor03(ref num9, num10, num7, num8, 0xFU, 0xE, 0x17U, array);
				EncryptionStuff._Incrementor03(ref num8, num9, num10, num7, 4U, 0x14, 0x18U, array);
				EncryptionStuff._Incrementor03(ref num7, num8, num9, num10, 9U, 5, 0x19U, array);
				EncryptionStuff._Incrementor03(ref num10, num7, num8, num9, 0xEU, 9, 0x1AU, array);
				EncryptionStuff._Incrementor03(ref num9, num10, num7, num8, 3U, 0xE, 0x1BU, array);
				EncryptionStuff._Incrementor03(ref num8, num9, num10, num7, 8U, 0x14, 0x1CU, array);
				EncryptionStuff._Incrementor03(ref num7, num8, num9, num10, 0xDU, 5, 0x1DU, array);
				EncryptionStuff._Incrementor03(ref num10, num7, num8, num9, 2U, 9, 0x1EU, array);
				EncryptionStuff._Incrementor03(ref num9, num10, num7, num8, 7U, 0xE, 0x1FU, array);
				EncryptionStuff._Incrementor03(ref num8, num9, num10, num7, 0xCU, 0x14, 0x20U, array);
				EncryptionStuff._Incrementor02(ref num7, num8, num9, num10, 5U, 4, 0x21U, array);
				EncryptionStuff._Incrementor02(ref num10, num7, num8, num9, 8U, 0xB, 0x22U, array);
				EncryptionStuff._Incrementor02(ref num9, num10, num7, num8, 0xBU, 0x10, 0x23U, array);
				EncryptionStuff._Incrementor02(ref num8, num9, num10, num7, 0xEU, 0x17, 0x24U, array);
				EncryptionStuff._Incrementor02(ref num7, num8, num9, num10, 1U, 4, 0x25U, array);
				EncryptionStuff._Incrementor02(ref num10, num7, num8, num9, 4U, 0xB, 0x26U, array);
				EncryptionStuff._Incrementor02(ref num9, num10, num7, num8, 7U, 0x10, 0x27U, array);
				EncryptionStuff._Incrementor02(ref num8, num9, num10, num7, 0xAU, 0x17, 0x28U, array);
				EncryptionStuff._Incrementor02(ref num7, num8, num9, num10, 0xDU, 4, 0x29U, array);
				EncryptionStuff._Incrementor02(ref num10, num7, num8, num9, 0U, 0xB, 0x2AU, array);
				EncryptionStuff._Incrementor02(ref num9, num10, num7, num8, 3U, 0x10, 0x2BU, array);
				EncryptionStuff._Incrementor02(ref num8, num9, num10, num7, 6U, 0x17, 0x2CU, array);
				EncryptionStuff._Incrementor02(ref num7, num8, num9, num10, 9U, 4, 0x2DU, array);
				EncryptionStuff._Incrementor02(ref num10, num7, num8, num9, 0xCU, 0xB, 0x2EU, array);
				EncryptionStuff._Incrementor02(ref num9, num10, num7, num8, 0xFU, 0x10, 0x2FU, array);
				EncryptionStuff._Incrementor02(ref num8, num9, num10, num7, 2U, 0x17, 0x30U, array);
				EncryptionStuff._Incrementor04(ref num7, num8, num9, num10, 0U, 6, 0x31U, array);
				EncryptionStuff._Incrementor04(ref num10, num7, num8, num9, 7U, 0xA, 0x32U, array);
				EncryptionStuff._Incrementor04(ref num9, num10, num7, num8, 0xEU, 0xF, 0x33U, array);
				EncryptionStuff._Incrementor04(ref num8, num9, num10, num7, 5U, 0x15, 0x34U, array);
				EncryptionStuff._Incrementor04(ref num7, num8, num9, num10, 0xCU, 6, 0x35U, array);
				EncryptionStuff._Incrementor04(ref num10, num7, num8, num9, 3U, 0xA, 0x36U, array);
				EncryptionStuff._Incrementor04(ref num9, num10, num7, num8, 0xAU, 0xF, 0x37U, array);
				EncryptionStuff._Incrementor04(ref num8, num9, num10, num7, 1U, 0x15, 0x38U, array);
				EncryptionStuff._Incrementor04(ref num7, num8, num9, num10, 8U, 6, 0x39U, array);
				EncryptionStuff._Incrementor04(ref num10, num7, num8, num9, 0xFU, 0xA, 0x3AU, array);
				EncryptionStuff._Incrementor04(ref num9, num10, num7, num8, 6U, 0xF, 0x3BU, array);
				EncryptionStuff._Incrementor04(ref num8, num9, num10, num7, 0xDU, 0x15, 0x3CU, array);
				EncryptionStuff._Incrementor04(ref num7, num8, num9, num10, 4U, 6, 0x3DU, array);
				EncryptionStuff._Incrementor04(ref num10, num7, num8, num9, 0xBU, 0xA, 0x3EU, array);
				EncryptionStuff._Incrementor04(ref num9, num10, num7, num8, 2U, 0xF, 0x3FU, array);
				EncryptionStuff._Incrementor04(ref num8, num9, num10, num7, 9U, 0x15, 0x40U, array);
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

		// Token: 0x060005B1 RID: 1457
		public static bool GetOnlyFipsAlgorithms()
		{
			if (!EncryptionStuff.fipsAlgorithmsChecked)
			{
				try
				{
					EncryptionStuff.allowOnlyFipsAlgorithms = CryptoConfig.AllowOnlyFipsAlgorithms;
				}
				catch
				{
				}
				EncryptionStuff.fipsAlgorithmsChecked = true;
			}
			return EncryptionStuff.allowOnlyFipsAlgorithms;
		}

		// Token: 0x060005DE RID: 1502
		internal static SymmetricAlgorithm GetSymmetricAlgorithm()
		{
			SymmetricAlgorithm result = null;
			if (EncryptionStuff.GetOnlyFipsAlgorithms())
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

		// Token: 0x0600072F RID: 1839
		internal static int TransformAlgorithm(HashAlgorithm hashAlgorithm, byte[] arrBuffer, int offSet, int count)
		{
			return hashAlgorithm.TransformBlock(arrBuffer, offSet, count, arrBuffer, offSet);
		}

		// Token: 0x060005E9 RID: 1513
		internal static string Write(string message, string initialisationVector)
		{
			byte[] array = Encoding.Unicode.GetBytes(message);
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
			byte[] initialisationVector2 = EncryptionStuff.GetInitialisationVector(Encoding.Unicode.GetBytes(initialisationVector));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = EncryptionStuff.GetSymmetricAlgorithm();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = initialisationVector2;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		// Token: 0x060005B9 RID: 1465
		static uint _BitWise01(uint value, ushort modifier)
		{
			return value >> (int)(0x20 - modifier) | value << (int)modifier;
		}

		// Token: 0x060005C0 RID: 1472
		static void _Incrementor01(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07)
		{
			value = input01 + EncryptionStuff._BitWise01(value + ((input01 & input02) | (~input01 & input03)) + input07[(int)((uint)((UIntPtr)input04))] + EncryptionStuff.incrementorRef01[(int)((uint)((UIntPtr)(input06 - 1U)))], input05);
		}

		// Token: 0x060005C1 RID: 1473
		static void _Incrementor02(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07) {
			value = input01 + EncryptionStuff._BitWise01(value + (input01 ^ input02 ^ input03) + input07[(int)((uint)((UIntPtr)input04))] + EncryptionStuff.incrementorRef01[(int)((uint)((UIntPtr)(input06 - 1U)))], input05);
		}

		// Token: 0x060005C2 RID: 1474
		static void _Incrementor03(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07) {
			value = input01 + EncryptionStuff._BitWise01(value + ((input01 & input03) | (input02 & ~input03)) + input07[(int)((uint)((UIntPtr)input04))] + EncryptionStuff.incrementorRef01[(int)((uint)((UIntPtr)(input06 - 1U)))], input05);
		}

		// Token: 0x060005C3 RID: 1475
		static void _Incrementor04(ref uint value, uint input01, uint input02, uint input03, uint input04, ushort input05, uint input06, uint[] input07) {
			value = input01 + EncryptionStuff._BitWise01(value + (input02 ^ (input01 | ~input03)) + input07[(int)((uint)((UIntPtr)input04))] + EncryptionStuff.incrementorRef01[(int)((uint)((UIntPtr)(input06 - 1U)))], input05);
		}
	}
}
