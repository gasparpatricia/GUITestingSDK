using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class TreeItem : TestObjectBase, IExpandCollapse
    {

        public TreeItem()
        {
        }

        public TreeItem(AutomationElement element) : base(element)
        {

        }

        public void Collapse()
        {
            ExpandCollapsePattern expandCollapsePattern = AutoElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Collapse();
            }
        }

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
