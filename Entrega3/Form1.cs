using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;

namespace Entrega3
{
    public partial class Form1 : Form
    {

        public static int counterX = 0;
        public static int counterY = 0;
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        //public static string[] biro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects");//
        public Form1()
        {
            InitializeComponent();
            GoFullscreen(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PictureBox o = pictureBox1;//

            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString() ;//
            /*string path2 = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + @"\Docs\tres.png";
            //MessageBox.Show(path2);//
            o.ImageLocation = path2;
            o.SizeMode = PictureBoxSizeMode.StretchImage;
            */
            //int counterX = 0;//
            //int counterY = 0;//
            string[] biro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects");
            string[] di = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
            string da = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
            foreach (string pir in di)
            {
                if (biro.Contains(da + @"\" + Path.GetFileNameWithoutExtension(pir) + ".bin") == false)
                {
                    Imagen k = new Imagen();
                    k.Nombre = Path.GetFileName(pir);
                    k.Direccionmemoria = pir;
                    k.Fecha = "10/10/2019";
                    IFormatter formatter2 = new BinaryFormatter();
                    string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
                    string path = pathi + @"\" + Path.GetFileNameWithoutExtension(pir) + ".bin";
                    Stream stream2 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter2.Serialize(stream2, k);
                    stream2.Close();
                }

            }
            //MessageBox.Show("Images have been serialized");//
            string[] biros = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects");
            foreach (string dir in biros)
            {

                

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dir, FileMode.Open, FileAccess.Read, FileShare.Read);
                Imagen Tempo = (Imagen)formatter.Deserialize(stream);
                
                PictureBox Temp = new PictureBox();
                //MessageBox.Show(Tempo.Direccionmemoria);//
                Temp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Temp.ImageLocation = Tempo.Direccionmemoria;
                Temp.Location = new Point(counterX, counterY);
                Temp.Name = Tempo.Nombre;
                Temp.Size = new System.Drawing.Size(126, 81);
                Temp.TabIndex = 0;
                Temp.TabStop = false;
                Temp.SizeMode = PictureBoxSizeMode.StretchImage;
                Temp.MouseHover += new System.EventHandler(this.MouseHoveringPictureBox);
                Temp.MouseLeave += new System.EventHandler(this.MouseLeavingPictureBox);
                counterX += 128;
                if(counterX > 512)
                {
                    counterY += 83;
                    counterX = 0;
                }
                stream.Close();
                this.DirectoryflowLayoutPanel1.Controls.Add(Temp);
                
            }

        }

        public void MouseHoveringPictureBox(object sender,EventArgs e)
        {
            PictureBox m = sender as PictureBox;
            DisplayPanel.Visible = true;
            DisplayBox.ImageLocation = m.ImageLocation;
            DisplayBox.SizeMode = PictureBoxSizeMode.StretchImage;
            
            textBox1.Text +="Name : " + m.Name+ "\r\n";
            textBox1.Text += "Image width : " + m.Image.Width + "\r\n";
            textBox1.Text += "Image height : " + m.Image.Height + "\r\n";
            textBox1.Text += "Image resolution : " + m.Image.VerticalResolution +" x " + m.Image.HorizontalResolution + "\r\n";
            textBox1.Text += "Image Pixel depth : " + Image.GetPixelFormatSize(m.Image.PixelFormat) + "\r\n";
            textBox1.Text += "Tags: ";
            

            

        }
        public void MouseLeavingPictureBox(object sender, EventArgs e)
        {
            textBox1.Text = "";
            DisplayPanel.Visible = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Importer importer = new Importer();
            importer.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddText addText = new AddText();
            addText.ShowDialog();
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddFilter addFilter = new AddFilter();
            addFilter.ShowDialog();
            this.Close();
        }

        private void SerializeTestButton_Click(object sender, EventArgs e)
        {
            foreach (string dir in diro)
            {
                Imagen k = new Imagen();
                k.Nombre = Path.GetFileName(dir);
                k.Direccionmemoria = dir;
                k.Fecha = "10/10/2019";
                IFormatter formatter = new BinaryFormatter();
                string pathi= Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
                string path = pathi + @"\" + Path.GetFileNameWithoutExtension(dir) +".bin";
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, k);
                stream.Close();
                
            }
            MessageBox.Show("Images have been serialized");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CollageMaker collageMaker = new CollageMaker();
            collageMaker.ShowDialog();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FusionMaker fusionMaker = new FusionMaker();
            fusionMaker.ShowDialog();
            this.Close();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            SlideShow slideshow = new SlideShow();
            slideshow.ShowDialog();
            this.Close();
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs\tres.png");
            ImageFormat format = img.RawFormat;
            MessageBox.Show("Image Type : " + format.ToString());
            MessageBox.Show("Image width : " + img.Width);
            MessageBox.Show("Image height : " + img.Height);
            MessageBox.Show("Image resolution : " + (img.VerticalResolution * img.HorizontalResolution));

            MessageBox.Show("Image Pixel depth : " + Image.GetPixelFormatSize(img.PixelFormat));
            /*MessageBox.Show("Image Creation Date : " + creation.ToString("yyyy-MM-dd"));
            MessageBox.Show("Image Creation Time : " + creation.ToString("hh:mm:ss"));
            MessageBox.Show("Image Modification Date : " + modify.ToString("yyyy-MM-dd"));
            MessageBox.Show("Image Modification Time : " + modify.ToString("hh:mm:ss"));*/

        }











        /*private void Button1_Click(object sender, EventArgs e)
{
   PictureBox o = pictureBox1;
   string path = "C:\\Users\\Lenovo\\Documents\\Memo\\tres.png";
   o.ImageLocation = path;
   o.SizeMode = PictureBoxSizeMode.StretchImage;




}*/
    }
}
