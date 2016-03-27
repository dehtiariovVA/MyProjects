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
    public class ThreadOfSearching
    {
        ManualResetEvent signal_event;
        Thread thread;
        List<FilesAndDirsInfo> filesAndDirectories;
        string path;

        public ThreadOfSearching(string name, string pathToDirectory, 
                                    List<FilesAndDirsInfo> list, ManualResetEvent e)
        {
            signal_event = e;
            path = pathToDirectory;
            filesAndDirectories = list;
            thread = new Thread(new ThreadStart(StartSearching));
            thread.Name = name;
            thread.IsBackground = true;
            thread.Start();
        }

        private void StartSearching()
        {
            DirectoryInfo root_directory = new DirectoryInfo(path);
            filesAndDirectories.Add(new MyDirectory(null, root_directory.FullName, 
                                                    root_directory.CreationTime));
            SearchFilesAndDirectories(path);
            signal_event.Set();
        }

        private void SearchFilesAndDirectories(string path)
        {
            try
            {
                DirectoryInfo root_directory = new DirectoryInfo(path);
                DirectoryInfo[] subDir = root_directory.GetDirectories();
                foreach (var directory in subDir)
                {
                    filesAndDirectories.Add(new MyDirectory(path, directory.FullName,
                                                                directory.CreationTime));
                    this.SearchFilesAndDirectories(directory.FullName);
                }
                FileInfo[] files = root_directory.GetFiles();
                foreach (var file in files)
                {
                    filesAndDirectories.Add(new MyFile(root_directory.FullName, file.Name,
                                                            file.CreationTime, file.Length));
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
