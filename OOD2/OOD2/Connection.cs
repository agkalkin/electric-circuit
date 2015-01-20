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
        public int endID { get; private set; }
        public int frontID { get; private set; }
        int x1;
        int x2;
        int y1;
        int y2;
        static Pen defaultP;
        static Pen positiveP;
        static Pen negativeP;
        public override bool Drawing(System.Drawing.Graphics gr)
        {
            if (this.output == 1)
                gr.DrawLine(positiveP, x1, x2, y1, y2);
            else if (this.output == 0)
                gr.DrawLine(negativeP, x1, x2, y1, y2);
            else
                gr.DrawLine(defaultP, x1, x2, y1, y2);
            return base.Drawing();
        }
        public Connection(int id,int frontID, int endID,int x1,int x2,int y1,int y2)
            : base(frontID, endID)
        {
            defaultP = new Pen(Color.Black, 3); //default color
            positiveP = new Pen(Color.Green, 3);
            negativeP = new Pen(Color.Red, 3);
            this.id = id;
            this.frontID = frontID;
            this.endID = endID;
            this.x1 = x1+70;
            this.x2 = x2+30;
            this.y1 = y1;
            this.y2 = y2+25;

            this.output = -1;
            
            
        }
        public void ChangeColors(Color t, Color f, Color u)//changes the pen color in the draw method for the connection
        {
            defaultP = new Pen(u, 3);
            positiveP = new Pen(t,3);
            negativeP = new Pen(f,3);
        }
        /// <summary>
        /// Sets logic value to a connection
        /// </summary>
        /// <param name="value">1 or 0</param>
        /// <returns></returns>
        public Boolean SetValue(int value)
        {
            if (value == 1 || value == 0)
            {
                output = value;
                return true;
            }
            else
                return false;
        }
        public int GetFrontID()
        {
            return frontID;
        }
        public int GetEndID()
        {
            return endID;
        }
        public void UpdateFrontHead(int x1,int x2)
        {
            this.x1 = x1 + 70;
            this.x2 = x2 + 30;
           
        }
        public void UpdateEndHead(int y1,int y2)
        {
            this.y1 = y1;
            this.y2 = y2 + 25;
        }
        public bool CheckIfPointIsOnConnection(int x,int y)
        {
            if (x1 * y2 + x * x2 + y1 * y - y2 * x - x1 * y - x2 * y1 == 0)
                return true;
            else return false;
        }
    }
}
