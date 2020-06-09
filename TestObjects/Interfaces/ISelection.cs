using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    public interface ISelection
    {
        void Select(int index);
        void Select(string text);
    }
}
