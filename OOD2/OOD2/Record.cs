﻿using System;
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

        Boolean Undo()
        {

            return true;
        }
        Boolean Redo()
        {
            return true;
        }
    }
}