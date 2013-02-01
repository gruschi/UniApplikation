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
        }

        private void saveCourseList_Click(object sender, EventArgs e)
        {
            XMLHandler.SerializeObject<CoursesList>((DataTable)this.DgVCourses.DataSource, Properties.Settings.Default.CoursesXMLPath);
        }
    }
}
