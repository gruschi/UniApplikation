using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace UniApplikation.App.Classes
{       
    public class Course : SetCoursesAlgo.Controller.Course
    {
        public Course(string Name, string Lecturer, int Places) : base(Name, Lecturer, Places)
        {            
        }                      
    }
    
}
