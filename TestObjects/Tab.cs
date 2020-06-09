using GUITestingSDK.Exceptions;
using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class Tab : TestObjectBase, ISelection
    {
        private AutomationElement[] tabItems = null;
        public Tab()
        {
        }

        public Tab(AutomationElement element) : base(element)
        {
            FindChildren();
        }

        public void Select(int index)
        {
            SelectionItemPattern selectionPattern = tabItems[index].GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (selectionPattern != null)
            {
                selectionPattern.Select();
            }
            else throw new WrongOperationException("Could not select item at given index.");

        }

        public void Select(string text)
        {
            foreach(AutomationElement element in tabItems)
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
                if (AutoElement != null && tabItems == null)
                {
                    AutomationElementCollection automationElementCollection = AutoElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30003), ControlType.TabItem));
                    
                    if (automationElementCollection.Count > 0)
                    {
                        tabItems = new AutomationElement[automationElementCollection.Count];
                        automationElementCollection.CopyTo(tabItems, 0);
                        return;
                    }
                }

                count++;
                Thread.Sleep(100);
            }
            while (tabItems == null && count < 10 * seconds);

            if(tabItems == null) throw new GUIObjectNotFoundException("Could not find the tab items.");

        }

    }
}
