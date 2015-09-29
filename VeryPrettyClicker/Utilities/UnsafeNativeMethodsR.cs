// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.UnsafeNativeMethods
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: D4F73B0E-3B8D-4341-A790-516ED5C6F955
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll

using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Windows.Forms
{
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethodsR
    {
        private static readonly Version VistaOSVersion = new Version(6, 0);
        public const int MB_PRECOMPOSED = 1;
        public const int SMTO_ABORTIFHUNG = 2;
        public const int LAYOUT_RTL = 1;
        public const int LAYOUT_BITMAPORIENTATIONPRESERVED = 8;

        internal static bool IsVista
        {
            get
            {
                OperatingSystem osVersion = Environment.OSVersion;
                if (osVersion == null || osVersion.Platform != PlatformID.Win32NT)
                    return false;
                return osVersion.Version.CompareTo(UnsafeNativeMethodsR.VistaOSVersion) >= 0;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCapture();

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        internal static extern uint SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, uint cchOutBuf, IntPtr ppvReserved);

        [DllImport("ole32.dll")]
        public static extern int ReadClassStg(HandleRef pStg, [In, Out] ref Guid pclsid);

        [DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern void CoTaskMemFree(IntPtr pv);

        [DllImport("user32.dll")]
        public static extern int GetClassName(HandleRef hwnd, StringBuilder lpClassName, int nMaxCount);

        public static IntPtr SetClassLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
                return UnsafeNativeMethodsR.SetClassLongPtr32(hWnd, nIndex, dwNewLong);
            return UnsafeNativeMethodsR.SetClassLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32.dll", EntryPoint = "SetClassLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClassLongPtr32(HandleRef hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetClassLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClassLongPtr64(HandleRef hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport("ole32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IClassFactory2 CoGetClassObject([In] ref Guid clsid, int dwContext, int serverInfo, [In] ref Guid refiid);

        [DllImport("ole32.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern object CoCreateInstance([In] ref Guid clsid, [MarshalAs(UnmanagedType.Interface)] object punkOuter, int context, [In] ref Guid iid);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLocaleInfo(int Locale, int LCType, StringBuilder lpLCData, int cchData);

        [DllImport("ole32.dll")]
        public static extern int WriteClassStm(UnsafeNativeMethodsR.IStream pStream, ref Guid clsid);

        [DllImport("ole32.dll")]
        public static extern int ReadClassStg(UnsafeNativeMethodsR.IStorage pStorage, out Guid clsid);

        [DllImport("ole32.dll")]
        public static extern int ReadClassStm(UnsafeNativeMethodsR.IStream pStream, out Guid clsid);

        [DllImport("ole32.dll")]
        public static extern int OleLoadFromStream(UnsafeNativeMethodsR.IStream pStorage, ref Guid iid, out UnsafeNativeMethodsR.IOleObject pObject);

        [DllImport("ole32.dll")]
        public static extern int OleSaveToStream(UnsafeNativeMethodsR.IPersistStream pPersistStream, UnsafeNativeMethodsR.IStream pStream);

        [DllImport("ole32.dll")]
        public static extern int CoGetMalloc(int dwReserved, out UnsafeNativeMethodsR.IMalloc pMalloc);

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PageSetupDlg([In, Out] NativeMethodsR.PAGESETUPDLG lppsd);

        [DllImport("comdlg32.dll", EntryPoint = "PrintDlg", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PrintDlg_32([In, Out] NativeMethodsR.PRINTDLG_32 lppd);

        [DllImport("comdlg32.dll", EntryPoint = "PrintDlg", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PrintDlg_64([In, Out] NativeMethodsR.PRINTDLG_64 lppd);

        public static bool PrintDlg([In, Out] NativeMethodsR.PRINTDLG lppd)
        {
            if (IntPtr.Size == 4)
            {
                NativeMethodsR.PRINTDLG_32 lppd1 = lppd as NativeMethodsR.PRINTDLG_32;
                if (lppd1 == null)
                    throw new NullReferenceException("PRINTDLG data is null");
                return UnsafeNativeMethodsR.PrintDlg_32(lppd1);
            }
            NativeMethodsR.PRINTDLG_64 lppd2 = lppd as NativeMethodsR.PRINTDLG_64;
            if (lppd2 == null)
                throw new NullReferenceException("PRINTDLG data is null");
            return UnsafeNativeMethodsR.PrintDlg_64(lppd2);
        }

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int PrintDlgEx([In, Out] NativeMethodsR.PRINTDLGEX lppdex);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int OleGetClipboard(ref System.Runtime.InteropServices.ComTypes.IDataObject data);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int OleSetClipboard(System.Runtime.InteropServices.ComTypes.IDataObject pDataObj);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int OleFlushClipboard();

        [DllImport("oleaut32.dll")]
        public static extern void OleCreatePropertyFrameIndirect(NativeMethodsR.OCPFIPARAMS p);

        [DllImport("oleaut32.dll", EntryPoint = "OleCreateFontIndirect", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IFont OleCreateIFontIndirect(NativeMethodsR.FONTDESC fd, ref Guid iid);

        [DllImport("oleaut32.dll", EntryPoint = "OleCreatePictureIndirect", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IPicture OleCreateIPictureIndirect([MarshalAs(UnmanagedType.AsAny)] object pictdesc, ref Guid iid, bool fOwn);

        [DllImport("oleaut32.dll", EntryPoint = "OleCreatePictureIndirect", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IPictureDisp OleCreateIPictureDispIndirect([MarshalAs(UnmanagedType.AsAny)] object pictdesc, ref Guid iid, bool fOwn);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IPicture OleCreatePictureIndirect(NativeMethodsR.PICTDESC pictdesc, [In] ref Guid refiid, bool fOwn);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IFont OleCreateFontIndirect(NativeMethodsR.tagFONTDESC fontdesc, [In] ref Guid refiid);

        [DllImport("oleaut32.dll")]
        public static extern int VarFormat(ref object pvarIn, HandleRef pstrFormat, int iFirstDay, int iFirstWeek, uint dwFlags, [In, Out] ref IntPtr pbstr);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int DragQueryFile(HandleRef hDrop, int iFile, StringBuilder lpszFile, int cch);

        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(HandleRef hwndParent, NativeMethodsR.EnumChildrenCallback lpEnumFunc, HandleRef lParam);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ShellExecute(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("shell32.dll", EntryPoint = "ShellExecute", CharSet = CharSet.Auto, BestFitMapping = false)]
        public static extern IntPtr ShellExecute_NoBFM(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetScrollPos(HandleRef hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnableScrollBar(HandleRef hWnd, int nBar, int value);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int Shell_NotifyIcon(int message, NativeMethodsR.NOTIFYICONDATA pnid);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool InsertMenuItem(HandleRef hMenu, int uItem, bool fByPosition, NativeMethodsR.MENUITEMINFO_T lpmii);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetMenu(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, [In, Out] NativeMethodsR.MENUITEMINFO_T lpmii);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, [In, Out] NativeMethodsR.MENUITEMINFO_T_RW lpmii);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, NativeMethodsR.MENUITEMINFO_T lpmii);

        [DllImport("user32.dll", EntryPoint = "CreateMenu", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreateMenu();

        public static IntPtr CreateMenu()
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateMenu(), NativeMethodsR.CommonHandles.Menu);
        }

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetOpenFileName([In, Out] NativeMethodsR.OPENFILENAME_I ofn);

        [DllImport("user32.dll")]
        public static extern bool EndDialog(HandleRef hWnd, IntPtr result);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MultiByteToWideChar(int CodePage, int dwFlags, byte[] lpMultiByteStr, int cchMultiByte, char[] lpWideCharStr, int cchWideChar);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern int WideCharToMultiByte(int codePage, int flags, [MarshalAs(UnmanagedType.LPWStr)] string wideStr, int chars, [In, Out] byte[] pOutBytes, int bufferBytes, IntPtr defaultChar, IntPtr pDefaultUsed);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void CopyMemory(HandleRef destData, HandleRef srcData, int size);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr pdst, byte[] psrc, int cb);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void CopyMemoryW(IntPtr pdst, string psrc, int cb);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void CopyMemoryW(IntPtr pdst, char[] psrc, int cb);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void CopyMemoryA(IntPtr pdst, string psrc, int cb);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void CopyMemoryA(IntPtr pdst, char[] psrc, int cb);

        [DllImport("kernel32.dll", EntryPoint = "DuplicateHandle", SetLastError = true)]
        private static extern IntPtr IntDuplicateHandle(HandleRef processSource, HandleRef handleSource, HandleRef processTarget, ref IntPtr handleTarget, int desiredAccess, bool inheritHandle, int options);

        public static IntPtr DuplicateHandle(HandleRef processSource, HandleRef handleSource, HandleRef processTarget, ref IntPtr handleTarget, int desiredAccess, bool inheritHandle, int options)
        {
            IntPtr num = UnsafeNativeMethodsR.IntDuplicateHandle(processSource, handleSource, processTarget, ref handleTarget, desiredAccess, inheritHandle, options);
            HandleCollectorR.Add(handleTarget, NativeMethodsR.CommonHandles.Kernel);
            return num;
        }

        [DllImport("ole32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IStorage StgOpenStorageOnILockBytes(UnsafeNativeMethodsR.ILockBytes iLockBytes, UnsafeNativeMethodsR.IStorage pStgPriority, int grfMode, int sndExcluded, int reserved);

        [DllImport("ole32.dll", PreserveSig = false)]
        public static extern IntPtr GetHGlobalFromILockBytes(UnsafeNativeMethodsR.ILockBytes pLkbyt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, NativeMethodsR.HookProc pfnhook, HandleRef hinst, int threadid);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardState(byte[] keystate);

        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto)]
        public static extern void Keybd_event(byte vk, byte scan, int flags, int extrainfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetKeyboardState(byte[] keystate);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnhookWindowsHookEx(HandleRef hhook);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short GetAsyncKeyState(int vkey);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CallNextHookEx(HandleRef hhook, int code, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ScreenToClient(HandleRef hWnd, [In, Out] NativeMethodsR.POINT pt);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetModuleFileName(HandleRef hModule, StringBuilder buffer, int length);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool IsDialogMessage(HandleRef hWndDlg, [In, Out] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage([In, Out] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DispatchMessage([In] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr DispatchMessageA([In] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr DispatchMessageW([In] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostThreadMessage(int id, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("ole32.dll")]
        public static extern int CoRegisterMessageFilter(HandleRef newFilter, ref IntPtr oldMsgFilter);

        [DllImport("ole32.dll", EntryPoint = "OleInitialize", SetLastError = true)]
        private static extern int IntOleInitialize(int val);

        public static int OleInitialize()
        {
            return UnsafeNativeMethodsR.IntOleInitialize(0);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumThreadWindows(int dwThreadId, NativeMethodsR.EnumThreadWindowsCallback lpfn, HandleRef lParam);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendDlgItemMessage(HandleRef hDlg, int nIDDlgItem, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int OleUninitialize();

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetSaveFileName([In, Out] NativeMethodsR.OPENFILENAME_I ofn);

        [DllImport("user32.dll", EntryPoint = "ChildWindowFromPointEx", CharSet = CharSet.Auto)]
        private static extern IntPtr _ChildWindowFromPointEx(HandleRef hwndParent, UnsafeNativeMethodsR.POINTSTRUCT pt, int uFlags);

        public static IntPtr ChildWindowFromPointEx(HandleRef hwndParent, int x, int y, int uFlags)
        {
            UnsafeNativeMethodsR.POINTSTRUCT pt = new UnsafeNativeMethodsR.POINTSTRUCT(x, y);
            return UnsafeNativeMethodsR._ChildWindowFromPointEx(hwndParent, pt, uFlags);
        }

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IntCloseHandle(HandleRef handle);

        public static bool CloseHandle(HandleRef handle)
        {
            HandleCollectorR.Remove((IntPtr)handle, NativeMethodsR.CommonHandles.Kernel);
            return UnsafeNativeMethodsR.IntCloseHandle(handle);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateCompatibleDC(HandleRef hDC);

        public static IntPtr CreateCompatibleDC(HandleRef hDC)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateCompatibleDC(hDC), NativeMethodsR.CommonHandles.CompatibleHDC);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool), In] bool fBlockIt);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SendInput(uint nInputs, NativeMethodsR.INPUT[] pInputs, int cbSize);

        [DllImport("kernel32.dll", EntryPoint = "MapViewOfFile", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntMapViewOfFile(HandleRef hFileMapping, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap);

        public static IntPtr MapViewOfFile(HandleRef hFileMapping, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntMapViewOfFile(hFileMapping, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap), NativeMethodsR.CommonHandles.Kernel);
        }

        [DllImport("kernel32.dll", EntryPoint = "UnmapViewOfFile", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IntUnmapViewOfFile(HandleRef pvBaseAddress);

        public static bool UnmapViewOfFile(HandleRef pvBaseAddress)
        {
            HandleCollectorR.Remove((IntPtr)pvBaseAddress, NativeMethodsR.CommonHandles.Kernel);
            return UnsafeNativeMethodsR.IntUnmapViewOfFile(pvBaseAddress);
        }

        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags);

        public static IntPtr GetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntGetDCEx(hWnd, hrgnClip, flags), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethodsR.BITMAP bm);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethodsR.LOGPEN lp);

        public static int GetObject(HandleRef hObject, NativeMethodsR.LOGPEN lp)
        {
            return UnsafeNativeMethodsR.GetObject(hObject, Marshal.SizeOf(typeof(NativeMethodsR.LOGPEN)), lp);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethodsR.LOGBRUSH lb);

        public static int GetObject(HandleRef hObject, NativeMethodsR.LOGBRUSH lb)
        {
            return UnsafeNativeMethodsR.GetObject(hObject, Marshal.SizeOf(typeof(NativeMethodsR.LOGBRUSH)), lb);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethodsR.LOGFONT lf);

        public static int GetObject(HandleRef hObject, NativeMethodsR.LOGFONT lp)
        {
            return UnsafeNativeMethodsR.GetObject(hObject, Marshal.SizeOf(typeof(NativeMethodsR.LOGFONT)), lp);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, ref int nEntries);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, int[] nEntries);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObjectType(HandleRef hObject);

        [DllImport("user32.dll", EntryPoint = "CreateAcceleratorTable", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreateAcceleratorTable(HandleRef pentries, int cCount);

        public static IntPtr CreateAcceleratorTable(HandleRef pentries, int cCount)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateAcceleratorTable(pentries, cCount), NativeMethodsR.CommonHandles.Accelerator);
        }

        [DllImport("user32.dll", EntryPoint = "DestroyAcceleratorTable", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyAcceleratorTable(HandleRef hAccel);

        public static bool DestroyAcceleratorTable(HandleRef hAccel)
        {
            HandleCollectorR.Remove((IntPtr)hAccel, NativeMethodsR.CommonHandles.Accelerator);
            return UnsafeNativeMethodsR.IntDestroyAcceleratorTable(hAccel);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short VkKeyScan(char key);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCapture(HandleRef hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos([In, Out] NativeMethodsR.POINT pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);

        [DllImport("user32.dll", EntryPoint = "SetWindowRgn", CharSet = CharSet.Auto)]
        private static extern int IntSetWindowRgn(HandleRef hwnd, HandleRef hrgn, bool fRedraw);

        public static int SetWindowRgn(HandleRef hwnd, HandleRef hrgn, bool fRedraw)
        {
            int num = UnsafeNativeMethodsR.IntSetWindowRgn(hwnd, hrgn, fRedraw);
            if (num != 0)
                HandleCollectorR.Remove((IntPtr)hrgn, NativeMethodsR.CommonHandles.GDI);
            return num;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetTempFileName(string tempDirName, string prefixName, int unique, StringBuilder sb);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(HandleRef hWnd, string text);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalReAlloc(HandleRef handle, int bytes, int flags);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalLock(HandleRef handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GlobalUnlock(HandleRef handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalFree(HandleRef handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GlobalSize(HandleRef handle);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmSetConversionStatus(HandleRef hIMC, int conversion, int sentence);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmGetConversionStatus(HandleRef hIMC, ref int conversion, ref int sentence);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmGetContext(HandleRef hWnd);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmReleaseContext(HandleRef hWnd, HandleRef hIMC);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmAssociateContext(HandleRef hWnd, HandleRef hIMC);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmDestroyContext(HandleRef hIMC);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmCreateContext();

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmSetOpenStatus(HandleRef hIMC, bool open);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmGetOpenStatus(HandleRef hIMC);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmNotifyIME(HandleRef hIMC, int dwAction, int dwIndex, int dwValue);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetAncestor(HandleRef hWnd, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsChild(HandleRef hWndParent, HandleRef hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsZoomed(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref NativeMethodsR.RECT rect, int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] NativeMethodsR.POINT pt, int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, bool wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int[] lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int[] wParam, int[] lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, ref int wParam, ref int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.TOOLINFO_T lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.TOOLINFO_TOOLTIP lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.TBBUTTON lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.TBBUTTONINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.TV_ITEM lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.TV_INSERTSTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.TV_HITTESTINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVBKIMAGE lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.LVHITTESTINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.TCITEM_T lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethodsR.HDLAYOUT hdlayout);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, HandleRef wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, HandleRef lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPStruct), In, Out] NativeMethodsR.PARAFORMAT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPStruct), In, Out] NativeMethodsR.CHARFORMATA lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPStruct), In, Out] NativeMethodsR.CHARFORMAT2A lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPStruct), In, Out] NativeMethodsR.CHARFORMATW lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.IUnknown)] out object editOle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.CHARRANGE lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.FINDTEXT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.TEXTRANGE lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.POINT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethodsR.POINT wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.REPASTESPECIAL lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.EDITSTREAM lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.EDITSTREAM64 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethodsR.GETTEXTLENGTHEX wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethodsR.SIZE lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] ref NativeMethodsR.LVFINDINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVHITTESTINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVCOLUMN_T lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] ref NativeMethodsR.LVITEM lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVCOLUMN lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVGROUP lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethodsR.POINT wParam, [In, Out] NativeMethodsR.LVINSERTMARK lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.LVINSERTMARK lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethodsR.LVTILEVIEWINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.MCHITTESTINFO lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.SYSTEMTIME lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.SYSTEMTIMEARRAY lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethodsR.LOGFONT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethodsR.MSG lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, [In, Out] ref NativeMethodsR.RECT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, ref short wParam, ref short lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, [MarshalAs(UnmanagedType.Bool), In, Out] ref bool wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, [In, Out] ref NativeMethodsR.RECT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, [In, Out] ref Rectangle lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, NativeMethodsR.ListViewCompareCallback pfnCompare);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam, int flags, int timeout, out IntPtr pdwResult);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(HandleRef hWnd, HandleRef hWndParent);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref NativeMethodsR.RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDlgItem(HandleRef hWnd, int nIDDlgItem);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string modName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefMDIChildProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern short GlobalDeleteAtom(short atom);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(HandleRef hModule, string lpProcName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClassInfo(HandleRef hInst, string lpszClass, [In, Out] NativeMethodsR.WNDCLASS_I wc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClassInfo(HandleRef hInst, string lpszClass, IntPtr h);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethodsR.RECT rc, int nUpdate);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref int value, int ignore);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref bool value, int ignore);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethodsR.HIGHCONTRAST_I rc, int nUpdate);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethodsR.NONCLIENTMETRICS metrics, int nUpdate);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethodsR.LOGFONT font, int nUpdate);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, bool[] flag, bool nUpdate);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetComputerName(StringBuilder lpBuffer, int[] nSize);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetUserName(StringBuilder lpBuffer, int[] nSize);

        [DllImport("user32.dll")]
        public static extern IntPtr GetProcessWindowStation();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetUserObjectInformation(HandleRef hObj, int nIndex, [MarshalAs(UnmanagedType.LPStruct)] NativeMethodsR.USEROBJECTFLAGS pvBuffer, int nLength, ref int lpnLengthNeeded);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ClientToScreen(HandleRef hWnd, [In, Out] NativeMethodsR.POINT pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MsgWaitForMultipleObjectsEx(int nCount, IntPtr pHandles, int dwMilliseconds, int dwWakeMask, int dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterDragDrop(HandleRef hwnd, UnsafeNativeMethodsR.IOleDropTarget target);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int RevokeDragDrop(HandleRef hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage([In, Out] ref NativeMethodsR.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool PeekMessageW([In, Out] ref NativeMethodsR.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern bool PeekMessageA([In, Out] ref NativeMethodsR.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern short GlobalAddAtom(string atomName);

        [DllImport("oleacc.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LresultFromObject(ref Guid refiid, IntPtr wParam, HandleRef pAcc);

        [DllImport("oleacc.dll", CharSet = CharSet.Auto)]
        public static extern int CreateStdAccessibleObject(HandleRef hWnd, int objID, ref Guid refiid, [MarshalAs(UnmanagedType.Interface), In, Out] ref object pAcc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void NotifyWinEvent(int winEvent, HandleRef hwnd, int objType, int objID);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetMenuItemID(HandleRef hMenu, int nPos);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetSubMenu(HandleRef hwnd, int index);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetMenuItemCount(HandleRef hMenu);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void GetErrorInfo(int reserved, [In, Out] ref UnsafeNativeMethodsR.IErrorInfo errorInfo);

        [DllImport("user32.dll", EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
        private static extern IntPtr IntBeginPaint(HandleRef hWnd, [In, Out] ref NativeMethodsR.PAINTSTRUCT lpPaint);

        public static IntPtr BeginPaint(HandleRef hWnd, [MarshalAs(UnmanagedType.LPStruct), In, Out] ref NativeMethodsR.PAINTSTRUCT lpPaint)
        {
            return IntPtr.Zero;//HandleCollectorR.Add(UnsafeNativeMethodsR.IntBeginPaint(hWnd, out lpPaint), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("user32.dll", EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
        private static extern bool IntEndPaint(HandleRef hWnd, ref NativeMethodsR.PAINTSTRUCT lpPaint);

        public static bool EndPaint(HandleRef hWnd, [MarshalAs(UnmanagedType.LPStruct), In] ref NativeMethodsR.PAINTSTRUCT lpPaint)
        {
            HandleCollectorR.Remove(lpPaint.hdc, NativeMethodsR.CommonHandles.HDC);
            return UnsafeNativeMethodsR.IntEndPaint(hWnd, ref lpPaint);
        }

        [DllImport("user32.dll", EntryPoint = "GetDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetDC(HandleRef hWnd);

        public static IntPtr GetDC(HandleRef hWnd)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntGetDC(hWnd), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetWindowDC(HandleRef hWnd);

        public static IntPtr GetWindowDC(HandleRef hWnd)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntGetWindowDC(hWnd), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseDC", CharSet = CharSet.Auto)]
        private static extern int IntReleaseDC(HandleRef hWnd, HandleRef hDC);

        public static int ReleaseDC(HandleRef hWnd, HandleRef hDC)
        {
            HandleCollectorR.Remove((IntPtr)hDC, NativeMethodsR.CommonHandles.HDC);
            return UnsafeNativeMethodsR.IntReleaseDC(hWnd, hDC);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateDC", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateDC(string lpszDriver, string lpszDeviceName, string lpszOutput, HandleRef devMode);

        public static IntPtr CreateDC(string lpszDriver)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateDC(lpszDriver, (string)null, (string)null, NativeMethodsR.NullHandleRef), NativeMethodsR.CommonHandles.HDC);
        }

        public static IntPtr CreateDC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef lpInitData)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateDC(lpszDriverName, lpszDeviceName, lpszOutput, lpInitData), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] IntPtr[] rc, int nUpdate);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendCallbackMessage(HandleRef hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
        public static extern void DragAcceptFiles(HandleRef hWnd, bool fAccept);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetScrollInfo(HandleRef hWnd, int fnBar, NativeMethodsR.SCROLLINFO si);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetScrollInfo(HandleRef hWnd, int fnBar, NativeMethodsR.SCROLLINFO si, bool redraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string libname);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool FreeLibrary(HandleRef hModule);

        public static IntPtr GetWindowLong(HandleRef hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return UnsafeNativeMethodsR.GetWindowLong32(hWnd, nIndex);
            return UnsafeNativeMethodsR.GetWindowLongPtr64(hWnd, nIndex);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);

        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, HandleRef dwNewLong)
        {
            if (IntPtr.Size == 4)
                return UnsafeNativeMethodsR.SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            return UnsafeNativeMethodsR.SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, NativeMethodsR.WndProc wndproc)
        {
            if (IntPtr.Size == 4)
                return UnsafeNativeMethodsR.SetWindowLongPtr32(hWnd, nIndex, wndproc);
            return UnsafeNativeMethodsR.SetWindowLongPtr64(hWnd, nIndex, wndproc);
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, NativeMethodsR.WndProc wndproc);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, NativeMethodsR.WndProc wndproc);

        [DllImport("ole32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.ILockBytes CreateILockBytesOnHGlobal(HandleRef hGlobal, bool fDeleteOnRelease);

        [DllImport("ole32.dll", PreserveSig = false)]
        public static extern UnsafeNativeMethodsR.IStorage StgCreateDocfileOnILockBytes(UnsafeNativeMethodsR.ILockBytes iLockBytes, int grfMode, int reserved);

        [DllImport("user32.dll", EntryPoint = "CreatePopupMenu", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreatePopupMenu();

        public static IntPtr CreatePopupMenu()
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreatePopupMenu(), NativeMethodsR.CommonHandles.Menu);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool RemoveMenu(HandleRef hMenu, int uPosition, int uFlags);

        [DllImport("user32.dll", EntryPoint = "DestroyMenu", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyMenu(HandleRef hMenu);

        public static bool DestroyMenu(HandleRef hMenu)
        {
            HandleCollectorR.Remove((IntPtr)hMenu, NativeMethodsR.CommonHandles.Menu);
            return UnsafeNativeMethodsR.IntDestroyMenu(hMenu);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetSystemMenu(HandleRef hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefFrameProc(IntPtr hWnd, IntPtr hWndClient, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMDISysAccel(IntPtr hWndClient, [In, Out] ref NativeMethodsR.MSG msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(HandleRef hwnd, int crKey, byte bAlpha, int dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetMenu(HandleRef hWnd, HandleRef hMenu);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowPlacement(HandleRef hWnd, ref NativeMethodsR.WINDOWPLACEMENT placement);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetStartupInfo([In, Out] NativeMethodsR.STARTUPINFO_I startupinfo_i);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetMenuDefaultItem(HandleRef hwnd, int nIndex, bool pos);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnableMenuItem(HandleRef hMenu, int UIDEnabledItem, int uEnable);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow(HandleRef hWnd);

        [DllImport("gdi32.dll", EntryPoint = "CreateIC", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef lpInitData);

        public static IntPtr CreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef lpInitData)
        {
            return HandleCollectorR.Add(UnsafeNativeMethodsR.IntCreateIC(lpszDriverName, lpszDeviceName, lpszOutput, lpInitData), NativeMethodsR.CommonHandles.HDC);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClipCursor(ref NativeMethodsR.RECT rcClip);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClipCursor(NativeMethodsR.COMRECT rcClip);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(HandleRef hcursor);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowCursor(bool bShow);

        [DllImport("user32.dll", EntryPoint = "DestroyCursor", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyCursor(HandleRef hCurs);

        public static bool DestroyCursor(HandleRef hCurs)
        {
            HandleCollectorR.Remove((IntPtr)hCurs, NativeMethodsR.CommonHandles.Cursor);
            return UnsafeNativeMethodsR.IntDestroyCursor(hCurs);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindow(HandleRef hWnd);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IntDeleteDC(HandleRef hDC);

        public static bool DeleteDC(HandleRef hDC)
        {
            HandleCollectorR.Remove((IntPtr)hDC, NativeMethodsR.CommonHandles.HDC);
            return UnsafeNativeMethodsR.IntDeleteDC(hDC);
        }

        public static bool DeleteCompatibleDC(HandleRef hDC)
        {
            HandleCollectorR.Remove((IntPtr)hDC, NativeMethodsR.CommonHandles.CompatibleHDC);
            return UnsafeNativeMethodsR.IntDeleteDC(hDC);
        }

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern bool GetMessageA([In, Out] ref NativeMethodsR.MSG msg, HandleRef hWnd, int uMsgFilterMin, int uMsgFilterMax);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetMessageW([In, Out] ref NativeMethodsR.MSG msg, HandleRef hWnd, int uMsgFilterMin, int uMsgFilterMax);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref NativeMethodsR.RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(HandleRef hWnd, IntPtr rect);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto)]
        private static extern IntPtr _WindowFromPoint(UnsafeNativeMethodsR.POINTSTRUCT pt);

        public static IntPtr WindowFromPoint(int x, int y)
        {
            return UnsafeNativeMethodsR._WindowFromPoint(new UnsafeNativeMethodsR.POINTSTRUCT(x, y));
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr WindowFromDC(HandleRef hDC);

        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr IntCreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, HandleRef hWndParent, HandleRef hMenu, HandleRef hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);

        public static IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, HandleRef hWndParent, HandleRef hMenu, HandleRef hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam)
        {
            return UnsafeNativeMethodsR.IntCreateWindowEx(dwExStyle, lpszClassName, lpszWindowName, style, x, y, width, height, hWndParent, hMenu, hInst, pvParam);
        }

        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Auto)]
        public static extern bool IntDestroyWindow(HandleRef hWnd);

        public static bool DestroyWindow(HandleRef hWnd)
        {
            return UnsafeNativeMethodsR.IntDestroyWindow(hWnd);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnregisterClass(string className, HandleRef hInstance);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetStockObject(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern short RegisterClass(NativeMethodsR.WNDCLASS_D wc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void WaitMessage();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPlacement(HandleRef hWnd, [In] ref NativeMethodsR.WINDOWPLACEMENT placement);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetSystemPowerStatus([In, Out] ref NativeMethodsR.SYSTEM_POWER_STATUS systemPowerStatus);

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetRegionData(HandleRef hRgn, int size, IntPtr lpRgnData);

        public static unsafe NativeMethodsR.RECT[] GetRectsFromRegion(IntPtr hRgn)
        {
            NativeMethodsR.RECT[] rectArray = (NativeMethodsR.RECT[])null;
            IntPtr num1 = IntPtr.Zero;
            try
            {
                int regionData = UnsafeNativeMethodsR.GetRegionData(new HandleRef((object)null, hRgn), 0, IntPtr.Zero);
                if (regionData != 0)
                {
                    num1 = Marshal.AllocCoTaskMem(regionData);
                    if (UnsafeNativeMethodsR.GetRegionData(new HandleRef((object)null, hRgn), regionData, num1) == regionData)
                    {
                        NativeMethodsR.RGNDATAHEADER* rgndataheaderPtr = (NativeMethodsR.RGNDATAHEADER*)(void*)num1;
                        if (rgndataheaderPtr->iType == 1)
                        {
                            rectArray = new NativeMethodsR.RECT[rgndataheaderPtr->nCount];
                            int num2 = rgndataheaderPtr->cbSizeOfStruct;
                            //for (int index = 0; index < rgndataheaderPtr->nCount; ++index)
                              //  rectArray[index] = *(NativeMethodsR.RECT*)((IntPtr)(void*)num1 + num2 + (IntPtr)Marshal.SizeOf(typeof(NativeMethodsR.RECT)) * index);
                        }
                    }
                }
            }
            finally
            {
                if (num1 != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(num1);
            }
            return rectArray;
        }

        internal static bool IsComObject(object o)
        {
            return Marshal.IsComObject(o);
        }

        internal static int ReleaseComObject(object objToRelease)
        {
            return Marshal.ReleaseComObject(objToRelease);
        }

        [ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
        public static object PtrToStructure(IntPtr lparam, System.Type cls)
        {
            return Marshal.PtrToStructure(lparam, cls);
        }

        [ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
        public static void PtrToStructure(IntPtr lparam, object data)
        {
            Marshal.PtrToStructure(lparam, data);
        }

        internal static int SizeOf(System.Type t)
        {
            return Marshal.SizeOf(t);
        }

        internal static void ThrowExceptionForHR(int errorCode)
        {
            Marshal.ThrowExceptionForHR(errorCode);
        }

        [DllImport("clr.dll", CharSet = CharSet.Unicode, BestFitMapping = false, PreserveSig = false)]
        internal static extern void CorLaunchApplication(uint hostType, string applicationFullName, int manifestPathsCount, string[] manifestPaths, int activationDataCount, string[] activationData, UnsafeNativeMethodsR.PROCESS_INFORMATION processInformation);

        internal struct POINTSTRUCT
        {
            public int x;
            public int y;

            public POINTSTRUCT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000122-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleDropTarget
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleDragEnter([MarshalAs(UnmanagedType.Interface), In] object pDataObj, [MarshalAs(UnmanagedType.U4), In] int grfKeyState, [In] UnsafeNativeMethodsR.POINTSTRUCT pt, [In, Out] ref int pdwEffect);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleDragOver([MarshalAs(UnmanagedType.U4), In] int grfKeyState, [In] UnsafeNativeMethodsR.POINTSTRUCT pt, [In, Out] ref int pdwEffect);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleDragLeave();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleDrop([MarshalAs(UnmanagedType.Interface), In] object pDataObj, [MarshalAs(UnmanagedType.U4), In] int grfKeyState, [In] UnsafeNativeMethodsR.POINTSTRUCT pt, [In, Out] ref int pdwEffect);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B196B289-BAB4-101A-B69C-00AA00341D07")]
        [ComImport]
        public interface IOleControlSite
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnControlInfoChanged();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int LockInPlaceActive(int fLock);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetExtendedControl([MarshalAs(UnmanagedType.IDispatch)] out object ppDisp);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int TransformCoords([In, Out] NativeMethodsR._POINTL pPtlHimetric, [In, Out] NativeMethodsR.tagPOINTF pPtfContainer, [MarshalAs(UnmanagedType.U4), In] int dwFlags);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int TranslateAccelerator([In] ref NativeMethodsR.MSG pMsg, [MarshalAs(UnmanagedType.U4), In] int grfModifiers);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnFocus(int fGotFocus);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ShowPropertyFrame();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000118-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleClientSite
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SaveObject();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMoniker([MarshalAs(UnmanagedType.U4), In] int dwAssign, [MarshalAs(UnmanagedType.U4), In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] out object moniker);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetContainer(out UnsafeNativeMethodsR.IOleContainer container);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ShowObject();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnShowWindow(int fShow);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int RequestNewObjectLayout();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000119-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleInPlaceSite
        {
            IntPtr GetWindow();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ContextSensitiveHelp(int fEnterMode);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CanInPlaceActivate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnInPlaceActivate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnUIActivate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetWindowContext([MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethodsR.IOleInPlaceFrame ppFrame, [MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethodsR.IOleInPlaceUIWindow ppDoc, [Out] NativeMethodsR.COMRECT lprcPosRect, [Out] NativeMethodsR.COMRECT lprcClipRect, [In, Out] NativeMethodsR.tagOIFI lpFrameInfo);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Scroll(NativeMethodsR.tagSIZE scrollExtant);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnUIDeactivate(int fUndoable);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnInPlaceDeactivate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DiscardUndoState();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DeactivateAndUndo();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnPosRectChange([In] NativeMethodsR.COMRECT lprcPosRect);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("742B0E01-14E6-101B-914E-00AA00300CAB")]
        [ComImport]
        public interface ISimpleFrameSite
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int PreMessageFilter(IntPtr hwnd, [MarshalAs(UnmanagedType.U4), In] int msg, IntPtr wp, IntPtr lp, [In, Out] ref IntPtr plResult, [MarshalAs(UnmanagedType.U4), In, Out] ref int pdwCookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int PostMessageFilter(IntPtr hwnd, [MarshalAs(UnmanagedType.U4), In] int msg, IntPtr wp, IntPtr lp, [In, Out] ref IntPtr plResult, [MarshalAs(UnmanagedType.U4), In] int dwCookie);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("40A050A0-3C31-101B-A82E-08002B2B2337")]
        [ComImport]
        public interface IVBGetControl
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumControls(int dwOleContF, int dwWhich, out UnsafeNativeMethodsR.IEnumUnknown ppenum);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("91733A60-3F4C-101B-A3F6-00AA0034E4E9")]
        [ComImport]
        public interface IGetVBAObject
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetObject([In] ref Guid riid, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.IVBFormat[] rval, int dwReserved);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07")]
        [ComImport]
        public interface IPropertyNotifySink
        {
            void OnChanged(int dispID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnRequestEdit(int dispID);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("9849FD60-3768-101B-8D72-AE6164FFE3CF")]
        [ComImport]
        public interface IVBFormat
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Format([In] ref object var, IntPtr pszFormat, IntPtr lpBuffer, short cpBuffer, int lcid, short firstD, short firstW, [MarshalAs(UnmanagedType.LPArray), Out] short[] result);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000100-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IEnumUnknown
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Next([MarshalAs(UnmanagedType.U4), In] int celt, [Out] IntPtr rgelt, IntPtr pceltFetched);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Skip([MarshalAs(UnmanagedType.U4), In] int celt);

            void Reset();

            void Clone(out UnsafeNativeMethodsR.IEnumUnknown ppenum);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000011B-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleContainer
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ParseDisplayName([MarshalAs(UnmanagedType.Interface), In] object pbc, [MarshalAs(UnmanagedType.BStr), In] string pszDisplayName, [MarshalAs(UnmanagedType.LPArray), Out] int[] pchEaten, [MarshalAs(UnmanagedType.LPArray), Out] object[] ppmkOut);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumObjects([MarshalAs(UnmanagedType.U4), In] int grfFlags, out UnsafeNativeMethodsR.IEnumUnknown ppenum);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int LockContainer(bool fLock);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000116-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleInPlaceFrame
        {
            IntPtr GetWindow();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ContextSensitiveHelp(int fEnterMode);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetBorder([Out] NativeMethodsR.COMRECT lprectBorder);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int RequestBorderSpace([In] NativeMethodsR.COMRECT pborderwidths);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetBorderSpace([In] NativeMethodsR.COMRECT pborderwidths);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetActiveObject([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr), In] string pszObjName);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int InsertMenus([In] IntPtr hmenuShared, [In, Out] NativeMethodsR.tagOleMenuGroupWidths lpMenuWidths);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetMenu([In] IntPtr hmenuShared, [In] IntPtr holemenu, [In] IntPtr hwndActiveObject);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int RemoveMenus([In] IntPtr hmenuShared);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetStatusText([MarshalAs(UnmanagedType.LPWStr), In] string pszStatusText);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnableModeless(bool fEnable);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int TranslateAccelerator([In] ref NativeMethodsR.MSG lpmsg, [MarshalAs(UnmanagedType.U2), In] short wID);
        }

        [Guid("BD3F23C0-D43E-11CF-893B-00AA00BDCE1A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComVisible(true)]
        [ComImport]
        public interface IDocHostUIHandler
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int ShowContextMenu([MarshalAs(UnmanagedType.U4), In] int dwID, [In] NativeMethodsR.POINT pt, [MarshalAs(UnmanagedType.Interface), In] object pcmdtReserved, [MarshalAs(UnmanagedType.Interface), In] object pdispReserved);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int GetHostInfo([In, Out] NativeMethodsR.DOCHOSTUIINFO info);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int ShowUI([MarshalAs(UnmanagedType.I4), In] int dwID, [In] UnsafeNativeMethodsR.IOleInPlaceActiveObject activeObject, [In] NativeMethodsR.IOleCommandTarget commandTarget, [In] UnsafeNativeMethodsR.IOleInPlaceFrame frame, [In] UnsafeNativeMethodsR.IOleInPlaceUIWindow doc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int HideUI();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int UpdateUI();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int EnableModeless([MarshalAs(UnmanagedType.Bool), In] bool fEnable);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int OnDocWindowActivate([MarshalAs(UnmanagedType.Bool), In] bool fActivate);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int OnFrameWindowActivate([MarshalAs(UnmanagedType.Bool), In] bool fActivate);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int ResizeBorder([In] NativeMethodsR.COMRECT rect, [In] UnsafeNativeMethodsR.IOleInPlaceUIWindow doc, bool fFrameWindow);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int TranslateAccelerator([In] ref NativeMethodsR.MSG msg, [In] ref Guid group, [MarshalAs(UnmanagedType.I4), In] int nCmdID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int GetOptionKeyPath([MarshalAs(UnmanagedType.LPArray), Out] string[] pbstrKey, [MarshalAs(UnmanagedType.U4), In] int dw);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int GetDropTarget([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleDropTarget pDropTarget, [MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethodsR.IOleDropTarget ppDropTarget);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int GetExternal([MarshalAs(UnmanagedType.Interface)] out object ppDispatch);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int TranslateUrl([MarshalAs(UnmanagedType.U4), In] int dwTranslate, [MarshalAs(UnmanagedType.LPWStr), In] string strURLIn, [MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int FilterDataObject(System.Runtime.InteropServices.ComTypes.IDataObject pDO, out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden | TypeLibTypeFlags.FDual | TypeLibTypeFlags.FOleAutomation)]
        [SuppressUnmanagedCodeSecurity]
        [Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E")]
        [ComImport]
        public interface IWebBrowser2
        {
            [DispId(200)]
            object Application { get; }

            [DispId(201)]
            object Parent { get; }

            [DispId(202)]
            object Container { get; }

            [DispId(203)]
            object Document { get; }

            [DispId(204)]
            bool TopLevelContainer { get; }

            [DispId(205)]
            string Type { get; }

            [DispId(206)]
            int Left { get; set; }

            [DispId(207)]
            int Top { get; set; }

            [DispId(208)]
            int Width { get; set; }

            [DispId(209)]
            int Height { get; set; }

            [DispId(210)]
            string LocationName { get; }

            [DispId(211)]
            string LocationURL { get; }

            [DispId(212)]
            bool Busy { get; }

            [DispId(0)]
            string Name { get; }

            [DispId(-515)]
            int HWND { get; }

            [DispId(400)]
            string FullName { get; }

            [DispId(401)]
            string Path { get; }

            [DispId(402)]
            bool Visible { get; set; }

            [DispId(403)]
            bool StatusBar { get; set; }

            [DispId(404)]
            string StatusText { get; set; }

            [DispId(405)]
            int ToolBar { get; set; }

            [DispId(406)]
            bool MenuBar { get; set; }

            [DispId(407)]
            bool FullScreen { get; set; }

            [DispId(-525)]
            WebBrowserReadyState ReadyState { get; }

            [DispId(550)]
            bool Offline { get; set; }

            [DispId(551)]
            bool Silent { get; set; }

            [DispId(552)]
            bool RegisterAsBrowser { get; set; }

            [DispId(553)]
            bool RegisterAsDropTarget { get; set; }

            [DispId(554)]
            bool TheaterMode { get; set; }

            [DispId(555)]
            bool AddressBar { get; set; }

            [DispId(556)]
            bool Resizable { get; set; }

            [DispId(100)]
            void GoBack();

            [DispId(101)]
            void GoForward();

            [DispId(102)]
            void GoHome();

            [DispId(103)]
            void GoSearch();

            [DispId(104)]
            void Navigate([In] string Url, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);

            [DispId(-550)]
            void Refresh();

            [DispId(105)]
            void Refresh2([In] ref object level);

            [DispId(106)]
            void Stop();

            [DispId(300)]
            void Quit();

            [DispId(301)]
            void ClientToWindow(out int pcx, out int pcy);

            [DispId(302)]
            void PutProperty([In] string property, [In] object vtValue);

            [DispId(303)]
            object GetProperty([In] string property);

            [DispId(500)]
            void Navigate2([In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);

            [DispId(501)]
            NativeMethodsR.OLECMDF QueryStatusWB([In] NativeMethodsR.OLECMDID cmdID);

            [DispId(502)]
            void ExecWB([In] NativeMethodsR.OLECMDID cmdID, [In] NativeMethodsR.OLECMDEXECOPT cmdexecopt, ref object pvaIn, IntPtr pvaOut);

            [DispId(503)]
            void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
        [ComImport]
        public interface DWebBrowserEvents2
        {
            [DispId(102)]
            void StatusTextChange([In] string text);

            [DispId(108)]
            void ProgressChange([In] int progress, [In] int progressMax);

            [DispId(105)]
            void CommandStateChange([In] long command, [In] bool enable);

            [DispId(106)]
            void DownloadBegin();

            [DispId(104)]
            void DownloadComplete();

            [DispId(113)]
            void TitleChange([In] string text);

            [DispId(112)]
            void PropertyChange([In] string szProperty);

            [DispId(250)]
            void BeforeNavigate2([MarshalAs(UnmanagedType.IDispatch), In] object pDisp, [In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers, [In, Out] ref bool cancel);

            [DispId(251)]
            void NewWindow2([MarshalAs(UnmanagedType.IDispatch), In, Out] ref object pDisp, [In, Out] ref bool cancel);

            [DispId(252)]
            void NavigateComplete2([MarshalAs(UnmanagedType.IDispatch), In] object pDisp, [In] ref object URL);

            [DispId(259)]
            void DocumentComplete([MarshalAs(UnmanagedType.IDispatch), In] object pDisp, [In] ref object URL);

            [DispId(253)]
            void OnQuit();

            [DispId(254)]
            void OnVisible([In] bool visible);

            [DispId(255)]
            void OnToolBar([In] bool toolBar);

            [DispId(256)]
            void OnMenuBar([In] bool menuBar);

            [DispId(257)]
            void OnStatusBar([In] bool statusBar);

            [DispId(258)]
            void OnFullScreen([In] bool fullScreen);

            [DispId(260)]
            void OnTheaterMode([In] bool theaterMode);

            [DispId(262)]
            void WindowSetResizable([In] bool resizable);

            [DispId(264)]
            void WindowSetLeft([In] int left);

            [DispId(265)]
            void WindowSetTop([In] int top);

            [DispId(266)]
            void WindowSetWidth([In] int width);

            [DispId(267)]
            void WindowSetHeight([In] int height);

            [DispId(263)]
            void WindowClosing([In] bool isChildWindow, [In, Out] ref bool cancel);

            [DispId(268)]
            void ClientToHostWindow([In, Out] ref long cx, [In, Out] ref long cy);

            [DispId(269)]
            void SetSecureLockIcon([In] int secureLockIcon);

            [DispId(270)]
            void FileDownload([In, Out] ref bool cancel);

            [DispId(271)]
            void NavigateError([MarshalAs(UnmanagedType.IDispatch), In] object pDisp, [In] ref object URL, [In] ref object frame, [In] ref object statusCode, [In, Out] ref bool cancel);

            [DispId(225)]
            void PrintTemplateInstantiation([MarshalAs(UnmanagedType.IDispatch), In] object pDisp);

            [DispId(226)]
            void PrintTemplateTeardown([MarshalAs(UnmanagedType.IDispatch), In] object pDisp);

            [DispId(227)]
            void UpdatePageStatus([MarshalAs(UnmanagedType.IDispatch), In] object pDisp, [In] ref object nPage, [In] ref object fDone);

            [DispId(272)]
            void PrivacyImpactedStateChange([In] bool bImpacted);
        }

        [SuppressUnmanagedCodeSecurity]
        [Guid("332C4425-26CB-11D0-B483-00C04FD90119")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        internal interface IHTMLDocument2
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetScript();

            UnsafeNativeMethodsR.IHTMLElementCollection GetAll();

            UnsafeNativeMethodsR.IHTMLElement GetBody();

            UnsafeNativeMethodsR.IHTMLElement GetActiveElement();

            UnsafeNativeMethodsR.IHTMLElementCollection GetImages();

            UnsafeNativeMethodsR.IHTMLElementCollection GetApplets();

            UnsafeNativeMethodsR.IHTMLElementCollection GetLinks();

            UnsafeNativeMethodsR.IHTMLElementCollection GetForms();

            UnsafeNativeMethodsR.IHTMLElementCollection GetAnchors();

            void SetTitle(string p);

            string GetTitle();

            UnsafeNativeMethodsR.IHTMLElementCollection GetScripts();

            void SetDesignMode(string p);

            string GetDesignMode();

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetSelection();

            string GetReadyState();

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetFrames();

            UnsafeNativeMethodsR.IHTMLElementCollection GetEmbeds();

            UnsafeNativeMethodsR.IHTMLElementCollection GetPlugins();

            void SetAlinkColor(object c);

            object GetAlinkColor();

            void SetBgColor(object c);

            object GetBgColor();

            void SetFgColor(object c);

            object GetFgColor();

            void SetLinkColor(object c);

            object GetLinkColor();

            void SetVlinkColor(object c);

            object GetVlinkColor();

            string GetReferrer();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLLocation GetLocation();

            string GetLastModified();

            void SetUrl(string p);

            string GetUrl();

            void SetDomain(string p);

            string GetDomain();

            void SetCookie(string p);

            string GetCookie();

            void SetExpando(bool p);

            bool GetExpando();

            void SetCharset(string p);

            string GetCharset();

            void SetDefaultCharset(string p);

            string GetDefaultCharset();

            string GetMimeType();

            string GetFileSize();

            string GetFileCreatedDate();

            string GetFileModifiedDate();

            string GetFileUpdatedDate();

            string GetSecurity();

            string GetProtocol();

            string GetNameProp();

            int Write([MarshalAs(UnmanagedType.SafeArray), In] object[] psarray);

            int WriteLine([MarshalAs(UnmanagedType.SafeArray), In] object[] psarray);

            [return: MarshalAs(UnmanagedType.Interface)]
            object Open(string mimeExtension, object name, object features, object replace);

            void Close();

            void Clear();

            bool QueryCommandSupported(string cmdID);

            bool QueryCommandEnabled(string cmdID);

            bool QueryCommandState(string cmdID);

            bool QueryCommandIndeterm(string cmdID);

            string QueryCommandText(string cmdID);

            object QueryCommandValue(string cmdID);

            bool ExecCommand(string cmdID, bool showUI, object value);

            bool ExecCommandShowHelp(string cmdID);

            UnsafeNativeMethodsR.IHTMLElement CreateElement(string eTag);

            void SetOnhelp(object p);

            object GetOnhelp();

            void SetOnclick(object p);

            object GetOnclick();

            void SetOndblclick(object p);

            object GetOndblclick();

            void SetOnkeyup(object p);

            object GetOnkeyup();

            void SetOnkeydown(object p);

            object GetOnkeydown();

            void SetOnkeypress(object p);

            object GetOnkeypress();

            void SetOnmouseup(object p);

            object GetOnmouseup();

            void SetOnmousedown(object p);

            object GetOnmousedown();

            void SetOnmousemove(object p);

            object GetOnmousemove();

            void SetOnmouseout(object p);

            object GetOnmouseout();

            void SetOnmouseover(object p);

            object GetOnmouseover();

            void SetOnreadystatechange(object p);

            object GetOnreadystatechange();

            void SetOnafterupdate(object p);

            object GetOnafterupdate();

            void SetOnrowexit(object p);

            object GetOnrowexit();

            void SetOnrowenter(object p);

            object GetOnrowenter();

            void SetOndragstart(object p);

            object GetOndragstart();

            void SetOnselectstart(object p);

            object GetOnselectstart();

            UnsafeNativeMethodsR.IHTMLElement ElementFromPoint(int x, int y);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLWindow2 GetParentWindow();

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetStyleSheets();

            void SetOnbeforeupdate(object p);

            object GetOnbeforeupdate();

            void SetOnerrorupdate(object p);

            object GetOnerrorupdate();

            string toString();

            [return: MarshalAs(UnmanagedType.Interface)]
            object CreateStyleSheet(string bstrHref, int lIndex);
        }

        [ComVisible(true)]
        [Guid("332C4426-26CB-11D0-B483-00C04FD90119")]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        internal interface IHTMLFramesCollection2
        {
            object Item(ref object idOrName);

            int GetLength();
        }

        [Guid("332C4427-26CB-11D0-B483-00C04FD90119")]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        public interface IHTMLWindow2
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object Item([In] ref object pvarIndex);

            int GetLength();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLFramesCollection2 GetFrames();

            void SetDefaultStatus([In] string p);

            string GetDefaultStatus();

            void SetStatus([In] string p);

            string GetStatus();

            int SetTimeout([In] string expression, [In] int msec, [In] ref object language);

            void ClearTimeout([In] int timerID);

            void Alert([In] string message);

            bool Confirm([In] string message);

            [return: MarshalAs(UnmanagedType.Struct)]
            object Prompt([In] string message, [In] string defstr);

            object GetImage();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLLocation GetLocation();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IOmHistory GetHistory();

            void Close();

            void SetOpener([In] object p);

            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetOpener();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IOmNavigator GetNavigator();

            void SetName([In] string p);

            string GetName();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLWindow2 GetParent();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLWindow2 Open([In] string URL, [In] string name, [In] string features, [In] bool replace);

            object GetSelf();

            object GetTop();

            object GetWindow();

            void Navigate([In] string URL);

            void SetOnfocus([In] object p);

            object GetOnfocus();

            void SetOnblur([In] object p);

            object GetOnblur();

            void SetOnload([In] object p);

            object GetOnload();

            void SetOnbeforeunload(object p);

            object GetOnbeforeunload();

            void SetOnunload([In] object p);

            object GetOnunload();

            void SetOnhelp(object p);

            object GetOnhelp();

            void SetOnerror([In] object p);

            object GetOnerror();

            void SetOnresize([In] object p);

            object GetOnresize();

            void SetOnscroll([In] object p);

            object GetOnscroll();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLDocument2 GetDocument();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLEventObj GetEvent();

            object Get_newEnum();

            object ShowModalDialog([In] string dialog, [In] ref object varArgIn, [In] ref object varOptions);

            void ShowHelp([In] string helpURL, [In] object helpArg, [In] string features);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLScreen GetScreen();

            object GetOption();

            void Focus();

            bool GetClosed();

            void Blur();

            void Scroll([In] int x, [In] int y);

            object GetClientInformation();

            int SetInterval([In] string expression, [In] int msec, [In] ref object language);

            void ClearInterval([In] int timerID);

            void SetOffscreenBuffering([In] object p);

            object GetOffscreenBuffering();

            [return: MarshalAs(UnmanagedType.Struct)]
            object ExecScript([In] string code, [In] string language);

            string toString();

            void ScrollBy([In] int x, [In] int y);

            void ScrollTo([In] int x, [In] int y);

            void MoveTo([In] int x, [In] int y);

            void MoveBy([In] int x, [In] int y);

            void ResizeTo([In] int x, [In] int y);

            void ResizeBy([In] int x, [In] int y);

            object GetExternal();
        }

        [ComVisible(true)]
        [Guid("3050f35c-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        public interface IHTMLScreen
        {
            int GetColorDepth();

            void SetBufferDepth(int d);

            int GetBufferDepth();

            int GetWidth();

            int GetHeight();

            void SetUpdateInterval(int i);

            int GetUpdateInterval();

            int GetAvailHeight();

            int GetAvailWidth();

            bool GetFontSmoothingEnabled();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("163BB1E0-6E00-11CF-837A-48DC04C10000")]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        internal interface IHTMLLocation
        {
            void SetHref([In] string p);

            string GetHref();

            void SetProtocol([In] string p);

            string GetProtocol();

            void SetHost([In] string p);

            string GetHost();

            void SetHostname([In] string p);

            string GetHostname();

            void SetPort([In] string p);

            string GetPort();

            void SetPathname([In] string p);

            string GetPathname();

            void SetSearch([In] string p);

            string GetSearch();

            void SetHash([In] string p);

            string GetHash();

            void Reload([In] bool flag);

            void Replace([In] string bstr);

            void Assign([In] string bstr);
        }

        [Guid("FECEAAA2-8405-11CF-8BA1-00AA00476DA6")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        internal interface IOmHistory
        {
            short GetLength();

            void Back();

            void Forward();

            void Go([In] ref object pvargdistance);
        }

        [Guid("FECEAAA5-8405-11CF-8BA1-00AA00476DA6")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        internal interface IOmNavigator
        {
            string GetAppCodeName();

            string GetAppName();

            string GetAppVersion();

            string GetUserAgent();

            bool JavaEnabled();

            bool TaintEnabled();

            object GetMimeTypes();

            object GetPlugins();

            bool GetCookieEnabled();

            object GetOpsProfile();

            string GetCpuClass();

            string GetSystemLanguage();

            string GetBrowserLanguage();

            string GetUserLanguage();

            string GetPlatform();

            string GetAppMinorVersion();

            int GetConnectionSpeed();

            bool GetOnLine();

            object GetUserProfile();
        }

        [ComVisible(true)]
        [Guid("3050F32D-98B5-11CF-BB82-00AA00BDCE0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        internal interface IHTMLEventObj
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetSrcElement();

            bool GetAltKey();

            bool GetCtrlKey();

            bool GetShiftKey();

            void SetReturnValue(object p);

            object GetReturnValue();

            void SetCancelBubble(bool p);

            bool GetCancelBubble();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetFromElement();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetToElement();

            void SetKeyCode([In] int p);

            int GetKeyCode();

            int GetButton();

            string GetEventType();

            string GetQualifier();

            int GetReason();

            int GetX();

            int GetY();

            int GetClientX();

            int GetClientY();

            int GetOffsetX();

            int GetOffsetY();

            int GetScreenX();

            int GetScreenY();

            object GetSrcFilter();
        }

        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        [Guid("3050F21F-98B5-11CF-BB82-00AA00BDCE0B")]
        internal interface IHTMLElementCollection
        {
            string toString();

            void SetLength(int p);

            int GetLength();

            [return: MarshalAs(UnmanagedType.Interface)]
            object Get_newEnum();

            [return: MarshalAs(UnmanagedType.IDispatch)]
            object Item(object idOrName, object index);

            [return: MarshalAs(UnmanagedType.Interface)]
            object Tags(object tagName);
        }

        [SuppressUnmanagedCodeSecurity]
        [Guid("3050F1FF-98B5-11CF-BB82-00AA00BDCE0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        internal interface IHTMLElement
        {
            void SetAttribute(string attributeName, object attributeValue, int lFlags);

            object GetAttribute(string attributeName, int lFlags);

            bool RemoveAttribute(string strAttributeName, int lFlags);

            void SetClassName(string p);

            string GetClassName();

            void SetId(string p);

            string GetId();

            string GetTagName();

            UnsafeNativeMethodsR.IHTMLElement GetParentElement();

            UnsafeNativeMethodsR.IHTMLStyle GetStyle();

            void SetOnhelp(object p);

            object GetOnhelp();

            void SetOnclick(object p);

            object GetOnclick();

            void SetOndblclick(object p);

            object GetOndblclick();

            void SetOnkeydown(object p);

            object GetOnkeydown();

            void SetOnkeyup(object p);

            object GetOnkeyup();

            void SetOnkeypress(object p);

            object GetOnkeypress();

            void SetOnmouseout(object p);

            object GetOnmouseout();

            void SetOnmouseover(object p);

            object GetOnmouseover();

            void SetOnmousemove(object p);

            object GetOnmousemove();

            void SetOnmousedown(object p);

            object GetOnmousedown();

            void SetOnmouseup(object p);

            object GetOnmouseup();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLDocument2 GetDocument();

            void SetTitle(string p);

            string GetTitle();

            void SetLanguage(string p);

            string GetLanguage();

            void SetOnselectstart(object p);

            object GetOnselectstart();

            void ScrollIntoView(object varargStart);

            bool Contains(UnsafeNativeMethodsR.IHTMLElement pChild);

            int GetSourceIndex();

            object GetRecordNumber();

            void SetLang(string p);

            string GetLang();

            int GetOffsetLeft();

            int GetOffsetTop();

            int GetOffsetWidth();

            int GetOffsetHeight();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetOffsetParent();

            void SetInnerHTML(string p);

            string GetInnerHTML();

            void SetInnerText(string p);

            string GetInnerText();

            void SetOuterHTML(string p);

            string GetOuterHTML();

            void SetOuterText(string p);

            string GetOuterText();

            void InsertAdjacentHTML(string where, string html);

            void InsertAdjacentText(string where, string text);

            UnsafeNativeMethodsR.IHTMLElement GetParentTextEdit();

            bool GetIsTextEdit();

            void Click();

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetFilters();

            void SetOndragstart(object p);

            object GetOndragstart();

            string toString();

            void SetOnbeforeupdate(object p);

            object GetOnbeforeupdate();

            void SetOnafterupdate(object p);

            object GetOnafterupdate();

            void SetOnerrorupdate(object p);

            object GetOnerrorupdate();

            void SetOnrowexit(object p);

            object GetOnrowexit();

            void SetOnrowenter(object p);

            object GetOnrowenter();

            void SetOndatasetchanged(object p);

            object GetOndatasetchanged();

            void SetOndataavailable(object p);

            object GetOndataavailable();

            void SetOndatasetcomplete(object p);

            object GetOndatasetcomplete();

            void SetOnfilterchange(object p);

            object GetOnfilterchange();

            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetChildren();

            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetAll();
        }

        [SuppressUnmanagedCodeSecurity]
        [Guid("3050F25E-98B5-11CF-BB82-00AA00BDCE0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        internal interface IHTMLStyle
        {
            void SetFontFamily(string p);

            string GetFontFamily();

            void SetFontStyle(string p);

            string GetFontStyle();

            void SetFontObject(string p);

            string GetFontObject();

            void SetFontWeight(string p);

            string GetFontWeight();

            void SetFontSize(object p);

            object GetFontSize();

            void SetFont(string p);

            string GetFont();

            void SetColor(object p);

            object GetColor();

            void SetBackground(string p);

            string GetBackground();

            void SetBackgroundColor(object p);

            object GetBackgroundColor();

            void SetBackgroundImage(string p);

            string GetBackgroundImage();

            void SetBackgroundRepeat(string p);

            string GetBackgroundRepeat();

            void SetBackgroundAttachment(string p);

            string GetBackgroundAttachment();

            void SetBackgroundPosition(string p);

            string GetBackgroundPosition();

            void SetBackgroundPositionX(object p);

            object GetBackgroundPositionX();

            void SetBackgroundPositionY(object p);

            object GetBackgroundPositionY();

            void SetWordSpacing(object p);

            object GetWordSpacing();

            void SetLetterSpacing(object p);

            object GetLetterSpacing();

            void SetTextDecoration(string p);

            string GetTextDecoration();

            void SetTextDecorationNone(bool p);

            bool GetTextDecorationNone();

            void SetTextDecorationUnderline(bool p);

            bool GetTextDecorationUnderline();

            void SetTextDecorationOverline(bool p);

            bool GetTextDecorationOverline();

            void SetTextDecorationLineThrough(bool p);

            bool GetTextDecorationLineThrough();

            void SetTextDecorationBlink(bool p);

            bool GetTextDecorationBlink();

            void SetVerticalAlign(object p);

            object GetVerticalAlign();

            void SetTextTransform(string p);

            string GetTextTransform();

            void SetTextAlign(string p);

            string GetTextAlign();

            void SetTextIndent(object p);

            object GetTextIndent();

            void SetLineHeight(object p);

            object GetLineHeight();

            void SetMarginTop(object p);

            object GetMarginTop();

            void SetMarginRight(object p);

            object GetMarginRight();

            void SetMarginBottom(object p);

            object GetMarginBottom();

            void SetMarginLeft(object p);

            object GetMarginLeft();

            void SetMargin(string p);

            string GetMargin();

            void SetPaddingTop(object p);

            object GetPaddingTop();

            void SetPaddingRight(object p);

            object GetPaddingRight();

            void SetPaddingBottom(object p);

            object GetPaddingBottom();

            void SetPaddingLeft(object p);

            object GetPaddingLeft();

            void SetPadding(string p);

            string GetPadding();

            void SetBorder(string p);

            string GetBorder();

            void SetBorderTop(string p);

            string GetBorderTop();

            void SetBorderRight(string p);

            string GetBorderRight();

            void SetBorderBottom(string p);

            string GetBorderBottom();

            void SetBorderLeft(string p);

            string GetBorderLeft();

            void SetBorderColor(string p);

            string GetBorderColor();

            void SetBorderTopColor(object p);

            object GetBorderTopColor();

            void SetBorderRightColor(object p);

            object GetBorderRightColor();

            void SetBorderBottomColor(object p);

            object GetBorderBottomColor();

            void SetBorderLeftColor(object p);

            object GetBorderLeftColor();

            void SetBorderWidth(string p);

            string GetBorderWidth();

            void SetBorderTopWidth(object p);

            object GetBorderTopWidth();

            void SetBorderRightWidth(object p);

            object GetBorderRightWidth();

            void SetBorderBottomWidth(object p);

            object GetBorderBottomWidth();

            void SetBorderLeftWidth(object p);

            object GetBorderLeftWidth();

            void SetBorderStyle(string p);

            string GetBorderStyle();

            void SetBorderTopStyle(string p);

            string GetBorderTopStyle();

            void SetBorderRightStyle(string p);

            string GetBorderRightStyle();

            void SetBorderBottomStyle(string p);

            string GetBorderBottomStyle();

            void SetBorderLeftStyle(string p);

            string GetBorderLeftStyle();

            void SetWidth(object p);

            object GetWidth();

            void SetHeight(object p);

            object GetHeight();

            void SetStyleFloat(string p);

            string GetStyleFloat();

            void SetClear(string p);

            string GetClear();

            void SetDisplay(string p);

            string GetDisplay();

            void SetVisibility(string p);

            string GetVisibility();

            void SetListStyleType(string p);

            string GetListStyleType();

            void SetListStylePosition(string p);

            string GetListStylePosition();

            void SetListStyleImage(string p);

            string GetListStyleImage();

            void SetListStyle(string p);

            string GetListStyle();

            void SetWhiteSpace(string p);

            string GetWhiteSpace();

            void SetTop(object p);

            object GetTop();

            void SetLeft(object p);

            object GetLeft();

            string GetPosition();

            void SetZIndex(object p);

            object GetZIndex();

            void SetOverflow(string p);

            string GetOverflow();

            void SetPageBreakBefore(string p);

            string GetPageBreakBefore();

            void SetPageBreakAfter(string p);

            string GetPageBreakAfter();

            void SetCssText(string p);

            string GetCssText();

            void SetPixelTop(int p);

            int GetPixelTop();

            void SetPixelLeft(int p);

            int GetPixelLeft();

            void SetPixelWidth(int p);

            int GetPixelWidth();

            void SetPixelHeight(int p);

            int GetPixelHeight();

            void SetPosTop(float p);

            float GetPosTop();

            void SetPosLeft(float p);

            float GetPosLeft();

            void SetPosWidth(float p);

            float GetPosWidth();

            void SetPosHeight(float p);

            float GetPosHeight();

            void SetCursor(string p);

            string GetCursor();

            void SetClip(string p);

            string GetClip();

            void SetFilter(string p);

            string GetFilter();

            void SetAttribute(string strAttributeName, object AttributeValue, int lFlags);

            object GetAttribute(string strAttributeName, int lFlags);

            bool RemoveAttribute(string strAttributeName, int lFlags);
        }

        [Guid("00000115-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleInPlaceUIWindow
        {
            IntPtr GetWindow();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ContextSensitiveHelp(int fEnterMode);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetBorder([Out] NativeMethodsR.COMRECT lprectBorder);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int RequestBorderSpace([In] NativeMethodsR.COMRECT pborderwidths);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetBorderSpace([In] NativeMethodsR.COMRECT pborderwidths);

            void SetActiveObject([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr), In] string pszObjName);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [Guid("00000117-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleInPlaceActiveObject
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetWindow(out IntPtr hwnd);

            void ContextSensitiveHelp(int fEnterMode);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int TranslateAccelerator([In] ref NativeMethodsR.MSG lpmsg);

            void OnFrameWindowActivate(bool fActivate);

            void OnDocWindowActivate(int fActivate);

            void ResizeBorder([In] NativeMethodsR.COMRECT prcBorder, [In] UnsafeNativeMethodsR.IOleInPlaceUIWindow pUIWindow, bool fFrameWindow);

            void EnableModeless(int fEnable);
        }

        [Guid("00000114-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleWindow
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetWindow(out IntPtr hwnd);

            void ContextSensitiveHelp(int fEnterMode);
        }

        [Guid("00000113-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [ComImport]
        public interface IOleInPlaceObject
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetWindow(out IntPtr hwnd);

            void ContextSensitiveHelp(int fEnterMode);

            void InPlaceDeactivate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int UIDeactivate();

            void SetObjectRects([In] NativeMethodsR.COMRECT lprcPosRect, [In] NativeMethodsR.COMRECT lprcClipRect);

            void ReactivateAndUndo();
        }

        [SuppressUnmanagedCodeSecurity]
        [Guid("00000112-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleObject
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetClientSite([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleClientSite pClientSite);

            UnsafeNativeMethodsR.IOleClientSite GetClientSite();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetHostNames([MarshalAs(UnmanagedType.LPWStr), In] string szContainerApp, [MarshalAs(UnmanagedType.LPWStr), In] string szContainerObj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Close(int dwSaveOption);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetMoniker([MarshalAs(UnmanagedType.U4), In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface), In] object pmk);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMoniker([MarshalAs(UnmanagedType.U4), In] int dwAssign, [MarshalAs(UnmanagedType.U4), In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] out object moniker);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int InitFromData([MarshalAs(UnmanagedType.Interface), In] System.Runtime.InteropServices.ComTypes.IDataObject pDataObject, int fCreation, [MarshalAs(UnmanagedType.U4), In] int dwReserved);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetClipboardData([MarshalAs(UnmanagedType.U4), In] int dwReserved, out System.Runtime.InteropServices.ComTypes.IDataObject data);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DoVerb(int iVerb, [In] IntPtr lpmsg, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, [In] NativeMethodsR.COMRECT lprcPosRect);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumVerbs(out UnsafeNativeMethodsR.IEnumOLEVERB e);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleUpdate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsUpToDate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetUserClassID([In, Out] ref Guid pClsid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetUserType([MarshalAs(UnmanagedType.U4), In] int dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string userType);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetExtent([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, [In] NativeMethodsR.tagSIZEL pSizel);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetExtent([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, [Out] NativeMethodsR.tagSIZEL pSizel);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Advise(IAdviseSink pAdvSink, out int cookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Unadvise([MarshalAs(UnmanagedType.U4), In] int dwConnection);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumAdvise(out IEnumSTATDATA e);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMiscStatus([MarshalAs(UnmanagedType.U4), In] int dwAspect, out int misc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetColorScheme([In] NativeMethodsR.tagLOGPALETTE pLogpal);
        }

        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B196B288-BAB4-101A-B69C-00AA00341D07")]
        [ComImport]
        public interface IOleControl
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetControlInfo([Out] NativeMethodsR.tagCONTROLINFO pCI);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnMnemonic([In] ref NativeMethodsR.MSG pMsg);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnAmbientPropertyChange(int dispID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int FreezeEvents(int bFreeze);
        }

        [Guid("0000010d-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IViewObject
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Draw([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsR.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] NativeMethodsR.COMRECT lprcBounds, [In] NativeMethodsR.COMRECT lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetColorSet([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsR.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, [Out] NativeMethodsR.tagLOGPALETTE ppColorSet);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Freeze([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Unfreeze([MarshalAs(UnmanagedType.U4), In] int dwFreeze);

            void SetAdvise([MarshalAs(UnmanagedType.U4), In] int aspects, [MarshalAs(UnmanagedType.U4), In] int advf, [MarshalAs(UnmanagedType.Interface), In] IAdviseSink pAdvSink);

            void GetAdvise([MarshalAs(UnmanagedType.LPArray), In, Out] int[] paspects, [MarshalAs(UnmanagedType.LPArray), In, Out] int[] advf, [MarshalAs(UnmanagedType.LPArray), In, Out] IAdviseSink[] pAdvSink);
        }

        [Guid("00000127-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IViewObject2
        {
            void Draw([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsR.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] NativeMethodsR.COMRECT lprcBounds, [In] NativeMethodsR.COMRECT lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetColorSet([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsR.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, [Out] NativeMethodsR.tagLOGPALETTE ppColorSet);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Freeze([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Unfreeze([MarshalAs(UnmanagedType.U4), In] int dwFreeze);

            void SetAdvise([MarshalAs(UnmanagedType.U4), In] int aspects, [MarshalAs(UnmanagedType.U4), In] int advf, [MarshalAs(UnmanagedType.Interface), In] IAdviseSink pAdvSink);

            void GetAdvise([MarshalAs(UnmanagedType.LPArray), In, Out] int[] paspects, [MarshalAs(UnmanagedType.LPArray), In, Out] int[] advf, [MarshalAs(UnmanagedType.LPArray), In, Out] IAdviseSink[] pAdvSink);

            void GetExtent([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, int lindex, [In] NativeMethodsR.tagDVTARGETDEVICE ptd, [Out] NativeMethodsR.tagSIZEL lpsizel);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000010C-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IPersist
        {
            [SuppressUnmanagedCodeSecurity]
            void GetClassID(out Guid pClassID);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("37D84F60-42CB-11CE-8135-00AA004BB851")]
        [ComImport]
        public interface IPersistPropertyBag
        {
            void GetClassID(out Guid pClassID);

            void InitNew();

            void Load([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IPropertyBag pPropBag, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IErrorLog pErrorLog);

            void Save([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IPropertyBag pPropBag, [MarshalAs(UnmanagedType.Bool), In] bool fClearDirty, [MarshalAs(UnmanagedType.Bool), In] bool fSaveAllProperties);
        }

        [Guid("CF51ED10-62FE-11CF-BF86-00A0C9034836")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IQuickActivate
        {
            void QuickActivate([In] UnsafeNativeMethodsR.tagQACONTAINER pQaContainer, [Out] UnsafeNativeMethodsR.tagQACONTROL pQaControl);

            void SetContentExtent([In] NativeMethodsR.tagSIZEL pSizel);

            void GetContentExtent([Out] NativeMethodsR.tagSIZEL pSizel);
        }

        [Guid("55272A00-42CB-11CE-8135-00AA004BB851")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IPropertyBag
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Read([MarshalAs(UnmanagedType.LPWStr), In] string pszPropName, [In, Out] ref object pVar, [In] UnsafeNativeMethodsR.IErrorLog pErrorLog);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Write([MarshalAs(UnmanagedType.LPWStr), In] string pszPropName, [In] ref object pVar);
        }

        [Guid("3127CA40-446E-11CE-8135-00AA004BB851")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IErrorLog
        {
            void AddError([MarshalAs(UnmanagedType.LPWStr), In] string pszPropName_p0, [MarshalAs(UnmanagedType.Struct), In] NativeMethodsR.tagEXCEPINFO pExcepInfo_p1);
        }

        [Guid("00000109-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IPersistStream
        {
            void GetClassID(out Guid pClassId);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsDirty();

            void Load([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm);

            void Save([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm, [MarshalAs(UnmanagedType.Bool), In] bool fClearDirty);

            long GetSizeMax();
        }

        [Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [ComImport]
        public interface IPersistStreamInit
        {
            void GetClassID(out Guid pClassID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsDirty();

            void Load([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm);

            void Save([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm, [MarshalAs(UnmanagedType.Bool), In] bool fClearDirty);

            void GetSizeMax([MarshalAs(UnmanagedType.LPArray), Out] long pcbSize);

            void InitNew();
        }

        [Guid("B196B286-BAB4-101A-B69C-00AA00341D07")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [ComImport]
        public interface IConnectionPoint
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetConnectionInterface(out Guid iid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetConnectionPointContainer([MarshalAs(UnmanagedType.Interface)] ref UnsafeNativeMethodsR.IConnectionPointContainer pContainer);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Advise([MarshalAs(UnmanagedType.Interface), In] object pUnkSink, ref int cookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Unadvise(int cookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumConnections(out object pEnum);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000010A-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IPersistStorage
        {
            void GetClassID(out Guid pClassID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsDirty();

            void InitNew(UnsafeNativeMethodsR.IStorage pstg);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Load(UnsafeNativeMethodsR.IStorage pstg);

            void Save(UnsafeNativeMethodsR.IStorage pStgSave, bool fSameAsLoad);

            void SaveCompleted(UnsafeNativeMethodsR.IStorage pStgNew);

            void HandsOffStorage();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00020404-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IEnumVariant
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Next([MarshalAs(UnmanagedType.U4), In] int celt, [In, Out] IntPtr rgvar, [MarshalAs(UnmanagedType.LPArray), Out] int[] pceltFetched);

            void Skip([MarshalAs(UnmanagedType.U4), In] int celt);

            void Reset();

            void Clone([MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.IEnumVariant[] ppenum);
        }

        [Guid("00000104-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IEnumOLEVERB
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Next([MarshalAs(UnmanagedType.U4)] int celt, [Out] NativeMethodsR.tagOLEVERB rgelt, [MarshalAs(UnmanagedType.LPArray), Out] int[] pceltFetched);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Skip([MarshalAs(UnmanagedType.U4), In] int celt);

            void Reset();

            void Clone(out UnsafeNativeMethodsR.IEnumOLEVERB ppenum);
        }

        [Guid("EAC04BC0-3791-11d2-BB95-0060977B464C")]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IAutoComplete2
        {
            int Init([In] HandleRef hwndEdit, [In] IEnumString punkACL, [In] string pwszRegKeyPath, [In] string pwszQuickComplete);

            void Enable([In] bool fEnable);

            int SetOptions([In] int dwFlag);

            void GetOptions([Out] IntPtr pdwFlag);
        }

        [Guid("0000000C-0000-0000-C000-000000000046")]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IStream
        {
            int Read(IntPtr buf, int len);

            int Write(IntPtr buf, int len);

            [return: MarshalAs(UnmanagedType.I8)]
            long Seek([MarshalAs(UnmanagedType.I8), In] long dlibMove, int dwOrigin);

            void SetSize([MarshalAs(UnmanagedType.I8), In] long libNewSize);

            [return: MarshalAs(UnmanagedType.I8)]
            long CopyTo([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm, [MarshalAs(UnmanagedType.I8), In] long cb, [MarshalAs(UnmanagedType.LPArray), Out] long[] pcbRead);

            void Commit(int grfCommitFlags);

            void Revert();

            void LockRegion([MarshalAs(UnmanagedType.I8), In] long libOffset, [MarshalAs(UnmanagedType.I8), In] long cb, int dwLockType);

            void UnlockRegion([MarshalAs(UnmanagedType.I8), In] long libOffset, [MarshalAs(UnmanagedType.I8), In] long cb, int dwLockType);

            void Stat([Out] NativeMethodsR.STATSTG pStatstg, int grfStatFlag);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IStream Clone();
        }

        public abstract class CharBuffer
        {
            public abstract IntPtr AllocCoTaskMem();

            public abstract string GetString();

            public abstract void PutCoTaskMem(IntPtr ptr);

            public abstract void PutString(string s);

            public static UnsafeNativeMethodsR.CharBuffer CreateBuffer(int size)
            {
                if (Marshal.SystemDefaultCharSize == 1)
                    return (UnsafeNativeMethodsR.CharBuffer)new UnsafeNativeMethodsR.AnsiCharBuffer(size);
                return (UnsafeNativeMethodsR.CharBuffer)new UnsafeNativeMethodsR.UnicodeCharBuffer(size);
            }
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000000B-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IStorage
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IStream CreateStream([MarshalAs(UnmanagedType.BStr), In] string pwcsName, [MarshalAs(UnmanagedType.U4), In] int grfMode, [MarshalAs(UnmanagedType.U4), In] int reserved1, [MarshalAs(UnmanagedType.U4), In] int reserved2);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IStream OpenStream([MarshalAs(UnmanagedType.BStr), In] string pwcsName, IntPtr reserved1, [MarshalAs(UnmanagedType.U4), In] int grfMode, [MarshalAs(UnmanagedType.U4), In] int reserved2);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IStorage CreateStorage([MarshalAs(UnmanagedType.BStr), In] string pwcsName, [MarshalAs(UnmanagedType.U4), In] int grfMode, [MarshalAs(UnmanagedType.U4), In] int reserved1, [MarshalAs(UnmanagedType.U4), In] int reserved2);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IStorage OpenStorage([MarshalAs(UnmanagedType.BStr), In] string pwcsName, IntPtr pstgPriority, [MarshalAs(UnmanagedType.U4), In] int grfMode, IntPtr snbExclude, [MarshalAs(UnmanagedType.U4), In] int reserved);

            void CopyTo(int ciidExclude, [MarshalAs(UnmanagedType.LPArray), In] Guid[] pIIDExclude, IntPtr snbExclude, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStorage stgDest);

            void MoveElementTo([MarshalAs(UnmanagedType.BStr), In] string pwcsName, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStorage stgDest, [MarshalAs(UnmanagedType.BStr), In] string pwcsNewName, [MarshalAs(UnmanagedType.U4), In] int grfFlags);

            void Commit(int grfCommitFlags);

            void Revert();

            void EnumElements([MarshalAs(UnmanagedType.U4), In] int reserved1, IntPtr reserved2, [MarshalAs(UnmanagedType.U4), In] int reserved3, [MarshalAs(UnmanagedType.Interface)] out object ppVal);

            void DestroyElement([MarshalAs(UnmanagedType.BStr), In] string pwcsName);

            void RenameElement([MarshalAs(UnmanagedType.BStr), In] string pwcsOldName, [MarshalAs(UnmanagedType.BStr), In] string pwcsNewName);

            void SetElementTimes([MarshalAs(UnmanagedType.BStr), In] string pwcsName, [In] NativeMethodsR.FILETIME pctime, [In] NativeMethodsR.FILETIME patime, [In] NativeMethodsR.FILETIME pmtime);

            void SetClass([In] ref Guid clsid);

            void SetStateBits(int grfStateBits, int grfMask);

            void Stat([Out] NativeMethodsR.STATSTG pStatStg, int grfStatFlag);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [Guid("B196B284-BAB4-101A-B69C-00AA00341D07")]
        [ComImport]
        public interface IConnectionPointContainer
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object EnumConnectionPoints();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int FindConnectionPoint([In] ref Guid guid, [MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethodsR.IConnectionPoint ppCP);
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagQACONTAINER
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize = Marshal.SizeOf(typeof(UnsafeNativeMethodsR.tagQACONTAINER));
            public IntPtr hpal = IntPtr.Zero;
            public UnsafeNativeMethodsR.IOleClientSite pClientSite;
            [MarshalAs(UnmanagedType.Interface)]
            public object pAdviseSink;
            public UnsafeNativeMethodsR.IPropertyNotifySink pPropertyNotifySink;
            [MarshalAs(UnmanagedType.Interface)]
            public object pUnkEventSink;
            [MarshalAs(UnmanagedType.U4)]
            public int dwAmbientFlags;
            [MarshalAs(UnmanagedType.U4)]
            public uint colorFore;
            [MarshalAs(UnmanagedType.U4)]
            public uint colorBack;
            [MarshalAs(UnmanagedType.Interface)]
            public object pFont;
            [MarshalAs(UnmanagedType.Interface)]
            public object pUndoMgr;
            [MarshalAs(UnmanagedType.U4)]
            public int dwAppearance;
            public int lcid;
            [MarshalAs(UnmanagedType.Interface)]
            public object pBindHost;
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagQACONTROL
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize = Marshal.SizeOf(typeof(UnsafeNativeMethodsR.tagQACONTROL));
            [MarshalAs(UnmanagedType.U4)]
            public int dwMiscStatus;
            [MarshalAs(UnmanagedType.U4)]
            public int dwViewStatus;
            [MarshalAs(UnmanagedType.U4)]
            public int dwEventCookie;
            [MarshalAs(UnmanagedType.U4)]
            public int dwPropNotifyCookie;
            [MarshalAs(UnmanagedType.U4)]
            public int dwPointerActivationPolicy;
        }

        [Guid("0000000A-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface ILockBytes
        {
            void ReadAt([MarshalAs(UnmanagedType.U8), In] long ulOffset, [Out] IntPtr pv, [MarshalAs(UnmanagedType.U4), In] int cb, [MarshalAs(UnmanagedType.LPArray), Out] int[] pcbRead);

            void WriteAt([MarshalAs(UnmanagedType.U8), In] long ulOffset, IntPtr pv, [MarshalAs(UnmanagedType.U4), In] int cb, [MarshalAs(UnmanagedType.LPArray), Out] int[] pcbWritten);

            void Flush();

            void SetSize([MarshalAs(UnmanagedType.U8), In] long cb);

            void LockRegion([MarshalAs(UnmanagedType.U8), In] long libOffset, [MarshalAs(UnmanagedType.U8), In] long cb, [MarshalAs(UnmanagedType.U4), In] int dwLockType);

            void UnlockRegion([MarshalAs(UnmanagedType.U8), In] long libOffset, [MarshalAs(UnmanagedType.U8), In] long cb, [MarshalAs(UnmanagedType.U4), In] int dwLockType);

            void Stat([Out] NativeMethodsR.STATSTG pstatstg, [MarshalAs(UnmanagedType.U4), In] int grfStatFlag);
        }

        public delegate int BrowseCallbackProc(IntPtr hwnd, int msg, IntPtr lParam, IntPtr lpData);

        [TypeLibType((short)4176)]
        [Guid("618736E0-3C3D-11CF-810C-00AA00389B71")]
        [ComImport]
        public interface IAccessibleInternal
        {
            [TypeLibFunc((short)64)]
            [DispId(-5000)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object get_accParent();

            [DispId(-5001)]
            [TypeLibFunc((short)64)]
            int get_accChildCount();

            [DispId(-5002)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object get_accChild([MarshalAs(UnmanagedType.Struct), In] object varChild);

            [TypeLibFunc((short)64)]
            [DispId(-5003)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accName([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5004)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accValue([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5005)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accDescription([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [TypeLibFunc((short)64)]
            [DispId(-5006)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accRole([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [TypeLibFunc((short)64)]
            [DispId(-5007)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accState([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5008)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accHelp([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5009)]
            [TypeLibFunc((short)64)]
            int get_accHelpTopic([MarshalAs(UnmanagedType.BStr)] out string pszHelpFile, [MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5010)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accKeyboardShortcut([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5011)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accFocus();

            [TypeLibFunc((short)64)]
            [DispId(-5012)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accSelection();

            [DispId(-5013)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accDefaultAction([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5014)]
            [TypeLibFunc((short)64)]
            void accSelect([In] int flagsSelect, [MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5015)]
            [TypeLibFunc((short)64)]
            void accLocation(out int pxLeft, out int pyTop, out int pcxWidth, out int pcyHeight, [MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5016)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object accNavigate([In] int navDir, [MarshalAs(UnmanagedType.Struct), In, Optional] object varStart);

            [DispId(-5017)]
            [TypeLibFunc((short)64)]
            [return: MarshalAs(UnmanagedType.Struct)]
            object accHitTest([In] int xLeft, [In] int yTop);

            [TypeLibFunc((short)64)]
            [DispId(-5018)]
            void accDoDefaultAction([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild);

            [DispId(-5003)]
            [TypeLibFunc((short)64)]
            void set_accName([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild, [MarshalAs(UnmanagedType.BStr), In] string pszName);

            [TypeLibFunc((short)64)]
            [DispId(-5004)]
            void set_accValue([MarshalAs(UnmanagedType.Struct), In, Optional] object varChild, [MarshalAs(UnmanagedType.BStr), In] string pszValue);
        }

        [SuppressUnmanagedCodeSecurity]
        [StructLayout(LayoutKind.Sequential)]
        internal class PROCESS_INFORMATION
        {
            public IntPtr hProcess = IntPtr.Zero;
            public IntPtr hThread = IntPtr.Zero;
            private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
            public int dwProcessId;
            public int dwThreadId;

            ~PROCESS_INFORMATION()
            {
                this.Close();
            }

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal void Close()
            {
                if (this.hProcess != (IntPtr)0 && this.hProcess != UnsafeNativeMethodsR.PROCESS_INFORMATION.INVALID_HANDLE_VALUE)
                {
                    UnsafeNativeMethodsR.PROCESS_INFORMATION.CloseHandle(new HandleRef((object)this, this.hProcess));
                    this.hProcess = UnsafeNativeMethodsR.PROCESS_INFORMATION.INVALID_HANDLE_VALUE;
                }
                if (!(this.hThread != (IntPtr)0) || !(this.hThread != UnsafeNativeMethodsR.PROCESS_INFORMATION.INVALID_HANDLE_VALUE))
                    return;
                UnsafeNativeMethodsR.PROCESS_INFORMATION.CloseHandle(new HandleRef((object)this, this.hThread));
                this.hThread = UnsafeNativeMethodsR.PROCESS_INFORMATION.INVALID_HANDLE_VALUE;
            }

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool CloseHandle(HandleRef handle);
        }

        [Guid("00000121-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleDropSource
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleQueryContinueDrag(int fEscapePressed, [MarshalAs(UnmanagedType.U4), In] int grfKeyState);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleGiveFeedback([MarshalAs(UnmanagedType.U4), In] int dwEffect);
        }

        [Guid("00000016-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleMessageFilter
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
        }

        [Guid("626FC520-A41E-11cf-A731-00A0C9082637")]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        internal interface IHTMLDocument
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetScript();
        }

        [SuppressUnmanagedCodeSecurity]
        [Guid("3050F485-98B5-11CF-BB82-00AA00BDCE0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        internal interface IHTMLDocument3
        {
            void ReleaseCapture();

            void Recalc([In] bool fForce);

            object CreateTextNode([In] string text);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetDocumentElement();

            string GetUniqueID();

            bool AttachEvent([In] string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            void DetachEvent([In] string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            void SetOnrowsdelete([In] object p);

            object GetOnrowsdelete();

            void SetOnrowsinserted([In] object p);

            object GetOnrowsinserted();

            void SetOncellchange([In] object p);

            object GetOncellchange();

            void SetOndatasetchanged([In] object p);

            object GetOndatasetchanged();

            void SetOndataavailable([In] object p);

            object GetOndataavailable();

            void SetOndatasetcomplete([In] object p);

            object GetOndatasetcomplete();

            void SetOnpropertychange([In] object p);

            object GetOnpropertychange();

            void SetDir([In] string p);

            string GetDir();

            void SetOncontextmenu([In] object p);

            object GetOncontextmenu();

            void SetOnstop([In] object p);

            object GetOnstop();

            object CreateDocumentFragment();

            object GetParentDocument();

            void SetEnableDownload([In] bool p);

            bool GetEnableDownload();

            void SetBaseUrl([In] string p);

            string GetBaseUrl();

            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetChildNodes();

            void SetInheritStyleSheets([In] bool p);

            bool GetInheritStyleSheets();

            void SetOnbeforeeditfocus([In] object p);

            object GetOnbeforeeditfocus();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElementCollection GetElementsByName([In] string v);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement GetElementById([In] string v);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElementCollection GetElementsByTagName([In] string v);
        }

        [ComVisible(true)]
        [Guid("3050F69A-98B5-11CF-BB82-00AA00BDCE0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        internal interface IHTMLDocument4
        {
            void Focus();

            bool HasFocus();

            void SetOnselectionchange(object p);

            object GetOnselectionchange();

            object GetNamespaces();

            object createDocumentFromUrl(string bstrUrl, string bstrOptions);

            void SetMedia(string bstrMedia);

            string GetMedia();

            object CreateEventObject([In, Optional] ref object eventObject);

            bool FireEvent(string eventName);

            object CreateRenderStyle(string bstr);

            void SetOncontrolselect(object p);

            object GetOncontrolselect();

            string GetURLUnencoded();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f613-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLDocumentEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1026)]
            bool onstop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1027)]
            void onbeforeeditfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1037)]
            void onselectionchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [ComVisible(true)]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("3050f4ae-98b5-11cf-bb82-00aa00bdce0b")]
        public interface IHTMLWindow3
        {
            int GetScreenLeft();

            int GetScreenTop();

            bool AttachEvent(string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            void DetachEvent(string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            int SetTimeout([In] ref object expression, int msec, [In] ref object language);

            int SetInterval([In] ref object expression, int msec, [In] ref object language);

            void Print();

            void SetBeforePrint(object o);

            object GetBeforePrint();

            void SetAfterPrint(object o);

            object GetAfterPrint();

            object GetClipboardData();

            object ShowModelessDialog(string url, object varArgIn, object options);
        }

        [ComVisible(true)]
        [Guid("3050f6cf-98b5-11cf-bb82-00aa00bdce0b")]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IHTMLWindow4
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object CreatePopup([In] ref object reserved);

            [return: MarshalAs(UnmanagedType.Interface)]
            object frameElement();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f625-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLWindowEvents2
        {
            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1008)]
            void onunload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            bool onerror(string description, string url, int line);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1017)]
            void onbeforeunload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1024)]
            void onbeforeprint(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1025)]
            void onafterprint(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f666-98b5-11cf-bb82-00aa00bdce0b")]
        [ComVisible(true)]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IHTMLPopup
        {
            void show(int x, int y, int w, int h, ref object element);

            void hide();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLDocument GetDocument();

            bool IsOpen();
        }

        [Guid("3050f48B-98b5-11cf-bb82-00aa00bdce0b")]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        internal interface IHTMLEventObj2
        {
            void SetAttribute(string attributeName, object attributeValue, int lFlags);

            object GetAttribute(string attributeName, int lFlags);

            bool RemoveAttribute(string attributeName, int lFlags);

            void SetPropertyName(string name);

            string GetPropertyName();

            void SetBookmarks(ref object bm);

            object GetBookmarks();

            void SetRecordset(ref object rs);

            object GetRecordset();

            void SetDataFld(string df);

            string GetDataFld();

            void SetBoundElements(ref object be);

            object GetBoundElements();

            void SetRepeat(bool r);

            bool GetRepeat();

            void SetSrcUrn(string urn);

            string GetSrcUrn();

            void SetSrcElement(ref object se);

            object GetSrcElement();

            void SetAltKey(bool alt);

            bool GetAltKey();

            void SetCtrlKey(bool ctrl);

            bool GetCtrlKey();

            void SetShiftKey(bool shift);

            bool GetShiftKey();

            void SetFromElement(ref object element);

            object GetFromElement();

            void SetToElement(ref object element);

            object GetToElement();

            void SetButton(int b);

            int GetButton();

            void SetType(string type);

            string GetType();

            void SetQualifier(string q);

            string GetQualifier();

            void SetReason(int r);

            int GetReason();

            void SetX(int x);

            int GetX();

            void SetY(int y);

            int GetY();

            void SetClientX(int x);

            int GetClientX();

            void SetClientY(int y);

            int GetClientY();

            void SetOffsetX(int x);

            int GetOffsetX();

            void SetOffsetY(int y);

            int GetOffsetY();

            void SetScreenX(int x);

            int GetScreenX();

            void SetScreenY(int y);

            int GetScreenY();

            void SetSrcFilter(ref object filter);

            object GetSrcFilter();

            object GetDataTransfer();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [ComVisible(true)]
        [Guid("3050f814-98b5-11cf-bb82-00aa00bdce0b")]
        [SuppressUnmanagedCodeSecurity]
        internal interface IHTMLEventObj4
        {
            int GetWheelDelta();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("3050f434-98b5-11cf-bb82-00aa00bdce0b")]
        [SuppressUnmanagedCodeSecurity]
        [ComVisible(true)]
        internal interface IHTMLElement2
        {
            string ScopeName();

            void SetCapture(bool containerCapture);

            void ReleaseCapture();

            void SetOnLoseCapture(object v);

            object GetOnLoseCapture();

            string GetComponentFromPoint(int x, int y);

            void DoScroll(object component);

            void SetOnScroll(object v);

            object GetOnScroll();

            void SetOnDrag(object v);

            object GetOnDrag();

            void SetOnDragEnd(object v);

            object GetOnDragEnd();

            void SetOnDragEnter(object v);

            object GetOnDragEnter();

            void SetOnDragOver(object v);

            object GetOnDragOver();

            void SetOnDragleave(object v);

            object GetOnDragLeave();

            void SetOnDrop(object v);

            object GetOnDrop();

            void SetOnBeforeCut(object v);

            object GetOnBeforeCut();

            void SetOnCut(object v);

            object GetOnCut();

            void SetOnBeforeCopy(object v);

            object GetOnBeforeCopy();

            void SetOnCopy(object v);

            object GetOnCopy(object p);

            void SetOnBeforePaste(object v);

            object GetOnBeforePaste(object p);

            void SetOnPaste(object v);

            object GetOnPaste(object p);

            object GetCurrentStyle();

            void SetOnPropertyChange(object v);

            object GetOnPropertyChange(object p);

            object GetClientRects();

            object GetBoundingClientRect();

            void SetExpression(string propName, string expression, string language);

            object GetExpression(string propName);

            bool RemoveExpression(string propName);

            void SetTabIndex(int v);

            short GetTabIndex();

            void Focus();

            void SetAccessKey(string v);

            string GetAccessKey();

            void SetOnBlur(object v);

            object GetOnBlur();

            void SetOnFocus(object v);

            object GetOnFocus();

            void SetOnResize(object v);

            object GetOnResize();

            void Blur();

            void AddFilter(object pUnk);

            void RemoveFilter(object pUnk);

            int ClientHeight();

            int ClientWidth();

            int ClientTop();

            int ClientLeft();

            bool AttachEvent(string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            void DetachEvent(string ev, [MarshalAs(UnmanagedType.IDispatch), In] object pdisp);

            object ReadyState();

            void SetOnReadyStateChange(object v);

            object GetOnReadyStateChange();

            void SetOnRowsDelete(object v);

            object GetOnRowsDelete();

            void SetOnRowsInserted(object v);

            object GetOnRowsInserted();

            void SetOnCellChange(object v);

            object GetOnCellChange();

            void SetDir(string v);

            string GetDir();

            object CreateControlRange();

            int GetScrollHeight();

            int GetScrollWidth();

            void SetScrollTop(int v);

            int GetScrollTop();

            void SetScrollLeft(int v);

            int GetScrollLeft();

            void ClearAttributes();

            void MergeAttributes(object mergeThis);

            void SetOnContextMenu(object v);

            object GetOnContextMenu();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement InsertAdjacentElement(string where, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IHTMLElement insertedElement);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElement applyElement([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IHTMLElement apply, string where);

            string GetAdjacentText(string where);

            string ReplaceAdjacentText(string where, string newText);

            bool CanHaveChildren();

            int AddBehavior(string url, ref object oFactory);

            bool RemoveBehavior(int cookie);

            object GetRuntimeStyle();

            object GetBehaviorUrns();

            void SetTagUrn(string v);

            string GetTagUrn();

            void SetOnBeforeEditFocus(object v);

            object GetOnBeforeEditFocus();

            int GetReadyStateValue();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IHTMLElementCollection GetElementsByTagName(string v);
        }

        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("3050f673-98b5-11cf-bb82-00aa00bdce0b")]
        [SuppressUnmanagedCodeSecurity]
        internal interface IHTMLElement3
        {
            void MergeAttributes(object mergeThis, object pvarFlags);

            bool IsMultiLine();

            bool CanHaveHTML();

            void SetOnLayoutComplete(object v);

            object GetOnLayoutComplete();

            void SetOnPage(object v);

            object GetOnPage();

            void SetInflateBlock(bool v);

            bool GetInflateBlock();

            void SetOnBeforeDeactivate(object v);

            object GetOnBeforeDeactivate();

            void SetActive();

            void SetContentEditable(string v);

            string GetContentEditable();

            bool IsContentEditable();

            void SetHideFocus(bool v);

            bool GetHideFocus();

            void SetDisabled(bool v);

            bool GetDisabled();

            bool IsDisabled();

            void SetOnMove(object v);

            object GetOnMove();

            void SetOnControlSelect(object v);

            object GetOnControlSelect();

            bool FireEvent(string bstrEventName, IntPtr pvarEventObject);

            void SetOnResizeStart(object v);

            object GetOnResizeStart();

            void SetOnResizeEnd(object v);

            object GetOnResizeEnd();

            void SetOnMoveStart(object v);

            object GetOnMoveStart();

            void SetOnMoveEnd(object v);

            object GetOnMoveEnd();

            void SetOnMouseEnter(object v);

            object GetOnMouseEnter();

            void SetOnMouseLeave(object v);

            object GetOnMouseLeave();

            void SetOnActivate(object v);

            object GetOnActivate();

            void SetOnDeactivate(object v);

            object GetOnDeactivate();

            bool DragDrop();

            int GlyphMode();
        }

        [ComVisible(true)]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("3050f5da-98b5-11cf-bb82-00aa00bdce0b")]
        public interface IHTMLDOMNode
        {
            long GetNodeType();

            UnsafeNativeMethodsR.IHTMLDOMNode GetParentNode();

            bool HasChildNodes();

            object GetChildNodes();

            object GetAttributes();

            UnsafeNativeMethodsR.IHTMLDOMNode InsertBefore(UnsafeNativeMethodsR.IHTMLDOMNode newChild, object refChild);

            UnsafeNativeMethodsR.IHTMLDOMNode RemoveChild(UnsafeNativeMethodsR.IHTMLDOMNode oldChild);

            UnsafeNativeMethodsR.IHTMLDOMNode ReplaceChild(UnsafeNativeMethodsR.IHTMLDOMNode newChild, UnsafeNativeMethodsR.IHTMLDOMNode oldChild);

            UnsafeNativeMethodsR.IHTMLDOMNode CloneNode(bool fDeep);

            UnsafeNativeMethodsR.IHTMLDOMNode RemoveNode(bool fDeep);

            UnsafeNativeMethodsR.IHTMLDOMNode SwapNode(UnsafeNativeMethodsR.IHTMLDOMNode otherNode);

            UnsafeNativeMethodsR.IHTMLDOMNode ReplaceNode(UnsafeNativeMethodsR.IHTMLDOMNode replacement);

            UnsafeNativeMethodsR.IHTMLDOMNode AppendChild(UnsafeNativeMethodsR.IHTMLDOMNode newChild);

            string NodeName();

            void SetNodeValue(object v);

            object GetNodeValue();

            UnsafeNativeMethodsR.IHTMLDOMNode FirstChild();

            UnsafeNativeMethodsR.IHTMLDOMNode LastChild();

            UnsafeNativeMethodsR.IHTMLDOMNode PreviousSibling();

            UnsafeNativeMethodsR.IHTMLDOMNode NextSibling();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f60f-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f610-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLAnchorEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f611-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLAreaEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f617-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLButtonElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f612-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLControlElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f614-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLFormElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1007)]
            bool onsubmit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1015)]
            bool onreset(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f7ff-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLFrameSiteEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f616-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLImgEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1000)]
            void onabort(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f61a-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [ComImport]
        public interface DHTMLInputFileElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412082)]
            bool onchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412102)]
            void onselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1000)]
            void onabort(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f61b-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLInputImageEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412080)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412083)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412084)]
            void onabort(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f618-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLInputTextElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1001)]
            bool onchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1006)]
            void onselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1001)]
            void onabort(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f61c-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLLabelEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f61d-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLLinkElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412080)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412083)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f61e-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLMapEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f61f-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLMarqueeElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412092)]
            void onbounce(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412086)]
            void onfinish(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412085)]
            void onstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f619-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLOptionButtonElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412082)]
            bool onchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f622-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLSelectElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147412082)]
            void onchange_void(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("3050f615-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLStyleElementEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1003)]
            void onload(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f623-98b5-11cf-bb82-00aa00bdce0b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLTableEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [Guid("3050f624-98b5-11cf-bb82-00aa00bdce0b")]
        [ComImport]
        public interface DHTMLTextContainerEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1001)]
            void onchange_void(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1006)]
            void onselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("3050f621-98b5-11cf-bb82-00aa00bdce0b")]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface DHTMLScriptEvents2
        {
            [DispId(-2147418102)]
            bool onhelp(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-600)]
            bool onclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-601)]
            bool ondblclick(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-603)]
            bool onkeypress(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-602)]
            void onkeydown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-604)]
            void onkeyup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418103)]
            void onmouseout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418104)]
            void onmouseover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-606)]
            void onmousemove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-605)]
            void onmousedown(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-607)]
            void onmouseup(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418100)]
            bool onselectstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418095)]
            void onfilterchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418101)]
            bool ondragstart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418108)]
            bool onbeforeupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418107)]
            void onafterupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418099)]
            bool onerrorupdate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418106)]
            bool onrowexit(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418105)]
            void onrowenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418098)]
            void ondatasetchanged(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418097)]
            void ondataavailable(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418096)]
            void ondatasetcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418094)]
            void onlosecapture(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418093)]
            void onpropertychange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1014)]
            void onscroll(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418111)]
            void onfocus(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418112)]
            void onblur(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1016)]
            void onresize(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418092)]
            bool ondrag(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418091)]
            void ondragend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418090)]
            bool ondragenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418089)]
            bool ondragover(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418088)]
            void ondragleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418087)]
            bool ondrop(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418083)]
            bool onbeforecut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418086)]
            bool oncut(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418082)]
            bool onbeforecopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418085)]
            bool oncopy(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418081)]
            bool onbeforepaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418084)]
            bool onpaste(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1023)]
            bool oncontextmenu(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418080)]
            void onrowsdelete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418079)]
            void onrowsinserted(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-2147418078)]
            void oncellchange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(-609)]
            void onreadystatechange(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1030)]
            void onlayoutcomplete(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1031)]
            void onpage(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1042)]
            void onmouseenter(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1043)]
            void onmouseleave(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1044)]
            void onactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1045)]
            void ondeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1034)]
            bool onbeforedeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1047)]
            bool onbeforeactivate(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1048)]
            void onfocusin(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1049)]
            void onfocusout(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1035)]
            void onmove(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1036)]
            bool oncontrolselect(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1038)]
            bool onmovestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1039)]
            void onmoveend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1040)]
            bool onresizestart(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1041)]
            void onresizeend(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1033)]
            bool onmousewheel(UnsafeNativeMethodsR.IHTMLEventObj evtObj);

            [DispId(1002)]
            void onerror(UnsafeNativeMethodsR.IHTMLEventObj evtObj);
        }

        [Guid("39088D7E-B71E-11D1-8F39-00C04FD946D0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IExtender
        {
            int Align { get; set; }

            bool Enabled { get; set; }

            int Height { get; set; }

            int Left { get; set; }

            bool TabStop { get; set; }

            int Top { get; set; }

            bool Visible { get; set; }

            int Width { get; set; }

            string Name { get; }

            object Parent { get; }

            IntPtr Hwnd { get; }

            object Container { get; }

            void Move([MarshalAs(UnmanagedType.Interface), In] object left, [MarshalAs(UnmanagedType.Interface), In] object top, [MarshalAs(UnmanagedType.Interface), In] object width, [MarshalAs(UnmanagedType.Interface), In] object height);
        }

        [Guid("8A701DA0-4FEB-101B-A82E-08002B2B2337")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IGetOleObject
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object GetOleObject(ref Guid riid);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("CB2F6722-AB3A-11d2-9C40-00C04FA30A3E")]
        [ComImport]
        internal interface ICorRuntimeHost
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateLogicalThreadState();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DeleteLogicalThreadState();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SwitchInLogicalThreadState([In] ref uint pFiberCookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SwitchOutLogicalThreadState(out uint FiberCookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int LocksHeldByLogicalThread(out uint pCount);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int MapFile(IntPtr hFile, out IntPtr hMapAddress);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetConfiguration([MarshalAs(UnmanagedType.IUnknown)] out object pConfiguration);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Start();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Stop();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateDomain(string pwzFriendlyName, [MarshalAs(UnmanagedType.IUnknown)] object pIdentityArray, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDefaultDomain([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumDomains(out IntPtr hEnum);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int NextDomain(IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CloseEnum(IntPtr hEnum);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateDomainEx(string pwzFriendlyName, [MarshalAs(UnmanagedType.IUnknown)] object pSetup, [MarshalAs(UnmanagedType.IUnknown)] object pEvidence, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateDomainSetup([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomainSetup);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateEvidence([MarshalAs(UnmanagedType.IUnknown)] out object pEvidence);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int UnloadDomain([MarshalAs(UnmanagedType.IUnknown)] object pAppDomain);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CurrentDomain([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);
        }

        [Guid("CB2F6723-AB3A-11d2-9C40-00C04FA30A3E")]
        [ComImport]
        internal class CorRuntimeHost
        {
            //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            //public CorRuntimeHost();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000C0601-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IMsoComponentManager
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int QueryService(ref Guid guidService, ref Guid iid, [MarshalAs(UnmanagedType.Interface)] out object ppvObj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FDebugMessage(IntPtr hInst, int msg, IntPtr wParam, IntPtr lParam);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FRegisterComponent(UnsafeNativeMethodsR.IMsoComponent component, NativeMethodsR.MSOCRINFOSTRUCT pcrinfo, out IntPtr dwComponentID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FRevokeComponent(IntPtr dwComponentID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FUpdateComponentRegistration(IntPtr dwComponentID, NativeMethodsR.MSOCRINFOSTRUCT pcrinfo);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FOnComponentActivate(IntPtr dwComponentID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FSetTrackingComponent(IntPtr dwComponentID, [MarshalAs(UnmanagedType.Bool), In] bool fTrack);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void OnComponentEnterState(IntPtr dwComponentID, int uStateID, int uContext, int cpicmExclude, int rgpicmExclude, int dwReserved);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FOnComponentExitState(IntPtr dwComponentID, int uStateID, int uContext, int cpicmExclude, int rgpicmExclude);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FInState(int uStateID, IntPtr pvoid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FContinueIdle();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FPushMessageLoop(IntPtr dwComponentID, int uReason, int pvLoopData);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FCreateSubComponentManager([MarshalAs(UnmanagedType.Interface)] object punkOuter, [MarshalAs(UnmanagedType.Interface)] object punkServProv, ref Guid riid, out IntPtr ppvObj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FGetParentComponentManager(out UnsafeNativeMethodsR.IMsoComponentManager ppicm);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FGetActiveComponent(int dwgac, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.IMsoComponent[] ppic, NativeMethodsR.MSOCRINFOSTRUCT pcrinfo, int dwReserved);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000C0600-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IMsoComponent
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FDebugMessage(IntPtr hInst, int msg, IntPtr wParam, IntPtr lParam);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FPreTranslateMessage(ref NativeMethodsR.MSG msg);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void OnEnterState(int uStateID, bool fEnter);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void OnAppActivate(bool fActive, int dwOtherThreadID);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void OnLoseActivation();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void OnActivationChange(UnsafeNativeMethodsR.IMsoComponent component, bool fSameComponent, int pcrinfo, bool fHostIsActivating, int pchostinfo, int dwReserved);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FDoIdle(int grfidlef);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FContinueMessageLoop(int uReason, int pvLoopData, [MarshalAs(UnmanagedType.LPArray)] NativeMethodsR.MSG[] pMsgPeeked);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            bool FQueryTerminate(bool fPromptUser);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void Terminate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            IntPtr HwndGetWindow(int dwWhich, int dwReserved);
        }

        [Guid("8CC497C0-A1DF-11ce-8098-00AA0047BE5D")]
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [SuppressUnmanagedCodeSecurity]
        public interface ITextDocument
        {
            string GetName();

            object GetSelection();

            int GetStoryCount();

            object GetStoryRanges();

            int GetSaved();

            void SetSaved(int value);

            object GetDefaultTabStop();

            void SetDefaultTabStop(object value);

            void New();

            void Open(object pVar, int flags, int codePage);

            void Save(object pVar, int flags, int codePage);

            int Freeze();

            int Unfreeze();

            void BeginEditCollection();

            void EndEditCollection();

            int Undo(int count);

            int Redo(int count);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.ITextRange Range(int cp1, int cp2);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.ITextRange RangeFromPoint(int x, int y);
        }

        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("8CC497C2-A1DF-11ce-8098-00AA0047BE5D")]
        [ComVisible(true)]
        public interface ITextRange
        {
            string GetText();

            void SetText(string text);

            object GetChar();

            void SetChar(object ch);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.ITextRange GetDuplicate();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.ITextRange GetFormattedText();

            void SetFormattedText([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.ITextRange range);

            int GetStart();

            void SetStart(int cpFirst);

            int GetEnd();

            void SetEnd(int cpLim);

            object GetFont();

            void SetFont(object font);

            object GetPara();

            void SetPara(object para);

            int GetStoryLength();

            int GetStoryType();

            void Collapse(int start);

            int Expand(int unit);

            int GetIndex(int unit);

            void SetIndex(int unit, int index, int extend);

            void SetRange(int cpActive, int cpOther);

            int InRange([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.ITextRange range);

            int InStory([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.ITextRange range);

            int IsEqual([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.ITextRange range);

            void Select();

            int StartOf(int unit, int extend);

            int EndOf(int unit, int extend);

            int Move(int unit, int count);

            int MoveStart(int unit, int count);

            int MoveEnd(int unit, int count);

            int MoveWhile(object cset, int count);

            int MoveStartWhile(object cset, int count);

            int MoveEndWhile(object cset, int count);

            int MoveUntil(object cset, int count);

            int MoveStartUntil(object cset, int count);

            int MoveEndUntil(object cset, int count);

            int FindText(string text, int cch, int flags);

            int FindTextStart(string text, int cch, int flags);

            int FindTextEnd(string text, int cch, int flags);

            int Delete(int unit, int count);

            void Cut(out object pVar);

            void Copy(out object pVar);

            void Paste(object pVar, int format);

            int CanPaste(object pVar, int format);

            int CanEdit();

            void ChangeCase(int type);

            void GetPoint(int type, out int x, out int y);

            void SetPoint(int x, int y, int type, int extend);

            void ScrollIntoView(int value);

            object GetEmbeddedObject();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00020D03-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IRichEditOleCallback
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetNewStorage(out UnsafeNativeMethodsR.IStorage ret);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetInPlaceContext(IntPtr lplpFrame, IntPtr lplpDoc, IntPtr lpFrameInfo);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ShowContainerUI(int fShow);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int QueryInsertObject(ref Guid lpclsid, IntPtr lpstg, int cp);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DeleteObject(IntPtr lpoleobj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int QueryAcceptData(System.Runtime.InteropServices.ComTypes.IDataObject lpdataobj, IntPtr lpcfFormat, int reco, int fReally, IntPtr hMetaPict);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int ContextSensitiveHelp(int fEnterMode);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetClipboardData(NativeMethodsR.CHARRANGE lpchrg, int reco, IntPtr lplpdataobj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDragDropEffect(bool fDrag, int grfKeyState, ref int pdwEffect);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetContextMenu(short seltype, IntPtr lpoleobj, NativeMethodsR.CHARRANGE lpchrg, out IntPtr hmenu);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("1C2056CC-5EF4-101B-8BC8-00AA003E3B29")]
        [ComImport]
        public interface IOleInPlaceObjectWindowless
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetClientSite([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleClientSite pClientSite);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetClientSite(out UnsafeNativeMethodsR.IOleClientSite site);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetHostNames([MarshalAs(UnmanagedType.LPWStr), In] string szContainerApp, [MarshalAs(UnmanagedType.LPWStr), In] string szContainerObj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Close(int dwSaveOption);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetMoniker([MarshalAs(UnmanagedType.U4), In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface), In] object pmk);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMoniker([MarshalAs(UnmanagedType.U4), In] int dwAssign, [MarshalAs(UnmanagedType.U4), In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] out object moniker);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int InitFromData([MarshalAs(UnmanagedType.Interface), In] System.Runtime.InteropServices.ComTypes.IDataObject pDataObject, int fCreation, [MarshalAs(UnmanagedType.U4), In] int dwReserved);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetClipboardData([MarshalAs(UnmanagedType.U4), In] int dwReserved, out System.Runtime.InteropServices.ComTypes.IDataObject data);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DoVerb(int iVerb, [In] IntPtr lpmsg, [MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, [In] NativeMethodsR.COMRECT lprcPosRect);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumVerbs(out UnsafeNativeMethodsR.IEnumOLEVERB e);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OleUpdate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsUpToDate();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetUserClassID([In, Out] ref Guid pClsid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetUserType([MarshalAs(UnmanagedType.U4), In] int dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string userType);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetExtent([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, [In] NativeMethodsR.tagSIZEL pSizel);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetExtent([MarshalAs(UnmanagedType.U4), In] int dwDrawAspect, [Out] NativeMethodsR.tagSIZEL pSizel);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Advise([MarshalAs(UnmanagedType.Interface), In] IAdviseSink pAdvSink, out int cookie);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Unadvise([MarshalAs(UnmanagedType.U4), In] int dwConnection);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int EnumAdvise(out IEnumSTATDATA e);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMiscStatus([MarshalAs(UnmanagedType.U4), In] int dwAspect, out int misc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SetColorScheme([In] NativeMethodsR.tagLOGPALETTE pLogpal);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int OnWindowMessage([MarshalAs(UnmanagedType.U4), In] int msg, [MarshalAs(UnmanagedType.U4), In] int wParam, [MarshalAs(UnmanagedType.U4), In] int lParam, [MarshalAs(UnmanagedType.U4), Out] int plResult);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDropTarget([MarshalAs(UnmanagedType.Interface), Out] object ppDropTarget);
        }

        [Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleServiceProvider
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int QueryService([In] ref Guid guidService, [In] ref Guid riid, out IntPtr ppvObject);
        }

        [Guid("000C060B-0000-0000-C000-000000000046")]
        [ComImport]
        public class SMsoComponentManager
        {
            //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            //public SMsoComponentManager();
        }

        [Guid("00bb2762-6a77-11d0-a535-00c04fd7d062")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        [ComImport]
        public interface IAutoComplete
        {
            int Init([In] HandleRef hwndEdit, [In] IEnumString punkACL, [In] string pwszRegKeyPath, [In] string pwszQuickComplete);

            void Enable([In] bool fEnable);
        }

        public class AnsiCharBuffer : UnsafeNativeMethodsR.CharBuffer
        {
            internal byte[] buffer;
            internal int offset;

            public AnsiCharBuffer(int size)
            {
                this.buffer = new byte[size];
            }

            public override IntPtr AllocCoTaskMem()
            {
                IntPtr destination = Marshal.AllocCoTaskMem(this.buffer.Length);
                Marshal.Copy(this.buffer, 0, destination, this.buffer.Length);
                return destination;
            }

            public override string GetString()
            {
                int index = this.offset;
                while (index < this.buffer.Length && (int)this.buffer[index] != 0)
                    ++index;
                string @string = Encoding.Default.GetString(this.buffer, this.offset, index - this.offset);
                if (index < this.buffer.Length)
                    ++index;
                this.offset = index;
                return @string;
            }

            public override void PutCoTaskMem(IntPtr ptr)
            {
                Marshal.Copy(ptr, this.buffer, 0, this.buffer.Length);
                this.offset = 0;
            }

            public override void PutString(string s)
            {
                byte[] bytes = Encoding.Default.GetBytes(s);
                int length = Math.Min(bytes.Length, this.buffer.Length - this.offset);
                Array.Copy((Array)bytes, 0, (Array)this.buffer, this.offset, length);
                this.offset += length;
                if (this.offset >= this.buffer.Length)
                    return;
                this.buffer[this.offset++] = (byte)0;
            }
        }

        public class UnicodeCharBuffer : UnsafeNativeMethodsR.CharBuffer
        {
            internal char[] buffer;
            internal int offset;

            public UnicodeCharBuffer(int size)
            {
                this.buffer = new char[size];
            }

            public override IntPtr AllocCoTaskMem()
            {
                IntPtr destination = Marshal.AllocCoTaskMem(this.buffer.Length * 2);
                Marshal.Copy(this.buffer, 0, destination, this.buffer.Length);
                return destination;
            }

            public override string GetString()
            {
                int index = this.offset;
                while (index < this.buffer.Length && (int)this.buffer[index] != 0)
                    ++index;
                string str = new string(this.buffer, this.offset, index - this.offset);
                if (index < this.buffer.Length)
                    ++index;
                this.offset = index;
                return str;
            }

            public override void PutCoTaskMem(IntPtr ptr)
            {
                Marshal.Copy(ptr, this.buffer, 0, this.buffer.Length);
                this.offset = 0;
            }

            public override void PutString(string s)
            {
                int count = Math.Min(s.Length, this.buffer.Length - this.offset);
                s.CopyTo(0, this.buffer, this.offset, count);
                this.offset += count;
                if (this.offset >= this.buffer.Length)
                    return;
                this.buffer[this.offset++] = char.MinValue;
            }
        }

        public class ComStreamFromDataStream : UnsafeNativeMethodsR.IStream
        {
            private long virtualPosition = -1L;
            protected Stream dataStream;

            public ComStreamFromDataStream(Stream dataStream)
            {
                if (dataStream == null)
                    throw new ArgumentNullException("dataStream");
                this.dataStream = dataStream;
            }

            private void ActualizeVirtualPosition()
            {
                if (this.virtualPosition == -1L)
                    return;
                if (this.virtualPosition > this.dataStream.Length)
                    this.dataStream.SetLength(this.virtualPosition);
                this.dataStream.Position = this.virtualPosition;
                this.virtualPosition = -1L;
            }

            public UnsafeNativeMethodsR.IStream Clone()
            {
                UnsafeNativeMethodsR.ComStreamFromDataStream.NotImplemented();
                return (UnsafeNativeMethodsR.IStream)null;
            }

            public void Commit(int grfCommitFlags)
            {
                this.dataStream.Flush();
                this.ActualizeVirtualPosition();
            }

            public long CopyTo(UnsafeNativeMethodsR.IStream pstm, long cb, long[] pcbRead)
            {
                int cb1 = 4096;
                IntPtr num1 = Marshal.AllocHGlobal(cb1);
                if (num1 == IntPtr.Zero)
                    throw new OutOfMemoryException();
                long num2 = 0L;
                try
                {
                    while (num2 < cb)
                    {
                        int length = cb1;
                        if (num2 + (long)length > cb)
                            length = (int)(cb - num2);
                        int len = this.Read(num1, length);
                        if (len != 0)
                        {
                            if (pstm.Write(num1, len) != len)
                                throw UnsafeNativeMethodsR.ComStreamFromDataStream.EFail("Wrote an incorrect number of bytes");
                            num2 += (long)len;
                        }
                        else
                            break;
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(num1);
                }
                if (pcbRead != null && pcbRead.Length > 0)
                    pcbRead[0] = num2;
                return num2;
            }

            public Stream GetDataStream()
            {
                return this.dataStream;
            }

            public void LockRegion(long libOffset, long cb, int dwLockType)
            {
            }

            protected static ExternalException EFail(string msg)
            {
                throw new ExternalException(msg, -2147467259);
            }

            protected static void NotImplemented()
            {
                throw new ExternalException(SR1.GetString("UnsafeNativeMethodsNotImplemented"), -2147467263);
            }

            public int Read(IntPtr buf, int length)
            {
                byte[] numArray = new byte[length];
                int length1 = this.Read(numArray, length);
                Marshal.Copy(numArray, 0, buf, length1);
                return length1;
            }

            public int Read(byte[] buffer, int length)
            {
                this.ActualizeVirtualPosition();
                return this.dataStream.Read(buffer, 0, length);
            }

            public void Revert()
            {
                UnsafeNativeMethodsR.ComStreamFromDataStream.NotImplemented();
            }

            public long Seek(long offset, int origin)
            {
                long num = this.virtualPosition;
                if (this.virtualPosition == -1L)
                    num = this.dataStream.Position;
                long length = this.dataStream.Length;
                switch (origin)
                {
                    case 0:
                        if (offset <= length)
                        {
                            this.dataStream.Position = offset;
                            this.virtualPosition = -1L;
                            break;
                        }
                        this.virtualPosition = offset;
                        break;
                    case 1:
                        if (offset + num <= length)
                        {
                            this.dataStream.Position = num + offset;
                            this.virtualPosition = -1L;
                            break;
                        }
                        this.virtualPosition = offset + num;
                        break;
                    case 2:
                        if (offset <= 0L)
                        {
                            this.dataStream.Position = length + offset;
                            this.virtualPosition = -1L;
                            break;
                        }
                        this.virtualPosition = length + offset;
                        break;
                }
                if (this.virtualPosition != -1L)
                    return this.virtualPosition;
                return this.dataStream.Position;
            }

            public void SetSize(long value)
            {
                this.dataStream.SetLength(value);
            }

            public void Stat(NativeMethodsR.STATSTG pstatstg, int grfStatFlag)
            {
                pstatstg.type = 2;
                pstatstg.cbSize = this.dataStream.Length;
                pstatstg.grfLocksSupported = 2;
            }

            public void UnlockRegion(long libOffset, long cb, int dwLockType)
            {
            }

            public int Write(IntPtr buf, int length)
            {
                byte[] numArray = new byte[length];
                Marshal.Copy(buf, numArray, 0, length);
                return this.Write(numArray, length);
            }

            public int Write(byte[] buffer, int length)
            {
                this.ActualizeVirtualPosition();
                this.dataStream.Write(buffer, 0, length);
                return length;
            }
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B196B28F-BAB4-101A-B69C-00AA00341D07")]
        [ComImport]
        public interface IClassFactory2
        {
            void CreateInstance([MarshalAs(UnmanagedType.Interface), In] object unused, [In] ref Guid refiid, [MarshalAs(UnmanagedType.LPArray), Out] object[] ppunk);

            void LockServer(int fLock);

            void GetLicInfo([Out] NativeMethodsR.tagLICINFO licInfo);

            void RequestLicKey([MarshalAs(UnmanagedType.U4), In] int dwReserved, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrKey);

            void CreateInstanceLic([MarshalAs(UnmanagedType.Interface), In] object pUnkOuter, [MarshalAs(UnmanagedType.Interface), In] object pUnkReserved, [In] ref Guid riid, [MarshalAs(UnmanagedType.BStr), In] string bstrKey, [MarshalAs(UnmanagedType.Interface)] out object ppVal);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B196B285-BAB4-101A-B69C-00AA00341D07")]
        [ComImport]
        public interface IEnumConnectionPoints
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Next(int cConnections, out UnsafeNativeMethodsR.IConnectionPoint pCp, out int pcFetched);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Skip(int cSkip);

            void Reset();

            UnsafeNativeMethodsR.IEnumConnectionPoints Clone();
        }

        [Guid("00020400-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IDispatch
        {
            int GetTypeInfoCount();

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.ITypeInfo GetTypeInfo([MarshalAs(UnmanagedType.U4), In] int iTInfo, [MarshalAs(UnmanagedType.U4), In] int lcid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetIDsOfNames([In] ref Guid riid, [MarshalAs(UnmanagedType.LPArray), In] string[] rgszNames, [MarshalAs(UnmanagedType.U4), In] int cNames, [MarshalAs(UnmanagedType.U4), In] int lcid, [MarshalAs(UnmanagedType.LPArray), Out] int[] rgDispId);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Invoke(int dispIdMember, [In] ref Guid riid, [MarshalAs(UnmanagedType.U4), In] int lcid, [MarshalAs(UnmanagedType.U4), In] int dwFlags, [In, Out] NativeMethodsR.tagDISPPARAMS pDispParams, [MarshalAs(UnmanagedType.LPArray), Out] object[] pVarResult, [In, Out] NativeMethodsR.tagEXCEPINFO pExcepInfo, [MarshalAs(UnmanagedType.LPArray), Out] IntPtr[] pArgErr);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00020401-0000-0000-C000-000000000046")]
        [ComImport]
        public interface ITypeInfo
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetTypeAttr(ref IntPtr pTypeAttr);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetTypeComp([MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeComp[] ppTComp);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetFuncDesc([MarshalAs(UnmanagedType.U4), In] int index, ref IntPtr pFuncDesc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetVarDesc([MarshalAs(UnmanagedType.U4), In] int index, ref IntPtr pVarDesc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetNames(int memid, [MarshalAs(UnmanagedType.LPArray), Out] string[] rgBstrNames, [MarshalAs(UnmanagedType.U4), In] int cMaxNames, [MarshalAs(UnmanagedType.LPArray), Out] int[] pcNames);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetRefTypeOfImplType([MarshalAs(UnmanagedType.U4), In] int index, [MarshalAs(UnmanagedType.LPArray), Out] int[] pRefType);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetImplTypeFlags([MarshalAs(UnmanagedType.U4), In] int index, [MarshalAs(UnmanagedType.LPArray), Out] int[] pImplTypeFlags);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetIDsOfNames(IntPtr rgszNames, int cNames, IntPtr pMemId);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Invoke();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDocumentation(int memid, ref string pBstrName, ref string pBstrDocString, [MarshalAs(UnmanagedType.LPArray), Out] int[] pdwHelpContext, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrHelpFile);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDllEntry(int memid, NativeMethodsR.tagINVOKEKIND invkind, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrDllName, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrName, [MarshalAs(UnmanagedType.LPArray), Out] short[] pwOrdinal);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetRefTypeInfo(IntPtr hreftype, ref UnsafeNativeMethodsR.ITypeInfo pTypeInfo);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int AddressOfMember();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateInstance([In] ref Guid riid, [MarshalAs(UnmanagedType.LPArray), Out] object[] ppvObj);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetMops(int memid, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrMops);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetContainingTypeLib([MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeLib[] ppTLib, [MarshalAs(UnmanagedType.LPArray), Out] int[] pIndex);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void ReleaseTypeAttr(IntPtr typeAttr);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void ReleaseFuncDesc(IntPtr funcDesc);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void ReleaseVarDesc(IntPtr varDesc);
        }

        [Guid("00020403-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface ITypeComp
        {
            void RemoteBind([MarshalAs(UnmanagedType.LPWStr), In] string szName, [MarshalAs(UnmanagedType.U4), In] int lHashVal, [MarshalAs(UnmanagedType.U2), In] short wFlags, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeInfo[] ppTInfo, [MarshalAs(UnmanagedType.LPArray), Out] NativeMethodsR.tagDESCKIND[] pDescKind, [MarshalAs(UnmanagedType.LPArray), Out] NativeMethodsR.tagFUNCDESC[] ppFuncDesc, [MarshalAs(UnmanagedType.LPArray), Out] NativeMethodsR.tagVARDESC[] ppVarDesc, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeComp[] ppTypeComp, [MarshalAs(UnmanagedType.LPArray), Out] int[] pDummy);

            void RemoteBindType([MarshalAs(UnmanagedType.LPWStr), In] string szName, [MarshalAs(UnmanagedType.U4), In] int lHashVal, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeInfo[] ppTInfo);
        }

        [Guid("00020402-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface ITypeLib
        {
            void RemoteGetTypeInfoCount([MarshalAs(UnmanagedType.LPArray), Out] int[] pcTInfo);

            void GetTypeInfo([MarshalAs(UnmanagedType.U4), In] int index, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeInfo[] ppTInfo);

            void GetTypeInfoType([MarshalAs(UnmanagedType.U4), In] int index, [MarshalAs(UnmanagedType.LPArray), Out] NativeMethodsR.tagTYPEKIND[] pTKind);

            void GetTypeInfoOfGuid([In] ref Guid guid, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeInfo[] ppTInfo);

            void RemoteGetLibAttr(IntPtr ppTLibAttr, [MarshalAs(UnmanagedType.LPArray), Out] int[] pDummy);

            void GetTypeComp([MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeComp[] ppTComp);

            void RemoteGetDocumentation(int index, [MarshalAs(UnmanagedType.U4), In] int refPtrFlags, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrName, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrDocString, [MarshalAs(UnmanagedType.LPArray), Out] int[] pdwHelpContext, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrHelpFile);

            void RemoteIsName([MarshalAs(UnmanagedType.LPWStr), In] string szNameBuf, [MarshalAs(UnmanagedType.U4), In] int lHashVal, [MarshalAs(UnmanagedType.LPArray), Out] IntPtr[] pfName, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrLibName);

            void RemoteFindName([MarshalAs(UnmanagedType.LPWStr), In] string szNameBuf, [MarshalAs(UnmanagedType.U4), In] int lHashVal, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.ITypeInfo[] ppTInfo, [MarshalAs(UnmanagedType.LPArray), Out] int[] rgMemId, [MarshalAs(UnmanagedType.LPArray), In, Out] short[] pcFound, [MarshalAs(UnmanagedType.LPArray), Out] string[] pBstrLibName);

            void LocalReleaseTLibAttr();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("DF0B3D60-548F-101B-8E65-08002B2BD119")]
        [ComImport]
        public interface ISupportErrorInfo
        {
            int InterfaceSupportsErrorInfo([In] ref Guid riid);
        }

        [Guid("1CF2B120-547D-101B-8E65-08002B2BD119")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IErrorInfo
        {
            [SuppressUnmanagedCodeSecurity]
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetGUID(out Guid pguid);

            [SuppressUnmanagedCodeSecurity]
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetSource([MarshalAs(UnmanagedType.BStr), In, Out] ref string pBstrSource);

            [SuppressUnmanagedCodeSecurity]
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDescription([MarshalAs(UnmanagedType.BStr), In, Out] ref string pBstrDescription);

            [SuppressUnmanagedCodeSecurity]
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetHelpFile([MarshalAs(UnmanagedType.BStr), In, Out] ref string pBstrHelpFile);

            [SuppressUnmanagedCodeSecurity]
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetHelpContext([MarshalAs(UnmanagedType.U4), In, Out] ref int pdwHelpContext);
        }

        [SuppressUnmanagedCodeSecurity]
        [StructLayout(LayoutKind.Sequential)]
        public class OFNOTIFY
        {
            public IntPtr hdr_hwndFrom = IntPtr.Zero;
            public IntPtr hdr_idFrom = IntPtr.Zero;
            public IntPtr lpOFN = IntPtr.Zero;
            public IntPtr pszFile = IntPtr.Zero;
            public int hdr_code;
        }

        [Flags]
        public enum BrowseInfos
        {
            NewDialogStyle = 64,
            HideNewFolderButton = 512,
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            public string lpszTitle;
            public int ulFlags;
            public UnsafeNativeMethodsR.BrowseCallbackProc lpfn;
            public IntPtr lParam;
            public int iImage;
        }

        [SuppressUnmanagedCodeSecurity]
        internal class Shell32
        {
            [DllImport("shell32.dll")]
            public static extern int SHGetSpecialFolderLocation(IntPtr hwnd, int csidl, ref IntPtr ppidl);

            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);

            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SHBrowseForFolder([In] UnsafeNativeMethodsR.BROWSEINFO lpbi);

            [DllImport("shell32.dll")]
            public static extern int SHGetMalloc([MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.IMalloc[] ppMalloc);

            [DllImport("shell32.dll", EntryPoint = "SHGetFolderPathEx")]
            private static extern int SHGetFolderPathExPrivate(ref Guid rfid, uint dwFlags, IntPtr hToken, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath, uint cchPath);

            public static int SHGetFolderPathEx(ref Guid rfid, uint dwFlags, IntPtr hToken, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath, uint cchPath)
            {
                if (UnsafeNativeMethodsR.IsVista)
                    return UnsafeNativeMethodsR.Shell32.SHGetFolderPathExPrivate(ref rfid, dwFlags, hToken, pszPath, cchPath);
                throw new NotSupportedException();
            }

            //[DllImport("shell32.dll")]
            //public static extern int SHCreateShellItem(IntPtr pidlParent, IntPtr psfParent, IntPtr pidl, out FileDialogNative.IShellItem ppsi);

            [DllImport("shell32.dll")]
            public static extern int SHILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath, out IntPtr ppIdl, ref uint rgflnOut);
        }

        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000002-0000-0000-c000-000000000046")]
        [ComImport]
        public interface IMalloc
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            IntPtr Alloc(int cb);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            IntPtr Realloc(IntPtr pv, int cb);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void Free(IntPtr pv);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetSize(IntPtr pv);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int DidAlloc(IntPtr pv);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            void HeapMinimize();
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000126-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IRunnableObject
        {
            void GetRunningClass(out Guid guid);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Run(IntPtr lpBindContext);

            bool IsRunning();

            void LockRunning(bool fLock, bool fLastUnlockCloses);

            void SetContainedObject(bool fContained);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B722BCC7-4E68-101B-A2BC-00AA00404770")]
        [ComVisible(true)]
        [ComImport]
        public interface IOleDocumentSite
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            [return: MarshalAs(UnmanagedType.I4)]
            int ActivateMe([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleDocumentView pViewToActivate);
        }

        [Guid("B722BCC6-4E68-101B-A2BC-00AA00404770")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComVisible(true)]
        public interface IOleDocumentView
        {
            void SetInPlaceSite([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleInPlaceSite pIPSite);

            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethodsR.IOleInPlaceSite GetInPlaceSite();

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetDocument();

            void SetRect([In] ref NativeMethodsR.RECT prcView);

            void GetRect([In, Out] ref NativeMethodsR.RECT prcView);

            void SetRectComplex([In] NativeMethodsR.RECT prcView, [In] NativeMethodsR.RECT prcHScroll, [In] NativeMethodsR.RECT prcVScroll, [In] NativeMethodsR.RECT prcSizeBox);

            void Show(bool fShow);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int UIActivate(bool fUIActivate);

            void Open();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int Close([MarshalAs(UnmanagedType.U4), In] int dwReserved);

            void SaveViewState([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm);

            void ApplyViewState([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm);

            void Clone([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IOleInPlaceSite pIPSiteNew, [MarshalAs(UnmanagedType.LPArray), Out] UnsafeNativeMethodsR.IOleDocumentView[] ppViewNew);
        }

        [Guid("b722bcc5-4e68-101b-a2bc-00aa00404770")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IOleDocument
        {
            [MethodImpl(MethodImplOptions.PreserveSig)]
            int CreateView(UnsafeNativeMethodsR.IOleInPlaceSite pIPSite, UnsafeNativeMethodsR.IStream pstm, int dwReserved, out UnsafeNativeMethodsR.IOleDocumentView ppView);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int GetDocMiscStatus(out int pdwStatus);

            int EnumViews(out object ppEnum, out UnsafeNativeMethodsR.IOleDocumentView ppView);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000011e-0000-0000-C000-000000000046")]
        [ComImport]
        public interface IOleCache
        {
            int Cache(ref FORMATETC pformatetc, int advf);

            void Uncache(int dwConnection);

            object EnumCache();

            void InitCache(System.Runtime.InteropServices.ComTypes.IDataObject pDataObject);

            void SetData(ref FORMATETC pformatetc, ref STGMEDIUM pmedium, bool fRelease);
        }

        [Guid("BEF6E002-A874-101A-8BBA-00AA00300CAB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IFont
        {
            [return: MarshalAs(UnmanagedType.BStr)]
            string GetName();

            void SetName([MarshalAs(UnmanagedType.BStr), In] string pname);

            [return: MarshalAs(UnmanagedType.U8)]
            long GetSize();

            void SetSize([MarshalAs(UnmanagedType.U8), In] long psize);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBold();

            void SetBold([MarshalAs(UnmanagedType.Bool), In] bool pbold);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetItalic();

            void SetItalic([MarshalAs(UnmanagedType.Bool), In] bool pitalic);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetUnderline();

            void SetUnderline([MarshalAs(UnmanagedType.Bool), In] bool punderline);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetStrikethrough();

            void SetStrikethrough([MarshalAs(UnmanagedType.Bool), In] bool pstrikethrough);

            [return: MarshalAs(UnmanagedType.I2)]
            short GetWeight();

            void SetWeight([MarshalAs(UnmanagedType.I2), In] short pweight);

            [return: MarshalAs(UnmanagedType.I2)]
            short GetCharset();

            void SetCharset([MarshalAs(UnmanagedType.I2), In] short pcharset);

            IntPtr GetHFont();

            void Clone(out UnsafeNativeMethodsR.IFont ppfont);

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int IsEqual([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IFont pfontOther);

            void SetRatio(int cyLogical, int cyHimetric);

            void QueryTextMetrics(out IntPtr ptm);

            void AddRefHfont(IntPtr hFont);

            void ReleaseHfont(IntPtr hFont);

            void SetHdc(IntPtr hdc);
        }

        [Guid("7BF80980-BF32-101A-8BBB-00AA00300CAB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface IPicture
        {
            IntPtr GetHandle();

            IntPtr GetHPal();

            [return: MarshalAs(UnmanagedType.I2)]
            short GetPictureType();

            int GetWidth();

            int GetHeight();

            void Render(IntPtr hDC, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, IntPtr rcBounds);

            void SetHPal(IntPtr phpal);

            IntPtr GetCurDC();

            void SelectPicture(IntPtr hdcIn, [MarshalAs(UnmanagedType.LPArray), Out] IntPtr[] phdcOut, [MarshalAs(UnmanagedType.LPArray), Out] IntPtr[] phbmpOut);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetKeepOriginalFormat();

            void SetKeepOriginalFormat([MarshalAs(UnmanagedType.Bool), In] bool pfkeep);

            void PictureChanged();

            [MethodImpl(MethodImplOptions.PreserveSig)]
            int SaveAsFile([MarshalAs(UnmanagedType.Interface), In] UnsafeNativeMethodsR.IStream pstm, int fSaveMemCopy, out int pcbSize);

            int GetAttributes();
        }

        [Guid("7BF80981-BF32-101A-8BBB-00AA00300CAB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport]
        public interface IPictureDisp
        {
            IntPtr Handle { get; }

            IntPtr HPal { get; }

            short PictureType { get; }

            int Width { get; }

            int Height { get; }

            void Render(IntPtr hdc, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc);
        }

        [SuppressUnmanagedCodeSecurity]
        internal class ThemingScope
        {
            private const int ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 4;
            private const int ACTCTX_FLAG_RESOURCE_NAME_VALID = 8;
            private static UnsafeNativeMethodsR.ThemingScope.ACTCTX enableThemingActivationContext;
            private static IntPtr hActCtx;
            private static bool contextCreationSucceeded;

            private static bool IsContextActive()
            {
                IntPtr handle = IntPtr.Zero;
                if (UnsafeNativeMethodsR.ThemingScope.contextCreationSucceeded && UnsafeNativeMethodsR.ThemingScope.GetCurrentActCtx(out handle))
                    return handle == UnsafeNativeMethodsR.ThemingScope.hActCtx;
                return false;
            }

            public static IntPtr Activate()
            {
                IntPtr lpCookie = IntPtr.Zero;
                if (UnsafeNativeMethodsR.ThemingScope.contextCreationSucceeded && (OSFeature.Feature.IsPresent(OSFeature.Themes) && !UnsafeNativeMethodsR.ThemingScope.IsContextActive()) && !UnsafeNativeMethodsR.ThemingScope.ActivateActCtx(UnsafeNativeMethodsR.ThemingScope.hActCtx, out lpCookie))
                    lpCookie = IntPtr.Zero;
                return lpCookie;
            }

            public static IntPtr Deactivate(IntPtr userCookie)
            {
                if (userCookie != IntPtr.Zero && OSFeature.Feature.IsPresent(OSFeature.Themes) && UnsafeNativeMethodsR.ThemingScope.DeactivateActCtx(0, userCookie))
                    userCookie = IntPtr.Zero;
                return userCookie;
            }

            public static bool CreateActivationContext(string dllPath, int nativeResourceManifestID)
            {
                lock (typeof(UnsafeNativeMethodsR.ThemingScope))
                {
                    if (!UnsafeNativeMethodsR.ThemingScope.contextCreationSucceeded && OSFeature.Feature.IsPresent(OSFeature.Themes))
                    {
                        UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext = new UnsafeNativeMethodsR.ThemingScope.ACTCTX();
                        UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext.cbSize = Marshal.SizeOf(typeof(UnsafeNativeMethodsR.ThemingScope.ACTCTX));
                        UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext.lpSource = dllPath;
                        UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext.lpResourceName = (IntPtr)nativeResourceManifestID;
                        UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext.dwFlags = 8U;
                        UnsafeNativeMethodsR.ThemingScope.hActCtx = UnsafeNativeMethodsR.ThemingScope.CreateActCtx(ref UnsafeNativeMethodsR.ThemingScope.enableThemingActivationContext);
                        UnsafeNativeMethodsR.ThemingScope.contextCreationSucceeded = UnsafeNativeMethodsR.ThemingScope.hActCtx != new IntPtr(-1);
                    }
                    return UnsafeNativeMethodsR.ThemingScope.contextCreationSucceeded;
                }
            }

            [DllImport("kernel32.dll")]
            private static extern IntPtr CreateActCtx(ref UnsafeNativeMethodsR.ThemingScope.ACTCTX actctx);

            [DllImport("kernel32.dll")]
            private static extern bool ActivateActCtx(IntPtr hActCtx, out IntPtr lpCookie);

            [DllImport("kernel32.dll")]
            private static extern bool DeactivateActCtx(int dwFlags, IntPtr lpCookie);

            [DllImport("kernel32.dll")]
            private static extern bool GetCurrentActCtx(out IntPtr handle);

            private struct ACTCTX
            {
                public int cbSize;
                public uint dwFlags;
                public string lpSource;
                public ushort wProcessorArchitecture;
                public ushort wLangId;
                public string lpAssemblyDirectory;
                public IntPtr lpResourceName;
                public string lpApplicationName;
            }
        }
    }
}
