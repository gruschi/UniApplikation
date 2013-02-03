using SetCoursesAlgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCoursesAlgo
{
    public class Handler
    {
        internal static string sCourseXMLPath;
        internal static string sStudentXMLPath;


        private StudentsList objStudensList;
        private CoursesList objCourseList;

        private StudentsList objStudentsListCopy;//Kopie aus welcher wir Daten löschen können ?

        private int cCalculate = 0;

        public Handler(string sCourseXMLPath, string sStudentXMLPath)
        {
            Handler.sCourseXMLPath = sCourseXMLPath;
            Handler.sStudentXMLPath = sStudentXMLPath;

            this.objStudensList = StudentsList.getListFromXML(Handler.sStudentXMLPath);
            this.objCourseList = CoursesList.getListFromXML(Handler.sCourseXMLPath);

            this.objStudentsListCopy = objStudensList;
            this.objCourseList.repair();
        }

        public bool calculate()
        {
            this.cCalculate = 0;
            this.objStudensList.Students.Shuffle();

            foreach (Student tmpStudent in this.objStudentsListCopy.Students)
            {
                for(int p = 0; p < tmpStudent.Prioritys.Count; p++){
                    if (tmpStudent.Prioritys[p] != null)
                    {
                        Course selectedCourse = this.objCourseList.getCourse(tmpStudent.Prioritys[p].Value);

                        if (selectedCourse.addStudent(tmpStudent))
                        {
                            tmpStudent.Prioritys[p] = null;

                            //Noch Prios vorhanden ? Wenn nicht wird Student aus liste gelöscht
                            if (!tmpStudent.hasPrioritys())
                            {
                                this.objStudentsListCopy.Students.Remove(tmpStudent);
                            }

                            p = tmpStudent.Prioritys.Count;//Nur ein Kurs pro Durchgang!
                        }
                    }
                }
                
            }

            ++this.cCalculate;

            if (this.objStudentsListCopy.Students.Count > 0)
            {
                if (this.cCalculate < 10)
                {
                    this.calculate();
                }        
            }

            if (this.objStudentsListCopy.Students.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void saveResult()
        {
            
        }
    }    
}
