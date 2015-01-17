using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Source:Logic
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ID { get; private set; }
        public Source(int id, int x, int y)
            : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.ID = id;
        }

        public override Boolean MoveElement(int x, int y)
        {
            this.X = x;
            this.Y = y;
            return true;
        }
    }
}
