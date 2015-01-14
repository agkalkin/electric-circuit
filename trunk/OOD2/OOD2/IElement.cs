using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    interface IElement
    {
        int id;
        int input, output; //currently attached inputs and outputs
        int maxInput, maxOutput; // max amount for inputs and outputs
        int oldX, oldY;
        int x, y;

        bool Drawing();
        IElement(int x, int y);
    }
}
