using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UniApplikation.App.Classes
{
    [Serializable]
    class WrongParameterException : Exception
    {       

        public WrongParameterException() : base() { }    

        public WrongParameterException(string message)
        : base(message) { }
    
        public WrongParameterException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    
        public WrongParameterException(string message, Exception innerException)
            : base(message, innerException) { }
    
        public WrongParameterException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected WrongParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
