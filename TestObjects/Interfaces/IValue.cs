using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    /// <summary>
    /// This method is used to describe the value behavior.
    /// </summary>
    public interface IValue
    {
        /// <summary>
        /// This method sets the value of an object if the value is not read-only.
        /// </summary>
        /// <param name="value">The value to be set.</param>
        void SetValue(string value);

        /// <summary>
        /// This method returns the current value of the object.
        /// </summary>
        /// <returns>Returns the current text inside the object.</returns>
        string GetValue();

        /// <summary>
        /// This method returns the read-only state of the object.
        /// </summary>
        /// <returns>Returns true if the object is read-only, false otherwise.</returns>
        bool IsReadOnly();
    }
}
