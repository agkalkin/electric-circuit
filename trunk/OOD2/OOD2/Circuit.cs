using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2
{
    class Circuit
    {
        // Color definitions for colouring connections
        Color cTrue, cFalse, cUnknown;
        IElement firstSelectedId;
        IElement secondSelectedId;
        List<IElement> elements;
        Record undo_redo;
        static int lastId;

        Boolean AddConnection();
        Boolean AddElement(int id);
        //Added 2 more parameters for coordinates
        //Not sure if we'll need them
        Boolean MoveElement(int id, int x, int y);
        //Added parameter
        Boolean RemoveConnection(int id);
        Boolean RemoveElement(int id);
        //Not sure if we'll need the last 2
        int Calculate();
        void AssignColor();
    }
}
