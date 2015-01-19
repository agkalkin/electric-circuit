using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2
{
    [Serializable]
    class Connection:Logic
    {
        //IDs of elements that are connected to the front and back
        int endID;
        int frontID;
        int x1;
        int x2;
        int y1;
        int y2;
        public override bool Drawing(System.Drawing.Graphics gr)
        {
            Pen conn=new Pen(Color.Black,5);
            gr.DrawLine(conn, x1, x2, y1, y2);
            return base.Drawing();
        }
        public Connection(int id,int frontID, int endID,int x1,int x2,int y1,int y2)
            : base(frontID, endID)
        {
            this.id = id;
            this.frontID = frontID;
            this.endID = endID;
            this.x1 = x1+70;
            this.x2 = x2+30;
            this.y1 = y1;
            this.y2 = y2+25;
        }
    }
}
