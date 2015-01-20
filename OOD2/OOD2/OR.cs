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
        private KeyValuePair<int, int>[] InputValues;

        public OR(int id,int x, int y) : base(id, x, y) 
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.maxInput = 2;
            this.maxOutput = 1;
            this.input = 0;
            this.output = 0;
            this.InputValues = new KeyValuePair<int, int>[maxInput];
        }
        public override bool Drawing(System.Drawing.Graphics gr)
        {
            gr.DrawImage(OOD2.Properties.Resources.OR, x, y);
            return true;
        }

        /// <summary>
        /// Generates output
        /// </summary>
        /// <returns></returns>
        public override int Output()
        {
            int output = -1;
            if (InputValues[0].Value != InputValues[1].Value)
                output = 1;
            else if (InputValues[0].Value == 1 && InputValues[1].Value == 1)
                output = 1;
            else if (InputValues[0].Value == 0 && InputValues[1].Value == 1)
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

        public override Boolean SetInput(int value, int sourceId)
        {
            if ((value == 1 || value == 0))
            {
                if (input < maxInput)
                {
                    InputValues[input] = new KeyValuePair<int, int>(sourceId, value);
                    input++;
                }
                else if (input == maxInput)
                    for (int i = 0; i < maxInput; i++)
                    {
                        if (InputValues[i].Key == id)
                            InputValues[i] = new KeyValuePair<int, int>(sourceId, value);
                    }
                return true;
            }
            else
                return false;
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
