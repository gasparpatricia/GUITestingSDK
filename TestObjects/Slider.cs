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
    /// <summary>
    /// This class represents a Slider object from the GUI.
    /// </summary>
    public class Slider : TestObjectBase, IValue
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Slider()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Slider(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method sets the value of an object if the value is not read-only.
        /// This action is not supported in WinForms slider controls.
        /// </summary>
        /// <param name="value">The value to be set.</param>
        public void SetValue(string value)
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern.Current.IsReadOnly == true)
                throw new WrongOperationException("The value can not be set because the object is read only.");
            if (valuePattern != null && valuePattern.Current.IsReadOnly == false)
            {
                valuePattern.SetValue(value);
            }

        }

        /// <summary>
        /// This method returns the current value of the object.
        /// This action is not supported in WinForms slider controls.
        /// </summary>
        /// <returns>Returns the current text inside the object.</returns>
        public string GetValue()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.Value;
            }
            return null;
        }

        /// <summary>
        /// This method returns the read-only state of the object.
        /// This action is not supported in WinForms slider controls.
        /// </summary>
        /// <returns>Returns true if the object is read-only, false otherwise.</returns>
        public bool IsReadOnly()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.IsReadOnly;
            }
            return false;
        }

    }
}
