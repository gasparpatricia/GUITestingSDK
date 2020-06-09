using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
     public class Window : TestObjectBase, IWindow
    {

        public Window()
        {
        }

        public Window(AutomationElement element) : base(element)
        {

        }

        public void Close()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                windowPattern.Close();
            }
        }

        public bool IsTopMost()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                return windowPattern.Current.IsTopmost;
            }
            return false;
        }

        public bool CanMinimize()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                return windowPattern.Current.CanMinimize;
            }
            return false;
        }

        public bool CanMaximize()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                return windowPattern.Current.CanMaximize;
            }
            return false;
        }
    }
}
