using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    /// <summary>
    /// This interface is used to describe the selection item behavior from within a container object.
    /// </summary>
    public interface ISelectionItem
    {
        /// <summary>
        /// This method performs the selection action on the object.
        /// </summary>
        void Select();

        /// <summary>
        /// This method performs the deselection action on the object.
        /// </summary>
        void Deselect();
    }
}
