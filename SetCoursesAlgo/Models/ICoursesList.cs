using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    [XmlRoot("CoursesList")]
    public interface ICoursesList : IXMLList
    {
        [XmlElement("Listenbezeichner")]
        public string Listenname;
        [XmlArray("CoursesArray")]
        [XmlArrayItem("CourseObjekt")]
        public ICourse[] Courses;
        // Konstruktoren
      

        /// <summary>
        /// Returns this Class from a Deserialized XML File
        /// </summary>
        /// <returns></returns>
        public static ICoursesList getListFromXML();

        public DataTable getDataTable();
        
    }
}
