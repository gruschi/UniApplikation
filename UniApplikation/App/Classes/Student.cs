using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
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
                            ///
        [XmlArray("PrioritysArray")]
        [XmlArrayItem("PriorityObject")]        
        public Priority[] Prioritys;//TODO vielleicht anders regeln ? Checken ob Sortierung stimmt!

        public Student()
        {

        }

        public Student(string Name, string Surname, string ID, string Group)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID = ID;
            this.Group = Group;      
            this.Prioritys = new Priority[6];
        }

        public static Student getInstance(string Name, string Surname, string ID)
        {
            StudentsList objStudentList = StudentsList.getListFromXML();

            foreach (Student tmpStudent in objStudentList.Students)
            {
                if (tmpStudent.Name == Name && tmpStudent.Surname == Surname && tmpStudent.ID == ID)
                {
                    return tmpStudent;
                }
            }

            return null;
        }

        internal void setChoose(int priotity, string sAnswer)
        {
            this.Prioritys[priotity] = new Priority(priotity, sAnswer);
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
        internal void addPrioritys(Student student)
        {
            for (int i = 0; i < this.Prioritys.Length; i++)
            {
                if (student.Prioritys[i] != null && student.Prioritys[i].Value.Length > 0 && student.Prioritys[i].Value != "Noch nicht abgestimmt")
                {
                    this.Prioritys[i] = student.Prioritys[i];
                }
            }
        }
    }
}
