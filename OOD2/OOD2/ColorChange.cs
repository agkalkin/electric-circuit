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
    public partial class ColorChange : Form
    {
        public Color zeroColor;
        public Color oneColor;
        public Color unkwColor;

        public ColorChange()
        {
            InitializeComponent();
        }

        private void ColorChange_Load(object sender, EventArgs e)
        {

            foreach (System.Reflection.PropertyInfo c in typeof(Color).GetProperties())
            {
                if (c.PropertyType.FullName == "System.Drawing.Color")
                {
                    zeroCb.Items.Add(c.Name);
                    oneCb.Items.Add(c.Name);
                    unkwCb.Items.Add(c.Name);
                }
                zeroCb.SelectedIndex = zeroCb.FindStringExact("Red");
                oneCb.SelectedIndex = oneCb.FindStringExact("Green");
                unkwCb.SelectedIndex = unkwCb.FindStringExact("Gray");
            }
        }

        private void zeroCb_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillRectangle(GetCurrentBrush(zeroCb.Items[e.Index].ToString()), e.Bounds);
            Font f = zeroCb.Font;
            e.Graphics.DrawString(zeroCb.Items[e.Index].ToString(), f, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void oneCb_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillRectangle(GetCurrentBrush(oneCb.Items[e.Index].ToString()), e.Bounds);
            Font f = oneCb.Font;
            e.Graphics.DrawString(oneCb.Items[e.Index].ToString(), f, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void unkwCb_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillRectangle(GetCurrentBrush(unkwCb.Items[e.Index].ToString()), e.Bounds);
            Font f = unkwCb.Font;
            e.Graphics.DrawString(unkwCb.Items[e.Index].ToString(), f, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        private Brush GetCurrentBrush(string colorName)
        {
            return new SolidBrush(Color.FromName(colorName));
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if ((zeroCb.SelectedItem.ToString()) == (oneCb.SelectedItem.ToString()) || (zeroCb.SelectedItem.ToString()) == (unkwCb.SelectedItem.ToString()) || (oneCb.SelectedItem.ToString()) == (unkwCb.SelectedItem.ToString()))
            {
                MessageBox.Show("The colors must be different for all three options");
            }
            else
            {
                
                zeroColor = Color.FromName(zeroCb.SelectedItem.ToString());
                oneColor = Color.FromName(oneCb.SelectedItem.ToString());
                unkwColor = Color.FromName(unkwCb.SelectedItem.ToString());
                this.Close();

            }
        }
    }
}
