using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using UniApplikation.App.Classes;
using System.Text.RegularExpressions;

namespace UniApplikation
{
    public partial class LoadExcelFiles : UserControl
    {
        public LoadExcelFiles()
        {
            InitializeComponent();
        }

        private void cmdOpenFileDialog_Click(object sender, EventArgs e)
        {
            string[] Pfad;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files (*.xls,*.xlsx)|*.xls,*.xlsx|All Files (*.*)|*.*";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Pfad = openFileDialog1.FileNames;

                foreach (string tmpPath in Pfad)
                {
                    this.saveExcelDataToXML(Pfad);
                }                
            }
                

        }

        private void saveExcelDataToXML(string[] Pfad)
        {
            foreach (string tmpPath in Pfad)
            {
                this.readExcelData(tmpPath);
            }
            
        }

        private void readExcelData(string sFile)
        {         
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int rCnt = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(sFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            App.Classes.Student[] objStudents = new App.Classes.Student[range.Rows.Count];
            int iStudentsIndex = 0;

            #region getPriority from PathName
            string[] tmpPathSplits = sFile.Split('_');
            int priotity = Convert.ToInt32(Regex.Match(tmpPathSplits[(tmpPathSplits.Length - 2)], @"\d+").Value) - 1;
            #endregion

            //Gehe das ganze Tabellenblatt durch
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)//Startet von 2. Zeile wegen Überschriften
            {
                //Hier haben wir Zugriff auf jede Zeile
                if ((range.Cells[rCnt, 1] as Excel.Range).Value2 != null)
                {                        
                    string sName = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
                    string sSurname = (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                    string sID = (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                    string sGroup = (string)(range.Cells[rCnt, 4] as Excel.Range).Value2;
                    string sAnswer = (string)(range.Cells[rCnt, 5] as Excel.Range).Value2;

                    Student tmpStudent = new App.Classes.Student(sName, sSurname, sID, sGroup);
                    tmpStudent.setChoose(priotity, sAnswer);

                    objStudents[iStudentsIndex] = tmpStudent;
                    ++iStudentsIndex;                        
                }
            }

            //TODO Save StudentList Auslagern, sonst wird immer überschrieben!
            App.Classes.StudentsList objStudentsList = App.Classes.StudentsList.getListFromXML();
            objStudentsList.setStudents(objStudents);//Set/Merges Students, Overrides existing Prioritys (if necesarry)
            objStudentsList.saveList();

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();          
        }
    }
}
