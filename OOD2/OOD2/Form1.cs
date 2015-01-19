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
        TypeOfChange lastchange;
        IElement addedelement;
        public Form1()
        {
            InitializeComponent();
            thecircuit = new Circuit();
            NewElement = TypeOfElement.NONE;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

                        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            NewElement=TypeOfElement.ANDGATE;
            
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            thecircuit.Undo(lastchange);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            thecircuit.Redo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.NOTGATE;
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.ORGATE;
            
            
        }

        private void button7_Click(object sender, EventArgs e)

        {
            NewElement = TypeOfElement.SINK;
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.SOURCE;

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.CONNECTION;

      

        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            int[,] matrix = new int[40, 30];
            int height = 0;
            int width = 0;
            int size = 15;
            Graphics gr = e.Graphics;
            for (int i = 1; i <= 40; i++)
            {
                height = height + size;
                width = 0;
                for (int j = 1; j <= 30; j++)
                {
                    gr.DrawRectangle(Pens.Black, height, width, size, size);
                    width = width + size;
                }
            } 
        }

        private void DrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            if(NewElement!=TypeOfElement.NONE)
            {
                thecircuit.AddElement(NewElement,e.X,e.Y);
                    NewElement = TypeOfElement.NONE;
                    thecircuit.UpdateUndoRedo();
                    lastchange = TypeOfChange.ADD;
            }
                    
         
        }
    }
}
