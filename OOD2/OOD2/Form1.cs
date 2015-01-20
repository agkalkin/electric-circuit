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
        TypeOfChange lastchange;//saves the last action type the user done.
        bool connvalue;// Set the connection creation as true after you press the connection button
        int moveid;//remember the ID of the element which is about to be moved;
        int removeid;//rembember the ID of the element to be removed;
        public Form1()
        {
            InitializeComponent();
            thecircuit = new Circuit();
            NewElement = TypeOfElement.NONE;
            moveid = 0;
            removeid = 0;
            connvalue = false;
                        
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
            connvalue = false;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            thecircuit.Undo(lastchange);
            DrawArea.Refresh();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            thecircuit.Redo();
            DrawArea.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.NOTGATE;
            connvalue = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.ORGATE;
            connvalue = false;
            
        }

        private void button7_Click(object sender, EventArgs e)

        {
            NewElement = TypeOfElement.SINK;
            
            connvalue = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.SOURCE;
            connvalue = false;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NewElement = TypeOfElement.CONNECTION;
            connvalue = true;
            thecircuit.ClearSelecter();
        }


        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            thecircuit.Draw(e.Graphics);        
         }

        private void DrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (thecircuit.SearchForClick(e.X,e.Y, connvalue))// if it returns true it creates a connection between the two previosly selected elements
            { DrawArea.Refresh(); connvalue = false; }

           if(NewElement!=TypeOfElement.NONE && NewElement!=TypeOfElement.CONNECTION)//it creates an element, adds it to the list, and draws it on the form.
            {  
                    thecircuit.AddElement(NewElement, e.X, e.Y);
                    NewElement = TypeOfElement.NONE;
                    thecircuit.UpdateUndoRedo();
                    lastchange = TypeOfChange.ADD;
                    DrawArea.Refresh();               
            }
                        
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler fh = new FileHandler();
            int offsetX = this.Size.Width - this.DisplayRectangle.Width;
            int offsetY = this.Size.Height - this.DisplayRectangle.Height;

            int gridX = DrawArea.Location.X;
            int gridY = DrawArea.Location.Y;

            bool x = fh.SavePng(this.Location.X, this.Location.Y, gridX, gridY);
            if (x == true)
            {
                MessageBox.Show("Image saved.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        private void DrawArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = -1;
            int value = -1;
            id = thecircuit.GetSelectedId(e.X, e.Y, connvalue);
            if (id > 0)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                PickValue dialog = new PickValue(x, y);
                if (dialog.ShowDialog() == DialogResult.OK)
                    value = dialog.Output();
                if (thecircuit.ChangeLogicValue(id, value))
                    DrawArea.Refresh();
            }
        }
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            moveid=thecircuit.FindElement(e.X, e.Y);
            
            removeid = thecircuit.FindElement(e.X, e.Y);
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            //if(thecircuit.MoveElement(moveid, e.X, e.Y))
            //{DrawArea.Refresh();
            //lastchange = TypeOfChange.MOVE;
            //}
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {

        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            thecircuit.RemoveElement(removeid);
            DrawArea.Refresh();
        }

        private void DrawArea_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

    }
}
