using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Controller
{
    public class Student
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
       
        [XmlArray("PrioritysArray")]
        [XmlArrayItem("PriorityObject")]
        public List<Priority> Prioritys = new List<Priority>();//TODO vielleicht anders regeln ? Checken ob Sortierung stimmt!



        public Student()
        {

        }

        public Student(string Name, string Surname, string ID, string Group)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID = ID;
            this.Group = Group;            
        }        

        public void setChoose(int priotity, string sAnswer, bool bCountCourses)
        {
            if (priotity > -1)
            {
                this.Prioritys.Add(new Priority(priotity, sAnswer));
            }
            else
            {
                try
                {
                    this.countCourses = Convert.ToInt32(sAnswer);
                }
                catch (FormatException)
                {
                    SetCourse.App.Classes.Logger.LogMessageToFile("ERROR AT STUDENT COUNT COURSES FORMAT ID:" + this.ID);
                }
            }
        }

        public bool Equals(Student tmpStudent)
        {
            if (tmpStudent != null && tmpStudent.ID == this.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overrides own Prioritys from the Prioritys from Parameter student
        /// </summary>
        /// <param name="student">Student what shall override</param>
        public void addPrioritys(Student student)
        {
            for (int i = 0; i < this.Prioritys.Count; i++)
            {
                if (student.Prioritys[i] != null && student.Prioritys[i].Value.Length > 0 && student.Prioritys[i].Value != "Noch nicht abgestimmt")
                {
                    this.Prioritys[i] = student.Prioritys[i];
                }
            }
        }
  
    }
}
