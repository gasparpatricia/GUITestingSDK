using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    public interface IGridItem
    {
        int GetColumnIndex();
        int GetRowIndex();
        Table GetContainer();
    }
}
