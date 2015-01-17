using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class NOT : Gate
    {
        public NOT(int id, int x, int y) : base(id, x, y) 
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }

        /// <summary>
        /// Generates output by reversing input (1 to 0 and vice versa)
        /// </summary>
        /// <param name="input"> 1 or 0</param>
        /// <returns></returns>
        public override int Output(int input)
        {
            int output = -1;
            if (input == 0)
                output = 1;
            else if (input == 1)
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

        public override int id
        {
            get;
            set;
        }

        public override int input
        {
            get;
            set;
        }
        public override int output
        {
            get;
            set;
        }

        public override int maxInput
        {
            get;
            set;
        }

        public override int maxOutput
        {
            get;
            set;
        }

        public override int oldX
        {
            get;
            set;
        }

        public override int oldY
        {
            get;
            set;
        }

        public override int x
        {
            get;
            set;
        }

        public override int y
        {
            get;
            set;
        }
    }
}
