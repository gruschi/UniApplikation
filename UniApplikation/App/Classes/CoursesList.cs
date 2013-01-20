using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    [XmlRoot("CoursesList")]
    public class CoursesList : IXMLList
    {
        [XmlElement("Listenbezeichner")]
        public string Listenname;
        [XmlArray("CoursesArray")]
        [XmlArrayItem("CourseObjekt")]
        public Course[] Courses;
        // Konstruktoren
        public CoursesList() { }

        public CoursesList(string name)
        {         
            this.Listenname = name;            
        }
        
    }
}
