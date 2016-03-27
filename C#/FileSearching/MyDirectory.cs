using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class MyDirectory:FilesAndDirsInfo
    {
        public MyDirectory(string parent, string name, DateTime dateOfCreation)
        {
            Parent = parent;
            Name = name;
            DateOfCreation = dateOfCreation;
        }
        public override string ToString()
        {
            Name = Name.Substring(Name.LastIndexOf('\\') + 1);
            return String.Format("DirectoryName:{0}(CreationTime:{1})",
                                    Name, DateOfCreation);
        }
    }
}
