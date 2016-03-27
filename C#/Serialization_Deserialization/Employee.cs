using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Reflection;

namespace Task_3
{
    [Serializable]
    public class Employee
    {
        private string lastname;
        private string firstname;
        private int age;
        private string addres;
        private string department;
        [NonSerialized]
        private string employeeID;
        
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Addres
        {
            get
            {
                return addres;
            }
            set
            {
                addres = value;
            }
        }
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }
        public Employee() 
        {
        }
        public Employee(string lastName, string firstName, int age, string department, string addres)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Department = department;
            Addres = addres;
        }
        public override string ToString()
        {
            SetID();
            return String.Format("LastName: " + LastName + "\n" +
                                 "FirstName: " + FirstName + "\n" +
                                 "Age: " + Age + "\n" +
                                 "Department: " + Department + "\n" +
                                 "Addres: " + GetAddres() + "\n" +
                                 "EmployeeID: " + employeeID + "\n");                      
        }

        void SetID()
        {
            string ID = LastName + " " + FirstName;
            typeof(Employee).GetField("employeeID",
            BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, ID);
        }

        object GetAddres()
        {
            object addres = typeof(Employee).GetField("addres",
                         BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            return addres;
        }

        public string GetID()
        {
            return employeeID;
        }
    }
}
