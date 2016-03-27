using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace FinalTask
{
    public partial class Form1 : Form
    {
        ManualResetEvent signal_event = new ManualResetEvent(false);
        List<FilesAndDirsInfo> filesAndDirectories = new List<FilesAndDirsInfo>();
        ThreadOfSearching searching;
        TreeFiller tree_filler;
        string path;

        public Form1()
        {
            InitializeComponent();
            tree_filler = new TreeFiller("Thread for filling TreeView", treeView1,
                                            filesAndDirectories, signal_event);            
        }

        private void btn_SearchFiles_Click(object sender, EventArgs e)
        {
            filesAndDirectories.Clear();
            treeView1.Nodes.Clear();
            searching = new ThreadOfSearching("Thread of searching", @path,
                                                filesAndDirectories, signal_event); 
            btn_SearchFiles.Enabled = false;
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            if (folderBrowserDialog1.SelectedPath != "")
            {
                btn_SearchFiles.Enabled = true;
            }
        }
    }
}
