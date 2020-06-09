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
    public class TableItem : TestObjectBase, IValue
    {

        public  TableItem()
        {
        }

        public TableItem(AutomationElement element) : base(element)
        {

        }

        //value pattern, griditem pattern, tableitem

        public string GetValue()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.Value;
            }

            return null;
        }

        public bool IsReadOnly()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.IsReadOnly;
            }
            return false;
        }

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
