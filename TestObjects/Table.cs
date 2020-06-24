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
    /// This class represents a Table object from the GUI.
    /// </summary>
    public class Table : TestObjectBase, ITable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Table()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Table(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method returns the column count of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns the number of columns.</returns>
        public int GetColumnCount()
        {
            GridPattern gridPattern = AutoElement.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
            if (gridPattern != null)
            {
                return gridPattern.Current.ColumnCount;
            }
            else
            {
                TablePattern tablePattern = AutoElement.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                if (tablePattern != null)
                {
                    return tablePattern.Current.ColumnCount;
                }
            }

            return 0;
        }

        /// <summary>
        /// This method returns the row count of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns the number of rows.</returns>
        public int GetRowCount()
        {
            GridPattern gridPattern = AutoElement.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
            if (gridPattern != null)
            {
                return gridPattern.Current.RowCount;
            }
            else
            {
                TablePattern tablePattern = AutoElement.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                if (tablePattern != null)
                {
                    return tablePattern.Current.RowCount;
                }
            }
            return 0;
        }

        /// <summary>
        /// This method returns the row headers of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns an array with the object row headers.</returns>
        public string[] GetRowHeaders()
        {
            TablePattern tablePattern = AutoElement.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
            if (tablePattern != null)
            {
                List<string> headers = new List<string>();
                AutomationElement[] elements = tablePattern.Current.GetRowHeaders();
                foreach (AutomationElement elem in elements)
                {
                    headers.Add(elem.Current.Name);
                }
                return headers.ToArray();
            }
            return null;
        }

        /// <summary>
        /// This method returns the column headers of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns an array with the object column headers.</returns>
        public string[] GetColumnHeaders()
        {
            TablePattern tablePattern = AutoElement.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
            if (tablePattern != null)
            {
                List<string> headers = new List<string>();
                AutomationElement[] elements = tablePattern.Current.GetColumnHeaders();
                foreach (AutomationElement elem in elements)
                {
                    headers.Add(elem.Current.Name);
                }
                return headers.ToArray();
            }
            return null;
        }

        /// <summary>
        /// This method returns a TableItem object inside the table, with the given row and column indexes.
        /// </summary>
        /// <param name="rowindex">TableItem row index</param>
        /// <param name="columnIndex">TableItem column index</param>
        /// <returns></returns>
        public TableItem GetItem(int rowindex, int columnIndex)
        {
            GridPattern gridPattern = AutoElement.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
            if (gridPattern != null)
            {
                return new TableItem(gridPattern.GetItem(rowindex, columnIndex));
            }
            return null;
        }
    }
}
