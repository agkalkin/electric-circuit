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

        Boolean AddConnection()
        {
            return true;
        }
        Boolean AddElement(int id)
        {
            return true;
        }
        //Added 2 more parameters for coordinates
        //Not sure if we'll need them
        Boolean MoveElement(int id, int x, int y)
        {
            return true;
        }
        //Added parameter
        Boolean RemoveConnection(int id)
        {
            return true;
        }
        Boolean RemoveElement(int id)
        {
            return true;
        }
        //Not sure if we'll need the last 2
        int Calculate()
        {
            return -1;
        }
        void AssignColor()
        {

        }
    }
}
