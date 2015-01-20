using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{

        [Serializable]
    abstract class Gate: IElement
    {
      
        public Gate(int id,int x, int y) { }
        /// <summary>
        /// Takes two inputs and generates output
        /// </summary>
        /// <returns> 0 or 1 (TRUE or FALSE)</returns>
        public virtual int Output()
        {
            int output = -1;

            return output;
        }

        public virtual Boolean SetInput(int value, int id)
        {
                return false;
        }
        public virtual Boolean SetInput(int value)
        {
            return false;
        }

        public virtual bool Drawing(System.Drawing.Graphics gr)
        { 
            return true; 
        }

        public virtual Boolean MoveElement(int x, int y)
        {
            oldX = this.x;
            oldY = this.y;
            this.x = x;
            this.y = y;
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
