using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    [XmlRoot("Studentslist")]
    public class StudentsList
    {

        [XmlElement("Listenbezeichner")]
        public string Listenname;

        [XmlArray("StudentsArray")]
        [XmlArrayItem("StudentsObjekt")]
        public List<Student> Students = null;
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
            string sPath = Handler.sStudentXMLPath;
            StudentsList tmpList = XMLHandler.DeserializeObject<StudentsList>(sPath);
            return (tmpList != null)? tmpList : new StudentsList("Studentenliste");        
        }

        /// <summary>
        /// Set Students, Overrides existing Prioritys (if necesarry)
        /// </summary>
        /// <param name="objStudentArray"></param>
        public void setStudents(List<Student> objStudentArray)
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
        private void mergeStudents(List<Student> objStudentArray)
        {
            for(int i = 0; i < objStudentArray.Count; i++){               

                for(int u = 0; u < this.Students.Count; u++){
                    if (this.Students[u] != null && this.Students[u].Equals(objStudentArray[i]))
                    {
                        this.Students[u].addPrioritys(objStudentArray[i]);//Setzen der Prioritys das es nicht überschrieben wird
                        this.Students[u].setChoose(-1, objStudentArray[i].countCourses.ToString(), true);//Setzt Wahl der Course das diese nicht überschrieben werden
                        u = this.Students.Count;//Stop for Loop                      
                    }
                }             
            }            
        }
       
        /// <summary>
        /// Saves List to XML File (Serialize)
        /// </summary>
        internal void saveList()
        {
            //Delete all null in the Array
            List<Student> tmpStudentList = new List<Student>();            

            foreach (Student tmpStudent in this.Students)
            {
                if (tmpStudent != null)
                {
                    tmpStudentList.Add(tmpStudent);                    
                }
            }

            this.Students = tmpStudentList;

            XMLHandler.SerializeObject<StudentsList>(this, Handler.sStudentXMLPath);
        }
    }

    /// <summary>
    /// Shuffles the List
    /// </summary>
    static class MyExtensions
    {
        static readonly Random Random = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
