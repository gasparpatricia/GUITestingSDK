using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class Table : TestObjectBase, ITable
    {

        public Table()
        {
        }

        public Table(AutomationElement element) : base(element)
        {

        }

        //Unsupported for WinForms
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

        //Unsupported for WinForms
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

        //Unsupported for WinForms
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

        //Unsupported for WinForms
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

        //Unsupported for WinForms
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
