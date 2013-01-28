using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SetCoursesAlgo.Models
{       
    public interface ICourse
    {        
           
        [XmlElement("Name")]
        public string Name;
        [XmlElement("Lecturer")]
        public string Lecturer;
        [XmlElement("Places", DataType = "int")]
        public int Places;///Places Left                
      
   }
    
}
