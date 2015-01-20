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
        string fileLocation;

        Boolean OpenPng()
        {
            return true;
        }

        public Boolean SavePng(int formLocX, int formLocY, int offX, int offY)
        {
            try
            {
                int x = 228; //X of grid
                int y = 31; //Y of grid
                int width = 620; //Width of image
                int height = 460; //Height of image

                Bitmap image = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(image);

                //g.CopyFromScreen(218, 41, 218, 41, new System.Drawing.Size(622, 472), CopyPixelOperation.SourceCopy);
                x = x + formLocX;
                y = y + formLocY + 24;
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height), CopyPixelOperation.SourceCopy);

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
                Logger.logwriter(ex.Message, ex.StackTrace);
                return false;
            }
            
        }

        /// <summary>
        /// Opens editable file
        /// </summary>
        /// <returns>List of elements on circuit</returns>
        public List<IElement> OpenFile()
        {
            List<IElement> list = new List<IElement>();
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
                    MessageBox.Show("Input/Output error");
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
                MessageBox.Show("Loading done !");
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
