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

        public Boolean SavePng()
        {
            try
            {

                Bitmap image = new Bitmap(622, 472,
                       System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(image);
                g.CopyFromScreen(218, 41, 218, 41,
                         new System.Drawing.Size(622, 472),
                         CopyPixelOperation.SourceCopy);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "png";
                dlg.Filter = "Png Files|*.png";
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                    image.Save(dlg.FileName, ImageFormat.Png);
                return true;
                //try
                //{
                //    Rectangle s_rect = window.Bounds;
                //    using (Bitmap bmp = new Bitmap(s_rect.Width, s_rect.Height))
                //    {
                //        using (Graphics gScreen = Graphics.FromImage(bmp))
                //            gScreen.CopyFromScreen(s_rect.Location, Point.Empty, s_rect.Size);
                //        bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                //    }
                //}
                //catch (Exception ex) { Logger.logwriter(ex.Message, ex.StackTrace); }
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
        List<IElement> OpenFile()
        {
            List<IElement> list = new List<IElement>();
            return list;
        }

        /// <summary>
        /// Saves to editable file
        /// </summary>
        /// <param name="elements">List of elements on circuit</param>
        /// <returns>True if successful</returns>
        Boolean SaveToFile(List<IElement> elements)
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
