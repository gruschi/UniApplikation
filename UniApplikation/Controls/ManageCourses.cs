using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniApplikation
{
    public partial class ManageCourses : UserControl
    {
        public ManageCourses()
        {
            InitializeComponent();
        }

        private void saveCourseList_Click(object sender, EventArgs e)
        {
            App.Classes.XMLHandler.SerializeObject((DataTable)this.DgVCourses.DataSource);
        }
    }
}
