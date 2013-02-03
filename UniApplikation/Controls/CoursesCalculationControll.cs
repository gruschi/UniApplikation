using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib = SetCoursesAlgo.Models;

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
            SetCoursesAlgo.Handler objHandler = new SetCoursesAlgo.Handler(Properties.Settings.Default.CoursesXMLPath, Properties.Settings.Default.StudentsXMLPath);
            objHandler.calculate();
            objHandler.saveResult();
        }
    }
}
