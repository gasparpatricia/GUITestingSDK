using GUITestingSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    /// <summary>
    /// This class represents a List object from the GUI.
    /// </summary>
    public class List : TestObjectBase
    {
        private AutomationElement[] listItems = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public List()
        {

        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public List(AutomationElement element) : base(element)
        {
            FindChildren();
        }

        /// <summary>
        /// This method performs the selection action on the item at the given index inside this object.
        /// </summary>
        /// <param name="index"></param>
        public void Select(int index)
        {
            SelectionItemPattern selectionPattern = listItems[index].GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionPattern != null)
            {
                selectionPattern.Select();
            }
            else throw new WrongOperationException("Could not select item at given index.");

        }

        /// <summary>
        /// This method performs the selection action on the item with the given text inside this object.
        /// </summary>
        /// <param name="text"></param>
        public void Select(string text)
        {
            foreach (AutomationElement element in listItems)
            {
                if (element.Current.Name.Equals(text))
                {
                    SelectionItemPattern selectionPattern = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    if (selectionPattern != null)
                    {
                        selectionPattern.Select();
                        return;
                    }
                    else throw new WrongOperationException("Could not select item with given text.");
                }

            }
            throw new WrongOperationException("Could not find the item with given text.");
        }

        /// <summary>
        /// This method initializes the children inside the list. It has by default 10 seconds to find the objects, otherwise throws GUIObjectNotFoundException.
        /// </summary>
        /// <param name="seconds"></param>
        private void FindChildren(int seconds = 10)
        {
            int count = 0;

            do
            {
                if (AutoElement != null && listItems == null)
                {
                    AutomationElementCollection automationElementCollection = AutoElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30003), ControlType.ListItem));

                    if (automationElementCollection.Count > 0)
                    {
                        listItems = new AutomationElement[automationElementCollection.Count];
                        automationElementCollection.CopyTo(listItems, 0);
                        return;
                    }
                }

                count++;
                Thread.Sleep(100);
            }
            while (listItems == null && count < 10 * seconds);

            if (listItems == null) throw new GUIObjectNotFoundException("Could not find the list items.");

        }

    }
}
