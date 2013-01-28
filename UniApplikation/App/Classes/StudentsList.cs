using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SetCoursesAlgo.Models;

namespace UniApplikation.App.Classes
{
    [XmlRoot("Studentslist")]
    public class StudentsList : IStudentsList
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
                bool bStudentUpdated = false;

                for(int u = 0; u < this.Students.Length; u++){
                    if (this.Students[u] != null && this.Students[u].Equals(objStudentArray[i]))
                    {
                        this.Students[u].addPrioritys(objStudentArray[i]);//Setzen der Prioritys das es nicht überschrieben wird
                        this.Students[u].setChoose(-1, objStudentArray[i].countCourses.ToString(), true);//Setzt Wahl der Course das diese nicht überschrieben werden
                        u = this.Students.Length;

                        bStudentUpdated = true;//TODO theoretisch kann man hier direkt u = MAX setzen da es ja nicht weitergehen muss oder ?!
                    }
                }

                if (bStudentUpdated == false)
                {
                    Array.Resize(ref this.Students, this.Students.Length+1);//Resize the Array
                    this.Students[this.Students.Length - 1] = objStudentArray[i];
                }
            }            
        }
       
        /// <summary>
        /// Saves List to XML File (Serialize)
        /// </summary>
        internal void saveList()
        {
            //Delete all null in the Array
            Student[] tmpStudentArray = new Student[1];
            int tmpStudentArrayIndex = 0;

            foreach (Student tmpStudent in this.Students)
            {
                if (tmpStudent != null)
                {
                    tmpStudentArray[tmpStudentArrayIndex] = tmpStudent;
                    Array.Resize(ref tmpStudentArray, tmpStudentArray.Length + 1);
                    ++tmpStudentArrayIndex;
                }
            }

            Array.Resize(ref tmpStudentArray, tmpStudentArray.Length - 1);

            this.Students = tmpStudentArray;

            XMLHandler.SerializeObject<StudentsList>(this, Properties.Settings.Default.StudentsXMLPath);
        }
    }
}
