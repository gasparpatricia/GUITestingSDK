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
    /// This class represents a TreeItem object from the GUI.
    /// </summary>
    public class TreeItem : TestObjectBase, IExpandCollapse
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TreeItem()
        {
        }

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public TreeItem(AutomationElement element) : base(element)
        {

        }

        /// <summary>
        /// This method performs the collapse action on the object.
        /// </summary>
        public void Collapse()
        {
            ExpandCollapsePattern expandCollapsePattern = AutoElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Collapse();
            }
        }

        /// <summary>
        /// This method performs the expand action on the object.
        /// </summary>
        public void Expand()
        {
            ExpandCollapsePattern expandCollapsePattern = AutoElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
        }
    }
}
