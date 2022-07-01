namespace vJoyInterfaceWrap {
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    internal static class Win32Wrapper {
        [DllImport("kernel32", SetLastError = true, CallingConvention = CallingConvention.Winapi)] private static extern IntPtr LoadLibrary(string libraryName);

        [DllImport("kernel32", SetLastError = true, CallingConvention = CallingConvention.Winapi)] private static extern IntPtr GetProcAddress(IntPtr hwnd, string procedureName);

        internal static bool Is64BitOs() {
            if(IntPtr.Size == 8)
                return true; // We are running a 64-bit Process, of course we are in a 64-bit system!
            var handle = LoadLibrary("kernel32");
            if(handle != IntPtr.Zero) {
                var fnPtr = GetProcAddress(handle, "IsWow64Process");
                if(fnPtr != IntPtr.Zero) {
                    var fnDelegate = (IsWow64ProcessDelegate)Marshal.GetDelegateForFunctionPointer(fnPtr, typeof(IsWow64ProcessDelegate));
                    bool isWow64;
                    return fnDelegate.Invoke(Process.GetCurrentProcess().Handle, out isWow64) && isWow64;
                    // Return true if we're running a 32-bit process in a 64-bit OS
                }
            }
            return false; // We can't check if we are running a 32-bit process on 64-bit OS :(
        }

        #region Nested type: IsWow64ProcessDelegate

        private delegate bool IsWow64ProcessDelegate([In] IntPtr handle, [Out] out bool isWow64Process);

        #endregion
    }
}