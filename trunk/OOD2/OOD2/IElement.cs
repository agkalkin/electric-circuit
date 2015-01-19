using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{   
 
    interface IElement
    {
        int id { get;}
        int input { get;}
        int output { get;} //currently attached inputs and outputs
        int maxInput { get;}
        int maxOutput { get;} // max amount for inputs and outputs
        int oldX { get; }
        int oldY { get; }
        int x { get; }
        int y { get; }
        int logicValue { get; }

        bool Drawing(System.Drawing.Graphics gr);

        Boolean MoveElement(int x, int y);
    }
}
