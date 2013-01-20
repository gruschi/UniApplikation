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
    public class Course
    {        
        
    //Die zu serialisierende Klasse
    //(Die XML-Attribute werden nur für die Xml-serialisierung gebraucht)    

        [XmlElement("Name")]
        public string Name;
        [XmlElement("Lecturer")]
        public string Lecturer;
        [XmlElement("Places", DataType = "int")]
        public int Places;///Places Left                

        public Course()
        {
            
        }

        public Course(string Name, string Lecturer, int Places)
        {
            this.Name = Name;
            this.Lecturer = Lecturer;
            this.Places = Places;
        }
            
   }
    
}
