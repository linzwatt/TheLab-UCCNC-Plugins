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

namespace MfKP42m2oa64TIB4sD0
{
	internal class SGIrQcmgt97uvDTgI6P
	{
		private delegate void O5uUu9QT7RaaAlMf8q7(object o);

		internal class G3ycxdQZ1KT9ALQ8cdt : Attribute
		{
			internal class SxBa0QQ0Ag8jbNOa0fm<m1x0gvQ1qhGqDn8vw8J>
			{
				public SxBa0QQ0Ag8jbNOa0fm() : base() {
					//Discarded unreachable code: IL_0002
					feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
				}
			}

			public G3ycxdQZ1KT9ALQ8cdt(object _0020)
			{
			}//Discarded unreachable code: IL_0002

		}

		internal class VRQJ1nQfyo6y0QXrEYv
		{
			internal static string rCVQMOBPV9(string _0020, string _0020)
			{
				//Discarded unreachable code: IL_0002
				byte[] bytes = Encoding.Unicode.GetBytes(_0020);
				byte[] key = new byte[32]
				{
					82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
					51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
					34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
					1, 88
				};
				byte[] iV = dmvOnxWOYM(Encoding.Unicode.GetBytes(_0020));
				MemoryStream memoryStream = new MemoryStream();
				SymmetricAlgorithm symmetricAlgorithm = ysrOQ64ZP3();
				symmetricAlgorithm.Key = key;
				symmetricAlgorithm.IV = iV;
				CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.Close();
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate uint qmDREFQp83LYtI4yaIG(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr BXZFCBQy0DgGbSSL85F();

		internal struct tRccNmQRO7nnpmyPaO2
		{
			internal bool D3aQ8Y0eVs;

			internal byte[] B2cQhrDuuI;
		}

		internal class KETCsYQ72YqX3GW5QKQ
		{
			private BinaryReader DsqQUEknQW;

			public KETCsYQ72YqX3GW5QKQ(Stream _0020)
			{
				//Discarded unreachable code: IL_0002
				DsqQUEknQW = new BinaryReader(_0020);
			}

			[SpecialName]
			internal Stream NJK0HP6bbE()
			{
				//Discarded unreachable code: IL_0002
				return DsqQUEknQW.BaseStream;
			}

			internal byte[] lObQGdwufS(int _0020)
			{
				//Discarded unreachable code: IL_0002
				return DsqQUEknQW.ReadBytes(_0020);
			}

			internal int TZWQuhpYSe(byte[] _0020, int _0020, int _0020)
			{
				//Discarded unreachable code: IL_0002
				return DsqQUEknQW.Read(_0020, _0020, _0020);
			}

			internal int H1AQcQSsvc()
			{
				//Discarded unreachable code: IL_0002
				return DsqQUEknQW.ReadInt32();
			}

			internal void wjqQCvYxAO()
			{
				//Discarded unreachable code: IL_0002
				DsqQUEknQW.Close();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private delegate IntPtr IvU1JSQljONHqJXASrd(IntPtr hModule, string lpName, uint lpType);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr VDHPPEQrJEEJHyJWjy2(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int mMWuspQDJHFYSiKWR3u(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int kKC8kxQASsrb4c9hsTl(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr eJtwbrQafUbinZ14N0Y(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int mM5ZwWQB59s8kGdMwtQ(IntPtr ptr);

		[Flags]
		private enum InpDWYQvwkCXqYTaEnP
		{

		}

		internal static Assembly tXYOvJ8XOr;

		private static uint[] x65Ot3UIVC;

		private static bool gS1OLmgue5;

		private static bool VK5O94t8E1;

		internal static RSACryptoServiceProvider m8mOo0e3gB;

		private static List<string> Mi5OJ3VjBe;

		private static List<int> tYXOgxcSV9;

		private static object GrdOz8RkRK;

		private static SortedList rIlQOY9wld;

		private static int b8kQQ9dxI9;

		private static long A5VQHGan76;

		private static IntPtr wrcQxpDMN9;

		internal static Hashtable EerQY3Qjti;

		private static mMWuspQDJHFYSiKWR3u bxKQNqnpXa;

		private static kKC8kxQASsrb4c9hsTl kH2QidWK9N;

		private static string DE8QWypLek;

		private static int[] HyAQ54wiD1;

		private static long QF5QFLFrFE;

		internal static qmDREFQp83LYtI4yaIG aXfQnW3Dx6;

		private static object fiYOIullvp;

		private static IntPtr SGsQwmhk6c;

		private static int tjVOVVBTrG;

		private static IvU1JSQljONHqJXASrd gN6QefYQJj;

		private static IntPtr BGRO68o8XQ;

		private static eJtwbrQafUbinZ14N0Y FemQjD8JBJ;

		private static bool lkcQ3ecCFq;

		private static Dictionary<int, int> xxmOkXd00F;

		private static mM5ZwWQB59s8kGdMwtQ HEOQPoaAui;

		private static IntPtr m6ZOXBVv8J;

		private static int IyOQdivZQQ;

		private static bool lT4QmcaY24;

		private static bool vjWOBO9012;

		private static VDHPPEQrJEEJHyJWjy2 ALKQEJHi0K;

		[G3ycxdQZ1KT9ALQ8cdt(typeof(G3ycxdQZ1KT9ALQ8cdt.SxBa0QQ0Ag8jbNOa0fm<object>[]))]
		private static bool fXWQqdVJkf;

		private static int NCKQbbOa53;

		internal static qmDREFQp83LYtI4yaIG TYeQ4lgLQC;

		private static int AwTQSy7LA5;

		private static byte[] NKlO2FpeaA;

		private static byte[] nD0OKHoXUk;

		private static bool OD5Qs0H9XP;

		static SGIrQcmgt97uvDTgI6P()
		{
			vjWOBO9012 = false;
			tXYOvJ8XOr = typeof(SGIrQcmgt97uvDTgI6P).Assembly;
			x65Ot3UIVC = new uint[64]
			{
				3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
				4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
				3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
				1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
				681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
				2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
				4149444226u, 3174756917u, 718787259u, 3951481745u
			};
			gS1OLmgue5 = false;
			VK5O94t8E1 = false;
			m8mOo0e3gB = null;
			xxmOkXd00F = null;
			fiYOIullvp = new object();
			tjVOVVBTrG = 0;
			Mi5OJ3VjBe = null;
			tYXOgxcSV9 = null;
			NKlO2FpeaA = new byte[0];
			nD0OKHoXUk = new byte[0];
			BGRO68o8XQ = IntPtr.Zero;
			m6ZOXBVv8J = IntPtr.Zero;
			GrdOz8RkRK = new string[0];
			HyAQ54wiD1 = new int[0];
			NCKQbbOa53 = 1;
			lT4QmcaY24 = false;
			rIlQOY9wld = new SortedList();
			b8kQQ9dxI9 = 0;
			A5VQHGan76 = 0L;
			aXfQnW3Dx6 = null;
			TYeQ4lgLQC = null;
			QF5QFLFrFE = 0L;
			AwTQSy7LA5 = 0;
			OD5Qs0H9XP = false;
			lkcQ3ecCFq = false;
			IyOQdivZQQ = 0;
			wrcQxpDMN9 = IntPtr.Zero;
			fXWQqdVJkf = false;
			EerQY3Qjti = new Hashtable();
			gN6QefYQJj = null;
			ALKQEJHi0K = null;
			bxKQNqnpXa = null;
			kH2QidWK9N = null;
			FemQjD8JBJ = null;
			HEOQPoaAui = null;
			SGsQwmhk6c = IntPtr.Zero;
			DE8QWypLek = Encoding.Unicode.GetString(new byte[8] { 134, 123, 241, 8, 24, 98, 77, 199 });
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		private void LJrH7u7F5N()
		{
		}

		internal static byte[] EFQmKhLtsA(byte[] _0020)
		{
			uint[] array = new uint[16];
			uint num = (uint)((448 - _0020.Length * 8 % 512 + 512) % 512);
			if (num == 0)
			{
				num = 512u;
			}
			uint num2 = (uint)(_0020.Length + num / 8u + 8);
			ulong num3 = (ulong)_0020.Length * 8uL;
			byte[] array2 = new byte[num2];
			for (int i = 0; i < _0020.Length; i++)
			{
				array2[i] = _0020[i];
			}
			array2[_0020.Length] |= 128;
			for (int num4 = 8; num4 > 0; num4--)
			{
				array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFF);
			}
			uint num5 = (uint)(array2.Length * 8) / 32u;
			uint num6 = 1732584193u;
			uint num7 = 4023233417u;
			uint num8 = 2562383102u;
			uint num9 = 271733878u;
			for (uint num10 = 0u; num10 < num5 / 16u; num10++)
			{
				uint num11 = num10 << 6;
				for (uint num12 = 0u; num12 < 61; num12 += 4)
				{
					array[num12 >> 2] = (uint)((array2[num11 + (num12 + 3)] << 24) | (array2[num11 + (num12 + 2)] << 16) | (array2[num11 + (num12 + 1)] << 8) | array2[num11 + num12]);
				}
				uint num13 = num6;
				uint num14 = num7;
				uint num15 = num8;
				uint num16 = num9;
				ggWm67DrFi(ref num6, num7, num8, num9, 0u, 7, 1u, array);
				ggWm67DrFi(ref num9, num6, num7, num8, 1u, 12, 2u, array);
				ggWm67DrFi(ref num8, num9, num6, num7, 2u, 17, 3u, array);
				ggWm67DrFi(ref num7, num8, num9, num6, 3u, 22, 4u, array);
				ggWm67DrFi(ref num6, num7, num8, num9, 4u, 7, 5u, array);
				ggWm67DrFi(ref num9, num6, num7, num8, 5u, 12, 6u, array);
				ggWm67DrFi(ref num8, num9, num6, num7, 6u, 17, 7u, array);
				ggWm67DrFi(ref num7, num8, num9, num6, 7u, 22, 8u, array);
				ggWm67DrFi(ref num6, num7, num8, num9, 8u, 7, 9u, array);
				ggWm67DrFi(ref num9, num6, num7, num8, 9u, 12, 10u, array);
				ggWm67DrFi(ref num8, num9, num6, num7, 10u, 17, 11u, array);
				ggWm67DrFi(ref num7, num8, num9, num6, 11u, 22, 12u, array);
				ggWm67DrFi(ref num6, num7, num8, num9, 12u, 7, 13u, array);
				ggWm67DrFi(ref num9, num6, num7, num8, 13u, 12, 14u, array);
				ggWm67DrFi(ref num8, num9, num6, num7, 14u, 17, 15u, array);
				ggWm67DrFi(ref num7, num8, num9, num6, 15u, 22, 16u, array);
				owMmXpOLhZ(ref num6, num7, num8, num9, 1u, 5, 17u, array);
				owMmXpOLhZ(ref num9, num6, num7, num8, 6u, 9, 18u, array);
				owMmXpOLhZ(ref num8, num9, num6, num7, 11u, 14, 19u, array);
				owMmXpOLhZ(ref num7, num8, num9, num6, 0u, 20, 20u, array);
				owMmXpOLhZ(ref num6, num7, num8, num9, 5u, 5, 21u, array);
				owMmXpOLhZ(ref num9, num6, num7, num8, 10u, 9, 22u, array);
				owMmXpOLhZ(ref num8, num9, num6, num7, 15u, 14, 23u, array);
				owMmXpOLhZ(ref num7, num8, num9, num6, 4u, 20, 24u, array);
				owMmXpOLhZ(ref num6, num7, num8, num9, 9u, 5, 25u, array);
				owMmXpOLhZ(ref num9, num6, num7, num8, 14u, 9, 26u, array);
				owMmXpOLhZ(ref num8, num9, num6, num7, 3u, 14, 27u, array);
				owMmXpOLhZ(ref num7, num8, num9, num6, 8u, 20, 28u, array);
				owMmXpOLhZ(ref num6, num7, num8, num9, 13u, 5, 29u, array);
				owMmXpOLhZ(ref num9, num6, num7, num8, 2u, 9, 30u, array);
				owMmXpOLhZ(ref num8, num9, num6, num7, 7u, 14, 31u, array);
				owMmXpOLhZ(ref num7, num8, num9, num6, 12u, 20, 32u, array);
				sUHmz04PDk(ref num6, num7, num8, num9, 5u, 4, 33u, array);
				sUHmz04PDk(ref num9, num6, num7, num8, 8u, 11, 34u, array);
				sUHmz04PDk(ref num8, num9, num6, num7, 11u, 16, 35u, array);
				sUHmz04PDk(ref num7, num8, num9, num6, 14u, 23, 36u, array);
				sUHmz04PDk(ref num6, num7, num8, num9, 1u, 4, 37u, array);
				sUHmz04PDk(ref num9, num6, num7, num8, 4u, 11, 38u, array);
				sUHmz04PDk(ref num8, num9, num6, num7, 7u, 16, 39u, array);
				sUHmz04PDk(ref num7, num8, num9, num6, 10u, 23, 40u, array);
				sUHmz04PDk(ref num6, num7, num8, num9, 13u, 4, 41u, array);
				sUHmz04PDk(ref num9, num6, num7, num8, 0u, 11, 42u, array);
				sUHmz04PDk(ref num8, num9, num6, num7, 3u, 16, 43u, array);
				sUHmz04PDk(ref num7, num8, num9, num6, 6u, 23, 44u, array);
				sUHmz04PDk(ref num6, num7, num8, num9, 9u, 4, 45u, array);
				sUHmz04PDk(ref num9, num6, num7, num8, 12u, 11, 46u, array);
				sUHmz04PDk(ref num8, num9, num6, num7, 15u, 16, 47u, array);
				sUHmz04PDk(ref num7, num8, num9, num6, 2u, 23, 48u, array);
				frsO5q8rY2(ref num6, num7, num8, num9, 0u, 6, 49u, array);
				frsO5q8rY2(ref num9, num6, num7, num8, 7u, 10, 50u, array);
				frsO5q8rY2(ref num8, num9, num6, num7, 14u, 15, 51u, array);
				frsO5q8rY2(ref num7, num8, num9, num6, 5u, 21, 52u, array);
				frsO5q8rY2(ref num6, num7, num8, num9, 12u, 6, 53u, array);
				frsO5q8rY2(ref num9, num6, num7, num8, 3u, 10, 54u, array);
				frsO5q8rY2(ref num8, num9, num6, num7, 10u, 15, 55u, array);
				frsO5q8rY2(ref num7, num8, num9, num6, 1u, 21, 56u, array);
				frsO5q8rY2(ref num6, num7, num8, num9, 8u, 6, 57u, array);
				frsO5q8rY2(ref num9, num6, num7, num8, 15u, 10, 58u, array);
				frsO5q8rY2(ref num8, num9, num6, num7, 6u, 15, 59u, array);
				frsO5q8rY2(ref num7, num8, num9, num6, 13u, 21, 60u, array);
				frsO5q8rY2(ref num6, num7, num8, num9, 4u, 6, 61u, array);
				frsO5q8rY2(ref num9, num6, num7, num8, 11u, 10, 62u, array);
				frsO5q8rY2(ref num8, num9, num6, num7, 2u, 15, 63u, array);
				frsO5q8rY2(ref num7, num8, num9, num6, 9u, 21, 64u, array);
				num6 += num13;
				num7 += num14;
				num8 += num15;
				num9 += num16;
			}
			byte[] array3 = new byte[16];
			Array.Copy(BitConverter.GetBytes(num6), 0, array3, 0, 4);
			Array.Copy(BitConverter.GetBytes(num7), 0, array3, 4, 4);
			Array.Copy(BitConverter.GetBytes(num8), 0, array3, 8, 4);
			Array.Copy(BitConverter.GetBytes(num9), 0, array3, 12, 4);
			return array3;
		}

		private static void ggWm67DrFi(ref uint _0020, uint _0020, uint _0020, uint _0020, uint _0020, ushort _0020, uint _0020, uint[] _0020)
		{
			_0020 += b6hObdk8y7(_0020 + ((_0020 & _0020) | (~_0020 & _0020)) + _0020[_0020] + x65Ot3UIVC[_0020 - 1], _0020);
		}

		private static void owMmXpOLhZ(ref uint _0020, uint _0020, uint _0020, uint _0020, uint _0020, ushort _0020, uint _0020, uint[] _0020)
		{
			_0020 += b6hObdk8y7(_0020 + ((_0020 & _0020) | (_0020 & ~_0020)) + _0020[_0020] + x65Ot3UIVC[_0020 - 1], _0020);
		}

		private static void sUHmz04PDk(ref uint _0020, uint _0020, uint _0020, uint _0020, uint _0020, ushort _0020, uint _0020, uint[] _0020)
		{
			_0020 += b6hObdk8y7(_0020 + (_0020 ^ _0020 ^ _0020) + _0020[_0020] + x65Ot3UIVC[_0020 - 1], _0020);
		}

		private static void frsO5q8rY2(ref uint _0020, uint _0020, uint _0020, uint _0020, uint _0020, ushort _0020, uint _0020, uint[] _0020)
		{
			_0020 += b6hObdk8y7(_0020 + (_0020 ^ (_0020 | ~_0020)) + _0020[_0020] + x65Ot3UIVC[_0020 - 1], _0020);
		}

		private static uint b6hObdk8y7(uint _0020, ushort _0020)
		{
			return (_0020 >> 32 - _0020) | (_0020 << (int)_0020);
		}

		internal static bool CTfOmUgBYs()
		{
			if (!gS1OLmgue5)
			{
				hutOHiktTr();
				gS1OLmgue5 = true;
			}
			return VK5O94t8E1;
		}

		internal SGIrQcmgt97uvDTgI6P()
		{
		}

		private void rB5OOrvaPT(byte[] _0020, byte[] _0020, byte[] _0020)
		{
			int num = _0020.Length % 4;
			int num2 = _0020.Length / 4;
			byte[] array = new byte[_0020.Length];
			int num3 = _0020.Length / 4;
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			if (num > 0)
			{
				num2++;
			}
			uint num7 = 0u;
			for (int i = 0; i < num2; i++)
			{
				int num8 = i % num3;
				int num9 = i * 4;
				num7 = (uint)(num8 * 4);
				num5 = (uint)((_0020[num7 + 3] << 24) | (_0020[num7 + 2] << 16) | (_0020[num7 + 1] << 8) | _0020[num7]);
				uint num10 = 255u;
				int num11 = 0;
				if (i == num2 - 1 && num > 0)
				{
					num6 = 0u;
					num4 += num5;
					for (int j = 0; j < num; j++)
					{
						if (j > 0)
						{
							num6 <<= 8;
						}
						num6 |= _0020[_0020.Length - (1 + j)];
					}
				}
				else
				{
					num4 += num5;
					num7 = (uint)num9;
					num6 = (uint)((_0020[num7 + 3] << 24) | (_0020[num7 + 2] << 16) | (_0020[num7 + 1] << 8) | _0020[num7]);
				}
				uint num12 = num4;
				num4 = 0u;
				uint num13 = 1840705395u;
				uint num14 = 1055757149u;
				uint num15 = 1090617392u;
				uint num16 = num12;
				uint num17 = 1274038789u;
				uint num18 = 867558696u;
				uint num19 = (((num14 & 0xF0F0F0F) >> 4) | ((num14 & 0xF0F0F0F0u) << 4)) + num13;
				num14 = (num14 << 6) | (num14 >> 26);
				if ((double)num15 == 0.0)
				{
					num15--;
				}
				num15 = (uint)(((ushort)num13 - 1610850215) * (int)(uint)((double)num13 / (double)num15 + (double)num15) + (ushort)num13);
				num13 = num14 ^ num14 ^ 0x7F4AF7Eu;
				num17 -= num14;
				uint num20 = ((num18 >> 13) | (num18 << 19)) ^ num14;
				num18 = ((num20 & 0xF0F0F0F0u) >> 4) | ((num20 & 0xF0F0F0F) << 4);
				num16 = (num16 ^ (num16 << 13)) + num13;
				num16 = (num16 ^ (num16 << 27)) + num17;
				num4 = num12 + (uint)(double)((((num14 << 21) + num17) ^ num13) - ((num16 ^ (num16 >> 3)) + num18));
				if (i == num2 - 1 && num > 0)
				{
					uint num21 = num4 ^ num6;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num10 <<= 8;
							num11 += 8;
						}
						array[num9 + k] = (byte)((num21 & num10) >> num11);
					}
				}
				else
				{
					uint num22 = num4 ^ num6;
					array[num9] = (byte)(num22 & 0xFFu);
					array[num9 + 1] = (byte)((num22 & 0xFF00) >> 8);
					array[num9 + 2] = (byte)((num22 & 0xFF0000) >> 16);
					array[num9 + 3] = (byte)((num22 & 0xFF000000u) >> 24);
				}
			}
			NKlO2FpeaA = array;
		}

		internal static SymmetricAlgorithm ysrOQ64ZP3()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (CTfOmUgBYs())
			{
				return new AesCryptoServiceProvider();
			}
			try
			{
				return new RijndaelManaged();
			}
			catch
			{
				return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
		}

		internal static void hutOHiktTr()
		{
			try
			{
				VK5O94t8E1 = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		internal static byte[] dmvOnxWOYM(byte[] _0020)
		{
			if (!CTfOmUgBYs())
			{
				return new MD5CryptoServiceProvider().ComputeHash(_0020);
			}
			return EFQmKhLtsA(_0020);
		}

		internal static void rtCO4ntHaf(HashAlgorithm _0020, Stream _0020, uint _0020, byte[] _0020)
		{
			while (_0020 != 0)
			{
				int num = ((_0020 > (uint)_0020.Length) ? _0020.Length : ((int)_0020));
				_0020.Read(_0020, 0, num);
				AgtOFAii1U(_0020, _0020, 0, num);
				_0020 -= (uint)num;
			}
		}

		internal static void AgtOFAii1U(HashAlgorithm _0020, byte[] _0020, int _0020, int _0020)
		{
			_0020.TransformBlock(_0020, _0020, _0020, _0020, _0020);
		}

		internal static uint djYOSWDTg4(uint _0020, int _0020, long _0020, BinaryReader _0020)
		{
			for (int i = 0; i < _0020; i++)
			{
				_0020.BaseStream.Position = _0020 + (i * 40 + 8);
				uint num = _0020.ReadUInt32();
				uint num2 = _0020.ReadUInt32();
				_0020.ReadUInt32();
				uint num3 = _0020.ReadUInt32();
				if (num2 <= _0020 && _0020 < num2 + num)
				{
					return num3 + _0020 - num2;
				}
			}
			return 0u;
		}

		public static void D29OsexGGH(RuntimeTypeHandle _0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(_0020);
				if (xxmOkXd00F == null)
				{
					lock (fiYOIullvp)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(SGIrQcmgt97uvDTgI6P).Assembly.GetManifestResourceStream("mWQc273Qn08NsHVFXQ.CbAK6EdZ9Hptaso6Je"));
						binaryReader.BaseStream.Position = 0L;
						byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						binaryReader.Close();
						if (array.Length > 0)
						{
							int num = array.Length % 4;
							int num2 = array.Length / 4;
							byte[] array2 = new byte[array.Length];
							uint num3 = 0u;
							uint num4 = 0u;
							if (num > 0)
							{
								num2++;
							}
							uint num5 = 0u;
							for (int i = 0; i < num2; i++)
							{
								int num6 = i * 4;
								uint num7 = 255u;
								int num8 = 0;
								if (i == num2 - 1 && num > 0)
								{
									num4 = 0u;
									for (int j = 0; j < num; j++)
									{
										if (j > 0)
										{
											num4 <<= 8;
										}
										num4 |= array[array.Length - (1 + j)];
									}
								}
								else
								{
									num5 = (uint)num6;
									num4 = (uint)((array[num5 + 3] << 24) | (array[num5 + 2] << 16) | (array[num5 + 1] << 8) | array[num5]);
								}
								num3 = num3;
								num3 += mL7OxV9Hi3(num3);
								if (i == num2 - 1 && num > 0)
								{
									uint num9 = num3 ^ num4;
									for (int k = 0; k < num; k++)
									{
										if (k > 0)
										{
											num7 <<= 8;
											num8 += 8;
										}
										array2[num6 + k] = (byte)((num9 & num7) >> num8);
									}
								}
								else
								{
									uint num10 = num3 ^ num4;
									array2[num6] = (byte)(num10 & 0xFFu);
									array2[num6 + 1] = (byte)((num10 & 0xFF00) >> 8);
									array2[num6 + 2] = (byte)((num10 & 0xFF0000) >> 16);
									array2[num6 + 3] = (byte)((num10 & 0xFF000000u) >> 24);
								}
							}
							array = array2;
							array2 = null;
							int num11 = array.Length / 8;
							KETCsYQ72YqX3GW5QKQ kETCsYQ72YqX3GW5QKQ = new KETCsYQ72YqX3GW5QKQ(new MemoryStream(array));
							for (int l = 0; l < num11; l++)
							{
								dictionary.Add(kETCsYQ72YqX3GW5QKQ.H1AQcQSsvc(), kETCsYQ72YqX3GW5QKQ.H1AQcQSsvc());
							}
							kETCsYQ72YqX3GW5QKQ.wjqQCvYxAO();
						}
						xxmOkXd00F = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				foreach (FieldInfo fieldInfo in fields)
				{
					int metadataToken = fieldInfo.MetadataToken;
					int num12 = xxmOkXd00F[metadataToken];
					bool flag = (num12 & 0x40000000) > 0;
					MethodInfo methodInfo = (MethodInfo)typeof(SGIrQcmgt97uvDTgI6P).Module.ResolveMethod(num12 & 0x3FFFFFFF, typeFromHandle.GetGenericArguments(), new Type[0]);
					if (methodInfo.IsStatic)
					{
						fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						continue;
					}
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
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, skipVisibility: true);
					ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
					for (int num14 = 0; num14 < num13; num14++)
					{
						switch (num14)
						{
						case 0:
							iLGenerator.Emit(OpCodes.Ldarg_0);
							break;
						case 1:
							iLGenerator.Emit(OpCodes.Ldarg_1);
							break;
						case 2:
							iLGenerator.Emit(OpCodes.Ldarg_2);
							break;
						case 3:
							iLGenerator.Emit(OpCodes.Ldarg_3);
							break;
						default:
							iLGenerator.Emit(OpCodes.Ldarg_S, num14);
							break;
						}
					}
					iLGenerator.Emit(OpCodes.Tailcall);
					iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
					iLGenerator.Emit(OpCodes.Ret);
					fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
				}
			}
			catch (Exception)
			{
			}
		}

		private static uint G75OdVlZ68(uint _0020)
		{
			return (uint)"{11111-22222-10009-11112}".Length;
		}

		private static uint mL7OxV9Hi3(uint _0020)
		{
			return 0u;
		}

		internal static void aC7OqK8GmE()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void xkiOYNQ5g9(Stream _0020, int _0020)
		{
			//Discarded unreachable code: IL_214f, IL_215e
			int num = 125;
			byte[] array = default(byte[]);
			int num3 = default(int);
			byte[] array2 = default(byte[]);
			CryptoStream cryptoStream = default(CryptoStream);
			byte[] array3 = default(byte[]);
			int num4 = default(int);
			SymmetricAlgorithm symmetricAlgorithm = default(SymmetricAlgorithm);
			Stream stream = default(Stream);
			byte[] array4 = default(byte[]);
			byte[] array5 = default(byte[]);
			int num5 = default(int);
			ICryptoTransform transform = default(ICryptoTransform);
			byte[] array6 = default(byte[]);
			KETCsYQ72YqX3GW5QKQ kETCsYQ72YqX3GW5QKQ = default(KETCsYQ72YqX3GW5QKQ);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 355:
						array[22] = (byte)num3;
						num2 = 50;
						continue;
					case 136:
						array2[5] = 129;
						num2 = 198;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 200:
						num3 = 45 + 25;
						num2 = 163;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 259:
						array2[3] = 134;
						num = 96;
						break;
					case 358:
						array2[13] = 30;
						num2 = 287;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 196:
						array2[7] = 143;
						num2 = 272;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 16;
						}
						continue;
					case 105:
						YZlkBkHpyFs2gYZAATf(cryptoStream, array3, 0, array3.Length);
						num2 = 191;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 366;
						}
						continue;
					case 5:
						array[22] = 138;
						num2 = 185;
						continue;
					case 225:
						num3 = 203 - 67;
						num2 = 79;
						continue;
					case 38:
						num3 = 158 + 83;
						num2 = 128;
						continue;
					case 235:
						num3 = 120 + 118;
						num2 = 42;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 7:
						array[14] = (byte)num3;
						num2 = 285;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 277:
						num4 = 126 + 59;
						num2 = 112;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 6;
						}
						continue;
					case 89:
						array2[7] = 72;
						num = 181;
						break;
					case 36:
						num3 = 138 - 46;
						num2 = 355;
						continue;
					case 341:
						array[27] = 35;
						num2 = 66;
						continue;
					case 35:
						array[12] = (byte)num3;
						num2 = 219;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 296:
						symmetricAlgorithm = (SymmetricAlgorithm)Q7C38HH0BLLj18uhZHF();
						num2 = 331;
						continue;
					case 48:
						array2[4] = (byte)num4;
						num2 = 343;
						continue;
					case 93:
						array2[3] = (byte)num4;
						num2 = 297;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 62:
						num3 = 15 + 92;
						num2 = 103;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 201:
						array[6] = 129;
						num2 = 172;
						continue;
					case 77:
						array[19] = (byte)num3;
						num2 = 235;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 61:
						array[17] = 142;
						num2 = 2;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 175;
						}
						continue;
					case 27:
						array[18] = (byte)num3;
						num2 = 180;
						continue;
					case 182:
						array[13] = 116;
						num2 = 37;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 243;
						}
						continue;
					case 312:
						num4 = 171 - 57;
						num = 348;
						break;
					case 29:
						num3 = 182 + 45;
						num2 = 240;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 51:
						num4 = 13 - 2;
						num2 = 319;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 46:
						num4 = 235 - 78;
						num2 = 328;
						continue;
					case 362:
						array[18] = 134;
						num2 = 64;
						continue;
					case 63:
						array[31] = 168;
						num2 = 148;
						continue;
					case 22:
						array2[13] = (byte)num4;
						num2 = 271;
						continue;
					case 173:
						array[4] = 96;
						num2 = 170;
						continue;
					case 115:
						array2 = new byte[16];
						num2 = 111;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 56:
						num4 = 107 + 96;
						num2 = 142;
						continue;
					case 102:
						array[3] = 137;
						num2 = 335;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 183:
						num4 = 102 + 70;
						num2 = 184;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 294;
						}
						continue;
					case 163:
						array[29] = (byte)num3;
						num2 = 336;
						continue;
					case 174:
						array[9] = 138;
						num2 = 167;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 216:
						array2[12] = 84;
						num2 = 247;
						continue;
					case 6:
						array[10] = 35;
						num2 = 238;
						continue;
					case 131:
						array2[2] = (byte)num4;
						num2 = 352;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 254;
						}
						continue;
					case 319:
						array2[15] = (byte)num4;
						num2 = 239;
						continue;
					case 110:
						array2[5] = (byte)num4;
						num2 = 340;
						continue;
					case 292:
						array[22] = (byte)num3;
						num2 = 109;
						continue;
					case 30:
						num3 = 237 - 79;
						num2 = 228;
						continue;
					case 247:
						array2[12] = 141;
						num2 = 305;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 226:
						num4 = 24 + 96;
						num2 = 100;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 332;
						}
						continue;
					case 21:
						num3 = 114 + 53;
						num2 = 73;
						continue;
					case 345:
						array[7] = 140;
						num2 = 195;
						continue;
					case 213:
						array[24] = (byte)num3;
						num2 = 263;
						continue;
					case 114:
						num3 = 69 + 47;
						num2 = 65;
						continue;
					case 354:
						array2[9] = 213;
						num2 = 123;
						continue;
					case 150:
						array[28] = (byte)num3;
						num2 = 85;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 54;
						}
						continue;
					case 47:
						array[9] = (byte)num3;
						num2 = 252;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 244;
						}
						continue;
					case 151:
						array[23] = 85;
						num2 = 299;
						continue;
					case 332:
						array2[7] = (byte)num4;
						num2 = 196;
						continue;
					case 347:
						array[4] = (byte)num3;
						num2 = 173;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 248:
						array2[7] = (byte)num4;
						num2 = 89;
						continue;
					case 274:
						array2[10] = 99;
						num2 = 257;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 280:
						array[31] = (byte)num3;
						num2 = 63;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 97:
						array[30] = (byte)num3;
						num = 330;
						break;
					case 49:
						array[15] = (byte)num3;
						num2 = 119;
						continue;
					case 137:
						array2[4] = 10;
						num2 = 75;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 194;
						}
						continue;
					case 249:
						array[5] = 124;
						num2 = 78;
						continue;
					case 186:
						array[3] = 142;
						num2 = 158;
						continue;
					case 297:
						num4 = 188 - 62;
						num2 = 48;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 284:
						array2[15] = 168;
						num2 = 222;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 187;
						}
						continue;
					case 246:
						array2[6] = 183;
						num2 = 322;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 286:
						array[21] = 242;
						num2 = 5;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 310:
						array2[1] = (byte)num4;
						num2 = 11;
						continue;
					case 103:
						array[1] = (byte)num3;
						num2 = 321;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 283:
						num3 = 2 + 26;
						num = 133;
						break;
					case 99:
						array[31] = 75;
						num2 = 90;
						continue;
					case 194:
						num4 = 59 + 21;
						num2 = 193;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 349;
						}
						continue;
					case 325:
						array2[3] = (byte)num4;
						num2 = 259;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 98:
						num3 = 124 - 94;
						num = 206;
						break;
					case 251:
						array[24] = (byte)num3;
						num2 = 52;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 83;
						}
						continue;
					case 363:
						array[2] = 77;
						num = 106;
						break;
					case 167:
						num3 = 74 + 28;
						num2 = 266;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 103;
						}
						continue;
					case 9:
						array[24] = (byte)num3;
						num2 = 276;
						continue;
					case 351:
						array[29] = (byte)num3;
						num2 = 342;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 152:
						msbD3eH8q4l5dR2D8Ud(stream);
						num = 318;
						break;
					case 350:
						array[8] = (byte)num3;
						num2 = 1;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 0;
						}
						continue;
					case 127:
						array[12] = (byte)num3;
						num2 = 182;
						continue;
					case 10:
						array4[5] = array5[2];
						num2 = 244;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 156;
						}
						continue;
					case 71:
						array[20] = 30;
						num2 = 34;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 336:
						num3 = 7 + 62;
						num2 = 351;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 55;
						}
						continue;
					case 261:
						array[10] = 97;
						num2 = 326;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 322:
						array2[6] = 140;
						num2 = 17;
						continue;
					case 279:
						num3 = 223 - 74;
						num2 = 116;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 330:
						array[30] = 148;
						num2 = 92;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 83;
						}
						continue;
					case 169:
						array2[3] = 132;
						num2 = 154;
						continue;
					case 2:
						array2[8] = (byte)num4;
						num2 = 100;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 75:
						if (array5 != null)
						{
							num2 = 52;
							continue;
						}
						goto case 157;
					case 257:
						num4 = 152 - 73;
						num2 = 0;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 0;
						}
						continue;
					case 302:
						array[26] = (byte)num3;
						num2 = 279;
						continue;
					case 154:
						array2[3] = 62;
						num2 = 46;
						continue;
					case 357:
						array[30] = (byte)num3;
						num2 = 28;
						continue;
					case 1:
						num3 = 156 - 116;
						num2 = 68;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 193:
						num4 = 130 + 48;
						num = 16;
						break;
					case 218:
						array2[14] = (byte)num4;
						num2 = 43;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 15:
						num3 = 123 - 76;
						num2 = 79;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 199;
						}
						continue;
					case 245:
						array[6] = (byte)num3;
						num2 = 147;
						continue;
					case 349:
						array2[5] = (byte)num4;
						num2 = 178;
						continue;
					case 72:
						array4[1] = array5[0];
						num2 = 47;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 67;
						}
						continue;
					case 117:
						array[9] = (byte)num3;
						num2 = 291;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 210;
						}
						continue;
					case 215:
						array[14] = 167;
						num2 = 265;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 210:
						array2[11] = (byte)num4;
						num2 = 269;
						continue;
					case 272:
						num4 = 118 + 63;
						num2 = 248;
						continue;
					case 123:
						num4 = 18 + 17;
						num2 = 4;
						continue;
					case 65:
						array[12] = (byte)num3;
						num2 = 127;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 138;
						}
						continue;
					case 309:
						array[4] = (byte)num3;
						num2 = 30;
						continue;
					case 28:
						array[30] = 203;
						num2 = 227;
						continue;
					case 175:
						array[17] = 62;
						num2 = 255;
						continue;
					case 189:
						array[3] = (byte)num3;
						num2 = 234;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 74:
						array2[6] = (byte)num4;
						num2 = 86;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 63;
						}
						continue;
					case 40:
						num3 = 88 + 22;
						num2 = 231;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 177:
						num3 = 90 - 6;
						num2 = 91;
						continue;
					case 356:
						array2[1] = (byte)num4;
						num2 = 346;
						continue;
					case 348:
						array2[10] = (byte)num4;
						num2 = 317;
						continue;
					case 130:
						array2[0] = (byte)num4;
						num2 = 230;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 129:
						array[26] = 102;
						num2 = 31;
						continue;
					case 3:
						array[22] = (byte)num3;
						num2 = 20;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 198:
						num4 = 52 + 112;
						num2 = 74;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 134;
						}
						continue;
					case 122:
						array[8] = 150;
						num2 = 316;
						continue;
					case 153:
						array[11] = 60;
						num2 = 53;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 43;
						}
						continue;
					case 238:
						array[10] = 121;
						num2 = 261;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 293:
						array[6] = (byte)num3;
						num2 = 156;
						continue;
					case 250:
						num3 = 224 - 74;
						num2 = 347;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 311:
						array[1] = 194;
						num2 = 281;
						continue;
					case 104:
						array2[0] = (byte)num4;
						num2 = 277;
						continue;
					case 8:
						num3 = 138 - 26;
						num2 = 337;
						continue;
					case 101:
						array[29] = 17;
						num2 = 120;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 119:
						num3 = 236 - 78;
						num2 = 260;
						continue;
					case 276:
						num3 = 100 + 58;
						num2 = 157;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 213;
						}
						continue;
					case 13:
						num3 = 7 + 94;
						num2 = 168;
						continue;
					case 20:
						array[22] = 154;
						num2 = 203;
						continue;
					case 266:
						array[9] = (byte)num3;
						num2 = 197;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 160:
						array[20] = 196;
						num2 = 71;
						continue;
					case 221:
						array2[9] = 101;
						num2 = 323;
						continue;
					case 344:
						num3 = 23 + 115;
						num2 = 189;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 318:
						msbD3eH8q4l5dR2D8Ud(cryptoStream);
						num2 = 82;
						continue;
					case 41:
						array[27] = 123;
						num2 = 15;
						continue;
					case 25:
						array[21] = 111;
						num2 = 290;
						continue;
					case 181:
						array2[8] = 155;
						num2 = 162;
						continue;
					case 203:
						num3 = 106 + 34;
						num = 333;
						break;
					case 253:
						array[15] = 118;
						num2 = 283;
						continue;
					case 326:
						array[11] = 108;
						num2 = 188;
						continue;
					case 26:
						array[29] = (byte)num3;
						num2 = 101;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 15;
						}
						continue;
					case 42:
						array[19] = (byte)num3;
						num2 = 94;
						continue;
					case 338:
						array[3] = (byte)num3;
						num2 = 250;
						continue;
					case 118:
						num3 = 118 + 63;
						num2 = 350;
						continue;
					case 100:
						num4 = 161 - 49;
						num2 = 140;
						continue;
					case 314:
						array2[15] = 110;
						num2 = 31;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 284;
						}
						continue;
					case 206:
						array[7] = (byte)num3;
						num2 = 122;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 94:
						array[19] = 113;
						num2 = 8;
						continue;
					case 287:
						num4 = 22 + 43;
						num2 = 218;
						continue;
					case 205:
						num3 = 198 - 66;
						num2 = 117;
						continue;
					case 83:
						num3 = 104 + 36;
						num2 = 18;
						continue;
					case 334:
						array[9] = (byte)num3;
						num2 = 174;
						continue;
					case 244:
						array4[7] = array5[3];
						num = 159;
						break;
					case 331:
						EZZ9XkH1FjeLvNgjCkl(symmetricAlgorithm, CipherMode.CBC);
						num2 = 267;
						continue;
					case 232:
						array[25] = (byte)num3;
						num2 = 129;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 268:
						return;
					case 113:
						num3 = 170 + 15;
						num2 = 232;
						continue;
					case 88:
					case 212:
						if (num5 >= array4.Length)
						{
							num2 = 23;
							if (OgZfGjHeBVJMcB5pW2N())
							{
								continue;
							}
							break;
						}
						goto case 70;
					case 82:
						array3 = NKlO2FpeaA;
						num2 = 275;
						continue;
					case 146:
						array2[2] = (byte)num4;
						num2 = 169;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 343:
						num4 = 129 - 43;
						num2 = 190;
						continue;
					case 106:
						num3 = 48 + 11;
						num2 = 19;
						continue;
					case 267:
						transform = (ICryptoTransform)vR06PWHfY7l9ek95Qx0(symmetricAlgorithm, array6, array4);
						num2 = 139;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 258;
						}
						continue;
					case 269:
						array2[11] = 119;
						num2 = 72;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 187;
						}
						continue;
					case 79:
						array[28] = (byte)num3;
						num2 = 298;
						continue;
					case 141:
						array3 = (byte[])fGI9NwHPZWbKIQqPquB(kETCsYQ72YqX3GW5QKQ, (int)bq9XDFHjGyveRVl5mkY(AOO50XHNpe35nMwRImc(kETCsYQ72YqX3GW5QKQ)));
						num2 = 209;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 329;
						}
						continue;
					case 121:
						num3 = 244 - 81;
						num2 = 9;
						continue;
					case 192:
						array[20] = (byte)num3;
						num2 = 13;
						continue;
					case 116:
						array[27] = (byte)num3;
						num2 = 47;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 341;
						}
						continue;
					case 323:
						array2[9] = 135;
						num2 = 183;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 135;
						}
						continue;
					case 170:
						num3 = 123 + 28;
						num2 = 309;
						continue;
					default:
						array2[10] = (byte)num4;
						num = 145;
						break;
					case 295:
						num3 = 15 + 106;
						num2 = 301;
						continue;
					case 321:
						num3 = 149 + 24;
						num2 = 365;
						continue;
					case 190:
						array2[4] = (byte)num4;
						num2 = 137;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 168:
						array[20] = (byte)num3;
						num2 = 160;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 208:
						num3 = 10 + 119;
						num2 = 15;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 97;
						}
						continue;
					case 60:
						num3 = 84 + 83;
						num2 = 242;
						continue;
					case 139:
						num3 = 118 + 30;
						num2 = 33;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 301:
						array[26] = (byte)num3;
						num2 = 206;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 254;
						}
						continue;
					case 4:
						array2[10] = (byte)num4;
						num2 = 312;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 254:
						num3 = 176 + 71;
						num2 = 302;
						continue;
					case 184:
						array[16] = 101;
						num = 320;
						break;
					case 149:
						num3 = 238 - 79;
						num2 = 49;
						continue;
					case 282:
						array[13] = (byte)num3;
						num2 = 69;
						continue;
					case 316:
						array[8] = 143;
						num2 = 118;
						continue;
					case 241:
						array2[13] = 137;
						num2 = 44;
						continue;
					case 335:
						num3 = 195 - 65;
						num2 = 58;
						continue;
					case 281:
						array[1] = 121;
						num2 = 62;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 53:
						num3 = 128 - 42;
						num2 = 171;
						continue;
					case 111:
						num4 = 141 - 47;
						num2 = 130;
						continue;
					case 125:
						kETCsYQ72YqX3GW5QKQ = new KETCsYQ72YqX3GW5QKQ(_0020);
						num2 = 124;
						continue;
					case 34:
						num3 = 72 + 100;
						num2 = 143;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 185:
						num3 = 41 + 86;
						num2 = 3;
						continue;
					case 91:
						array[16] = (byte)num3;
						num = 61;
						break;
					case 270:
						array2[11] = (byte)num4;
						num2 = 315;
						continue;
					case 328:
						array2[3] = (byte)num4;
						num2 = 214;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 299:
						num3 = 2 + 58;
						num2 = 251;
						continue;
					case 73:
						array[0] = (byte)num3;
						num2 = 311;
						continue;
					case 133:
						array[16] = (byte)num3;
						num2 = 184;
						continue;
					case 329:
						LR8XJTHwSWPHqbbYBrf(kETCsYQ72YqX3GW5QKQ);
						num2 = 164;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 327:
						array4[15] = array5[7];
						num2 = 157;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 54:
						num3 = 88 + 38;
						num2 = 144;
						continue;
					case 303:
						num4 = 138 - 17;
						num2 = 146;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 44;
						}
						continue;
					case 300:
						array2[7] = 83;
						num2 = 226;
						continue;
					case 278:
						array[18] = (byte)num3;
						num2 = 57;
						continue;
					case 59:
						array2[15] = (byte)num4;
						num2 = 56;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 275:
						new SGIrQcmgt97uvDTgI6P().rB5OOrvaPT(array6, array4, array3);
						num2 = 268;
						continue;
					case 317:
						array2[10] = 58;
						num = 274;
						break;
					case 180:
						array[18] = 135;
						num2 = 60;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 15;
						}
						continue;
					case 33:
						array[28] = (byte)num3;
						num2 = 200;
						continue;
					case 222:
						num4 = 6 + 108;
						num2 = 59;
						continue;
					case 165:
						num5++;
						num2 = 145;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 212;
						}
						continue;
					case 159:
						array4[9] = array5[4];
						num2 = 211;
						continue;
					case 294:
						array2[9] = (byte)num4;
						num2 = 354;
						continue;
					case 138:
						array[12] = 81;
						num2 = 84;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 195:
						num3 = 79 + 23;
						num2 = 308;
						continue;
					case 229:
						array[26] = (byte)num3;
						num = 155;
						break;
					case 360:
						num3 = 74 + 108;
						num2 = 176;
						continue;
					case 57:
						num3 = 80 + 80;
						num2 = 27;
						continue;
					case 37:
						array[31] = 43;
						num2 = 364;
						continue;
					case 134:
						array2[5] = (byte)num4;
						num2 = 32;
						continue;
					case 64:
						num3 = 185 - 61;
						num2 = 278;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 30;
						}
						continue;
					case 16:
						array2[1] = (byte)num4;
						num2 = 14;
						continue;
					case 313:
						num4 = 150 - 50;
						num2 = 310;
						continue;
					case 158:
						array[3] = 94;
						num2 = 102;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 224:
						array[23] = 156;
						num2 = 151;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 359:
						num3 = 38 + 66;
						num2 = 192;
						continue;
					case 67:
						array4[3] = array5[1];
						num2 = 10;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 5;
						}
						continue;
					case 157:
						num5 = 0;
						num = 88;
						break;
					case 288:
						array[18] = 115;
						num2 = 362;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 140:
						array2[8] = (byte)num4;
						num2 = 221;
						continue;
					case 86:
						array2[6] = 122;
						num = 246;
						break;
					case 78:
						array[5] = 102;
						num2 = 36;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 55;
						}
						continue;
					case 346:
						num4 = 221 - 73;
						num2 = 95;
						continue;
					case 155:
						num3 = 101 + 2;
						num2 = 204;
						continue;
					case 14:
						num4 = 177 - 59;
						num = 161;
						break;
					case 202:
						num4 = 132 - 44;
						num2 = 270;
						continue;
					case 197:
						array[9] = 144;
						num2 = 223;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 216;
						}
						continue;
					case 109:
						array[23] = 112;
						num2 = 224;
						continue;
					case 52:
						if (array5.Length > 0)
						{
							num2 = 72;
							continue;
						}
						goto case 157;
					case 19:
						array[2] = (byte)num3;
						num = 24;
						break;
					case 128:
						array[24] = (byte)num3;
						num2 = 54;
						continue;
					case 80:
						num4 = 164 - 54;
						num2 = 205;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 356;
						}
						continue;
					case 239:
						array4 = array2;
						num = 107;
						break;
					case 58:
						array[3] = (byte)num3;
						num2 = 344;
						continue;
					case 342:
						num3 = 129 - 43;
						num2 = 26;
						continue;
					case 207:
						num4 = 137 - 45;
						num2 = 89;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 353;
						}
						continue;
					case 228:
						array[5] = (byte)num3;
						num2 = 273;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 189;
						}
						continue;
					case 262:
						array5 = (byte[])XbFF2aHZy2BRgQyN7jC(O8AWMXHT4JyyvFEQ1a1(tXYOvJ8XOr));
						num2 = 75;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 74;
						}
						continue;
					case 44:
						num4 = 193 - 64;
						num2 = 22;
						continue;
					case 188:
						num3 = 190 - 63;
						num2 = 209;
						continue;
					case 43:
						array2[14] = 112;
						num2 = 233;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 290:
						array[21] = 164;
						num2 = 286;
						continue;
					case 156:
						array[7] = 199;
						num2 = 10;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 306;
						}
						continue;
					case 92:
						num3 = 162 - 54;
						num2 = 357;
						continue;
					case 143:
						array[21] = (byte)num3;
						num2 = 25;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 87:
						NKlO2FpeaA = (byte[])mF6bhMHR7oVI0uYQrZk(stream);
						num2 = 152;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 97;
						}
						continue;
					case 204:
						array[26] = (byte)num3;
						num2 = 295;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 81:
						array2[12] = 141;
						num2 = 216;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 61;
						}
						continue;
					case 12:
						num3 = 80 + 100;
						num2 = 35;
						continue;
					case 361:
						array[0] = 88;
						num2 = 108;
						continue;
					case 209:
						array[11] = (byte)num3;
						num = 153;
						break;
					case 353:
						array2[11] = (byte)num4;
						num2 = 202;
						continue;
					case 230:
						array2[0] = 126;
						num = 339;
						break;
					case 231:
						array[14] = (byte)num3;
						num2 = 215;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 298:
						num3 = 22 + 72;
						num2 = 150;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 236:
						array2[6] = (byte)num4;
						num2 = 300;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 39:
						cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
						num2 = 93;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 105;
						}
						continue;
					case 96:
						num4 = 70 + 87;
						num2 = 93;
						continue;
					case 220:
						num3 = 87 + 61;
						num2 = 71;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 282;
						}
						continue;
					case 308:
						array[7] = (byte)num3;
						num2 = 98;
						continue;
					case 24:
						num3 = 190 + 40;
						num2 = 166;
						continue;
					case 263:
						array[24] = 192;
						num2 = 38;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 315:
						num4 = 108 + 32;
						num2 = 210;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 273:
						array[5] = 126;
						num2 = 249;
						continue;
					case 76:
						num3 = 52 + 75;
						num2 = 132;
						continue;
					case 166:
						array[2] = (byte)num3;
						num2 = 186;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 324:
						array4[13] = array5[6];
						num2 = 327;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 71;
						}
						continue;
					case 364:
						array6 = array;
						num2 = 115;
						continue;
					case 17:
						num4 = 79 + 47;
						num2 = 236;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 264:
						num4 = 242 - 80;
						num2 = 2;
						continue;
					case 70:
						array6[num5] = (byte)(array6[num5] ^ array4[num5]);
						num2 = 165;
						continue;
					case 305:
						num4 = 90 - 35;
						num2 = 45;
						continue;
					case 45:
						array2[12] = (byte)num4;
						num2 = 155;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 241;
						}
						continue;
					case 69:
						array[14] = 241;
						num2 = 40;
						continue;
					case 18:
						array[24] = (byte)num3;
						num2 = 121;
						continue;
					case 90:
						num3 = 147 - 49;
						num2 = 280;
						continue;
					case 289:
						num3 = 97 - 35;
						num2 = 293;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 161:
						array2[2] = (byte)num4;
						num = 237;
						break;
					case 256:
						array2[13] = 169;
						num2 = 358;
						continue;
					case 243:
						array[13] = 163;
						num2 = 98;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 220;
						}
						continue;
					case 162:
						array2[8] = 90;
						num2 = 264;
						continue;
					case 23:
						if (_0020 == -1)
						{
							num2 = 296;
							continue;
						}
						goto case 275;
					case 223:
						array[10] = 108;
						num2 = 6;
						continue;
					case 142:
						array2[15] = (byte)num4;
						num2 = 51;
						continue;
					case 291:
						num3 = 134 - 44;
						num2 = 47;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 234:
						num3 = 155 - 62;
						num2 = 338;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 145:
						array2[11] = 43;
						num2 = 207;
						continue;
					case 124:
						GWDVZvHiOSyHsNiDdT6(AOO50XHNpe35nMwRImc(kETCsYQ72YqX3GW5QKQ), 0L);
						num2 = 141;
						continue;
					case 32:
						num4 = 111 + 90;
						num2 = 110;
						continue;
					case 179:
						array2[1] = 122;
						num2 = 80;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 132:
						array[17] = (byte)num3;
						num2 = 150;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 288;
						}
						continue;
					case 112:
						array2[0] = (byte)num4;
						num2 = 179;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 340:
						num4 = 229 - 76;
						num2 = 74;
						continue;
					case 144:
						array[25] = (byte)num3;
						num2 = 191;
						continue;
					case 199:
						array[27] = (byte)num3;
						num2 = 135;
						continue;
					case 214:
						num4 = 198 - 66;
						num2 = 325;
						continue;
					case 84:
						num3 = 135 + 108;
						num2 = 127;
						continue;
					case 126:
						num3 = 94 + 83;
						num = 7;
						break;
					case 135:
						array[28] = 119;
						num2 = 225;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 68:
						array[8] = (byte)num3;
						num2 = 205;
						continue;
					case 172:
						num3 = 52 + 112;
						num2 = 245;
						continue;
					case 85:
						array[28] = 77;
						num2 = 139;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 107:
						mD5YxRHWxSoHEL7XMOa(array4);
						num = 262;
						break;
					case 191:
						array[25] = 164;
						num2 = 113;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 120:
						array[29] = 224;
						num2 = 208;
						continue;
					case 50:
						num3 = 74 - 64;
						num2 = 292;
						continue;
					case 320:
						array[16] = 115;
						num = 177;
						break;
					case 178:
						array2[5] = 141;
						num = 136;
						break;
					case 255:
						array[17] = 122;
						num2 = 76;
						continue;
					case 66:
						array[27] = 120;
						num2 = 41;
						continue;
					case 237:
						num4 = 228 - 76;
						num2 = 131;
						continue;
					case 171:
						array[11] = (byte)num3;
						num2 = 29;
						continue;
					case 227:
						array[31] = 84;
						num2 = 99;
						continue;
					case 252:
						num3 = 112 + 53;
						num2 = 334;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 352:
						array2[2] = 146;
						num2 = 303;
						continue;
					case 339:
						num4 = 117 + 41;
						num2 = 104;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 211:
						array4[11] = array5[5];
						num = 324;
						break;
					case 242:
						array[18] = (byte)num3;
						num = 307;
						break;
					case 333:
						array[22] = (byte)num3;
						num2 = 36;
						continue;
					case 108:
						array[0] = 237;
						num2 = 21;
						continue;
					case 219:
						num3 = 240 - 80;
						num2 = 304;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 265:
						array[14] = 135;
						num2 = 217;
						continue;
					case 307:
						num3 = 97 + 61;
						num2 = 77;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 306:
						array[7] = 86;
						num2 = 345;
						continue;
					case 258:
						stream = (Stream)lkYjadHMdW4FpqUEEZ8();
						num2 = 39;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 12;
						}
						continue;
					case 240:
						array[11] = (byte)num3;
						num2 = 360;
						continue;
					case 337:
						array[19] = (byte)num3;
						num2 = 359;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 174;
						}
						continue;
					case 233:
						array2[14] = 73;
						num2 = 314;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 147:
						array[6] = 162;
						num2 = 289;
						continue;
					case 271:
						array2[13] = 78;
						num2 = 228;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							num2 = 256;
						}
						continue;
					case 285:
						array[15] = 73;
						num2 = 149;
						continue;
					case 187:
						array2[12] = 84;
						num2 = 81;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 365:
						array[1] = (byte)num3;
						num2 = 363;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 131;
						}
						continue;
					case 217:
						array[14] = 151;
						num2 = 126;
						continue;
					case 31:
						num3 = 116 + 97;
						num2 = 229;
						continue;
					case 11:
						array2[1] = 77;
						num2 = 193;
						continue;
					case 164:
						array = new byte[32];
						num2 = 361;
						continue;
					case 148:
						array[31] = 209;
						num2 = 37;
						if (!OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 27;
						}
						continue;
					case 366:
						ouwTBsHyEYByh6lf3yI(cryptoStream);
						num2 = 87;
						continue;
					case 95:
						array2[1] = (byte)num4;
						num2 = 26;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							num2 = 313;
						}
						continue;
					case 55:
						array[5] = 118;
						num2 = 201;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					case 176:
						array[12] = (byte)num3;
						num2 = 12;
						if (OgZfGjHeBVJMcB5pW2N())
						{
							continue;
						}
						break;
					case 260:
						array[15] = (byte)num3;
						num2 = 253;
						if (dV0HluHEcAFh7AkGhS5() != null)
						{
							num2 = 230;
						}
						continue;
					case 304:
						array[12] = (byte)num3;
						num2 = 114;
						if (dV0HluHEcAFh7AkGhS5() == null)
						{
							continue;
						}
						break;
					}
					break;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string InHOenpqO0(int _0020)
		{
			if (NKlO2FpeaA.Length == 0)
			{
				Mi5OJ3VjBe = new List<string>();
				tYXOgxcSV9 = new List<int>();
				xkiOYNQ5g9(tXYOvJ8XOr.GetManifestResourceStream("NYVZ5QbAorSWyluZxn.uNGIFdm1vqy5NYiSby"), _0020);
			}
			if (tjVOVVBTrG < 75)
			{
				if (tXYOvJ8XOr != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				tjVOVVBTrG++;
			}
			int num = BitConverter.ToInt32(NKlO2FpeaA, _0020);
			if (num < tYXOgxcSV9.Count && tYXOgxcSV9[num] == _0020)
			{
				return Mi5OJ3VjBe[num];
			}
			try
			{
				feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
				byte[] array = new byte[num];
				Array.Copy(NKlO2FpeaA, _0020 + 4, array, 0, num);
				string @string = Encoding.Unicode.GetString(array, 0, array.Length);
				Mi5OJ3VjBe.Add(@string);
				tYXOgxcSV9.Add(_0020);
				Array.Copy(BitConverter.GetBytes(Mi5OJ3VjBe.Count - 1), 0, NKlO2FpeaA, _0020, 4);
				return @string;
			}
			catch
			{
			}
			return "";
		}

		internal static string bQpOEhXAOO(string _0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(_0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		private static int IEeONCQttu()
		{
			return 5;
		}

		private static void EbcOiPwq7D()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		private static Delegate WSDOjWpEuK(IntPtr _0020, Type _0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[2] { _0020, _0020 });
		}

		internal static object hyxOP8hPrh(object _0020)
		{
			try
			{
				if (File.Exists(((Assembly)_0020).Location))
				{
					return ((Assembly)_0020).Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(((Assembly)_0020).GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return ((Assembly)_0020).GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(_0020.GetType().GetProperty("Location").GetValue(_0020, new object[0])
					.ToString()))
				{
					return _0020.GetType().GetProperty("Location").GetValue(_0020, new object[0])
						.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr eCvOwevlLR(string _0020);

		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr jCROW6sMRI(IntPtr _0020, string _0020);

		private static IntPtr YPqOTo2hUS(IntPtr _0020, string _0020, uint _0020)
		{
			if (gN6QefYQJj == null)
			{
				gN6QefYQJj = (IvU1JSQljONHqJXASrd)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Find ".Trim() + "ResourceA"), typeof(IvU1JSQljONHqJXASrd));
			}
			return gN6QefYQJj(_0020, _0020, _0020);
		}

		private static IntPtr r0LOZlRpa6(IntPtr _0020, uint _0020, uint _0020, uint _0020)
		{
			if (ALKQEJHi0K == null)
			{
				ALKQEJHi0K = (VDHPPEQrJEEJHyJWjy2)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Virtual ".Trim() + "Alloc"), typeof(VDHPPEQrJEEJHyJWjy2));
			}
			return ALKQEJHi0K(_0020, _0020, _0020, _0020);
		}

		private static int IqbO0CjNI1(IntPtr _0020, IntPtr _0020, [In][Out] byte[] _0020, uint _0020, out IntPtr _0020)
		{
			if (bxKQNqnpXa == null)
			{
				bxKQNqnpXa = (mMWuspQDJHFYSiKWR3u)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(mMWuspQDJHFYSiKWR3u));
			}
			return bxKQNqnpXa(_0020, _0020, _0020, _0020, out _0020);
		}

		private static int cKoO12lxfL(IntPtr _0020, int _0020, int _0020, ref int _0020)
		{
			if (kH2QidWK9N == null)
			{
				kH2QidWK9N = (kKC8kxQASsrb4c9hsTl)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Virtual ".Trim() + "Protect"), typeof(kKC8kxQASsrb4c9hsTl));
			}
			return kH2QidWK9N(_0020, _0020, _0020, ref _0020);
		}

		private static IntPtr wHvOfJXx83(uint _0020, int _0020, uint _0020)
		{
			if (FemQjD8JBJ == null)
			{
				FemQjD8JBJ = (eJtwbrQafUbinZ14N0Y)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Open ".Trim() + "Process"), typeof(eJtwbrQafUbinZ14N0Y));
			}
			return FemQjD8JBJ(_0020, _0020, _0020);
		}

		private static int hOZOMNUDKf(IntPtr _0020)
		{
			if (HEOQPoaAui == null)
			{
				HEOQPoaAui = (mM5ZwWQB59s8kGdMwtQ)Marshal.GetDelegateForFunctionPointer(jCROW6sMRI(PLs0L7jWH3(), "Close ".Trim() + "Handle"), typeof(mM5ZwWQB59s8kGdMwtQ));
			}
			return HEOQPoaAui(_0020);
		}

		[SpecialName]
		private static IntPtr PLs0L7jWH3()
		{
			if (SGsQwmhk6c == IntPtr.Zero)
			{
				SGsQwmhk6c = eCvOwevlLR("kernel ".Trim() + "32.dll");
			}
			return SGsQwmhk6c;
		}

		private static byte[] w5aOpC5Hi9(string _0020)
		{
			using FileStream fileStream = new FileStream(_0020, FileMode.Open, FileAccess.Read, FileShare.Read);
			int num = 0;
			int num2 = (int)fileStream.Length;
			byte[] array = new byte[num2];
			while (num2 > 0)
			{
				int num3 = fileStream.Read(array, num, num2);
				num += num3;
				num2 -= num3;
			}
			return array;
		}

		internal static Stream zf5OywJBBp()
		{
			return new MemoryStream();
		}

		internal static byte[] AwHORx0uMV(Stream _0020)
		{
			return ((MemoryStream)_0020).ToArray();
		}

		private static byte[] jymO8443gT(byte[] _0020)
		{
			Stream stream = zf5OywJBBp();
			SymmetricAlgorithm symmetricAlgorithm = ysrOQ64ZP3();
			symmetricAlgorithm.Key = new byte[32]
			{
				144, 30, 70, 183, 211, 79, 198, 184, 32, 188,
				26, 19, 140, 169, 144, 81, 31, 167, 186, 131,
				224, 59, 108, 232, 123, 36, 33, 113, 216, 34,
				225, 70
			};
			symmetricAlgorithm.IV = new byte[16]
			{
				222, 194, 143, 26, 243, 121, 122, 217, 245, 155,
				111, 37, 63, 253, 180, 230
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(_0020, 0, _0020.Length);
			cryptoStream.Close();
			byte[] result = AwHORx0uMV(stream);
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			return result;
		}

		private unsafe static int eOfOhpaBBY(string _0020)
		{
			fixed (char* ptr = _0020)
			{
				int num = 5381;
				int num2 = num;
				char* ptr2 = ptr;
				int num3;
				while ((num3 = *ptr2) != 0)
				{
					num = ((num << 5) + num) ^ num3;
					num3 = ptr2[1];
					if (num3 == 0)
					{
						break;
					}
					num2 = ((num2 << 5) + num2) ^ num3;
					ptr2 += 2;
				}
				return num + num2 * 1566083941;
			}
		}

		internal static bool biGO7Gv708(string _0020, string _0020)
		{
			if (_0020 == _0020)
			{
				return true;
			}
			if (_0020 == null || _0020 == null)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			int num2 = 0;
			if (_0020.StartsWith(DE8QWypLek))
			{
				flag = true;
				num = (int)(_0020[4] | ((uint)_0020[5] << 8) | ((uint)_0020[6] << 16) | ((uint)_0020[7] << 24));
			}
			if (_0020.StartsWith(DE8QWypLek))
			{
				flag2 = true;
				num2 = (int)(_0020[4] | ((uint)_0020[5] << 8) | ((uint)_0020[6] << 16) | ((uint)_0020[7] << 24));
			}
			if (!flag && !flag2)
			{
				return false;
			}
			if (!flag)
			{
				num = eOfOhpaBBY(_0020);
			}
			if (!flag2)
			{
				num2 = eOfOhpaBBY(_0020);
			}
			return num == num2;
		}

		private byte[] osOOGpX89x()
		{
			return null;
		}

		private byte[] AaiOuspRMl()
		{
			return null;
		}

		private byte[] YK9Ocr9T5N()
		{
			if ("{11111-22222-20001-00001}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		private byte[] UsqOCrIgsn()
		{
			if ("{11111-22222-20001-00002}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		private byte[] mjZOU9eEhT()
		{
			if ("{11111-22222-30001-00001}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		private byte[] usDOlj7rGD()
		{
			if ("{11111-22222-30001-00002}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		internal byte[] wFaOrLyaaJ()
		{
			if ("{11111-22222-40001-00001}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		internal byte[] u20ODe1idb()
		{
			if ("{11111-22222-40001-00002}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		internal byte[] eWCOAYQmbd()
		{
			if ("{11111-22222-50001-00001}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		internal byte[] cCLOaV6KRk()
		{
			if ("{11111-22222-50001-00002}".Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		internal static object AOO50XHNpe35nMwRImc(object P_0)
		{
			return ((KETCsYQ72YqX3GW5QKQ)P_0).NJK0HP6bbE();
		}

		internal static void GWDVZvHiOSyHsNiDdT6(object P_0, long P_1)
		{
			((Stream)P_0).Position = P_1;
		}

		internal static long bq9XDFHjGyveRVl5mkY(object P_0)
		{
			return ((Stream)P_0).Length;
		}

		internal static object fGI9NwHPZWbKIQqPquB(object P_0, int _0020)
		{
			return ((KETCsYQ72YqX3GW5QKQ)P_0).lObQGdwufS(_0020);
		}

		internal static void LR8XJTHwSWPHqbbYBrf(object P_0)
		{
			((KETCsYQ72YqX3GW5QKQ)P_0).wjqQCvYxAO();
		}

		internal static void mD5YxRHWxSoHEL7XMOa(object P_0)
		{
			Array.Reverse((Array)P_0);
		}

		internal static object O8AWMXHT4JyyvFEQ1a1(object P_0)
		{
			return ((Assembly)P_0).GetName();
		}

		internal static object XbFF2aHZy2BRgQyN7jC(object P_0)
		{
			return ((AssemblyName)P_0).GetPublicKeyToken();
		}

		internal static object Q7C38HH0BLLj18uhZHF()
		{
			return ysrOQ64ZP3();
		}

		internal static void EZZ9XkH1FjeLvNgjCkl(object P_0, CipherMode P_1)
		{
			((SymmetricAlgorithm)P_0).Mode = P_1;
		}

		internal static object vR06PWHfY7l9ek95Qx0(object P_0, object P_1, object P_2)
		{
			return ((SymmetricAlgorithm)P_0).CreateDecryptor((byte[])P_1, (byte[])P_2);
		}

		internal static object lkYjadHMdW4FpqUEEZ8()
		{
			return zf5OywJBBp();
		}

		internal static void YZlkBkHpyFs2gYZAATf(object P_0, object P_1, int P_2, int P_3)
		{
			((Stream)P_0).Write((byte[])P_1, P_2, P_3);
		}

		internal static void ouwTBsHyEYByh6lf3yI(object P_0)
		{
			((CryptoStream)P_0).FlushFinalBlock();
		}

		internal static object mF6bhMHR7oVI0uYQrZk(object P_0)
		{
			return AwHORx0uMV((Stream)P_0);
		}

		internal static void msbD3eH8q4l5dR2D8Ud(object P_0)
		{
			((Stream)P_0).Close();
		}

		internal static bool OgZfGjHeBVJMcB5pW2N()
		{
			return (object)null == null;
		}

		internal static object dV0HluHEcAFh7AkGhS5()
		{
			return null;
		}
	}
}
