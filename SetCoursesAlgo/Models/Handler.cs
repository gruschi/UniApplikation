using SetCoursesAlgo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        private int maxCalculations = Properties.Settings.Default.MaxCalculations;

        public Handler(string sCourseXMLPath, string sStudentXMLPath)
        {
            Handler.sCourseXMLPath = sCourseXMLPath;
            Handler.sStudentXMLPath = sStudentXMLPath;

            this.objStudensList = StudentsList.getListFromXML(Handler.sStudentXMLPath);
            this.objCourseList = CoursesList.getListFromXML(Handler.sCourseXMLPath);

            this.objStudentsListCopy = objStudensList;
            this.objCourseList.repair();
            this.cCalculate = 0;//Inital Set off calculate
        }

        /// <summary>
        /// Calculates the curses
        /// </summary>
        /// <returns></returns>
        public bool calculate()
        {            
            this.objStudensList.Students.Shuffle();            

            for (int i = this.objStudentsListCopy.Students.Count - 1; i >= 0; i--)
            {
                Student tmpStudent = this.objStudentsListCopy.Students[i];

                for (int p = 0; p < tmpStudent.Prioritys.Count; p++)
                {
                    if (tmpStudent.Prioritys[p] != null)
                    {
                        Course selectedCourse = this.objCourseList.getCourse(tmpStudent.Prioritys[p].Value);

                        if (selectedCourse.addStudent(tmpStudent))
                        {
                            tmpStudent.Prioritys[p] = null;
                            --tmpStudent.countCourses;

                            //Noch Prios vorhanden ? Wenn nicht wird Student aus Liste gelöscht
                            if (!tmpStudent.hasPrioritys() || tmpStudent.countCourses == 0)
                            {
                                this.objStudentsListCopy.Students.RemoveAt(i);
                            }

                            p = tmpStudent.Prioritys.Count;//Nur ein Kurs pro Durchgang!
                        }
                    }
                }                
            }

            ++this.cCalculate;

            if (this.objStudentsListCopy.Students.Count > 0)
            {
                if (this.cCalculate < this.maxCalculations)
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


        public List<DataTable> saveResult()
        {
            List<DataTable> dtCoursesOutput = new List<DataTable>();

            foreach(Course tmpCourse in this.objCourseList.Courses){
                DataTable dtTemp = new DataTable();
                dtTemp.TableName = tmpCourse.Name;
                dtTemp.Columns.Add("Platznummer");
                dtTemp.Columns.Add("Studentenname");//TODO ID ?

                for(int i = 0; i < tmpCourse.objStudents.Count; i++){
                    dtTemp.Rows.Add(i, tmpCourse.objStudents[i].Name);
                }

                dtCoursesOutput.Add(dtTemp);
            }

            return dtCoursesOutput;
        }
    }    
}
