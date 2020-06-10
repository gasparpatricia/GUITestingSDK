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
    /// This class represents a CheckBox object from the GUI.
    /// </summary>
    public class CheckBox : TestObjectBase, IToggle
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CheckBox()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public CheckBox(AutomationElement element) : base(element)
        {

        }

        /// <inheritdoc/>
        /// <remarks>
        /// For the check box object, toggle performs a check action if the checkbox is not checked, and an uncheck action if the check box is checked.
        /// </remarks>
        public void Toggle()
        {
            TogglePattern togglePattern = AutoElement.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            if (togglePattern != null)
            {
                togglePattern.Toggle();
            }
        }

    }
}
