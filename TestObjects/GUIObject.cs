using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class GUIObject : TestObjectBase
    {

        public GUIObject()
        {
        }

        public GUIObject(AutomationElement element) : base(element)
        {

        }

    }
}
