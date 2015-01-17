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
    public partial class Form1 : Form
    {
        TypeOfElement NewElement;
        Circuit thecircuit;
        int idcounter;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

            int[,] matrix = new int[40, 30];
            int height = 220;
            int width = 58;
            int size = 15;
            Graphics gr = e.Graphics;
            for (int i = 1; i <= 40; i++)
            {
                height = height + size;
                width = 50;
                for (int j = 1; j <= 30; j++)
                {
                    gr.DrawRectangle(Pens.Black, height, width,size,size);
                    width = width + size;
                }
            } 
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
