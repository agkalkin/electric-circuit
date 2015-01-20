using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        bool allowmove;//if the button toggle move is pressed it allows the movement of elements around the grid.
        int removeconnection;// remebers the id of the connection pressed to be removed;
        ColorChange colorChanger;
        Color zero = Color.Red; //default color for logical value 0
        Color one = Color.Green; //default color for logical value 1
        Color unkw = Color.Gray; //default color for uknown state

        public Form1()
        {
            InitializeComponent();
            thecircuit = new Circuit();
            NewElement = TypeOfElement.NONE;
            moveid = 0;
            removeid = 0;
            connvalue = false;
            allowmove = false;
                        
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
            //saving image from screen
            FileHandler fh = new FileHandler();
            bool x = fh.SavePng(this.Location.X, this.Location.Y);
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
                {
                    thecircuit.RefreshConnections(id);
                    DrawArea.Refresh();
                }
            }
        }
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)// remembers the id of the selected.
        {
            moveid=thecircuit.FindElement(e.X, e.Y);
            removeid = thecircuit.FindElement(e.X, e.Y);
            removeconnection = thecircuit.FindConnection(e.X, e.Y);
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)//moves the element with the selected id if the move is toggled on
        {
            if (allowmove==true)
            {
                thecircuit.MoveElement(moveid, e.X, e.Y);
                DrawArea.Refresh();
                lastchange = TypeOfChange.MOVE;
            }
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {

        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            if (removeconnection != 0)
            { thecircuit.RemoveElement(removeconnection); }
            else
            { thecircuit.RemoveElement(removeid); }
                lastchange = TypeOfChange.REMOVE;
                DrawArea.Refresh();
            
        }

        private void DrawArea_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (allowmove == true)
            {
                allowmove = false; button11.Text = "Toggle Move ON";

            }
            else { allowmove = true; button11.Text = "Toggle Move OFF"; }


        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorChanger = new ColorChange();
            colorChanger.ShowDialog();
            zero = colorChanger.zeroColor;
            one = colorChanger.oneColor;
            unkw = colorChanger.unkwColor;
            thecircuit.AssignColor(zero, one, unkw);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //loading from file to grid
            FileHandler fh = new FileHandler();
            if (thecircuit.Elements.Count == 0)
            {
                thecircuit.Elements = fh.OpenFile();
                DrawArea.Refresh();
            }
            else
            {
                DialogResult result = MessageBox.Show("Would you like to save your changes", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
                if (result == DialogResult.Yes)
                {
                    fh.SaveToFile(thecircuit.Elements);
                    thecircuit.Elements = fh.OpenFile();
                    DrawArea.Refresh();
                }
                else if (result == DialogResult.Cancel)
                {
                    
                }
                else
                {                    
                    thecircuit.Elements = fh.OpenFile();
                    DrawArea.Refresh();
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saving from grid to file.
            FileHandler fh = new FileHandler();
            fh.SaveToFile(thecircuit.Elements);
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opening the manual
            try
            {
                Process.Start(@"..\..\OOD2_User_Manual_Group_D.docx"); 
            }
            catch (Exception ex)
            {
                Logger.logwriter(ex.Message, ex.StackTrace);
            }
            
        }

    }
}
