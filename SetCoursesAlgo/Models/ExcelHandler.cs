using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SetCoursesAlgo.Models
{
    public class ExcelHandler
    {
        public ExcelHandler()
        {

        }

        public static void readExcelData(object objFile, string sStudentXMLPath)
        {
            String sFile = objFile.ToString();//Parameter to String
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int rCnt = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(sFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            List<Student> objStudents = new List<Student>();
            int iStudentsIndex = 0;

            #region getPriority from PathName
            string[] tmpPathSplits = sFile.Split('_');

            int priotity = -1;
            bool bCountCourses = false;

            try
            {
                priotity = Convert.ToInt32(Regex.Match(tmpPathSplits[(tmpPathSplits.Length - 2)], @"\d+").Value) - 1;
            }
            catch (FormatException)
            {
                bCountCourses = true;
            }

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
                    string sAnswer = Convert.ToString((range.Cells[rCnt, 5] as Excel.Range).Value2);

                    if (sID == null || sID.Length < 2)
                    {
                        sID = "ID" + sName + "x" + sSurname;
                    }

                    Student tmpStudent = new Student(sName, sSurname, sID, sGroup);
                    tmpStudent.setChoose(priotity, sAnswer, bCountCourses);

                    objStudents.Add(tmpStudent);
                    ++iStudentsIndex;
                }
            }

            StudentsList objStudentsList = StudentsList.getListFromXML(sStudentXMLPath);
            objStudentsList.setStudents(objStudents);//Set/Merges Students, Overrides existing Prioritys (if necesarry)
            objStudentsList.saveList(sStudentXMLPath);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
        }
    
    }
}
