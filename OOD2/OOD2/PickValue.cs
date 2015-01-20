using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOD2
{
    public partial class PickValue : Form
    {
        private int value;
        //fields to store coordinates
        private int x;
        private int y;

        /// <summary>
        /// Create new form at specific location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PickValue(int x, int y)
        {
            InitializeComponent();
            value = -1;
            this.x = x;
            this.y = y;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = 1;
        }

        public int Output()
        {
            return value;
        }

        private void PickValue_Load(object sender, EventArgs e)
        {
            //this.SetDesktopLocation(this.x, this.y);
            this.Location = new System.Drawing.Point(this.x, this.y);
        }
    }
}
