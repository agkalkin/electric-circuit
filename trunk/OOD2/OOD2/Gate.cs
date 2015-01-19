using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    abstract class Gate: IElement
    {
        public Gate(int id,int x, int y) { }
        /// <summary>
        /// Takes two inputs and generates output
        /// </summary>
        /// <param name="input1">First input</param>
        /// <param name="input2">Second input</param>
        /// <returns> 0 or 1 (TRUE or FALSE)</returns>
        public virtual int Output(int input1, int input2)
        {
            int output = -1;

            return output;
        }
        public virtual bool Drawing(System.Drawing.Graphics gr)
        { return true; }
        /// <summary>
        /// Takes input and generates output
        /// </summary>
        /// <param name="input">Gate input</param>
        /// <returns>0 or 1 (TRUE or FALSE)</returns>
        public virtual int Output(int input)
        {
            int output = -1;

            return output;
        }

        public abstract Boolean MoveElement(int x, int y);

        public bool Drawing()
        {
            return true;
        }

        public abstract int id
        {
            get;
             set;
        }

        public abstract int input
        {
            get;
             set;
        }

        public abstract int output
        {
            get;
             set;
        }

        public abstract int maxInput
        {
            get;
             set;
        }

        public abstract int maxOutput
        {
            get;
             set;
        }

        public abstract int oldX
        {
            get;
             set;
        }

        public abstract int oldY
        {
            get;
             set;
        }

        public abstract int x
        {
            get;
            set;
        }

        public abstract int y
        {
            get;
            set;
        }
    }
}
