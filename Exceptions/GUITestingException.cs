using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.Exceptions
{
    public class GUITestingException : Exception
    {
        public GUITestingException() { }

        public GUITestingException(string message) : base (message)
        {
            
        }

        public GUITestingException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
