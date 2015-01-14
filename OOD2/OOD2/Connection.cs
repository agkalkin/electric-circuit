using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    class Connection:Logic
    {
        //IDs of elements that are connected to the front and back
        int endID;
        int frontID;

        public Connection(int frontID, int endID)
            : base(frontID, endID)
        {
            this.frontID = frontID;
            this.endID = endID;
        }
    }
}
