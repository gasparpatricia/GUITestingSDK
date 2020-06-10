using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    /// <summary>
    /// This class represents a Window object from the GUI.
    /// </summary>
    public class Window : TestObjectBase, IWindow
     {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Window()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Window(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method performs the close action on the object.
        /// </summary>
        public void Close()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                windowPattern.Close();
            }
        }

        /// <summary>
        /// This method returns the top-most state of the object.
        /// </summary>
        /// <returns>If the object is on top on the desktop, returns true. Returns false otherwise.</returns>
        public bool IsTopMost()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                return windowPattern.Current.IsTopmost;
            }
            return false;
        }

        /// <summary>
        /// This method returns the canMinimize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be minimized. Returns false otherwise.</returns>
        public bool CanMinimize()
        {
            WindowPattern windowPattern = AutoElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (windowPattern != null)
            {
                return windowPattern.Current.CanMinimize;
            }
            return false;
        }

        /// <summary>
        /// This method returns the canMaximize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be maximized. Returns false otherwise.</returns>
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
