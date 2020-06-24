using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    /// <summary>
    /// This class represents any from the GUI that does not have a class in the GUITestingSDK.
    /// </summary>
    public class GUIObject : TestObjectBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GUIObject()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public GUIObject(AutomationElement element) : base(element)
        {

        }

    }
}
