# C# Global Windows Hook

Purpose of this repository is to show how to hook (using WINAPI method SetWindowsHookEx) to Global Windows Event with C#.

Microsoft [says](https://support.microsoft.com/en-us/help/318804/how-to-set-a-windows-hook-in-visual-c-.net) only supported events are *WH_KEYBOARD_LL* and *WH_MOUSE_LL* wich is only **partialy** true.


#### Small backstory

*Because I needed to write application wich block keypresses only from certain keyboard I need cooperation of Raw&nbsp;Input API (check for concrete input device) and Keyboard HOOK (block keys). I have done some pieces togethter and has working Raw&nbsp;Input and Keyboard Low-Level hook. This seems OK, but later I found that this Low-Level event is called before RawInput and I need **WH_KEYBOARD** event, called after RawInput. So I did a try and it worked:*

## Idea

In [linked article](https://support.microsoft.com/en-us/help/318804/how-to-set-a-windows-hook-in-visual-c-.net) they said:

> To install a global hook, a hook must have a native DLL export to inject itself in another process that requires a valid, consistent function to call into. This behavior requires a DLL export.

I did a small search and found this nuget: [Unmanaged Exports (DllExport for .Net)](https://www.nuget.org/packages/UnmanagedExports).

They said it isn't working because C# doesn't have DLL Export, but here it is
(After compilation the task from this package does the (Magic) job. It takes the IL and add required exports of methods decorated with attribute [DllExport]).

## Important parts of code

*TODO*

### Event types

I am using this solution only with event type *WH_KEYBOARD*.
But I assume it will work with [other event types](https://msdn.microsoft.com/en-us/library/ms644990(v=vs.85).aspx) (with changes of lParam structure) too.

If someone tested new event type, please let me know, so i will update this table of supported event types:

| Event Type         | Value  | State          |
| ------------------ | ------ | :------------: |
| WH_CALLWNDPROC     | 4      | ?              |
| WH_CALLWNDPROCRET  | 12     | ?              |
| WH_CBT             | 5      | ?              |
| WH_DEBUG           | 9      | ?              |
| WH_FOREGROUNDIDLE  | 11     | ?              |
| WH_GETMESSAGE      | 3      | ?              |
| WH_JOURNALPLAYBACK | 1      | ?              |
| WH_JOURNALRECORD   | 0      | ?              |
| WH_KEYBOARD        | 2      | &#10004;       |
| WH_KEYBOARD_LL     | 13     | native support |
| WH_MOUSE           | 7      | ?              |
| WH_MOUSE_LL        | 14     | native support |
| WH_MSGFILTER       | -1     | ?              |
| WH_SHELL           | 10     | ?              |
| WH_SYSMSGFILTER    | 6      | ?              |

