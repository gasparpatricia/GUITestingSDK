using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public class ListItem : TestObjectBase
    {

        public ListItem()
        {
        }

        public ListItem(AutomationElement element) : base(element)
        {

        }

        public void Select()
        {
            SelectionItemPattern selectionPattern = AutoElement.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionPattern != null)
            {
                selectionPattern.AddToSelection();
            }
        }

        public void Deselect()
        {
            SelectionItemPattern selectionItemPattern = AutoElement.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionItemPattern != null)
            {
                AutomationElement selectionContainer = selectionItemPattern.Current.SelectionContainer;
                SelectionPattern selectionPattern = selectionContainer.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                
                if (!(selectionPattern.Current.IsSelectionRequired && selectionPattern.Current.GetSelection().GetLength(0) <=1) && selectionItemPattern.Current.IsSelected)
                {
                    selectionItemPattern.RemoveFromSelection();
                }
                
            }
        }
    }
}
