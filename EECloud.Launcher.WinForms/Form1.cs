﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EECloud.Launcher.WinForms
{
    public partial class Form1 : Form
    {
        #region Fields and properties

        private readonly string _separatorText = Environment.NewLine + new string('—', 28);
        private string SeparatorText { get { return _separatorText;  } }

        public FormWindowState LastShownWindowState { get; private set; }

        private readonly Process BgAppProcess = new Process { StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "EECloud.exe")
                                                                              {
                                                                                  UseShellExecute = false,
                                                                                  RedirectStandardOutput = true,
                                                                                  CreateNoWindow = true
                                                                              }
                                                            };

        private Thread KeepCheckingForOutputThread;

        private bool RestartingOnRequest;
        private DateTime LastRestart;
        private int RestartTry;
        #endregion

        #region Form and NotifyIcon events
        public Form1()
        {
            LastShownWindowState = WindowState;
            InitializeComponent();

            Icon = Properties.Resources.Icon;
            notifyIcon1.Icon = Properties.Resources.Icon;

            hideWindowToTrayOnMinimizeToolStripMenuItem.Checked = Properties.Settings.Default.AutoHideEnabled;

            BgAppProcess.Exited += BgAppProcess_Exited;
            RestartBgAppProcess();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortKeepCheckingForOutputThread();

            try
            {
                BgAppProcess.Kill();
            }
            catch
            {
                BgAppProcess.Dispose();
            }
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
        #endregion

        #region BgAppProcess-related stuff
        private void BgAppProcess_Exited(object sender, EventArgs e)
        {
            if (BgAppProcess.ExitCode == 0)
                Close();
            else
            {
                RestartBgAppProcess();
            }
        }

        private void RestartBgAppProcess()
        {
            LastRestart = DateTime.UtcNow;
            textBoxOutput.AppendText(SeparatorText);
            BgAppProcess.Start();

            AbortKeepCheckingForOutputThread();
            KeepCheckingForOutputThread = new Thread(KeepCheckingForOutput);
            KeepCheckingForOutputThread.SetApartmentState(ApartmentState.STA);
            KeepCheckingForOutputThread.Start();
        }

        private void KeepCheckingForOutput()
        {
            while (!BgAppProcess.StandardOutput.EndOfStream)
            {
                var output = BgAppProcess.StandardOutput.ReadLine();
                if (output != null && output != ">")
                    Invoke((MethodInvoker)(() => textBoxOutput.AppendText(Environment.NewLine + output)));
            }
        }

        private void AbortKeepCheckingForOutputThread()
        {
            if (KeepCheckingForOutputThread != null && KeepCheckingForOutputThread.IsAlive)
                KeepCheckingForOutputThread.Abort();
        }
        #endregion

        #region Main menu strip
        private void hideWindowToTrayOnMinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideWindowToTrayOnMinimizeToolStripMenuItem.Checked = !hideWindowToTrayOnMinimizeToolStripMenuItem.Checked;
            Properties.Settings.Default.AutoHideEnabled = hideWindowToTrayOnMinimizeToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}