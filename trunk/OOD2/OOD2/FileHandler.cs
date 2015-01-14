using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class FileHandler
    {
        //File path including name and extension
        string fileLocation;

        Boolean OpenPng();

        Boolean SavePng();

        /// <summary>
        /// Opens editable file
        /// </summary>
        /// <returns>List of elements on circuit</returns>
        List<IElement> OpenFile();

        /// <summary>
        /// Saves to editable file
        /// </summary>
        /// <param name="elements">List of elements on circuit</param>
        /// <returns>True if successful</returns>
        bool SaveToFile(List<IElement> elements);
    }
}
