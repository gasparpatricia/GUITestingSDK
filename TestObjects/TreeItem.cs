using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public class TreeItem : TestObjectBase
    {

        public TreeItem()
        {
        }

        public TreeItem(AutomationElement element) : base(element)
        {

        }

    }
}
