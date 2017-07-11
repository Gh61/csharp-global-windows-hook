using System;
using System.Runtime.InteropServices;

namespace KeyboardHookDll
{
	[ComVisible(false)]
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class NativeMethods
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		/// <summary>
		/// Installs an application-defined hook procedure into a hook chain.
		/// You would install a hook procedure to monitor the system for certain types of events.
		/// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
		/// </summary>
		/// <param name="idHook"></param>
		/// <param name="lpfn">
		/// A pointer to the hook procedure.
		/// If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process,
		/// the lpfn parameter must point to a hook procedure in a DLL.
		/// Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
		/// </param>
		/// <param name="hMod">
		/// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.
		/// The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process
		/// and if the hook procedure is within the code associated with the current process.
		/// </param>
		/// <param name="dwThreadId">Id of process you want to hook. 0 (zero) for all currently running processes.</param>
		/// <returns></returns>
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int idHook, Hooking.HookHandlerDelegate lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref Hooking.KBDLLHOOKSTRUCT lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
		public static extern short GetKeyState(int keyCode);
	}
}
