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
    /// This class represents the root of the UI which is the desktop.
    /// </summary>
    public class UIRoot
    {
        /// <summary>
        /// This method is used for finding a Window object inside the desktop.
        /// </summary>
        /// <param name="name">The name property of the window to find.</param>
        /// <param name="automationId">The automationId property of the window to find.</param>
        /// <param name="waitSeconds">The time in seconds allowed for the window search.</param>
        /// <returns>Returns a window object with the given properties.</returns>
        public static Window Find(string name = "", string automationId = "", int waitSeconds = 25)
        {
            int count = 0;
            AutomationElement testObject = null;

            Condition autoIdCondition = null;
            Condition nameCondition = null;

            if (name == "" && automationId == "") throw new GUITestingException("Can not find window without given properties.");

            if (name != "")
            {

                nameCondition = new PropertyCondition(AutomationElementIdentifiers.NameProperty, name);
            }

            if (automationId != "")
            {
                autoIdCondition = new PropertyCondition(AutomationElementIdentifiers.AutomationIdProperty, automationId);
            }

            AndCondition andCondition = null;

            if (autoIdCondition != null && nameCondition != null) andCondition = new AndCondition(nameCondition, autoIdCondition);

            do
            {
                if (andCondition != null) testObject = AutomationElement.RootElement.FindFirst(TreeScope.Children, andCondition);
                else if (nameCondition != null && autoIdCondition == null) testObject = AutomationElement.RootElement.FindFirst(TreeScope.Children, nameCondition);
                else if (nameCondition == null && autoIdCondition != null) testObject = AutomationElement.RootElement.FindFirst(TreeScope.Children, autoIdCondition);

                count++;
                Thread.Sleep(100);
            }
            while (testObject == null && count < 50 * waitSeconds);

            return new Window(testObject);
        }
    }
}
