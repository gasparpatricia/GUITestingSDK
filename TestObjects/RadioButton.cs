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
    /// This class represents a RadioButton object from the GUI.
    /// </summary>
    public class RadioButton : TestObjectBase, IInvoke
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RadioButton()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public RadioButton(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// For the radio button object, invoke performs a check action if the radio button is not checked.
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
