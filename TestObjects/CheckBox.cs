using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class CheckBox : TestObjectBase, IInvoke, IToggle
    {

        public CheckBox()
        {
        }

        public CheckBox(AutomationElement element) : base(element)
        {

        }

        public void Toggle()
        {
            TogglePattern togglePattern = AutoElement.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            if (togglePattern != null)
            {
                togglePattern.Toggle();
            }
        }

        public void Invoke()
        {
            InvokePattern invokePattern = AutoElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
        }

    }
}
