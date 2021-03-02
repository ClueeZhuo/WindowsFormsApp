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

        private void PrintThreadLog(int mainThreadID)
        {
            // 当前线程的标识符
            // A代码块
            int asyncThreadID = Thread.CurrentThread.ManagedThreadId;

            // 输出当前线程的扼要信息，及与UI线程的引用比对结果
            // B代码块
            label1.BeginInvoke((MethodInvoker)delegate ()
            {
                // 执行BeginInvoke内的方法的线程标识符
                int curThreadID = Thread.CurrentThread.ManagedThreadId;

                label1.Text = string.Format("Async Thread ID:{0},Current Thread ID:{1},Is UI Thread:{2}",
                asyncThreadID, curThreadID, curThreadID.Equals(mainThreadID));
            });

            while (true)
            {
                label1.Text += label1.Text;
            }
            // 挂起当前线程3秒，模拟耗时操作
            // C代码块
            Thread.Sleep(3000);
        }
    }
}
