using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    [XmlRoot("Studentslist")]
    class StudentsList : IXMLList
    {

        [XmlElement("Listenbezeichner")]
        public string Listenname;

        [XmlArray("StudentsArray")]
        [XmlArrayItem("StudentsObjekt")]
        public Student[] Students;
        // Konstruktoren
        public StudentsList() { }

        public StudentsList(string name)
        {         
            this.Listenname = name;            
        }

        public static StudentsList getList()
        {
                
        }
    }
}
