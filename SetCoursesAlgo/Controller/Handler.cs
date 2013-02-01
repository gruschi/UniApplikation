using SetCoursesAlgo.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCoursesAlgo
{
    public class Handler
    {
        private List<Course> objCoursesList;
        private List<Student> objStudentsList;


        private List<Student> objStudentsListCopy;//Kopie aus welcher wir Daten löschen können ?
        private int cCalculate = 0;

        public Handler(List<Course> objCoursesList, List<Student> objStudentsList)
        {
            this.objCoursesList = objCoursesList;
            this.objStudentsList = this.objStudentsListCopy = objStudentsList;
        }

        public bool calculate()
        {
            this.objStudentsList.Shuffle();

            foreach (Student tmpStudent in this.objStudentsListCopy)
            {
                for(int p = 0; p < tmpStudent.Prioritys.Count; p++){
                    Course selectedCourse = Course.getInstance(tmpStudent.Prioritys[p].Value.ToString());

                    if (selectedCourse.addStudent(tmpStudent))
                    {
                        tmpStudent.Prioritys.RemoveAt(p);

                        //Noch Prios vorhanden ? Wenn nicht wird Student aus liste gelöscht
                        if (tmpStudent.Prioritys.Count == 0)
                        {
                            this.objStudentsListCopy.Remove(tmpStudent);
                        }

                        p = tmpStudent.Prioritys.Count;//Nur ein Kurs pro Durchgang!
                    }
                }
                
            }

            ++this.cCalculate;

            if (this.cCalculate < 100 && this.objStudentsListCopy.Count > 0)
            {
                this.calculate();
            }
            return false;
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
