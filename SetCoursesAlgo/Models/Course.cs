using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    public class Course
    {
        public static Dictionary<string, Course> _instances = new Dictionary<string, Course>();
        static object _lock = new object();

        //Die zu serialisierende Klasse
        //(Die XML-Attribute werden nur für die Xml-serialisierung gebraucht)    

        [XmlElement("Name")]
        public string Name;
        [XmlElement("Lecturer")]
        public string Lecturer;
        [XmlElement("Places", DataType = "int")]
        public int Places;///Places Left            
       
        public int iMaxPlaces;

        public List<Student> objStudents = new List<Student> ();                     

        public Course()
        {

        }

        public Course(string Name, string Lecturer, int Places)
        {
            this.Name = Name;
            this.Lecturer = Lecturer;
            this.Places = Places;
            this.iMaxPlaces = Places;
        }      

        public bool addStudent(Student objStudent)
        {
            if (!this.findStudent(objStudent) && objStudent.countCourses > 0)
            {
                if (this.objStudents.Count >= iMaxPlaces)//Course full
                {
                    return false;
                }
                else
                {
                    this.objStudents.Add(objStudent);                    
                    return true;
                }
            }
            else
            {                
                return false;
            }
            
        }

        private bool findStudent(Student objStudent)
        {
            foreach (Student tmpStudent in this.objStudents)
            {
                if (objStudent.Equals(tmpStudent))
                {
                    return true;
                }
            }

            return false;
        }

        public static Course getInstance(string key)
        {
            lock (_lock)
            {
                if (!_instances.ContainsKey(key))
                {
                    _instances.Add(key, new Course());
                }
            }
            return _instances[key];
        }

        /// <summary>
        /// Override Equals and HasCode because of Dictionary.TryGetValue!
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var k = obj as Course;
            if (k != null)
            {
                return this.Name == k.Name;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
