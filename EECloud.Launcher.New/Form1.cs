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

namespace EECloud.Launcher.New
{
    public partial class Form1 : Form
    {
        private readonly string SeparatorText = Environment.NewLine + new string('—', 28);

        public FormWindowState LastShownWindowState;

        public Form1()
        {
            LastShownWindowState = WindowState;
            InitializeComponent();
            textBoxOutput.AppendText(SeparatorText);

            Icon = Properties.Resources.Icon;
            notifyIcon1.Icon = Properties.Resources.Icon;
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
    }
}
