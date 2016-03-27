using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace FinalTask
{
    public class TreeFiller
    {
        ManualResetEvent signal_event;
        Thread thread;
        List<FilesAndDirsInfo> filesAndDirectories;
        TreeView treeView;

        public TreeFiller(string name, TreeView tree, List<FilesAndDirsInfo> list, 
                            ManualResetEvent e)
        {
            signal_event = e;
            treeView = tree;
            filesAndDirectories = list;
            thread = new Thread(new ThreadStart(StartFillTree));
            thread.Name = name;
            thread.IsBackground = true;
            thread.Start();
        }

        private void StartFillTree()
        {
            while (true)
            {
                FillTree(treeView);
            }
        }

        MyDirectory root;
        private void FillTree(TreeView treeView)
        {
            signal_event.WaitOne();
            lock (new object())
            {
                root = (MyDirectory)filesAndDirectories[0];
                treeView.Invoke((Action)delegate
                {
                    treeView.Nodes.Add(root.Name, root.ToString());
                    for (int i = 1; i < filesAndDirectories.Count; i++)
                    {
                        if (filesAndDirectories[i] is MyDirectory)
                        {
                            AddDirectoryToTree((MyDirectory)filesAndDirectories[i]);
                        }
                        if (filesAndDirectories[i] is MyFile)
                        {
                            AddFileToTree((MyFile)filesAndDirectories[i]);
                        }
                    }
                });
            }
            Thread.Sleep(300);
            signal_event.Reset();            
        }

        void AddDirectoryToTree(MyDirectory dir)
        {
            try
            {
                MyDirectory directory = dir;
                if (directory.Parent == root.Name)
                {
                    treeView.Nodes[directory.Parent].Nodes.Add(directory.Name,
                                                                directory.ToString());
                }
                else
                {
                    TreeNode[] nodes = treeView.Nodes.Find(directory.Parent, true);
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        treeView.SelectedNode = nodes[j];
                        treeView.SelectedNode.Nodes.Add(directory.Name,
                                                            directory.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddFileToTree(MyFile f)
        {
            MyFile file = f;
            if (file.Parent == root.Name)
            {
                treeView.Nodes[file.Parent].Nodes.Add(file.ToString());
            }
            else
            {
                TreeNode[] nodes = treeView.Nodes.Find(file.Parent, true);
                for (int j = 0; j < nodes.Length; j++)
                {
                    treeView.SelectedNode = nodes[j];
                    treeView.SelectedNode.Nodes.Add(file.ToString());
                }
            }
        }
    }
}
