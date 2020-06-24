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
    /// This class represents a Button object from the GUI.
    /// </summary>
    public class Button : TestObjectBase, IInvoke
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Button()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Button(AutomationElement element) : base(element) 
        {
            
        }

        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// For the button object, invoke performs a click action.
        /// </summary>
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
