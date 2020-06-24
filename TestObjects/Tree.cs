using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    /// <summary>
    /// This class represents a Tree object from the GUI.
    /// </summary>
    public class Tree : TestObjectBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Tree()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Tree(AutomationElement element) : base(element)
        {

        }

    }
}
