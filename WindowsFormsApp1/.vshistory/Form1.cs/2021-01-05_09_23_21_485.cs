using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 储存UI线程的标识符
            int curThreadID = Thread.CurrentThread.ManagedThreadId;

            new Thread((ThreadStart)delegate ()
            {
                PrintThreadLog(curThreadID);
            })
            .Start();
        }
    }
    }
}
