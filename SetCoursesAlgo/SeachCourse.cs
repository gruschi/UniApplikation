using SetCoursesAlgo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetCoursesAlgo
{
    public partial class SeachCourse : Form
    {        
        public string sReturnCourseRight {get;set;}//Name des richtigen Kurses
        public string CourseName;//Name des Kurses der Falsch ist

        public SeachCourse()
        {
            InitializeComponent();
        }

        public SeachCourse(string courseName, List<Course> Courses) : this()
        {
            this.CourseName = courseName;

            this.txtCourseName.Text = this.CourseName;

            foreach (Course tmpCourse in Courses)
            {
                this.cBSelectCourse.Items.Add(tmpCourse.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cBSelectCourse.SelectedItem.ToString().Length > 0)
            {
                this.sReturnCourseRight = this.cBSelectCourse.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
           
            
            this.Close();
        }
    }
}
