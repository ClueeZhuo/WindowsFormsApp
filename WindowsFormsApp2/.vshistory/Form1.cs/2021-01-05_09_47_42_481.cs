using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly int Max_Item_Count = 10000;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)(delegate ()
            {
                for (int i = 0; i < Max_Item_Count; i++)
                {
                    // 此处警惕值类型装箱造成的"性能陷阱"
                    listView1.Invoke((MethodInvoker)delegate ()
                    {
                        listView1.Items.Add(new ListViewItem(new string[]
                        { i.ToString(), string.Format("This is No.{0} item", i.ToString()) }));
                    });
                };
            }))
.Start();
        }
    }
}
