using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Gate: IElement
    {
        /// <summary>
        /// Takes two inputs and generates output
        /// </summary>
        /// <param name="input1">First input</param>
        /// <param name="input2">Second input</param>
        /// <returns> 0 or 1 (TRUE or FALSE)</returns>
        abstract int Output(int input1, int input2);

        /// <summary>
        /// Takes input and generates output
        /// </summary>
        /// <param name="input">Gate input</param>
        /// <returns>0 or 1 (TRUE or FALSE)</returns>
        abstract int Output(int input);
    }
}
