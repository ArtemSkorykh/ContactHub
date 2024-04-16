using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ContactHub
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Desription { get; set; }

        static public List<Contact> UploadContacts()
        {
            List<Contact>? lc = new List<Contact>();
            if (Contact.TryParseXml())
            {

                XmlSerializer formatter = new XmlSerializer(typeof(List<Contact>));
                using (FileStream fs = new FileStream("contacts.xml", FileMode.OpenOrCreate))
                {
                   

                    lc = formatter.Deserialize(fs) as List<Contact>;
                    return lc;

                    
                }
            }
            return lc;

        }

        static public List<string> UploadShortContacts()
        {
            List<string> ls = new List<string>();
           
            List<Contact>lc =Contact.UploadContacts();
            if (lc.Count() != 0)
            {
                foreach (var item in lc)
                {
                    ls.Add(item.FirstName +" "+ item.Email);
                }
            }
            return ls;

        }

        static public void SaveContacts(List<Contact> lc)
        {
            File.Delete("contacts.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(List<Contact>));
            using (FileStream fs = new FileStream("contacts.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lc);
            }
        }

        static public bool TryParseXml()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Contact>));
            try
            {
                using (FileStream fs = new FileStream("contacts.xml", FileMode.OpenOrCreate))
                {
                    List<Contact>? lc = new List<Contact>();
                    lc = formatter.Deserialize(fs) as List<Contact>;
                }
                   
                return true;
            }
            catch (XmlException e)
            {
                return false;
            }
        }
    }
}
