
using System.Runtime.InteropServices;

namespace AlternatingCaps
{
    public static class FormExtension
    {
        // https://stackoverflow.com/questions/156046/show-a-form-without-stealing-focus

        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void ShowNotification(this Form frm)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetPositionToRightBottomCorner(frm);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
                frm.Left, frm.Top, frm.Width, frm.Height,
                SWP_NOACTIVATE);
        }

        public static void SetPositionToRightBottomCorner(this Form frm)
        {
            var screen = Screen.FromPoint(frm.Location);
            frm.Location = new Point(screen.WorkingArea.Right - frm.Width, screen.WorkingArea.Bottom - frm.Height);
        }
    }
}