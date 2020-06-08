using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public interface ITestObjectBase
    {

        //public TestObject Find(GUIElementType controlType, string name = "", string automationId = "", bool isEnabled = false, int waitSeconds = 25);



        void Click();
        void Hover();

        //[DllImport("user32.dll")]
       // public static extern void Focus();
    }
}
