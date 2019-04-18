using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatsLibrary
{
    public partial class frmLog : Form
    {

        public frmLog()
        {
            InitializeComponent();
        }

        private void frmLog_Load(object sender, EventArgs e)
        {

        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stats.WriteLog(txtLog.Text);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void WriteToLog(string log)
        {
            if (!txtLog.IsDisposed)
                txtLog.AppendText(log+"\n");
        }
    }
}

