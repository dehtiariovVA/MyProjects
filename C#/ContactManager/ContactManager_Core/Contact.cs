using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_Core
{
    public class Contact
    {
        private string first_name;
        private string last_name;
        private string group;
        private string home_number;
        private string mobile_number;
        private string photo;
        public string FirstName
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }
        public string LastName
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public string HomeNumber
        {
            get
            {
                return home_number;
            }
            set
            {
                home_number = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return mobile_number;
            }
            set
            {
                mobile_number = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public Contact(string f_n, string l_n, string gr, string h_n, string m_n, string ph)
        {
            FirstName = f_n;
            LastName = l_n;
            Group = gr;
            HomeNumber = h_n;
            MobileNumber = m_n;
            Photo = ph;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        public Contact() { }
    }
}
