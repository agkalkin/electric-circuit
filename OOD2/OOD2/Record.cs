using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Record
    {
        List<IElement> oldElements = new List<IElement>();
        List<IElement> easyredo;//always saves the last list after changes by undo have been made

        public Boolean Update(List<IElement> currentlist)
        {
            oldElements = currentlist;
            return true;
            
        }
        public List<IElement> UndoAdd(List<IElement>currentlist)
        {

                easyredo = currentlist;
                currentlist.RemoveAt(currentlist.Count-1);
                return currentlist;
            
        }
        public List<IElement>UndoMove(List<IElement>currentlist,int id)
        {
            easyredo = currentlist;
            currentlist[id].MoveElement(currentlist[id].oldX, currentlist[id].oldY);
            return currentlist;

        }
        public List<IElement>UndoRemove(List<IElement>currentlist)
        {
            easyredo = currentlist;
                return oldElements;
        }
        public List<IElement> Redo()
        {
            return easyredo;
        }
    }
}
