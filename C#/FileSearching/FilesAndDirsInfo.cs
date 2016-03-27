using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    public abstract class FilesAndDirsInfo
    {
        string parent;
        public string Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime DateOfCreation
        {
            get;
            set;
        }
        public long Size
        {
            get;
            set;
        }
    }
}
