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

        public bool Drawing()
        {
            return true;
        }

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
    }
}
