﻿using GUITestingSDK.Exceptions;
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
    /// <summary>
    /// This class represents a Tab object from the GUI.
    /// </summary>
    public class Tab : TestObjectBase, ISelection
    {
        private AutomationElement[] tabItems = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Tab()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// Initializes tab items that can be selected.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Tab(AutomationElement element) : base(element)
        {
            FindChildren();
        }

        /// <summary>
        /// This method performs the selection action on the item at the given index inside this object.
        /// </summary>
        /// <param name="index"></param>
        public void Select(int index)
        {
            SelectionItemPattern selectionPattern = tabItems[index].GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
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

        /// <summary>
        /// This method initializes the children inside the list. It has by default 10 seconds to find the objects, otherwise throws GUIObjectNotFoundException.
        /// </summary>
        /// <param name="seconds"></param>
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
