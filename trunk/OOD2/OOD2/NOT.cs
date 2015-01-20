using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    [Serializable]
    class NOT : Gate
    {
        public NOT(int id, int x, int y) : base(id, x, y) 
        {
            this.x = x; //current coordinates
            this.y = y;
            this.id = id; // id for the element on the grid
            this.maxInput = 1; // max no of inputs
            this.maxOutput = 1; //max no of outputs
            this.input = 0; //current input
            this.output = 0; //current output
        }

        private int InputValue;

        /// <summary>
        /// Generates output by reversing input (1 to 0 and vice versa)
        /// </summary>
        /// <param name="input"> 1 or 0</param>
        /// <returns></returns>
        public override int Output()
        {
            int output = -1;
            if (InputValue == 0)
                output = 1;
            else if (InputValue == 1)
                output = 0;
            return output;
        }

        public override Boolean SetInput(int value)
        {
            if ((value == 1 || value == 0) && (input < maxInput))
            {
                InputValue = value;
                return true;
            } 
            else
                return false;
        }

        public override Boolean MoveElement(int x, int y)
        {
            this.oldX = this.x;
            this.oldY = this.y;
            this.x = x;
            this.y = y;
            return true;
        }

        

        /// <summary>
        /// Max number of inputs
        /// </summary>
        public override int maxInput { get; protected set; }

        /// <summary>
        /// Max number of outputs
        /// </summary>
        public override int maxOutput { get; protected set; }
            public override bool Drawing(System.Drawing.Graphics gr)
        {
            gr.DrawImage(OOD2.Properties.Resources.NOT, x, y);
            return true;
        }
    }
}
