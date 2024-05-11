using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AlternatingCaps
{
    internal static class Program
    {
        #region Declarations and Imports

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static bool isAlternating = false;
        private static Keys lastKey = Keys.None;
        private static bool capsLockState;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion

        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (isAppInstanceRunning()) return;

            capsLockState = Control.IsKeyLocked(Keys.CapsLock);
            _hookID = SetHook(_proc);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            resetCapsLock();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static void ToggleCapsLock()
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;

            UnhookWindowsHookEx(_hookID);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            _hookID = SetHook(_proc);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);

                // int 35 = 0x23 = End key
                if (key == (Keys)Properties.Settings.Default.SwitcherKey)
                {
                    isAlternating = MainForm.SwitchAlternateCaps();
                    if (!isAlternating) resetCapsLock();
                }
                else if (key == Keys.CapsLock)
                {
                    capsLockState = !capsLockState;
                }
                else if (isAlternating && key >= Keys.A && key <= Keys.Z)
                {
                    if ((char.IsUpper((char)lastKey) && char.IsUpper((char)key)) ||
                        (char.IsLower((char)lastKey) && char.IsLower((char)key)))
                    {
                        ToggleCapsLock();
                    }
                    lastKey = key;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        /// <summary>
        /// Re-apply previous caps lock state if needed
        /// </summary>
        private static void resetCapsLock()
        {
            if (Control.IsKeyLocked(Keys.CapsLock) != capsLockState)
            {
                ToggleCapsLock();
            }
        }

        /// <summary>
        /// Checking for an existing instance of the application
        /// </summary>
        private static bool isAppInstanceRunning()
        {
            bool appNewInstance;
            Mutex m = new Mutex(true, Process.GetCurrentProcess().ProcessName, out appNewInstance);

            if (appNewInstance)
            {
                GC.KeepAlive(m);
            }
            
            return !appNewInstance; 
        }
    }
}