using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    [Serializable]
    class OR : Gate
    {
        public OR(int id,int x, int y) : base(id, x, y) 
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.maxInput = 2;
            this.maxOutput = 1;
        }
        public override bool Drawing(System.Drawing.Graphics gr)
        {
            gr.DrawImage(OOD2.Properties.Resources.OR, x, y);
            return true;
        }

        /// <summary>
        /// Generates output
        /// </summary>
        /// <param name="input"> 1 or 0</param>
        /// <returns></returns>
        public override int Output(int input1, int input2)
        {
            int output = -1;
            if (input1 != input2)
                output = 1;
            else if (input1 == 0 && input2 == 0)
                output = 0;
            return output;
        }

        public override Boolean MoveElement(int x, int y)
        {
            this.oldX = this.x;
            this.oldY = this.y;
            this.x = x;
            this.y = y;
            return true;
        }

        public override bool Drawing()
        {
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

    }
}
