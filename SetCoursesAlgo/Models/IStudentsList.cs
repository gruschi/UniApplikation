using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    [XmlRoot("Studentslist")]
    public interface IStudentsList : IXMLList
    {

        [XmlElement("Listenbezeichner")]
        public string Listenname;

        [XmlArray("StudentsArray")]
        [XmlArrayItem("StudentsObjekt")]
        public IStudent[] Students = null;
    
        public static IStudentsList getListFromXML();

        public void setStudents(IStudent[] objStudentArray;

        private void mergeStudents(IStudent[] objStudentArray);
       
        internal void saveList();
    }
}
