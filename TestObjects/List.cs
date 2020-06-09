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
    public class List : TestObjectBase
    {
        private AutomationElement[] listItems = null;

        public List()
        {

        }

        public List(AutomationElement element) : base(element)
        {
            FindChildren();
        }

        public void Select(int index)
        {
            SelectionItemPattern selectionPattern = listItems[index].GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionPattern != null)
            {
                selectionPattern.Select();
            }
            else throw new WrongOperationException("Could not select item at given index.");

        }

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
