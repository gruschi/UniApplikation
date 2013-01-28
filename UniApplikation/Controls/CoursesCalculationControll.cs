using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniApplikation.App.Classes;

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
            List<Student> studentList = new List<Student>();
            List<Course> courseList = new List<Course>();


            SetCoursesAlgo.Handler objHandler = new SetCoursesAlgo.Handler(courseList, studentList);            
        }
    }
}
