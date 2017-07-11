using System;
using RGiesecke.DllExport;

namespace KeyboardHookDll
{
	public static class Hooking
	{
		/// <summary>
		/// Structure returned by the hook whenever a key is pressed.
		/// </summary>
		public struct KBDLLHOOKSTRUCT
		{
			public int vkCode;
			int scanCode;
			public int flags;
			int time;
			int dwExtraInfo;
		}

		/// <summary>
		/// Delegate for callback from keyboard hook.
		/// </summary>
		public delegate IntPtr HookHandlerDelegate(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

		/// <summary>
		/// Gets or sets delegate called when <see cref="HookCallback"/> gets fired by Windows.
		/// </summary>
		public static HookHandlerDelegate HookFired
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets active hook's id.
		/// </summary>
		public static IntPtr HookId
		{
			get;
			set;
		}

		/// <summary>
		/// DLL Exported function for keyboard hook.
		/// </summary>
		[DllExport]
		public static IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
		{
			if (HookFired != null)
			{
				return HookFired(nCode, wParam, ref lParam);
			}

			// callback not set, calling next hooks
			return NativeMethods.CallNextHookEx(HookId, nCode, wParam, ref lParam);
		}
	}
}
