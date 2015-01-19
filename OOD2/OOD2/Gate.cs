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

        public abstract bool Drawing();

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
