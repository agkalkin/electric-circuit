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
        public Logic(int x, int y) { }
        public virtual Boolean MoveElement(int x, int y)
        {
            return true;
        }
        public virtual bool Drawing(System.Drawing.Graphics gr)
        { return true; }
        public virtual bool Drawing()
        {
            return true;
        }

        public virtual int id { get; protected set; }

        /// <summary>
        /// Number of inputs
        /// </summary>
        public virtual int input { get; protected set; }

        /// <summary>
        /// Number of outputs
        /// </summary>
        public virtual int output { get; protected set; }

        public virtual int maxInput { get; protected set; }

        public virtual int maxOutput { get; protected set; }

        public virtual int oldX { get; protected set; }

        public virtual int oldY { get; protected set; }

        public virtual int x { get; protected set; }

        public virtual int y { get; protected set; }

        public virtual int logicValue { get; protected set; }
    }
}
