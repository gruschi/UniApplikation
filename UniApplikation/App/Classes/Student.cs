using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    public class Student : SetCoursesAlgo.Controller.Student
    {
     
        public Student(string sName, string sSurname, string sID, string sGroup) :base(sName, sSurname, sID, sGroup){

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

        public void setChoose(int priotity, string sAnswer, bool bCountCourses)
        {
            if (priotity > -1)
            {                
                this.Prioritys[priotity] = new SetCoursesAlgo.Controller.Priority(priotity, sAnswer);
            }
            else
            {
                try
                {
                    this.countCourses = Convert.ToInt32(sAnswer);
                }
                catch (FormatException)
                {
                    Logger.LogMessageToFile("ERROR AT STUDENT COUNT COURSES FORMAT ID:" + this.ID);
                }
            }
        }        
    }
}
