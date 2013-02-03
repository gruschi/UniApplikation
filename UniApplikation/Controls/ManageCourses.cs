using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SetCoursesAlgo.Models;

namespace UniApplikation.Controls
{
    public partial class ManageCourses : UserControl
    {
        public ManageCourses()
        {
            InitializeComponent();

            //Bearbeiten der DataTable
            CoursesList CourseList = CoursesList.getListFromXML(Properties.Settings.Default.CoursesXMLPath);
            if (CourseList == null)
            {
                CourseList = new CoursesList("Kursliste");
            }

            this.DgVCourses.DataSource = CourseList.getDataTable();
        }

        private void saveCourseList_Click(object sender, EventArgs e)
        {
            CoursesList objCoursesList = new CoursesList("Kursliste");
            objCoursesList.Courses = CoursesList.ConvertDTtoCourseList((DataTable)this.DgVCourses.DataSource);

            XMLHandler.SerializeObject<CoursesList>(objCoursesList, Properties.Settings.Default.CoursesXMLPath);
        }
    }
}
