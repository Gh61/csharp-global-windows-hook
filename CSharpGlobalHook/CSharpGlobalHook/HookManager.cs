using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KeyboardHookDll;

namespace CSharpGlobalHook
{
	public class HookManager
	{
		// ReSharper disable once InconsistentNaming
		private const int WH_KEYBOARD = 2;
		// ReSharper disable once InconsistentNaming
		private const int WH_KEYBOARD_LL = 13;

		/// <summary>
		/// Active delegate for hooking callback (must be here to be not collected by GC).
		/// </summary>
		// ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
		private readonly Hooking.HookHandlerDelegate activeDelegate;

		/// <summary>
		/// Returns last pressed keys.
		/// </summary>
		public ObservableCollection<string> LastPressedKeys
		{
			get;
		}

		/// <summary>
		/// Gets or sets whether to block all keypresses across the whole system.
		/// </summary>
		public bool BlockAllKeys
		{
			get;
			set;
		}

		public HookManager()
		{
			this.LastPressedKeys = new ObservableCollection<string>();

			using (Process curProcess = Process.GetCurrentProcess())
			{
				var module = curProcess.Modules.Cast<ProcessModule>().Single(m => m.ModuleName.Contains("KeyboardHookDll"));
				var moduleHandle = NativeMethods.GetModuleHandle(module.ModuleName);

				// Setting up delegate to this object
				Hooking.HookFired = this.HookCallback;
				activeDelegate = Hooking.HookCallback;

				Hooking.HookId = NativeMethods.SetWindowsHookEx(WH_KEYBOARD, activeDelegate, moduleHandle, 0);

				string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
			}
		}

		private IntPtr HookCallback(int nCode, IntPtr wParam, ref Hooking.KBDLLHOOKSTRUCT lParam)
		{
			File.AppendAllText("log.txt", $"[{DateTime.Now:T}]: Ncode: {nCode}, Type: {(int)wParam}\n");

			if (nCode >= 0)
			{
				if (wParam == (IntPtr) Win32.WM_KEYUP || wParam == (IntPtr) Win32.WM_KEYDOWN
				 || wParam == (IntPtr) Win32.WM_SYSKEYUP || wParam == (IntPtr) Win32.WM_SYSKEYDOWN)
				{
					bool allowKey = !BlockAllKeys;

					//if (allowWindowsKey)
					{
						switch (lParam.flags)
						{
							//Ctrl+Esc
							case 0:
								if (lParam.vkCode == 27)
									allowKey = true;
								break;

							//Windows keys
							case 1:
								if ((lParam.vkCode == 91) || (lParam.vkCode == 92))
									allowKey = true;
								break;
						}
					}
					// Alt+Tab
					//if (allowAltTab)
					{
						if ((lParam.flags == 32) && (lParam.vkCode == 9))
							allowKey = true;
					}

					var keyName = ((Keys) lParam.vkCode).ToString();

					File.AppendAllText("log.txt", $@"[{DateTime.Now:T}]: Pressed {keyName}\n");

					LastPressedKeys.Add(keyName);

					// If more than 10 keys are present remove last.
					if (LastPressedKeys.Count > 10)
					{
						LastPressedKeys.RemoveAt(0);
					}

					//If this key is being suppressed, return a dummy value
					if (allowKey == false)
						return (IntPtr)1;
				}
			}

			return NativeMethods.CallNextHookEx(Hooking.HookId, nCode, wParam, ref lParam);
		}
	}
}
