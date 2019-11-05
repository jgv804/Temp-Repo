using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Entrega3
{
    public partial class AddFilter : Form
    {
        public static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        private PictureBox selectedPicture;
        public static int x = 1;
        public  AddFilter()
        {
            InitializeComponent();
        }

        private void AddFilter_Load(object sender, EventArgs e)
        {
            int counterX = 0;
            int counterY = 0;
            foreach (string dir in diro)
            {
                PictureBox Temp = new PictureBox();
                Temp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Temp.ImageLocation = dir;
                Temp.Location = new Point(counterX, counterY);
                Temp.Name = Path.GetFileName(dir);
                Temp.Size = new System.Drawing.Size(126, 81);
                Temp.TabIndex = 0;
                Temp.TabStop = false;
                Temp.SizeMode = PictureBoxSizeMode.StretchImage;
                Temp.DoubleClick += new EventHandler(picture_click);
                counterX += 128;
                if (counterX > 512)
                {
                    counterY += 83;
                    counterX = 0;
                }
                this.flowLayoutPanel1.Controls.Add(Temp);
            }
        }

        void picture_click(object sender, EventArgs e)
        {
            if (selectedPicture != null)
                selectedPicture.BorderStyle = BorderStyle.None;
            selectedPicture = (PictureBox)sender;
            selectedPicture.BorderStyle = BorderStyle.FixedSingle;
            panel1.Visible = true;
            pictureBox1.Image = selectedPicture.Image;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            panel2.Visible = true;
            label4.Visible = true;
            textBox1.Text = selectedPicture.Name;
        }

        //Agregar filtros

        public Bitmap GetArgbCopy(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);


            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }


            return bmpNew;
        }

        // Agrega a nueva copia la matriz de color
        private Bitmap ApplyColorMatrix(Image imag, ColorMatrix colorMatrix)
        {
            Bitmap bmp32BppSource = GetArgbCopy(imag);
            Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, PixelFormat.Format32bppArgb);


            using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width, bmp32BppSource.Height),
                                    0, 0, bmp32BppSource.Width, bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);


            }

            bmp32BppSource.Dispose();
            return bmp32BppDest;
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
           {
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0},
                new float[]{0, 0, 1, 0, 0},
                new float[]{0, 0, 0, 0.3f, 0},
                new float[]{0, 0, 0, 0, 1}
           });
            Bitmap bitmap = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            Image temp = bitmap;
            pictureBox2.Image = temp;
            button6.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
           {
                    new float[]{.3f, .3f, .3f, 0, 0},
                    new float[]{.59f, .59f, .59f, 0, 0},
                    new float[]{.11f, .11f, .11f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
           });
            Bitmap bitmap = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            Image temp = bitmap;
            pictureBox2.Image = temp;
            button6.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
           {
                   new float[] {.393f, .349f, .272f, 0, 0},
                   new float[] {.769f, .686f, .534f, 0, 0},
                   new float[] {.189f, .168f, .131f, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {0, 0, 0, 0, 1}
           });
            Bitmap bitmap = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            Image temp = bitmap;
            pictureBox2.Image = temp;
            button6.Visible = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 1, 1}
            });
            Bitmap bitmap = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            Image temp = bitmap;
            pictureBox2.Image = temp;
            button6.Visible = true;
        }

        //Volver a Main
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
            
            Image finalImage = pictureBox2.Image;
            string t = textBox1.Text;
            finalImage.Save(dir + @"\" + Path.GetFileNameWithoutExtension(t) + "-Filteredition" + x.ToString() + Path.GetExtension(t));
            Imagen p = new Imagen();
            label5.Visible = true;
            label5.Text = "Image saved successfully";
            IFormatter formatter = new BinaryFormatter();
            p.Nombre = Path.GetFileNameWithoutExtension(t) + "-Filteredition" + x.ToString() + Path.GetExtension(t);
            p.Direccionmemoria = dir + @"\" + Path.GetFileNameWithoutExtension(t) + "-Filteredition" + x.ToString() + Path.GetExtension(t);
            string paths = pathi + @"\" + Path.GetFileNameWithoutExtension(t) + "-Filteredition" + x.ToString()  + ".bin";
            Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();
            x += 1;

        }
    }
}
