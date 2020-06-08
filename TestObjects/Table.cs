using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public class Table : TestObjectBase
    {

        public Table()
        {
        }

        public Table(AutomationElement element) : base(element)
        {

        }

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
