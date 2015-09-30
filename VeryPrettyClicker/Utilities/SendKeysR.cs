// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.SendKeys
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: D4F73B0E-3B8D-4341-A790-516ED5C6F955
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Windows.Forms
{
    /// <summary>
    /// Предоставляет методы для отправки приложению сообщений о нажатиях клавиш.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public class SendKeysR
    {
        private static SendKeysR.KeywordVk[] keywords = new SendKeysR.KeywordVk[65]
    {
      new SendKeysR.KeywordVk("ENTER", 13),
      new SendKeysR.KeywordVk("TAB", 9),
      new SendKeysR.KeywordVk("ESC", 27),
      new SendKeysR.KeywordVk("ESCAPE", 27),
      new SendKeysR.KeywordVk("HOME", 36),
      new SendKeysR.KeywordVk("END", 35),
      new SendKeysR.KeywordVk("LEFT", 37),
      new SendKeysR.KeywordVk("RIGHT", 39),
      new SendKeysR.KeywordVk("UP", 38),
      new SendKeysR.KeywordVk("DOWN", 40),
      new SendKeysR.KeywordVk("PGUP", 33),
      new SendKeysR.KeywordVk("PGDN", 34),
      new SendKeysR.KeywordVk("NUMLOCK", 144),
      new SendKeysR.KeywordVk("SCROLLLOCK", 145),
      new SendKeysR.KeywordVk("PRTSC", 44),
      new SendKeysR.KeywordVk("BREAK", 3),
      new SendKeysR.KeywordVk("BACKSPACE", 8),
      new SendKeysR.KeywordVk("BKSP", 8),
      new SendKeysR.KeywordVk("BS", 8),
      new SendKeysR.KeywordVk("CLEAR", 12),
      new SendKeysR.KeywordVk("CAPSLOCK", 20),
      new SendKeysR.KeywordVk("INS", 45),
      new SendKeysR.KeywordVk("INSERT", 45),
      new SendKeysR.KeywordVk("DEL", 46),
      new SendKeysR.KeywordVk("DELETE", 46),
      new SendKeysR.KeywordVk("HELP", 47),
      new SendKeysR.KeywordVk("F1", 112),
      new SendKeysR.KeywordVk("F2", 113),
      new SendKeysR.KeywordVk("F3", 114),
      new SendKeysR.KeywordVk("F4", 115),
      new SendKeysR.KeywordVk("F5", 116),
      new SendKeysR.KeywordVk("F6", 117),
      new SendKeysR.KeywordVk("F7", 118),
      new SendKeysR.KeywordVk("F8", 119),
      new SendKeysR.KeywordVk("F9", 120),
      new SendKeysR.KeywordVk("F10", 121),
      new SendKeysR.KeywordVk("F11", 122),
      new SendKeysR.KeywordVk("F12", 123),
      new SendKeysR.KeywordVk("F13", 124),
      new SendKeysR.KeywordVk("F14", 125),
      new SendKeysR.KeywordVk("F15", 126),
      new SendKeysR.KeywordVk("F16", (int) sbyte.MaxValue),
      new SendKeysR.KeywordVk("MULTIPLY", 106),
      new SendKeysR.KeywordVk("ADD", 107),
      new SendKeysR.KeywordVk("SUBTRACT", 109),
      new SendKeysR.KeywordVk("DIVIDE", 111),
      new SendKeysR.KeywordVk("+", 107),
      new SendKeysR.KeywordVk("%", 65589),
      new SendKeysR.KeywordVk("^", 65590),
      new SendKeysR.KeywordVk("NUMPAD0",0x60),   //Numeric keypad 0 key 
        new SendKeysR.KeywordVk("NUMPAD1",0x61),   //Numeric keypad 1 key 
        new SendKeysR.KeywordVk("NUMPAD2",0x62),   //Numeric keypad 2 key 
        new SendKeysR.KeywordVk("NUMPAD3",0x63),   //Numeric keypad 3 key 
        new SendKeysR.KeywordVk("NUMPAD4",0x64),   //Numeric keypad 4 key 
        new SendKeysR.KeywordVk("NUMPAD5",0x65),   //Numeric keypad 5 key 
        new SendKeysR.KeywordVk("NUMPAD6",0x66),   //Numeric keypad 6 key 
        new SendKeysR.KeywordVk("NUMPAD7",0x67),   //Numeric keypad 7 key 
        new SendKeysR.KeywordVk("NUMPAD8",0x68),   //Numeric keypad 8 key 
        new SendKeysR.KeywordVk("NUMPAD9",0x69),   //Numeric keypad 9 key 
        new SendKeysR.KeywordVk("NUMPAD10",0x60),   //Numeric keypad 0 key 
        new SendKeysR.KeywordVk("NUMPAD11",0x6F),   //Divide key
        new SendKeysR.KeywordVk("NUMPAD12",0x6A),   //Decimal key 
        new SendKeysR.KeywordVk("10",0x30),   //Decimal key 
        new SendKeysR.KeywordVk("11",0xBD),   //Decimal key 
        new SendKeysR.KeywordVk("12",0xBB)   //Decimal key 
    };
        private static SendKeysR.SendMethodTypes? sendMethod = new SendKeysR.SendMethodTypes?();
        private static bool? hookSupported = new bool?();
        private static bool stopHook;
        private static IntPtr hhook;
        private static NativeMethodsR.HookProc hook;
        private static Queue events;
        private static bool fStartNewChar;
        private static SendKeysR.SKWindow messageWindow;
        private static bool capslockChanged;
        private static bool numlockChanged;
        private static bool scrollLockChanged;
        private static bool kanaChanged;
        private const int HAVESHIFT = 0;
        private const int HAVECTRL = 1;
        private const int HAVEALT = 2;
        private const int UNKNOWN_GROUPING = 10;
        private const int SHIFTKEYSCAN = 256;
        private const int CTRLKEYSCAN = 512;
        private const int ALTKEYSCAN = 1024;

        static SendKeysR()
        {
            Application.ThreadExit += new EventHandler(SendKeysR.OnThreadExit);
            SendKeysR.messageWindow = new SendKeysR.SKWindow();
            SendKeysR.messageWindow.CreateControl();
        }

        private SendKeysR()
        {
        }

        /// <summary>
        /// Посылает сообщения о нажатии клавиш активному приложению.
        /// </summary>
        /// <param name="keys">Строка, содержащая отправляемые данные о нажатиях клавиш.</param><exception cref="T:System.InvalidOperationException">Отсутствует активное приложение для отправки сообщений о нажатии клавиш.</exception><exception cref="T:System.ArgumentException">Объект <paramref name="keys"/> не представляет допустимые сообщения о нажатии клавиш.</exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Send(string keys)
        {
            SendKeysR.Send(keys, (Control)null, false);
        }

        public static void Send(string keys, IntPtr handle)
        {
            bool wait = true;
            //IntSecurity.UnmanagedCode.Demand();
            if (keys == null || keys.Length == 0)
                return;
            //if (!wait && !Application.MessageLoop)
            //throw new InvalidOperationException(SR1.GetString("SendKeysNoMessageLoop"));
            Queue previousEvents = (Queue)null;
            if (SendKeysR.events != null && SendKeysR.events.Count != 0)
                previousEvents = (Queue)SendKeysR.events.Clone();
            SendKeysR.ParseKeys(keys, handle);
            if (SendKeysR.events == null)
                return;
            SendKeysR.LoadSendMethodFromConfig();
            byte[] keyboardState = SendKeysR.GetKeyboardState();
            if (SendKeysR.sendMethod.Value != SendKeysR.SendMethodTypes.SendInput)
            {
                if (!SendKeysR.hookSupported.HasValue && SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.Default)
                    SendKeysR.TestHook();
                if (SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.JournalHook || SendKeysR.hookSupported.Value)
                {
                    SendKeysR.ClearKeyboardState();
                    SendKeysR.InstallHook();
                    SendKeysR.SetKeyboardState(keyboardState);
                }
            }
            if (SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.SendInput || SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.Default && !SendKeysR.hookSupported.Value)
                SendKeysR.SendInput(keyboardState, previousEvents);
            if (!wait)
                return;
            SendKeysR.Flush();
        }

        private static void Send(string keys, Control control, bool wait)
        {
            //IntSecurity.UnmanagedCode.Demand();
            if (keys == null || keys.Length == 0)
                return;
            //if (!wait && !Application.MessageLoop)
                //throw new InvalidOperationException(SR1.GetString("SendKeysNoMessageLoop"));
            Queue previousEvents = (Queue)null;
            if (SendKeysR.events != null && SendKeysR.events.Count != 0)
                previousEvents = (Queue)SendKeysR.events.Clone();
            SendKeysR.ParseKeys(keys, control != null ? control.Handle : IntPtr.Zero);
            if (SendKeysR.events == null)
                return;
            SendKeysR.LoadSendMethodFromConfig();
            byte[] keyboardState = SendKeysR.GetKeyboardState();
            if (SendKeysR.sendMethod.Value != SendKeysR.SendMethodTypes.SendInput)
            {
                if (!SendKeysR.hookSupported.HasValue && SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.Default)
                    SendKeysR.TestHook();
                if (SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.JournalHook || SendKeysR.hookSupported.Value)
                {
                    SendKeysR.ClearKeyboardState();
                    SendKeysR.InstallHook();
                    SendKeysR.SetKeyboardState(keyboardState);
                }
            }
            if (SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.SendInput || SendKeysR.sendMethod.Value == SendKeysR.SendMethodTypes.Default && !SendKeysR.hookSupported.Value)
                SendKeysR.SendInput(keyboardState, previousEvents);
            if (!wait)
                return;
            SendKeysR.Flush();
        }

        /// <summary>
        /// Отправляет указанные клавиши активному приложению и ожидает окончания обработки сообщений.
        /// </summary>
        /// <param name="keys">Строка, содержащая отправляемые данные о нажатиях клавиш.</param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void SendWait(string keys)
        {
            SendKeysR.SendWait(keys, (Control)null);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        private static void SendWait(string keys, Control control)
        {
            SendKeysR.Send(keys, control, true);
        }

        /// <summary>
        /// Обрабатывает все сообщения Windows, находящиеся в текущий момент в очереди сообщений.
        /// </summary>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void Flush()
        {
            Application.DoEvents();
            while (SendKeysR.events != null && SendKeysR.events.Count > 0)
                Application.DoEvents();
        }

        private static void AddEvent(SendKeysR.SKEvent skevent)
        {
            if (SendKeysR.events == null)
                SendKeysR.events = new Queue();
            SendKeysR.events.Enqueue((object)skevent);
        }

        private static bool AddSimpleKey(char character, int repeat, IntPtr hwnd, int[] haveKeys, bool fStartNewChar, int cGrp)
        {
            int num1 = (int)UnsafeNativeMethodsR.VkKeyScan(character);
            if (num1 != -1)
            {
                if (haveKeys[0] == 0 && (num1 & 256) != 0)
                {
                    SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 16, fStartNewChar, hwnd));
                    fStartNewChar = false;
                    haveKeys[0] = 10;
                }
                if (haveKeys[1] == 0 && (num1 & 512) != 0)
                {
                    SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 17, fStartNewChar, hwnd));
                    fStartNewChar = false;
                    haveKeys[1] = 10;
                }
                if (haveKeys[2] == 0 && (num1 & 1024) != 0)
                {
                    SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 18, fStartNewChar, hwnd));
                    fStartNewChar = false;
                    haveKeys[2] = 10;
                }
                SendKeysR.AddMsgsForVK(num1 & (int)byte.MaxValue, repeat, haveKeys[2] > 0 && haveKeys[1] == 0, hwnd);
                SendKeysR.CancelMods(haveKeys, 10, hwnd);
            }
            else
            {
                int num2 = SafeNativeMethodsR.OemKeyScan((short)((int)byte.MaxValue & (int)character));
                for (int index = 0; index < repeat; ++index)
                    SendKeysR.AddEvent(new SendKeysR.SKEvent(258, (int)character, num2 & (int)ushort.MaxValue, hwnd));
            }
            if (cGrp != 0)
                fStartNewChar = true;
            return fStartNewChar;
        }

        private static void AddMsgsForVK(int vk, int repeat, bool altnoctrldown, IntPtr hwnd)
        {
            for (int index = 0; index < repeat; ++index)
            {
                SendKeysR.AddEvent(new SendKeysR.SKEvent(altnoctrldown ? 260 : 256, vk, SendKeysR.fStartNewChar, hwnd));
                SendKeysR.AddEvent(new SendKeysR.SKEvent(altnoctrldown ? 261 : 257, vk, SendKeysR.fStartNewChar, hwnd));
            }
        }

        private static void CancelMods(int[] haveKeys, int level, IntPtr hwnd)
        {
            if (haveKeys[0] == level)
            {
                SendKeysR.AddEvent(new SendKeysR.SKEvent(257, 16, false, hwnd));
                haveKeys[0] = 0;
            }
            if (haveKeys[1] == level)
            {
                SendKeysR.AddEvent(new SendKeysR.SKEvent(257, 17, false, hwnd));
                haveKeys[1] = 0;
            }
            if (haveKeys[2] != level)
                return;
            SendKeysR.AddEvent(new SendKeysR.SKEvent(261, 18, false, hwnd));
            haveKeys[2] = 0;
        }

        private static void InstallHook()
        {
            if (!(SendKeysR.hhook == IntPtr.Zero))
                return;
            SendKeysR.hook = new NativeMethodsR.HookProc(new SendKeysR.SendKeysHookProc().Callback);
            SendKeysR.stopHook = false;
            SendKeysR.hhook = UnsafeNativeMethodsR.SetWindowsHookEx(1, SendKeysR.hook, new HandleRef((object)null, UnsafeNativeMethodsR.GetModuleHandle((string)null)), 0);
            if (SendKeysR.hhook == IntPtr.Zero)
                throw new SecurityException(SR1.GetString("SendKeysHookFailed"));
        }

        private static void TestHook()
        {
            SendKeysR.hookSupported = new bool?(false);
            try
            {
                IntPtr handle = UnsafeNativeMethodsR.SetWindowsHookEx(1, new NativeMethodsR.HookProc(SendKeysR.EmptyHookCallback), new HandleRef((object)null, UnsafeNativeMethodsR.GetModuleHandle((string)null)), 0);
                SendKeysR.hookSupported = new bool?(handle != IntPtr.Zero);
                if (!(handle != IntPtr.Zero))
                    return;
                UnsafeNativeMethodsR.UnhookWindowsHookEx(new HandleRef((object)null, handle));
            }
            catch
            {
            }
        }

        private static IntPtr EmptyHookCallback(int code, IntPtr wparam, IntPtr lparam)
        {
            return IntPtr.Zero;
        }

        private static void LoadSendMethodFromConfig()
        {
            if (SendKeysR.sendMethod.HasValue)
                return;
            SendKeysR.sendMethod = new SendKeysR.SendMethodTypes?(SendKeysR.SendMethodTypes.Default);
            try
            {
                string str = ConfigurationManager.AppSettings.Get("SendKeys");
                if (string.IsNullOrEmpty(str))
                    return;
                if (str.Equals("JournalHook", StringComparison.OrdinalIgnoreCase))
                {
                    SendKeysR.sendMethod = new SendKeysR.SendMethodTypes?(SendKeysR.SendMethodTypes.JournalHook);
                }
                else
                {
                    if (!str.Equals("SendInput", StringComparison.OrdinalIgnoreCase))
                        return;
                    SendKeysR.sendMethod = new SendKeysR.SendMethodTypes?(SendKeysR.SendMethodTypes.SendInput);
                }
            }
            catch
            {
            }
        }

        private static void JournalCancel()
        {
            if (!(SendKeysR.hhook != IntPtr.Zero))
                return;
            SendKeysR.stopHook = false;
            if (SendKeysR.events != null)
                SendKeysR.events.Clear();
            SendKeysR.hhook = IntPtr.Zero;
        }

        private static byte[] GetKeyboardState()
        {
            byte[] keystate = new byte[256];
            UnsafeNativeMethodsR.GetKeyboardState(keystate);
            return keystate;
        }

        private static void SetKeyboardState(byte[] keystate)
        {
            UnsafeNativeMethodsR.SetKeyboardState(keystate);
        }

        private static void ClearKeyboardState()
        {
            byte[] keyboardState = SendKeysR.GetKeyboardState();
            keyboardState[20] = (byte)0;
            keyboardState[144] = (byte)0;
            keyboardState[145] = (byte)0;
            SendKeysR.SetKeyboardState(keyboardState);
        }

        private static int MatchKeyword(string keyword)
        {
            for (int index = 0; index < SendKeysR.keywords.Length; ++index)
            {
                if (string.Equals(SendKeysR.keywords[index].keyword, keyword, StringComparison.OrdinalIgnoreCase))
                    return SendKeysR.keywords[index].vk;
            }
            return -1;
        }

        private static void OnThreadExit(object sender, EventArgs e)
        {
            try
            {
                SendKeysR.UninstallJournalingHook();
            }
            catch
            {
            }
        }

        private static void ParseKeys(string keys, IntPtr hwnd)
        {
            int index1 = 0;
            int[] haveKeys = new int[3];
            int num = 0;
            SendKeysR.fStartNewChar = true;
            for (int length = keys.Length; index1 < length; ++index1)
            {
                int repeat = 1;
                switch (keys[index1])
                {
                    case '%':
                        if (haveKeys[2] != 0)
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysString", new object[1]
              {
                (object) keys
              }));
                        SendKeysR.AddEvent(new SendKeysR.SKEvent(haveKeys[1] != 0 ? 256 : 260, 18, SendKeysR.fStartNewChar, hwnd));
                        SendKeysR.fStartNewChar = false;
                        haveKeys[2] = 10;
                        break;
                    case '(':
                        ++num;
                        if (num > 3)
                            throw new ArgumentException(SR1.GetString("SendKeysNestingError"));
                        if (haveKeys[0] == 10)
                            haveKeys[0] = num;
                        if (haveKeys[1] == 10)
                            haveKeys[1] = num;
                        if (haveKeys[2] == 10)
                        {
                            haveKeys[2] = num;
                            break;
                        }
                        break;
                    case ')':
                        if (num < 1)
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysString", new object[1]
              {
                (object) keys
              }));
                        SendKeysR.CancelMods(haveKeys, num, hwnd);
                        --num;
                        if (num == 0)
                        {
                            SendKeysR.fStartNewChar = true;
                            break;
                        }
                        break;
                    case '+':
                        if (haveKeys[0] != 0)
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysString", new object[1]
              {
                (object) keys
              }));
                        SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 16, SendKeysR.fStartNewChar, hwnd));
                        SendKeysR.fStartNewChar = false;
                        haveKeys[0] = 10;
                        break;
                    case '^':
                        if (haveKeys[1] != 0)
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysString", new object[1]
              {
                (object) keys
              }));
                        SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 17, SendKeysR.fStartNewChar, hwnd));
                        SendKeysR.fStartNewChar = false;
                        haveKeys[1] = 10;
                        break;
                    case '{':
                        int index2 = index1 + 1;
                        if (index2 + 1 < length && (int)keys[index2] == 125)
                        {
                            int index3 = index2 + 1;
                            while (index3 < length && (int)keys[index3] != 125)
                                ++index3;
                            if (index3 < length)
                                ++index2;
                        }
                        while (index2 < length && (int)keys[index2] != 125 && !char.IsWhiteSpace(keys[index2]))
                            ++index2;
                        if (index2 >= length)
                            throw new ArgumentException(SR1.GetString("SendKeysKeywordDelimError"));
                        string keyword = keys.Substring(index1 + 1, index2 - (index1 + 1));
                        if (char.IsWhiteSpace(keys[index2]))
                        {
                            while (index2 < length && char.IsWhiteSpace(keys[index2]))
                                ++index2;
                            if (index2 >= length)
                                throw new ArgumentException(SR1.GetString("SendKeysKeywordDelimError"));
                            if (char.IsDigit(keys[index2]))
                            {
                                int startIndex = index2;
                                while (index2 < length && char.IsDigit(keys[index2]))
                                    ++index2;
                                repeat = int.Parse(keys.Substring(startIndex, index2 - startIndex), (IFormatProvider)CultureInfo.InvariantCulture);
                            }
                        }
                        if (index2 >= length)
                            throw new ArgumentException(SR1.GetString("SendKeysKeywordDelimError"));
                        if ((int)keys[index2] != 125)
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysRepeat"));
                        int vk = SendKeysR.MatchKeyword(keyword);
                        if (vk != -1)
                        {
                            if (haveKeys[0] == 0 && (vk & 65536) != 0)
                            {
                                SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 16, SendKeysR.fStartNewChar, hwnd));
                                SendKeysR.fStartNewChar = false;
                                haveKeys[0] = 10;
                            }
                            if (haveKeys[1] == 0 && (vk & 131072) != 0)
                            {
                                SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 17, SendKeysR.fStartNewChar, hwnd));
                                SendKeysR.fStartNewChar = false;
                                haveKeys[1] = 10;
                            }
                            if (haveKeys[2] == 0 && (vk & 262144) != 0)
                            {
                                SendKeysR.AddEvent(new SendKeysR.SKEvent(256, 18, SendKeysR.fStartNewChar, hwnd));
                                SendKeysR.fStartNewChar = false;
                                haveKeys[2] = 10;
                            }
                            SendKeysR.AddMsgsForVK(vk, repeat, haveKeys[2] > 0 && haveKeys[1] == 0, hwnd);
                            SendKeysR.CancelMods(haveKeys, 10, hwnd);
                        }
                        else if (keyword.Length == 1)
                            SendKeysR.fStartNewChar = SendKeysR.AddSimpleKey(keyword[0], repeat, hwnd, haveKeys, SendKeysR.fStartNewChar, num);
                        else
                            throw new ArgumentException(SR1.GetString("InvalidSendKeysKeyword", new object[1]
              {
                (object) keys.Substring(index1 + 1, index2 - (index1 + 1))
              }));
                        index1 = index2;
                        break;
                    case '}':
                        throw new ArgumentException(SR1.GetString("InvalidSendKeysString", new object[1]
            {
              (object) keys
            }));
                    case '~':
                        SendKeysR.AddMsgsForVK(13, repeat, haveKeys[2] > 0 && haveKeys[1] == 0, hwnd);
                        break;
                    default:
                        SendKeysR.fStartNewChar = SendKeysR.AddSimpleKey(keys[index1], repeat, hwnd, haveKeys, SendKeysR.fStartNewChar, num);
                        break;
                }
            }
            if (num != 0)
                throw new ArgumentException(SR1.GetString("SendKeysGroupDelimError"));
            SendKeysR.CancelMods(haveKeys, 10, hwnd);
        }

        private static void SendInput(byte[] oldKeyboardState, Queue previousEvents)
        {
            SendKeysR.AddCancelModifiersForPreviousEvents(previousEvents);
            NativeMethodsR.INPUT[] pInputs = new NativeMethodsR.INPUT[2];
            pInputs[0].type = 1;
            pInputs[1].type = 1;
            pInputs[1].inputUnion.ki.wVk = (short)0;
            pInputs[1].inputUnion.ki.dwFlags = 6;
            pInputs[0].inputUnion.ki.dwExtraInfo = IntPtr.Zero;
            pInputs[0].inputUnion.ki.time = 0;
            pInputs[1].inputUnion.ki.dwExtraInfo = IntPtr.Zero;
            pInputs[1].inputUnion.ki.time = 0;
            int num1 = Marshal.SizeOf(typeof(NativeMethodsR.INPUT));
            uint num2 = 0U;
            int count;
            lock (SendKeysR.events.SyncRoot)
            {
                bool local_4 = UnsafeNativeMethodsR.BlockInput(true);
                try
                {
                    count = SendKeysR.events.Count;
                    SendKeysR.ClearGlobalKeys();
                    for (int local_5 = 0; local_5 < count; ++local_5)
                    {
                        SendKeysR.SKEvent local_6 = (SendKeysR.SKEvent)SendKeysR.events.Dequeue();
                        pInputs[0].inputUnion.ki.dwFlags = 0;
                        if (local_6.wm == 258)
                        {
                            pInputs[0].inputUnion.ki.wVk = (short)0;
                            pInputs[0].inputUnion.ki.wScan = (short)local_6.paramL;
                            pInputs[0].inputUnion.ki.dwFlags = 4;
                            pInputs[1].inputUnion.ki.wScan = (short)local_6.paramL;
                            num2 += UnsafeNativeMethodsR.SendInput(2U, pInputs, num1) - 1U;
                        }
                        else
                        {
                            pInputs[0].inputUnion.ki.wScan = (short)0;
                            if (local_6.wm == 257 || local_6.wm == 261)
                                pInputs[0].inputUnion.ki.dwFlags |= 2;
                            if (SendKeysR.IsExtendedKey(local_6))
                                pInputs[0].inputUnion.ki.dwFlags |= 1;
                            pInputs[0].inputUnion.ki.wVk = (short)local_6.paramL;
                            num2 += UnsafeNativeMethodsR.SendInput(1U, pInputs, num1);
                            SendKeysR.CheckGlobalKeys(local_6);
                        }
                        Thread.Sleep(1);
                    }
                    SendKeysR.ResetKeyboardUsingSendInput(num1);
                }
                finally
                {
                    SendKeysR.SetKeyboardState(oldKeyboardState);
                    if (local_4)
                        UnsafeNativeMethodsR.BlockInput(false);
                }
            }
            if ((long)num2 != (long)count)
                throw new Win32Exception();
        }

        private static void AddCancelModifiersForPreviousEvents(Queue previousEvents)
        {
            if (previousEvents == null)
                return;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            while (previousEvents.Count > 0)
            {
                SendKeysR.SKEvent skEvent = (SendKeysR.SKEvent)previousEvents.Dequeue();
                bool flag4;
                if (skEvent.wm == 257 || skEvent.wm == 261)
                    flag4 = false;
                else if (skEvent.wm == 256 || skEvent.wm == 260)
                    flag4 = true;
                else
                    continue;
                if (skEvent.paramL == 16)
                    flag1 = flag4;
                else if (skEvent.paramL == 17)
                    flag2 = flag4;
                else if (skEvent.paramL == 18)
                    flag3 = flag4;
            }
            if (flag1)
                SendKeysR.AddEvent(new SendKeysR.SKEvent(257, 16, false, IntPtr.Zero));
            else if (flag2)
            {
                SendKeysR.AddEvent(new SendKeysR.SKEvent(257, 17, false, IntPtr.Zero));
            }
            else
            {
                if (!flag3)
                    return;
                SendKeysR.AddEvent(new SendKeysR.SKEvent(261, 18, false, IntPtr.Zero));
            }
        }

        private static bool IsExtendedKey(SendKeysR.SKEvent skEvent)
        {
            if (skEvent.paramL != 38 && skEvent.paramL != 40 && (skEvent.paramL != 37 && skEvent.paramL != 39) && (skEvent.paramL != 33 && skEvent.paramL != 34 && (skEvent.paramL != 36 && skEvent.paramL != 35)) && skEvent.paramL != 45)
                return skEvent.paramL == 46;
            return true;
        }

        private static void ClearGlobalKeys()
        {
            SendKeysR.capslockChanged = false;
            SendKeysR.numlockChanged = false;
            SendKeysR.scrollLockChanged = false;
            SendKeysR.kanaChanged = false;
        }

        private static void CheckGlobalKeys(SendKeysR.SKEvent skEvent)
        {
            if (skEvent.wm != 256)
                return;
            switch (skEvent.paramL)
            {
                case 20:
                    SendKeysR.capslockChanged = !SendKeysR.capslockChanged;
                    break;
                case 21:
                    SendKeysR.kanaChanged = !SendKeysR.kanaChanged;
                    break;
                case 144:
                    SendKeysR.numlockChanged = !SendKeysR.numlockChanged;
                    break;
                case 145:
                    SendKeysR.scrollLockChanged = !SendKeysR.scrollLockChanged;
                    break;
            }
        }

        private static void ResetKeyboardUsingSendInput(int INPUTSize)
        {
            if (!SendKeysR.capslockChanged && !SendKeysR.numlockChanged && (!SendKeysR.scrollLockChanged && !SendKeysR.kanaChanged))
                return;
            NativeMethodsR.INPUT[] pInputs = new NativeMethodsR.INPUT[2];
            pInputs[0].type = 1;
            pInputs[0].inputUnion.ki.dwFlags = 0;
            pInputs[1].type = 1;
            pInputs[1].inputUnion.ki.dwFlags = 2;
            if (SendKeysR.capslockChanged)
            {
                pInputs[0].inputUnion.ki.wVk = (short)20;
                pInputs[1].inputUnion.ki.wVk = (short)20;
                int num = (int)UnsafeNativeMethodsR.SendInput(2U, pInputs, INPUTSize);
            }
            if (SendKeysR.numlockChanged)
            {
                pInputs[0].inputUnion.ki.wVk = (short)144;
                pInputs[1].inputUnion.ki.wVk = (short)144;
                int num = (int)UnsafeNativeMethodsR.SendInput(2U, pInputs, INPUTSize);
            }
            if (SendKeysR.scrollLockChanged)
            {
                pInputs[0].inputUnion.ki.wVk = (short)145;
                pInputs[1].inputUnion.ki.wVk = (short)145;
                int num = (int)UnsafeNativeMethodsR.SendInput(2U, pInputs, INPUTSize);
            }
            if (!SendKeysR.kanaChanged)
                return;
            pInputs[0].inputUnion.ki.wVk = (short)21;
            pInputs[1].inputUnion.ki.wVk = (short)21;
            int num1 = (int)UnsafeNativeMethodsR.SendInput(2U, pInputs, INPUTSize);
        }

        private static void UninstallJournalingHook()
        {
            if (!(SendKeysR.hhook != IntPtr.Zero))
                return;
            SendKeysR.stopHook = false;
            if (SendKeysR.events != null)
                SendKeysR.events.Clear();
            UnsafeNativeMethodsR.UnhookWindowsHookEx(new HandleRef((object)null, SendKeysR.hhook));
            SendKeysR.hhook = IntPtr.Zero;
        }

        private enum SendMethodTypes
        {
            Default = 1,
            JournalHook = 2,
            SendInput = 3,
        }

        private class SKWindow : Control
        {
            public SKWindow()
            {
                this.SetState(524288, true);
                this.SetState2(8, false);
                this.SetBounds(-1, -1, 0, 0);
                this.Visible = false;
            }

            private void SetState2(int p1, bool p2)
            {
                //throw new NotImplementedException();
            }

            private void SetState(int p1, bool p2)
            {
                //throw new NotImplementedException();
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg != 75)
                    return;
                try
                {
                    SendKeysR.JournalCancel();
                }
                catch
                {
                }
            }
        }

        private class KeywordVk
        {
            internal string keyword;
            internal int vk;

            public KeywordVk(string key, int v)
            {
                this.keyword = key;
                this.vk = v;
            }
        }

        private class SKEvent
        {
            internal int wm;
            internal int paramL;
            internal int paramH;
            internal IntPtr hwnd;

            public SKEvent(int a, int b, bool c, IntPtr hwnd)
            {
                this.wm = a;
                this.paramL = b;
                this.paramH = c ? 1 : 0;
                this.hwnd = hwnd;
            }

            public SKEvent(int a, int b, int c, IntPtr hwnd)
            {
                this.wm = a;
                this.paramL = b;
                this.paramH = c;
                this.hwnd = hwnd;
            }
        }

        private class SendKeysHookProc
        {
            private bool gotNextEvent;

            public virtual IntPtr Callback(int code, IntPtr wparam, IntPtr lparam)
            {
                NativeMethodsR.EVENTMSG eventmsg = (NativeMethodsR.EVENTMSG)UnsafeNativeMethodsR.PtrToStructure(lparam, typeof(NativeMethodsR.EVENTMSG));
                if ((int)UnsafeNativeMethodsR.GetAsyncKeyState(19) != 0)
                    SendKeysR.stopHook = true;
                switch (code)
                {
                    case 1:
                        this.gotNextEvent = true;
                        SendKeysR.SKEvent skEvent = (SendKeysR.SKEvent)SendKeysR.events.Peek();
                        eventmsg.message = skEvent.wm;
                        eventmsg.paramL = skEvent.paramL;
                        eventmsg.paramH = skEvent.paramH;
                        eventmsg.hwnd = skEvent.hwnd;
                        eventmsg.time = SafeNativeMethodsR.GetTickCount();
                        Marshal.StructureToPtr((object)eventmsg, lparam, true);
                        break;
                    case 2:
                        if (this.gotNextEvent)
                        {
                            if (SendKeysR.events != null && SendKeysR.events.Count > 0)
                                SendKeysR.events.Dequeue();
                            SendKeysR.stopHook = SendKeysR.events == null || SendKeysR.events.Count == 0;
                            break;
                        }
                        break;
                    default:
                        if (code < 0)
                        {
                            UnsafeNativeMethodsR.CallNextHookEx(new HandleRef((object)null, SendKeysR.hhook), code, wparam, lparam);
                            break;
                        }
                        break;
                }
                if (SendKeysR.stopHook)
                {
                    SendKeysR.UninstallJournalingHook();
                    this.gotNextEvent = false;
                }
                return IntPtr.Zero;
            }
        }
    }
}
