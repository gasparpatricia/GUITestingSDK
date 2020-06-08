using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public class UIRoot
    {

        public static Window Find(string name = "", string automationId = "", bool isEnabled = false, int waitSeconds = 25)
        {
            int count = 0;
            AutomationElement testObject = null;
            do
            {
                testObject = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30005), name));
                
                count++;
                Thread.Sleep(100);
            }
            while (testObject == null && count < 50 * waitSeconds);
            //testObject.SetFocus();
            return new Window(testObject);
        }
    }
}
