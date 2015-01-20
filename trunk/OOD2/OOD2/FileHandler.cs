using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing.Imaging;


namespace OOD2
{
    class FileHandler
    {

        //File path including name and extension
        //string fileLocation;

        Boolean OpenPng()
        {
            return true;
        }
        //Saves an image of the grid with the elements as a .png file
        public Boolean SavePng(int formLocX, int formLocY)
        {
            try
            {
                int x = 228; //X of grid
                int y = 31; //Y of grid
                int width = 620; //Width of image
                int height = 460; //Height of image

                Bitmap image = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(image);

                x = x + formLocX; //formLocX is the location of X of the form in the screen
                y = y + formLocY + 24;//formLocX is the location of Y of the form in the screen, 24 is the height of the menu
                //copying the screen from the form
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height), CopyPixelOperation.SourceCopy);
                //saving the screen as png
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "png";
                dlg.Filter = "Png Files|*.png";
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                    image.Save(dlg.FileName, ImageFormat.Png);
                return true;

            }
            catch(Exception ex)
            {
                Logger.logwriter(ex.Message, ex.StackTrace); //writing error message details to file.
                return false;
            }
            
        }

        /// <summary>
        /// Opens editable file
        /// </summary>
        /// <returns>List of elements on circuit</returns>
        public List<IElement> OpenFile()
        {
            List<IElement> list = new List<IElement>(); //list of elements to be written from file.
            //opening the binary file and and filling up the list
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                try
                {
                    fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    bf = new BinaryFormatter();
                    list = (List<IElement>)(bf.Deserialize(fs));

                }
                catch (IOException)
                {
                    MessageBox.Show("Input error");
                }
                finally
                {
                    if (fs != null)
                    { 
                        fs.Close(); 
                    }
                }
                MessageBox.Show("Loading complete!");
            }
            return list;
        }

        /// <summary>
        /// Saves to editable file
        /// </summary>
        /// <param name="elements">List of elements on circuit</param>
        /// <returns>True if successful</returns>
        public Boolean SaveToFile(List<IElement> elements)
        {
            //Saving the elements as a binary file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Binary files Files (*.bin*)|*.bin";
            sfd.DefaultExt = "bin";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream saveCrt = null;
                BinaryFormatter bf = null;

                try
                {
                    saveCrt = new FileStream(sfd.FileName, FileMode.CreateNew, FileAccess.Write);
                    bf = new BinaryFormatter();
                    bf.Serialize(saveCrt, elements);
                }
                catch (Exception ex)
                {
                    Logger.logwriter(ex.Message, ex.StackTrace);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (saveCrt != null)
                    {
                        saveCrt.Close();
                    }
                }
            }
            return true;
        }
    }
}
