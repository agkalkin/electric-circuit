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
            this.x = x; //x coordinate on the grid
            this.y = y; //y coordinate on the grid
            this.id = id; // id of the current gate on the grid
            this.maxInput = 1; //maximum number of inputs
            this.maxOutput = 0; //max number of outputs
            this.input = 0; //
            this.output = 0;//
        }
        //method to draw the sink element
        public override bool Drawing(System.Drawing.Graphics gr)
        {
            if (logicValue == 0)
                gr.DrawImage(OOD2.Properties.Resources.sink2, x, y);
            else if(logicValue == 1)
                gr.DrawImage(OOD2.Properties.Resources.sink_positive, x, y);
            return true;
        }
        //method to move the sink element
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
        public override Boolean SetInput(int value)
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
