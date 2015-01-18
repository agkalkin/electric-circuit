using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Record
    {
        List<TypeOfChange> changes;
        List<IElement> oldElements;
        List<IElement> easyredo;

        public Boolean Update(List<IElement> currentlist)
        {
            oldElements = currentlist;
            return true;
        }
        public List<IElement> Undo(TypeOfChange currentchange, List<IElement>currentlist)
        {

            if (currentchange == TypeOfChange.ADD)
            {
                easyredo = currentlist;
                currentlist.RemoveAt(currentlist.Count);
                return currentlist;
            }
            else if (currentchange == TypeOfChange.MOVE)
            {
                easyredo = currentlist;
                currentlist[currentlist.Count].MoveElement(currentlist[currentlist.Count].oldX, currentlist[currentlist.Count].oldY);
                return currentlist;
            }
            else if (currentchange == TypeOfChange.REMOVE)
            {
                easyredo = currentlist;
                return oldElements;
            }
            return null;
        }
        public List<IElement> Redo()
        {
            return easyredo;
        }
    }
}
