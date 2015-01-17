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
            IElement newconnection;
            newconnection = new Connection(firstSelectedId.id, secondSelectedId.id);
            elements.Add(newconnection);
            newconnection.Drawing();
            return true;
        }
        Boolean AddElement(int id,TypeOfElement newelement,int mousex,int mousey)
        {
            if (newelement == TypeOfElement.SOURCE)
            {
                Source newsource = new Source(mousex, mousey);
                //newsource.SetId(id);
                elements.Add(newsource);
                return true;
            }
            else if (newelement == TypeOfElement.ANDGATE)
            {
                AND newand = new AND(mousex, mousey);
                return true;
            }
            else if(newelement==TypeOfElement.NOTGATE)
            {
                NOT newnot = new NOT(mousex, mousey);
                return true;
            }
            else if(newelement==TypeOfElement.ORGATE)
            {
                OR newor = new OR(id, mousex, mousey);
                return true; 
            }
            else if(newelement==TypeOfElement.SINK)
            {
                Sink newsink = new Sink(mousex, mousey);
                elements.Add(newsink);
                return true; 
            }
            return false;
        }
        //Added 2 more parameters for coordinates
        //Not sure if we'll need them
        Boolean MoveElement(int id, int x, int y)
        {
            IElement searchelement;
            searchelement=elements.Find(search=> search.id==id);
            searchelement.x = x;
            searchelement.y = y;
            return true;
        }
        //Added parameter
        Boolean RemoveConnection(int id)
        {
            elements.Remove(elements.Find(x => x.id == id));
            return true;
        }
        Boolean RemoveElement(int id)
        {
            elements.Remove(elements.Find(x=>x.id==id));
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
