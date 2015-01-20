using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Record
    {
        List<IElement> oldElements = new List<IElement>(); // list of saved elements before the change
        List<IElement> easyredo;//always saves the last list after changes by undo have been made
        //method to update the 
        public Boolean Update(List<IElement> currentlist)
        {
            oldElements = currentlist;
            return true;
            
        }
        //method for undoing and add element action
        public List<IElement> UndoAdd(List<IElement>currentlist)
        {

                easyredo = currentlist;
                currentlist.RemoveAt(currentlist.Count-1);
                return currentlist;
            
        }
        //method for undoing an move action
        public List<IElement>UndoMove(List<IElement>currentlist,int id)
        {
            easyredo = currentlist;
            currentlist[id].MoveElement(currentlist[id].oldX, currentlist[id].oldY);
            return currentlist;
        }
        //method for undoing a remove action
        public List<IElement>UndoRemove(IElement removedelement)
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
