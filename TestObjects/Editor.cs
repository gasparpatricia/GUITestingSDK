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
    /// This class represents an Editor object from the GUI.
    /// </summary>
    public class Editor : TestObjectBase, IValue
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Editor()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Editor(AutomationElement element) : base(element)
        {

        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string GetValue()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.Value;
            }
            return null;
        }

        /// <inheritdoc/>
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
