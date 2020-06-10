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
    public class Menu : TestObjectBase, ISelection
    {
        AutomationElement[] menuItems = null;
        public Menu()
        {
        }

        public Menu(AutomationElement element) : base(element)
        {
            FindChildren();
        }

        public void Select(int index)
        {
            InvokePattern invokePattern = menuItems[index].GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
            else throw new WrongOperationException("Could not select item at given index.");

        }

        public void Select(string text)
        {
            foreach (AutomationElement element in menuItems)
            {
                if (element.Current.Name.Equals(text))
                {
                    InvokePattern invokePattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    if (invokePattern != null)
                    {
                        invokePattern.Invoke();
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
                if (AutoElement != null && menuItems == null)
                {
                    AutomationElementCollection automationElementCollection = AutoElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30003), ControlType.MenuItem));

                    if (automationElementCollection.Count > 0)
                    {
                        menuItems = new AutomationElement[automationElementCollection.Count];
                        automationElementCollection.CopyTo(menuItems, 0);
                        return;
                    }
                }

                count++;
                Thread.Sleep(100);
            }
            while (menuItems == null && count < 10 * seconds);

            if (menuItems == null) throw new GUIObjectNotFoundException("Could not find the menu items.");

        }
    }

}
