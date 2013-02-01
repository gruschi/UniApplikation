using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uni = UniApplikation.App.Classes;
using Lib = SetCoursesAlgo.Controller;

namespace UniApplikation.Controls
{
    public partial class CoursesCalculationControll : UserControl
    {
        public CoursesCalculationControll()
        {
            InitializeComponent();
        }

        private void startCalculation_Click(object sender, EventArgs e)
        {
            //Get Students + Courses from List
            List<Lib.Student> studentList = new List<Lib.Student>();
            List<Lib.Course> courseList = new List<Lib.Course>();

            Uni.StudentsList tmpStudentsList = Uni.StudentsList.getListFromXML();
            Uni.CoursesList tmpCoursesList = Uni.CoursesList.getListFromXML();

            foreach (Uni.Student tmpStudent in tmpStudentsList.Students)
            {                
                studentList.Add(tmpStudent);
            }

            foreach (Uni.Course tmpCourse in tmpCoursesList.Courses)
            {
                courseList.Add(tmpCourse);
            }

            SetCoursesAlgo.Handler objHandler = new SetCoursesAlgo.Handler(courseList, studentList);            
        }
    }
}
