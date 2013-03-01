using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EECloud.Launcher.WinForms
{
    public partial class Form1 : Form
    {
        private readonly string SeparatorText = Environment.NewLine + new string('—', 28);

        public FormWindowState LastShownWindowState;

        private readonly Process BgAppProcess = new Process { StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "EECloud.exe")
                                                                              {
                                                                                  UseShellExecute = false,
                                                                                  RedirectStandardOutput = true,
                                                                                  CreateNoWindow = true
                                                                              }
                                                            };

        private bool RestartingOnRequest;
        private DateTime LastRestart;
        private int RestartTry;

        public Form1()
        {
            LastShownWindowState = WindowState;
            InitializeComponent();

            textBoxOutput.AppendText(SeparatorText);

            Icon = Properties.Resources.Icon;
            notifyIcon1.Icon = Properties.Resources.Icon;

            BgAppProcess.Exited += BgAppProcess_Exited;
            RestartBgAppProcess();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BgAppProcess.Kill();
            }
            catch
            {
                BgAppProcess.Dispose();
            }
        }

        private void BgAppProcess_Exited(object sender, EventArgs e)
        {
            if (BgAppProcess.ExitCode == 0)
                Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                LastShownWindowState = WindowState;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = LastShownWindowState;
            Visible = true;
            Activate();
        }

        private void RestartBgAppProcess()
        {
            LastRestart = DateTime.UtcNow;
            BgAppProcess.Start();

            var thread = new System.Threading.Thread(KeepCheckingForOutput);
            thread.SetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
        }

        private void KeepCheckingForOutput()
        {
            while (!BgAppProcess.StandardError.EndOfStream)
            {
                var output = BgAppProcess.StandardOutput.ReadLine();
                if (output != null && output != ">")
                    Invoke((MethodInvoker) (() => textBoxOutput.AppendText(Environment.NewLine + output)));
            }
        }
    }
}
