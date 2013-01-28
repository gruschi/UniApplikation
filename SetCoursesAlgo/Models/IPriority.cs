using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    public interface IPriority
    {
        [XmlElement("Priority")]
        public int Prio;

        [XmlElement("Value")]
        public string Value; 
        
    }
}
