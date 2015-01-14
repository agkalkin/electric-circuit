using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    abstract class Logic: IElement
    {
        //Logic value of the element (0, 1 or "unknown"
        abstract int logicValue; 
    }
}
