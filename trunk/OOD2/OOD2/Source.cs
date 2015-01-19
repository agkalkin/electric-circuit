using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Source:Logic
    {
        public override int logicValue { get; protected set; }

        public Source(int id, int x, int y)
            : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }

        public override Boolean MoveElement(int x, int y)
        {
            this.x = x;
            this.y = y;
            return true;
        }

        /// <summary>
        /// Sets logic value to the source
        /// </summary>
        /// <param name="value"> 1 or 0</param>
        /// <returns>returns true if operation is successful</returns>
        public Boolean SetValue(int value)
        {
            if (value == 1 || value == 0)
            {
                logicValue = value;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Returns logic value of the source
        /// </summary>
        /// <returns>logic value (1 or 0)</returns>
        public int GetValue()
        {
            return logicValue;
        }

        /// <summary>
        /// Max number of inputs
        /// </summary>
        public override int maxInput { get; protected set; }

        /// <summary>
        /// Max number of outputs
        /// </summary>
        public override int maxOutput { get; protected set; }

        public override bool Drawing()
        {
            return true;
        }
    }
}
