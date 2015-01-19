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
        public Record undo_redo;
        private static int lastId = 1;

        public Circuit()
        {
            undo_redo = new Record();
            elements=new List<IElement>();
        }

        public void Undo(TypeOfChange lastchange)
        {
            elements=undo_redo.Undo(lastchange, elements);
        }
        public void Redo()
        {
            elements=undo_redo.Redo();
        }

        /// <summary>
        /// Generates next ID
        /// </summary>
        /// <returns>next ID</returns>
        private int GetId()
        {
            return lastId++;
        }
        
        public bool SearchForClick(int x,int y,bool conntrue)
        {
            foreach (IElement i in elements)
            {
                if (!(i is Connection))
                {
                    if (x > i.x - 70 && x < i.x + 70 && y > i.y - 50 && y < y + 50)
                    {
                        if (firstSelectedId==null)
                        { firstSelectedId = i; }
                        else if(firstSelectedId!=null && secondSelectedId !=null)
                        { firstSelectedId = i;
                        secondSelectedId = null;
                        }
                        else if (firstSelectedId != null)
                        { secondSelectedId = i; }
                        break;
                    }
                }
                
                
            }
            if (conntrue == true && secondSelectedId != null)
            {
                AddConnection(conntrue);
                return true;
            }
            return false;
            
        }
        public void ClearSelecter()
        {
            firstSelectedId = null;
            secondSelectedId = null;
        }
        public void Draw(Graphics e)
        {
            foreach(IElement i in elements)
            {
                i.Drawing(e);
            }
        }
        public void DrawLast(Graphics e)
        {
            if(elements.Count!=0)
            elements[elements.Count-1].Drawing(e);
        }
        public Boolean AddConnection(bool conntrue)
        {
                IElement newconnection;
                newconnection = new Connection(GetId(), firstSelectedId.id, secondSelectedId.id, firstSelectedId.x - 5, firstSelectedId.y, secondSelectedId.x, secondSelectedId.y - 5);
                elements.Add(newconnection);
                return true;
           
        }
        public Boolean AddElement(TypeOfElement newelement,int mousex,int mousey)
        {
            if (newelement == TypeOfElement.SOURCE)
            {
                Source newsource = new Source(GetId(), mousex, mousey);
                elements.Add(newsource);
                return true;
            }
            else if (newelement == TypeOfElement.ANDGATE)
            {
                AND newand = new AND(GetId(), mousex, mousey);
                elements.Add(newand);
                return true;
            }
            else if(newelement==TypeOfElement.NOTGATE)
            {
                NOT newnot = new NOT(GetId(), mousex, mousey);
                elements.Add(newnot);
                return true;
            }
            else if(newelement==TypeOfElement.ORGATE)
            {
                OR newor = new OR(GetId(), mousex, mousey);
                elements.Add(newor);
                return true; 
            }
            else if(newelement==TypeOfElement.SINK)
            {
                Sink newsink = new Sink(GetId(), mousex, mousey);
                elements.Add(newsink);
                return true; 
            }
            return false;
        }
        //Added 2 more parameters for coordinates
        //Not sure if we'll need them
        public Boolean MoveElement(int id, int x, int y)
        {
            IElement searchelement;
            searchelement=elements.Find(search=> search.id==id);
            searchelement.MoveElement(x, y);
            return true;
        }
        //Added parameter
        public Boolean RemoveConnection(int id)
        {
            elements.Remove(elements.Find(x => x.id == id));
            return true;
        }
        public Boolean RemoveElement(int id)
        {
            elements.Remove(elements.Find(x=>x.id==id));
            return true;
        }
        //Not sure if we'll need the last 2
        public int Calculate()
        {
            return -1;
        }
        void AssignColor()
        {

        }
        public void UpdateUndoRedo()
        {
            undo_redo.Update(elements);
        }
    }
}
