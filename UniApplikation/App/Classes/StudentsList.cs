using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    [XmlRoot("Studentslist")]
    public class StudentsList : IXMLList
    {

        [XmlElement("Listenbezeichner")]
        public string Listenname;

        [XmlArray("StudentsArray")]
        [XmlArrayItem("StudentsObjekt")]
        public Student[] Students = null;
        // Konstruktoren
        public StudentsList() { }

        public StudentsList(string name)
        {         
            this.Listenname = name;            
        }

        /// <summary>
        /// Returns this Class from a Deserialized XML File
        /// </summary>
        /// <returns></returns>
        public static StudentsList getListFromXML()
        {
            string sPath = Properties.Settings.Default.StudentsXMLPath;
            StudentsList tmpList = XMLHandler.DeserializeObject<StudentsList>(sPath);
            return (tmpList != null)? tmpList : new StudentsList("Studentenliste");        
        }

        /// <summary>
        /// Set Students, Overrides existing Prioritys (if necesarry)
        /// </summary>
        /// <param name="objStudentArray"></param>
        public void setStudents(Student[] objStudentArray)
        {
            //Test that students arent overwriten
            if (this.Students == null)
            {
                this.Students = objStudentArray;
            }
            else
            {
                this.mergeStudents(objStudentArray);
            }
            
        }

        /// <summary>
        /// Merges the Student Arrays so that students arent available twice
        /// </summary>
        /// <param name="objStudentArray"></param>
        private void mergeStudents(Student[] objStudentArray)
        {
            for(int i = 0; i < objStudentArray.Length; i++){
                for(int u = 0; u < this.Students.Length; u++){
                    if (this.Students[u] != null && this.Students[u].Equals(objStudentArray[i]))
                    {
                        this.Students[u].addPrioritys(objStudentArray[i]);
                        u = this.Students.Length;
                    }
                }
            }            
        }
       
        /// <summary>
        /// Saves List to XML File (Serialize)
        /// </summary>
        internal void saveList()
        {
            XMLHandler.SerializeObject<StudentsList>(this, Properties.Settings.Default.StudentsXMLPath);
        }
    }
}
