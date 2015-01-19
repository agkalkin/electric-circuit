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
        Pen color;

        public Circuit()
        {
            undo_redo = new Record();
            elements=new List<IElement>();
            cTrue = Color.Green;
            cFalse = Color.Red;
            cUnknown = Color.Black;
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
        {//when you press click on an element on the form it saves it. Does this two times and if its valid, creates connection between those elements
            foreach (IElement i in elements)
            {
                if (!(i is Connection))
                {
                    if (i.x<x && x<i.x+70 && i.y+50>y && y>i.y)
                    {
                        if (firstSelectedId==null)
                        { firstSelectedId = i; break; }
                        else if(firstSelectedId!=null && secondSelectedId !=null)
                        { firstSelectedId = i;
                        secondSelectedId = null;
                        break;
                        }
                        else if (firstSelectedId != null)
                        { secondSelectedId = i; break; }
                        else if(firstSelectedId==secondSelectedId)
                        {
                            ClearSelecter();
                            break;
                        }
                        
                    }
                    
                }
                
                
            }
            if (conntrue == true && secondSelectedId != null)//if there is a second selected element and the connection button was pressed adds a connection
            {
                AddConnection(conntrue);
                ClearSelecter();
                return true;
            }
            return false;
            
        }
        public void ClearSelecter() // it clears the first selected element and the second selected element
        {
            firstSelectedId = null;
            secondSelectedId = null;
        }
        public void Draw(Graphics e)//draws all the elements in the list of elements
        {
            foreach(IElement i in elements)
            {
                i.Drawing(e);
            }
        }
        public void DrawLast(Graphics e) // draws the last element in the element list
        {
            if(elements.Count!=0)
            elements[elements.Count-1].Drawing(e);
        }
        
        public Boolean AddConnection(bool conntrue)//adds a connection
        {
                
                IElement newconnection;
                newconnection = new Connection(GetId(), firstSelectedId.id, secondSelectedId.id, firstSelectedId.x, firstSelectedId.y, secondSelectedId.x, secondSelectedId.y);
                elements.Add(newconnection);
                return true;
           
        }
        public Boolean AddElement(TypeOfElement newelement,int mousex,int mousey)//it creates an element based on the new element desired by the user
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
        public void AssignColor(Color conntrue,Color connfalse, Color connunknown) // assigns the custom colors to the default ones
        {
            cTrue = conntrue;
            cFalse = connfalse;
            connunknown = connfalse;
        }
        public void UpdateUndoRedo() // updates the undo redo element list.
        {
            undo_redo.Update(elements);
        }
    }
}
