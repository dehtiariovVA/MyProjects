using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Runtime.Serialization.Formatters.Soap;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = DeserializeSourseFile();
            DisplayEmployeesInfo(employees);
            SelectAndSerialize(employees);
            Console.ReadLine();
        }

        static List<Employee> DeserializeSourseFile()
        {
            string path = ConfigurationManager.AppSettings.Get("employees_sourse");
            List<Employee> employees;
            XmlSerializer empSerializer = new XmlSerializer(typeof(List<Employee>), 
                                                new XmlRootAttribute("Employees"));
            using (FileStream fileForEmployees =
                              new FileStream(path, FileMode.Open))
            {
                employees = (List<Employee>)empSerializer.Deserialize(fileForEmployees);
            }
            return employees;
        }

        static void DisplayEmployeesInfo(List<Employee> employees)
        {
            int index_number=1;
            foreach(var employee in employees)
            {
                Console.Write("Employee №{0}:\n", index_number);
                Console.WriteLine(employee.ToString());                       
                index_number++;
            }
        }

        static void SelectAndSerialize(List<Employee> employees)
        {
            var employeeSelector = from employee in employees
                                   where (employee.Age >= 25 && employee.Age <= 35)
                                   orderby employee.GetID() select employee;
            List<Employee> selectedEmployees = employeeSelector.ToList<Employee>();
            XmlSerializer empSerializer = new XmlSerializer(typeof(List<Employee>), 
                                            new XmlRootAttribute("Employees"));
            string path = ConfigurationManager.AppSettings.Get("selected_employees");
            using (FileStream fileForEmployees =
                              new FileStream(path, FileMode.Create))
            {
                empSerializer.Serialize(fileForEmployees, selectedEmployees);
            }
        }
    }
}
