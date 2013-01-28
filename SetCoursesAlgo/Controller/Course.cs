using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCoursesAlgo.Controller
{
    internal class Course : SetCoursesAlgo.Models.ICourse
    {
        public string Name;
      
        public string Lecturer;
       
        public int iMaxPlaces;        

        public Student[] objStudents;
        private int iCounterStudents = 0;

        public Course(string name, string lecturer, int maxPlaces)
        {
            this.Name = name;
            this.Lecturer = lecturer;
            this.iMaxPlaces = maxPlaces;

            this.objStudents = new Student[maxPlaces];
        }

        public bool addStudent(Student objStudent)
        {
            if (this.iCounterStudents >= this.objStudents.Length)//Course full
            {
                return false;
            }
            else
            {
                this.objStudents[iCounterStudents] = objStudent;
                ++iCounterStudents;
                return true;
            }

            
        }
    }
}
