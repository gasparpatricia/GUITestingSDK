using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.Exceptions
{
    class WrongOperationException : GUITestingException
    {
        public WrongOperationException() { }

        public WrongOperationException(string message) : base(message)
        {

        }
        public WrongOperationException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
