using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Randomizer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public Form1()
        {
            InitializeComponent();

            //Hide to be hard to detect
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            //Start right after hiding
            this.timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Must be an array 'cuz it's getting ALL those processes
            Process[] notepadProcess = Process.GetProcessesByName("notepad");

            foreach (var process in notepadProcess)
            {
                int x = new Random().Next(0, Screen.PrimaryScreen.Bounds.Width - 500);  //Get screen size
                int y = new Random().Next(0, Screen.PrimaryScreen.Bounds.Height - 500);
                MoveWindow(process.MainWindowHandle, x, y, 500, 500, true);             //Set new window position
            }
        }
    }
}
