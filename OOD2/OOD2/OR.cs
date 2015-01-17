using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class OR : Gate
    {
        public OR(int id,int x, int y) : base(id, x, y) 
        {
            this.x = x;
            this.y = y;
            this.id = id;
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


        public override int id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int input
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int output
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int maxInput
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int maxOutput
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int oldX
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int oldY
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int x
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override int y
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
