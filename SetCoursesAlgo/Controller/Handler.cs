using SetCoursesAlgo.Controller;
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
        private List<ICourse> objCoursesList;
        private List<IStudent> objStudentsList;

        public Handler(List<ICourse> objCoursesList, List<IStudent> objStudentsList)
        {
            this.objCoursesList = objCoursesList;
            this.objStudentsList = objStudentsList;
        }

        public bool calculate()
        {
            this.objStudentsList.Shuffle();

            foreach (Student tmpStudent in this.objStudentsList)
            {

            }

            return false;
        }
    }

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
