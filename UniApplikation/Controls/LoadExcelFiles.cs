using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models = SetCoursesAlgo.Models;

namespace UniApplikation.Controls
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
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;)|*.xls;*.xlsx;|" + "All Files (*.*)|*.*";
            openFileDialog1.Multiselect = true;            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Pfad = openFileDialog1.FileNames;

                this.saveExcelDataToXML(Pfad);               
            }

            MessageBox.Show("Excellisten geladen");
        }

        private void saveExcelDataToXML(string[] Pfad)
        {
            
            //foreach (string tmpPath in Pfad)
            //{
            //    Thread tmpThread = new Thread(new ParameterizedThreadStart(this.readExcelData));
            //    tmpThread.Start(tmpPath);
            //    XMLHandler.threadList.Add(tmpThread);                
            //}

            //XMLHandler.checkThread.Start();//Test Thread which checks the other Threads and deletes them when they are finish

            foreach (string tmpPath in Pfad)
            {
                this.readExcelData(tmpPath);
            }
            
        }

        private void readExcelData(object objFile)
        {
            Models.ExcelHandler.readExcelData(objFile);
        }
    }
}
