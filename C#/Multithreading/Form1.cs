using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;

namespace Task_4
{
    public partial class Form1 : Form
    {
        Queue<string> generalQueue = new Queue<string>();
        ChildThread thread_1;
        ChildThread thread_2;

        public Form1()
        {
            InitializeComponent();

            thread_1 = new ChildThread("First child thread", generalQueue);
            thread_1.MessageOfException += GetMessage;
            thread_2 = new ChildThread("Second child thread", generalQueue);
            thread_2.MessageOfException += GetMessage;           
        }
      
        private void btnStartGeneration_Click(object sender, EventArgs e)
        {
            btnStartGeneration.Enabled = false;
            btnStopGeneration.Enabled = true;
            thread_1.StartGeneration();
            thread_2.StartGeneration();
        }

        private void btnStopGeneration_Click(object sender, EventArgs e)
        {
            btnStartGeneration.Enabled = true;
            btnStopGeneration.Enabled = false;
            thread_1.StopGeneration();
            thread_2.StopGeneration();
        }

        private void GetMessage()
        {
            tbForMessages.Invoke((Action)delegate
            {
                while (generalQueue.Count != 0)
                {
                    tbForMessages.Text += generalQueue.Dequeue() + Environment.NewLine;
                }
            });
        }
    }
}
