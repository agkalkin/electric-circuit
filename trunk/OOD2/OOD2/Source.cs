using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    [Serializable]
    class Source:Logic
    {
        public override int logicValue { get; protected set; }

        public Source(int id, int x, int y)
            : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.maxInput = 0;
            this.maxOutput = 1;
            this.logicValue = 0;
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
            if ((value == 1 || value == 0))
            {
                logicValue = value;
                return true;
            }
            else
                return false;
        }

        public override int Output()
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

        public override bool Drawing(System.Drawing.Graphics gr)
        {
            if (logicValue == 0)
                gr.DrawImage(OOD2.Properties.Resources.source2, x, y);
            else if (logicValue == 1)
                gr.DrawImage(OOD2.Properties.Resources.source_positive, x, y);
            return true;
        }
    }
}
