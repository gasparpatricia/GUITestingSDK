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
    /// This class represents a ListItem object from the GUI.
    /// </summary>
    public class ListItem : TestObjectBase, ISelectionItem
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ListItem()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public ListItem(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method performs the selection action on the object.
        /// </summary>
        public void Select()
        {
            SelectionItemPattern selectionPattern = AutoElement.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionPattern != null)
            {
                selectionPattern.AddToSelection();
            }
        }

        /// <summary>
        /// This method performs the deselection action on the object.
        /// </summary>
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
