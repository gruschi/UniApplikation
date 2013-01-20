using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    class Student
    {
        [XmlElement("ID")]
        public string ID;//Could be Immatrikulationsnr, or email or smth else
        
        [XmlElement("Name")]
        public string Name;

        [XmlElement("Surname")]
        public string Surname;
        
        [XmlElement("Group", DataType = "string")]
        public string Group;///Places Left        
                            ///
        [XmlElement("Prioritys")]
        public string[] Prioritys;



        public Student(string Name, string ID, string Group)
        {
            this.Name = Name;
            this.ID = ID;
            this.Group = Group;            
        }

        public static Student getInstance(string Name, string ID)
        {

        }
    }
}
