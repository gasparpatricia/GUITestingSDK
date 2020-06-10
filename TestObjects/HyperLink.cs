using GUITestingSDK;
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
    /// This class represents a HyperLink object from the GUI.
    /// </summary>
    public class HyperLink : TestObjectBase, IInvoke
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public HyperLink()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public HyperLink(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// For the hyperlink object, invoke performs a launch action.
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
