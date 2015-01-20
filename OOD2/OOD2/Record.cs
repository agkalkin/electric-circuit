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
        List<IElement> easyredo;//always saves the last list after changes by undo have been made

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
                currentlist.RemoveAt(currentlist.Count-1);
                return currentlist;
            }
            else if (currentchange == TypeOfChange.MOVE)
            {
                easyredo = currentlist;

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
