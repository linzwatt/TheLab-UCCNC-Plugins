using System;
using System.Runtime.InteropServices;

namespace DataRepositories {
	public class WINAPI32 {
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int DelegateCloseHandle(IntPtr ptr);

		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		public delegate IntPtr DelegateFindResourceA(IntPtr hModule, string lpName, uint lpType);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate IntPtr DelegateOpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate IntPtr DelegateVirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int DelegateVirtualProtect(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int DelegateWriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate uint _UnknownDelegate_01(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		delegate IntPtr _UnusedDelegate_01();
		delegate void _UnusedDelegate_02(object o);
		internal static WINAPI32.DelegateCloseHandle delegateCloseHandle;
		internal static WINAPI32.DelegateFindResourceA delegateFindResourceA;
		internal static WINAPI32.DelegateOpenProcess delegateOpenProcess;
		internal static WINAPI32.DelegateVirtualAlloc delegateVirtualAlloc;
		internal static WINAPI32.DelegateVirtualProtect delegateVirtualProtect;
		internal static WINAPI32.DelegateWriteProcessMemory delegateWriteProcessMemory;
		internal static IntPtr kernel32Ptr;
		internal static WINAPI32._UnknownDelegate_01 _unknownDelegate_01_01;
		internal static WINAPI32._UnknownDelegate_01 _unknownDelegate_01_02;

		public WINAPI32() {
			WINAPI32.kernel32Ptr = IntPtr.Zero;
			WINAPI32.delegateFindResourceA = null;
			WINAPI32.delegateVirtualAlloc = null;
			WINAPI32.delegateWriteProcessMemory = null;
			WINAPI32.delegateVirtualProtect = null;
			WINAPI32.delegateOpenProcess = null;
			WINAPI32.delegateCloseHandle = null;
			WINAPI32._unknownDelegate_01_01 = null;
			WINAPI32._unknownDelegate_01_02 = null;
		}

		// Token: 0x06000657 RID: 1623
		public static int K32_CloseHandle(IntPtr ptr) {
			if (WINAPI32.delegateCloseHandle == null) {
				WINAPI32.delegateCloseHandle = (WINAPI32.DelegateCloseHandle)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "CloseHandle"), typeof(WINAPI32.DelegateCloseHandle)); }
			return WINAPI32.delegateCloseHandle(ptr);
		}

		// Token: 0x06000656 RID: 1622
		public static IntPtr K32_FindResourceA(IntPtr hModule, string lpName, uint lpType) {
			if (WINAPI32.delegateFindResourceA == null) {
				WINAPI32.delegateFindResourceA = (WINAPI32.DelegateFindResourceA)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "FindResourceA"), typeof(WINAPI32.DelegateFindResourceA)); }
			return WINAPI32.delegateFindResourceA(hModule, lpName, lpType);
		}

		// Token: 0x06000655 RID: 1621
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr K32_GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x0600061D RID: 1565
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr K32_LoadLibrary(string lpFileName);

		// Token: 0x06000658 RID: 1624
		public static IntPtr K32_OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId) {
			if (WINAPI32.delegateOpenProcess == null) {
				WINAPI32.delegateOpenProcess = (WINAPI32.DelegateOpenProcess)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "OpenProcess"), typeof(WINAPI32.DelegateOpenProcess)); }
			return WINAPI32.delegateOpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);
		}

		// Token: 0x06000659 RID: 1625
		public static IntPtr K32_VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect) {
			if (WINAPI32.delegateVirtualAlloc == null) {
				WINAPI32.delegateVirtualAlloc = (WINAPI32.DelegateVirtualAlloc)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "VirtualAlloc"), typeof(WINAPI32.DelegateVirtualAlloc)); }
			return WINAPI32.delegateVirtualAlloc(lpAddress, dwSize, flAllocationType, flProtect);
		}

		// Token: 0x0600065A RID: 1626
		public static int K32_VirtualProtect(IntPtr lpAddress, int dwsize, int flNewProtect, ref int lpflOldProtect) {
			if (WINAPI32.delegateVirtualProtect == null) {
				WINAPI32.delegateVirtualProtect = (WINAPI32.DelegateVirtualProtect)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "VirtualProtect"), typeof(WINAPI32.DelegateVirtualProtect)); }
			return WINAPI32.delegateVirtualProtect(lpAddress, dwsize, flNewProtect, ref lpflOldProtect);
		}

		// Token: 0x0600065B RID: 1627
		public static int K32_WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten) {
			if (WINAPI32.delegateWriteProcessMemory == null) {
				WINAPI32.delegateWriteProcessMemory = (WINAPI32.DelegateWriteProcessMemory)Marshal.GetDelegateForFunctionPointer(WINAPI32.K32_GetProcAddress(WINAPI32.Kernel32Ptr(), "WriteProcessMemory"), typeof(WINAPI32.DelegateWriteProcessMemory)); }
			return WINAPI32.delegateWriteProcessMemory(hProcess, lpBaseAddress, buffer, size, out lpNumberOfBytesWritten);
		}

		// Token: 0x06000639 RID: 1593
		public static IntPtr Kernel32Ptr() {
			if (WINAPI32.kernel32Ptr == IntPtr.Zero) { WINAPI32.kernel32Ptr = WINAPI32.K32_LoadLibrary("kernel32.dll"); }
			return WINAPI32.kernel32Ptr;
		}
	}
}
