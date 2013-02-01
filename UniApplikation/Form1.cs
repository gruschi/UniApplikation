using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SetCoursesAlgo.Models;
using UniApplikation.Controls;
using SetCoursesAlgo.Models;

namespace UniApplikation
{
    public partial class UniApplikation : Form
    {
        List<Panel> arPanelSelektion = new List<Panel>();

        public UniApplikation()
        {
            InitializeComponent();

            this.arPanelSelektion.Add(this.contentPanelDefault);

            this.contentPanelDefault.Controls.Add(new DefaultControl());
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLHandler testObj = new XMLHandler();
            testObj.testSerializer();
        }

        private void hideAllPanels()
        {
            foreach(Panel tmpPanel in this.arPanelSelektion){
                tmpPanel.Hide();
            }
        }

        private void excellistenLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.contentPanelDefault.Controls.Clear();//TODO Anders ?
            this.contentPanelDefault.Controls.Add(new LoadExcelFiles());
            this.contentPanelDefault.Update();
        }

        private void verwaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.contentPanelDefault.Controls.Clear();//TODO Anders ?
            this.contentPanelDefault.Controls.Add(new ManageCourses());
            this.contentPanelDefault.Update();
        }

        private void berechnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.contentPanelDefault.Controls.Clear();//TODO Anders ?            
            this.contentPanelDefault.Controls.Add(new CoursesCalculationControll());
            this.contentPanelDefault.Update();
        }
    }
}
