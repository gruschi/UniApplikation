using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    public interface IStudent
    {
        [XmlElement("ID")]
        public string ID;//Could be Immatrikulationsnr, or email or smth else
        
        [XmlElement("Name")]
        public string Name;

        [XmlElement("Surname")]
        public string Surname;
        
        [XmlElement("Group", DataType = "string")]
        public string Group;///Places Left        

        [XmlElement("countCourses")]
        public int countCourses;///How Many Courses does this Student need ?

                            ///
        [XmlArray("PrioritysArray")]
        [XmlArrayItem("PriorityObject")]        
        public IPriority[] Prioritys;//TODO vielleicht anders regeln ? Checken ob Sortierung stimmt!
        

        public static IStudent getInstance(string Name, string Surname, string ID);

        internal void setChoose(int priotity, string sAnswer, bool bCountCourses);

        public bool Equals(IStudent tmpStudent);

        internal void addPrioritys(IStudent student);
    }
}
