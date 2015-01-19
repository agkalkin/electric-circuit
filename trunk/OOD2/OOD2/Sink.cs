using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    [Serializable]
    class Sink:Logic
    {
        public override int logicValue { get; protected set; }

        public Sink(int id, int x, int y)
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
        /// Sets logic value to the sink
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
        /// Returns logic value of the sink
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
    }
}
