using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    /// <summary>
    /// This interface is used to describe the invoke behavior.
    /// </summary>
    public interface IInvoke
    {
        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// </summary>
        void Invoke(); 
        
    }
}
