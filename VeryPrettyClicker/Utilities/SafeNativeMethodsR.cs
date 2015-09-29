// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.SafeNativeMethods
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: D4F73B0E-3B8D-4341-A790-516ED5C6F955
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethodsR
    {
        [DllImport("shlwapi.dll")]
        public static extern int SHAutoComplete(HandleRef hwndEdit, int flags);

        [DllImport("user32.dll")]
        public static extern int OemKeyScan(short wAsciiVal);

        [DllImport("gdi32.dll")]
        public static extern int GetSystemPaletteEntries(HandleRef hdc, int iStartIndex, int nEntries, byte[] lppe);

        [DllImport("gdi32.dll")]
        public static extern int GetDIBits(HandleRef hdc, HandleRef hbm, int uStartScan, int cScanLines, byte[] lpvBits, ref NativeMethodsR.BITMAPINFO_FLAT bmi, int uUsage);

        [DllImport("gdi32.dll")]
        public static extern int StretchDIBits(HandleRef hdc, int XDest, int YDest, int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth, int nSrcHeight, byte[] lpBits, ref NativeMethodsR.BITMAPINFO_FLAT lpBitsInfo, int iUsage, int dwRop);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr IntCreateCompatibleBitmap(HandleRef hDC, int width, int height);

        public static IntPtr CreateCompatibleBitmap(HandleRef hDC, int width, int height)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateCompatibleBitmap(hDC, width, height), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetScrollInfo(HandleRef hWnd, int fnBar, [In, Out] NativeMethodsR.SCROLLINFO si);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsAccelerator(HandleRef hAccel, int cAccelEntries, [In] ref NativeMethodsR.MSG lpMsg, short[] lpwCmd);

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ChooseFont([In, Out] NativeMethodsR.CHOOSEFONT cf);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetBitmapBits(HandleRef hbmp, int cbBuffer, byte[] lpvBits);

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CommDlgExtendedError();

        [DllImport("oleaut32.dll", CharSet = CharSet.Unicode)]
        public static extern void SysFreeString(HandleRef bstr);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)] string caption, int objects, [MarshalAs(UnmanagedType.Interface)] ref object pobjs, int pages, HandleRef pClsid, int locale, int reserved1, IntPtr reserved2);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)] string caption, int objects, [MarshalAs(UnmanagedType.Interface)] ref object pobjs, int pages, Guid[] pClsid, int locale, int reserved1, IntPtr reserved2);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)] string caption, int objects, HandleRef lplpobjs, int pages, HandleRef pClsid, int locale, int reserved1, IntPtr reserved2);

        [DllImport("hhctrl.ocx", CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)] string pszFile, int uCommand, int dwData);

        [DllImport("hhctrl.ocx", CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)] string pszFile, int uCommand, string dwData);

        [DllImport("hhctrl.ocx", CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)] string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)] NativeMethodsR.HH_POPUP dwData);

        [DllImport("hhctrl.ocx", CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)] string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)] NativeMethodsR.HH_FTS_QUERY dwData);

        [DllImport("hhctrl.ocx", CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)] string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)] NativeMethodsR.HH_AKLINK dwData);

        [DllImport("oleaut32.dll")]
        public static extern void VariantInit(HandleRef pObject);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void VariantClear(HandleRef pObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool LineTo(HandleRef hdc, int x, int y);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool MoveToEx(HandleRef hdc, int x, int y, NativeMethodsR.POINT pt);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool Rectangle(HandleRef hdc, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PatBlt(HandleRef hdc, int left, int top, int width, int height, int rop);

        [DllImport("kernel32.dll", EntryPoint = "GetThreadLocale", CharSet = CharSet.Auto)]
        public static extern int GetThreadLCID();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetMessagePos();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RegisterClipboardFormat(string format);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClipboardFormatName(int format, StringBuilder lpString, int cchMax);

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ChooseColor([In, Out] NativeMethodsR.CHOOSECOLOR cc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ExternalDeleteObject(HandleRef hObject);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool IntDeleteObject(HandleRef hObject);

        public static bool DeleteObject(HandleRef hObject)
        {
            HandleCollectorR.Remove((IntPtr)hObject, NativeMethodsR.CommonHandles.GDI);
            return SafeNativeMethodsR.IntDeleteObject(hObject);
        }

        [DllImport("oleaut32.dll", EntryPoint = "OleCreateFontIndirect", PreserveSig = false)]
        public static extern SafeNativeMethodsR.IFontDisp OleCreateIFontDispIndirect(NativeMethodsR.FONTDESC fd, ref Guid iid);

        [DllImport("gdi32.dll", EntryPoint = "CreateSolidBrush", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateSolidBrush(int crColor);

        public static IntPtr CreateSolidBrush(int crColor)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateSolidBrush(crColor), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowExtEx(HandleRef hDC, int x, int y, [In, Out] NativeMethodsR.SIZE size);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int FormatMessage(int dwFlags, HandleRef lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, HandleRef arguments);

        [DllImport("comctl32.dll")]
        public static extern void InitCommonControls();

        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControlsEx(NativeMethodsR.INITCOMMONCONTROLSEX icc);

        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Create(int cx, int cy, int flags, int cInitial, int cGrow);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Destroy(HandleRef himl);

        [DllImport("comctl32.dll", EntryPoint = "ImageList_Destroy")]
        public static extern bool ImageList_Destroy_Native(HandleRef himl);

        [DllImport("comctl32.dll")]
        public static extern int ImageList_GetImageCount(HandleRef himl);

        [DllImport("comctl32.dll")]
        public static extern int ImageList_Add(HandleRef himl, HandleRef hbmImage, HandleRef hbmMask);

        [DllImport("comctl32.dll")]
        public static extern int ImageList_ReplaceIcon(HandleRef himl, int index, HandleRef hicon);

        [DllImport("comctl32.dll")]
        public static extern int ImageList_SetBkColor(HandleRef himl, int clrBk);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Draw(HandleRef himl, int i, HandleRef hdcDst, int x, int y, int fStyle);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Replace(HandleRef himl, int i, HandleRef hbmImage, HandleRef hbmMask);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DrawEx(HandleRef himl, int i, HandleRef hdcDst, int x, int y, int dx, int dy, int rgbBk, int rgbFg, int fStyle);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_GetIconSize(HandleRef himl, out int x, out int y);

        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Duplicate(HandleRef himl);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Remove(HandleRef himl, int i);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_GetImageInfo(HandleRef himl, int i, NativeMethodsR.IMAGEINFO pImageInfo);

        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Read(UnsafeNativeMethodsR.IStream pstm);

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Write(HandleRef himl, UnsafeNativeMethodsR.IStream pstm);

        [DllImport("comctl32.dll")]
        public static extern int ImageList_WriteEx(HandleRef himl, int dwFlags, UnsafeNativeMethodsR.IStream pstm);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackPopupMenuEx(HandleRef hmenu, int fuFlags, int x, int y, HandleRef hwnd, NativeMethodsR.TPMPARAMS tpm);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetKeyboardLayout(int dwLayout);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ActivateKeyboardLayout(HandleRef hkl, int uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardLayoutList(int size, [MarshalAs(UnmanagedType.LPArray), Out] IntPtr[] hkls);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref NativeMethodsR.DEVMODE lpDevMode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(HandleRef hmonitor, [In, Out] NativeMethodsR.MONITORINFOEX info);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromPoint(NativeMethodsR.POINTSTRUCT pt, int flags);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromRect(ref NativeMethodsR.RECT rect, int flags);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(HandleRef handle, int flags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(HandleRef hdc, NativeMethodsR.COMRECT rcClip, NativeMethodsR.MonitorEnumProc lpfnEnum, IntPtr dwData);

        [DllImport("gdi32.dll", EntryPoint = "CreateHalftonePalette", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateHalftonePalette(HandleRef hdc);

        public static IntPtr CreateHalftonePalette(HandleRef hdc)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateHalftonePalette(hdc), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetPaletteEntries(HandleRef hpal, int iStartIndex, int nEntries, int[] lppe);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetTextMetricsW(HandleRef hDC, [In, Out] ref NativeMethodsR.TEXTMETRIC lptm);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetTextMetricsA(HandleRef hDC, [In, Out] ref NativeMethodsR.TEXTMETRICA lptm);

        public static int GetTextMetrics(HandleRef hDC, ref NativeMethodsR.TEXTMETRIC lptm)
        {
            //if (Marshal.SystemDefaultCharSize != 1)
              //  return SafeNativeMethodsR.GetTextMetricsW(hDC, out lptm);
            NativeMethodsR.TEXTMETRICA lptm1 = new NativeMethodsR.TEXTMETRICA();
            //int textMetricsA = SafeNativeMethodsR.GetTextMetricsA(hDC, out lptm1);
            lptm.tmHeight = lptm1.tmHeight;
            lptm.tmAscent = lptm1.tmAscent;
            lptm.tmDescent = lptm1.tmDescent;
            lptm.tmInternalLeading = lptm1.tmInternalLeading;
            lptm.tmExternalLeading = lptm1.tmExternalLeading;
            lptm.tmAveCharWidth = lptm1.tmAveCharWidth;
            lptm.tmMaxCharWidth = lptm1.tmMaxCharWidth;
            lptm.tmWeight = lptm1.tmWeight;
            lptm.tmOverhang = lptm1.tmOverhang;
            lptm.tmDigitizedAspectX = lptm1.tmDigitizedAspectX;
            lptm.tmDigitizedAspectY = lptm1.tmDigitizedAspectY;
            lptm.tmFirstChar = (char)lptm1.tmFirstChar;
            lptm.tmLastChar = (char)lptm1.tmLastChar;
            lptm.tmDefaultChar = (char)lptm1.tmDefaultChar;
            lptm.tmBreakChar = (char)lptm1.tmBreakChar;
            lptm.tmItalic = lptm1.tmItalic;
            lptm.tmUnderlined = lptm1.tmUnderlined;
            lptm.tmStruckOut = lptm1.tmStruckOut;
            lptm.tmPitchAndFamily = lptm1.tmPitchAndFamily;
            lptm.tmCharSet = lptm1.tmCharSet;
            return 1;//textMetricsA;
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateDIBSection", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateDIBSection(HandleRef hdc, HandleRef pbmi, int iUsage, byte[] ppvBits, IntPtr hSection, int dwOffset);

        public static IntPtr CreateDIBSection(HandleRef hdc, HandleRef pbmi, int iUsage, byte[] ppvBits, IntPtr hSection, int dwOffset)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateDIBSection(hdc, pbmi, iUsage, ppvBits, hSection, dwOffset), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, IntPtr lpvBits);

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, IntPtr lpvBits)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateBitmap(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateBitmapShort(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateBitmapShort(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateBitmapByte(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, byte[] lpvBits);

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, byte[] lpvBits)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateBitmapByte(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreatePatternBrush", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreatePatternBrush(HandleRef hbmp);

        public static IntPtr CreatePatternBrush(HandleRef hbmp)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreatePatternBrush(hbmp), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateBrushIndirect", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateBrushIndirect(NativeMethodsR.LOGBRUSH lb);

        public static IntPtr CreateBrushIndirect(NativeMethodsR.LOGBRUSH lb)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateBrushIndirect(lb), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", EntryPoint = "CreatePen", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreatePen(int nStyle, int nWidth, int crColor);

        public static IntPtr CreatePen(int nStyle, int nWidth, int crColor)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreatePen(nStyle, nWidth, crColor), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetViewportExtEx(HandleRef hDC, int x, int y, NativeMethodsR.SIZE size);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(HandleRef hInst, int iconId);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClipCursor([In, Out] ref NativeMethodsR.RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCursor();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetIconInfo(HandleRef hIcon, [In, Out] NativeMethodsR.ICONINFO info);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int IntersectClipRect(HandleRef hDC, int x1, int y1, int x2, int y2);

        [DllImport("user32.dll", EntryPoint = "CopyImage", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCopyImage(HandleRef hImage, int uType, int cxDesired, int cyDesired, int fuFlags);

        public static IntPtr CopyImage(HandleRef hImage, int uType, int cxDesired, int cyDesired, int fuFlags)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCopyImage(hImage, uType, cxDesired, cyDesired, fuFlags), NativeMethodsR.CommonHandles.GDI);
        }

        public static IntPtr CopyImageAsCursor(HandleRef hImage, int uType, int cxDesired, int cyDesired, int fuFlags)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCopyImage(hImage, uType, cxDesired, cyDesired, fuFlags), NativeMethodsR.CommonHandles.Cursor);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AdjustWindowRectEx(ref NativeMethodsR.RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int DoDragDrop(System.Runtime.InteropServices.ComTypes.IDataObject dataObject, UnsafeNativeMethodsR.IOleDropSource dropSource, int allowedEffects, int[] finalEffect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetSysColorBrush(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnableWindow(HandleRef hWnd, bool enable);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref NativeMethodsR.RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetDoubleClickTime();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetUpdateRgn(HandleRef hwnd, HandleRef hrgn, bool fErase);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(HandleRef hWnd, [In, Out] ref NativeMethodsR.RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int FillRect(HandleRef hdc, [In] ref NativeMethodsR.RECT rect, HandleRef hbrush);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetTextColor(HandleRef hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetBkColor(HandleRef hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetTextColor(HandleRef hDC, int crColor);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetBkColor(HandleRef hDC, int clr);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SelectPalette(HandleRef hdc, HandleRef hpal, int bForceBackground);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetViewportOrgEx(HandleRef hDC, int x, int y, [In, Out] NativeMethodsR.POINT point);

        [DllImport("gdi32.dll", EntryPoint = "CreateRectRgn", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateRectRgn(int x1, int y1, int x2, int y2);

        public static IntPtr CreateRectRgn(int x1, int y1, int x2, int y2)
        {
            return HandleCollectorR.Add(SafeNativeMethodsR.IntCreateRectRgn(x1, y1, x2, y2), NativeMethodsR.CommonHandles.GDI);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CombineRgn(HandleRef hRgn, HandleRef hRgn1, HandleRef hRgn2, int nCombineMode);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RealizePalette(HandleRef hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool LPtoDP(HandleRef hDC, [In, Out] ref NativeMethodsR.RECT lpRect, int nCount);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowOrgEx(HandleRef hDC, int x, int y, [In, Out] NativeMethodsR.POINT point);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetViewportOrgEx(HandleRef hDC, [In, Out] NativeMethodsR.POINT point);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetMapMode(HandleRef hDC, int nMapMode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowEnabled(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(SafeNativeMethodsR.EnumThreadWindowsCallback callback, IntPtr extraData);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(HandleRef hWnd, out int lpdwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeThread(HandleRef hWnd, out int lpdwExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);

        [CLSCompliant(false)]
        [DllImport("comctl32.dll")]
        private static extern bool _TrackMouseEvent(NativeMethodsR.TRACKMOUSEEVENT tme);

        public static bool TrackMouseEvent(NativeMethodsR.TRACKMOUSEEVENT tme)
        {
            return SafeNativeMethodsR._TrackMouseEvent(tme);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(HandleRef hwnd, ref NativeMethodsR.RECT rcUpdate, HandleRef hrgnUpdate, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(HandleRef hwnd, NativeMethodsR.COMRECT rcUpdate, HandleRef hrgnUpdate, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(HandleRef hWnd, ref NativeMethodsR.RECT rect, bool erase);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(HandleRef hWnd, NativeMethodsR.COMRECT rect, bool erase);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRgn(HandleRef hWnd, HandleRef hrgn, bool erase);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(HandleRef hWnd);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentProcessId();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int ScrollWindowEx(HandleRef hWnd, int nXAmount, int nYAmount, NativeMethodsR.COMRECT rectScrollRegion, ref NativeMethodsR.RECT rectClip, HandleRef hrgnUpdate, ref NativeMethodsR.RECT prcUpdate, int flags);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetThreadLocale();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool MessageBeep(int type);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawMenuBar(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsChild(HandleRef parent, HandleRef child);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetTimer(HandleRef hWnd, int nIDEvent, int uElapse, IntPtr lpTimerFunc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool KillTimer(HandleRef hwnd, int idEvent);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(HandleRef hWnd, string text, string caption, int type);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetTickCount();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScrollWindow(HandleRef hWnd, int nXAmount, int nYAmount, ref NativeMethodsR.RECT rectScrollRegion, ref NativeMethodsR.RECT rectClip);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentThread();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetThreadLocale(int Locale);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowUnicode(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawEdge(HandleRef hDC, ref NativeMethodsR.RECT rect, int edge, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawFrameControl(HandleRef hDC, ref NativeMethodsR.RECT rect, int type, int state);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClipRgn(HandleRef hDC, HandleRef hRgn);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetRgnBox(HandleRef hRegion, ref NativeMethodsR.RECT clipRect);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SelectClipRgn(HandleRef hDC, HandleRef hRgn);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetROP2(HandleRef hDC, int nDrawMode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawIcon(HandleRef hDC, int x, int y, HandleRef hIcon);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawIconEx(HandleRef hDC, int x, int y, HandleRef hIcon, int width, int height, int iStepIfAniCursor, HandleRef hBrushFlickerFree, int diFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetBkMode(HandleRef hDC, int nBkMode);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool BitBlt(HandleRef hDC, int x, int y, int nWidth, int nHeight, HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowCaret(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool HideCaret(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetCaretBlinkTime();

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsAppThemed();

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeAppProperties();

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern void SetThemeAppProperties(int Flags);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenThemeData(HandleRef hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszClassList);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int CloseThemeData(HandleRef hTheme);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsThemePartDefined(HandleRef hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int DrawThemeBackground(HandleRef hTheme, HandleRef hdc, int partId, int stateId, [In] NativeMethodsR.COMRECT pRect, [In] NativeMethodsR.COMRECT pClipRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int DrawThemeEdge(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethodsR.COMRECT pDestRect, int uEdge, int uFlags, [Out] NativeMethodsR.COMRECT pContentRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int DrawThemeParentBackground(HandleRef hwnd, HandleRef hdc, [In] NativeMethodsR.COMRECT prc);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int DrawThemeText(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, int dwTextFlags2, [In] NativeMethodsR.COMRECT pRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundContentRect(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethodsR.COMRECT pBoundingRect, [Out] NativeMethodsR.COMRECT pContentRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundExtent(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethodsR.COMRECT pContentRect, [Out] NativeMethodsR.COMRECT pExtentRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundRegion(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethodsR.COMRECT pRect, ref IntPtr pRegion);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeBool(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref bool pfVal);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeColor(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int pColor);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeEnumValue(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeFilename(HandleRef hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszThemeFilename, int cchMaxBuffChars);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeFont(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, int iPropId, NativeMethodsR.LOGFONT pFont);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeInt(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemePartSize(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethodsR.COMRECT prc, ThemeSizeType eSize, [Out] NativeMethodsR.SIZE psz);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemePosition(HandleRef hTheme, int iPartId, int iStateId, int iPropId, [Out] NativeMethodsR.POINT pPoint);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeMargins(HandleRef hTheme, HandleRef hDC, int iPartId, int iStateId, int iPropId, ref NativeMethodsR.MARGINS margins);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeString(HandleRef hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszBuff, int cchMaxBuffChars);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeDocumentationProperty([MarshalAs(UnmanagedType.LPWStr)] string pszThemeName, [MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, StringBuilder pszValueBuff, int cchMaxValChars);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeTextExtent(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, [In] NativeMethodsR.COMRECT pBoundingRect, [Out] NativeMethodsR.COMRECT pExtentRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeTextMetrics(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, ref TextMetrics ptm);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int HitTestThemeBackground(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, int dwOptions, [In] NativeMethodsR.COMRECT pRect, HandleRef hrgn, [In] NativeMethodsR.POINTSTRUCT ptTest, ref int pwHitTestCode);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsThemeBackgroundPartiallyTransparent(HandleRef hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern bool GetThemeSysBool(HandleRef hTheme, int iBoolId);

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        public static extern int GetThemeSysInt(HandleRef hTheme, int iIntId, ref int piValue);

        [DllImport("user32.dll")]
        public static extern IntPtr OpenInputDesktop(int dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fInherit, int dwDesiredAccess);

        [DllImport("user32.dll")]
        public static extern bool CloseDesktop(IntPtr hDesktop);

        public static int RGBToCOLORREF(int rgbValue)
        {
            int num = (rgbValue & (int)byte.MaxValue) << 16;
            rgbValue &= 16776960;
            rgbValue |= rgbValue >> 16 & (int)byte.MaxValue;
            rgbValue &= (int)ushort.MaxValue;
            rgbValue |= num;
            return rgbValue;
        }

        public static Color ColorFromCOLORREF(int colorref)
        {
            return Color.FromArgb(colorref & (int)byte.MaxValue, colorref >> 8 & (int)byte.MaxValue, colorref >> 16 & (int)byte.MaxValue);
        }

        public static int ColorToCOLORREF(Color color)
        {
            return (int)color.R | (int)color.G << 8 | (int)color.B << 16;
        }

        internal delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("BEF6E003-A874-101A-8BBA-00AA00300CAB")]
        [ComImport]
        public interface IFontDisp
        {
            string Name { get; set; }

            long Size { get; set; }

            bool Bold { get; set; }

            bool Italic { get; set; }

            bool Underline { get; set; }

            bool Strikethrough { get; set; }

            short Weight { get; set; }

            short Charset { get; set; }
        }
    }
}
