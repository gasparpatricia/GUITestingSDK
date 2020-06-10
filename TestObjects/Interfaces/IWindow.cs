using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    /// <summary>
    /// This interface is used to describe the window behavior.
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// This method performs the close action on the object.
        /// </summary>
        void Close();

        /// <summary>
        /// This method returns the top-most state of the object.
        /// </summary>
        /// <returns>If the object is on top on the desktop, returns true. Returns false otherwise.</returns>
        bool IsTopMost();

        /// <summary>
        /// This method returns the canMinimize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be minimized. Returns false otherwise.</returns>
        bool CanMinimize();

        /// <summary>
        /// This method returns the canMaximize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be maximized. Returns false otherwise.</returns>
        bool CanMaximize();
    }
}
