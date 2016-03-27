using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class MyFile:FilesAndDirsInfo
    {
        public MyFile(string parent, string name, DateTime dateOfCreation, long size)
        {
            Parent = parent;
            Name = name;
            DateOfCreation = dateOfCreation;
            Size = size;
        }
        public override string ToString()
        {
            Name = Name.Substring(Name.LastIndexOf('\\') + 1);
            return String.Format("FileName:{0}/CreationTime:{1}/FileSize:{2}",
                                    Name, DateOfCreation, Size);
        }
    }
}
