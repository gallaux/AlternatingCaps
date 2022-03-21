using System.Runtime.InteropServices;

namespace AlternatingCaps
{
    public enum FormHorizontalPosition
    {
        Left,
        Center,
        Right
    }

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

        public static void ShowNotification(this Form frm, FormHorizontalPosition pos = FormHorizontalPosition.Right)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetPositionToBottom(frm, pos);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
                frm.Left, frm.Top, frm.Width, frm.Height,
                SWP_NOACTIVATE);
        }

        public static void SetPositionToBottom(this Form frm, FormHorizontalPosition pos = FormHorizontalPosition.Right)
        {
            var screen = Screen.FromPoint(frm.Location);

            int x;
            switch (pos)
            {
                case FormHorizontalPosition.Left:
                    x = screen.WorkingArea.Left;
                    break;
                case FormHorizontalPosition.Right:
                    x = screen.WorkingArea.Right - frm.Width;
                    break;
                default: // Center
                    x = (screen.WorkingArea.Width - frm.Width) / 2;
                    break;
            }

            frm.Location = new Point(x, screen.WorkingArea.Bottom - frm.Height);
        }
    }
}