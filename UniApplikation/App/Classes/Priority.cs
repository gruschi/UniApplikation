using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    public class Priority
    {
        [XmlElement("Priority")]
        public int Prio;

        [XmlElement("Value")]
        public string Value;

        public Priority()
        {
        }

        public Priority(int prio, string value)
        {
            this.Prio = prio;
            this.Value = value;
        }
        
    }
}
