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
using System.Threading;

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
            Logger.sMessages.Clear();            

        }    

        private void excelExport_Click(object sender, EventArgs e)
        {
            Thread oThread = new Thread(new ParameterizedThreadStart(createExcelLists));

            oThread.Start(this.objHandler);
        }

        public void createExcelLists(object objHandler)
        {
            SetCoursesAlgo.Handler handler = (SetCoursesAlgo.Handler)objHandler;

            List<DataTable> objListDataTables = handler.saveResult();//Results of the Calculate in a List of DataTables       
            DataTable objMissingStudents = handler.getMissingStudents();        

            ExcelHandler.CreateExcelFile(objListDataTables, Properties.Settings.Default.OutputFilesPath);
            
            ExcelHandler.CreateExcelFile(objMissingStudents, Properties.Settings.Default.OutputFilesPath);//Students without courses

            MessageBox.Show("Die Excellisten wurden erstellt");

            //TODO Ausgabe von Fehlern;
            foreach (string msg in Logger.sMessages)
            {
                MessageBox.Show(msg);
            }
            Logger.sMessages.Clear();

            //Exportiere Zusammenfassung
            handler.exportReport(Properties.Settings.Default.OutputFilesPath);
        }


    }
}
