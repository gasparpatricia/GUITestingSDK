using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK
{
    public class GUIObjectNotFoundException : GUITestingException
    {
        public GUIObjectNotFoundException() { }

        public GUIObjectNotFoundException(string message) : base(message)
        {

        }
        public GUIObjectNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
