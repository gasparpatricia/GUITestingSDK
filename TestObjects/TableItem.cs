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
    /// This class represents a TableItem object from the GUI.
    /// </summary>
    public class TableItem : TestObjectBase, IValue
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TableItem()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public TableItem(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method returns the current value of the object.
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

        /// <summary>
        /// This method sets the value of an object if the value is not read-only.
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

        public int GetColumnIndex()
        {
            GridItemPattern gridItemPattern = AutoElement.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
            if (gridItemPattern != null)
            {
                return gridItemPattern.Current.Column;
            }
            return -1; //must be replaced
        }

        public int GetRowIndex()
        {
            GridItemPattern gridItemPattern = AutoElement.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
            if (gridItemPattern != null)
            {
                return gridItemPattern.Current.Row;
            }
            return -1; //must be replaced
        }

        public Table GetContainer()
        {
            GridItemPattern gridItemPattern = AutoElement.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
            if (gridItemPattern != null)
            {
                return new Table(gridItemPattern.Current.ContainingGrid);
            }
            else
            {
                TableItemPattern tableItemPattern = AutoElement.GetCurrentPattern(TableItemPattern.Pattern) as TableItemPattern;
                if (tableItemPattern != null)
                {
                    return new Table(tableItemPattern.Current.ContainingGrid);
                }
            }
            return null;
        }


    }
}
