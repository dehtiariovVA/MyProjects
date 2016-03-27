using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace ContactManager_Core
{
    public static class LinqToXmlModel
    {
        public static void AddContactToXml(Contact contact, XDocument doc)
        {
            XElement newElement = new XElement("Contact",
                                    new XElement("FirstName", contact.FirstName),
                                    new XElement("LastName", contact.LastName),
                                    new XElement("Group", contact.Group),
                                    new XElement("HomeNumber", contact.HomeNumber),
                                    new XElement("MobileNumber", contact.MobileNumber),
                                    new XElement("Photo", contact.Photo));
            doc.Descendants("Contacts").First().Add(newElement);
            doc.Save("ContactsStore.xml");
        }
        public static List<Contact> ContactsFromXmlToList(XDocument doc, List<Contact> list)
        {
            var contacts = from contact in doc.Element("Contacts").Elements("Contact")
                           select new Contact
                           {
                               FirstName = (string)contact.Element("FirstName"),
                               LastName = (string)contact.Element("LastName"),
                               Group = (string)contact.Element("Group"),
                               HomeNumber = (string)contact.Element("HomeNumber"),
                               MobileNumber = (string)contact.Element("MobileNumber"),
                               Photo=(string)contact.Element("Photo")
                           };
            foreach (var contact in contacts)
            {
                list.Add(contact);
            }
            return list;
        }
        public static void ContactsFromListToXml(List<Contact> contacts, XDocument doc)
        {
            IEnumerable<XElement> elements = doc.Root.Descendants("Contact").ToList();
            foreach (XElement element in elements)
                element.Remove();
            doc.Save("ContactsStore.xml");
            XDocument d = XDocument.Load("ContactsStore.xml");
            foreach (var contact in contacts)
            {
                XElement newElement = new XElement("Contact",
                                        new XElement("FirstName", contact.FirstName),
                                        new XElement("LastName", contact.LastName),
                                        new XElement("Group", contact.Group),
                                        new XElement("HomeNumber", contact.HomeNumber),
                                        new XElement("MobileNumber", contact.MobileNumber),
                                        new XElement("Photo", contact.Photo));
                d.Root.Add(newElement);
            }
            d.Save("ContactsStore.xml");
        }
    }
}
