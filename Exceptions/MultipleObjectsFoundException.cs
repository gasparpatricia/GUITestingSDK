using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK
{
    public class MultipleObjectsFoundException : GUITestingException
    {

        public MultipleObjectsFoundException() { }

        public MultipleObjectsFoundException(string message) : base(message)
        {

        }
        public MultipleObjectsFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
