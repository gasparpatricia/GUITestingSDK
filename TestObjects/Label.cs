using GUITestingSDK.Exceptions;
using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class Label : TestObjectBase, IValue
    {

        public Label()
        {
        }

        public Label(AutomationElement element) : base(element)
        {

        }


        public string GetValue()
        {
            if (AutoElement.Current.FrameworkId == "WinForm")
            {
                return AutoElement.Current.Name;
            }
            else
            {
                ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (valuePattern != null)
                {
                    return valuePattern.Current.Value;
                }
            }
            
            return null;
        }

        public bool IsReadOnly()
        {
            if (FrameworkId == "WinForm") {
                return true; 
            }
            else
            {
                ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (valuePattern != null)
                {
                    return valuePattern.Current.IsReadOnly;
                }
            }
            return true;
        }

        public void SetValue(string value)
        {
            if(IsReadOnly()) throw new WrongOperationException("Object is read only.");
        }
    }
}
