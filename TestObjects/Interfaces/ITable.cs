using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITestingSDK.TestObjects.Interfaces
{
    /// <summary>
    /// This interface is used to describe the table behavior.
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// This method returns the column headers of the object.
        /// </summary>
        /// <returns>Returns an array with the object column headers.</returns>
        string[] GetColumnHeaders();

        /// <summary>
        /// This method returns the row headers of the object.
        /// </summary>
        /// <returns>Returns an array with the object row headers.</returns>
        string[] GetRowHeaders();

        /// <summary>
        /// This method returns the column count of the object.
        /// </summary>
        /// <returns>Returns the number of columns.</returns>
        int GetColumnCount();

        /// <summary>
        /// This method returns the row count of the object.
        /// </summary>
        /// <returns>Returns the number of rows.</returns>
        int GetRowCount();
    }
}
