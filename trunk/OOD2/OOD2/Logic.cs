using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    abstract class Logic: IElement
    {
        //Logic value of the element (0, 1 or "unknown"
        public int logicValue;
        public Logic(int x, int y) { }

        public int id
        {
            get { throw new NotImplementedException(); }
        }

        public int input
        {
            get { throw new NotImplementedException(); }
        }

        public int output
        {
            get { throw new NotImplementedException(); }
        }

        public int maxInput
        {
            get { throw new NotImplementedException(); }
        }

        public int maxOutput
        {
            get { throw new NotImplementedException(); }
        }

        public int oldX
        {
            get { throw new NotImplementedException(); }
        }

        public int oldY
        {
            get { throw new NotImplementedException(); }
        }

        public int x
        {
            get { throw new NotImplementedException(); }
        }

        public int y
        {
            get { throw new NotImplementedException(); }
        }

        public bool Drawing()
        {
            throw new NotImplementedException();
        }
    }
}
