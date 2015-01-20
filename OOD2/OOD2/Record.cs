using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Record
    {
        List<IElement> oldElements = new List<IElement>();//the list of elements before the undo method
        List<IElement> easyredo;//always saves the last list after changes by undo have been made

        public Boolean Update(List<IElement> currentlist)//updates the list
        {
            oldElements = currentlist;
            return true;
            
        }
        public List<IElement> UndoAdd(List<IElement>currentlist)// removes the last added element, and saves the list before.
        {

                easyredo = currentlist;
                currentlist.RemoveAt(currentlist.Count-1);
                return currentlist;
            
        }
        public List<IElement>UndoMove(List<IElement>currentlist,int id)// saves the old values and then moves it back to his old position
        {
            easyredo = currentlist;
            currentlist[id].MoveElement(currentlist[id].oldX, currentlist[id].oldY);
            return currentlist;

        }
        public List<IElement>UndoRemove(IElement removedelement)// Remvoves an element and remembers it in the old list for the redo
        {
            if (removedelement != null)
            {
                easyredo = oldElements;
                oldElements.Add(removedelement);
                
            }
            return oldElements;
        }
        //method for redoing
        public List<IElement> Redo()
        {
            return easyredo;
        }
    }
}
