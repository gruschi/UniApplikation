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
using SetCoursesAlgo.Models;

namespace UniApplikation.Controls
{
    public partial class CoursesCalculationControll : UserControl
    {
        SetCoursesAlgo.Handler objHandler;

        public CoursesCalculationControll()
        {
            InitializeComponent();
        }

        private void startCalculation_Click(object sender, EventArgs e)
        {        
            this.objHandler = new SetCoursesAlgo.Handler(Properties.Settings.Default.CoursesXMLPath, Properties.Settings.Default.StudentsXMLPath);
            this.objHandler.calculate();
            this.excelExport.Enabled = true;

            //TODO Ausgabe von Fehlern;
            foreach (string msg in Logger.sMessages)
            {
                MessageBox.Show(msg);
            }

        }    

        private void excelExport_Click(object sender, EventArgs e)
        {
            List<DataTable> objListDataTables = this.objHandler.saveResult();//Results of the Calculate in a List of DataTables            
            ExcelHandler.CreateExcelFile(objListDataTables, Properties.Settings.Default.OutputFilesPath);
            DataTable objMissingStudents = this.objHandler.getMissingStudents();
            ExcelHandler.CreateExcelFile(objMissingStudents, Properties.Settings.Default.OutputFilesPath);//Students without courses

            MessageBox.Show("Die Excellisten wurden erstellt");

            //TODO Ausgabe von Fehlern;
            foreach (string msg in Logger.sMessages)
            {
                MessageBox.Show(msg);
            }
        }


    }
}
