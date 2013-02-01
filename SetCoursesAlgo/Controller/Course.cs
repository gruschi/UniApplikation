using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Controller
{
    public class Course
    {
        private static readonly Dictionary<object, Course> _instances = new Dictionary<object, Course>();

        //Die zu serialisierende Klasse
        //(Die XML-Attribute werden nur für die Xml-serialisierung gebraucht)    

        [XmlElement("Name")]
        public string Name;
        [XmlElement("Lecturer")]
        public string Lecturer;
        [XmlElement("Places", DataType = "int")]
        public int Places;///Places Left            


        public int iMaxPlaces;

        public List<Student> objStudents;
        private int iCounterStudents = 0;                

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
            if (this.iCounterStudents >= this.objStudents.Count)//Course full
            {
                return false;
            }
            else
            {
                this.objStudents.Add(objStudent);
                ++iCounterStudents;
                return true;
            }

            
        }

        public static Course getInstance(object key)
        {
            lock (_instances)
            {
                Course instance;
                if (!_instances.TryGetValue(key, out instance))
                {
                    instance = new Course();
                    _instances.Add(key, instance);
                }
                return instance;
            }
        }
    }
}
