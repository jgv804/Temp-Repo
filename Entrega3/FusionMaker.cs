using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    public partial class FusionMaker : Form
    {
        public static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        private PictureBox selectedPicture;
        PictureBox pieceSelected;
        int counter = 0;
        public static int x = 1;
        public FusionMaker()
        {
            InitializeComponent();
        }

        //Volver a Mail
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
        void picture_click(object sender, EventArgs e)
        {
            if (selectedPicture != null)
                selectedPicture.BorderStyle = BorderStyle.None;
            selectedPicture = (PictureBox)sender;
            selectedPicture.BorderStyle = BorderStyle.FixedSingle;
            pieceSelected.Image = selectedPicture.Image;
        }
        private void displayFlowPanel()
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
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

        //Select Picture 1
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox1;
            counter += 1;
            if (counter >= 2)
            {
                button1.Visible = true;
            }
        }

        //Select Picture 2
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox2;
            counter += 1;
            if (counter >= 2)
            {
                button1.Visible = true;
            }
        }

        //Resize Image
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //Funcion Fusion
        public void MakeFusion(Image Image1, Image Image2)
        {

            Bitmap bmp1 = ResizeImage(Image1, 500, 300);
            Bitmap bmp2 = ResizeImage(Image2, 500, 300);

            Bitmap bmp3 = new Bitmap(500, 300);

            Color p;
            Color p2;

            for (int y = 0; y < 300; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                     p = bmp1.GetPixel(x, y);
                     p2 = bmp2.GetPixel(x, y);

                     int a = p.A;
                     int b = p.B;
                     int r = p.R;
                     int g = p.G;

                     int a2 = p2.A;
                     int b2 = p2.B;
                     int r2 = p2.R;
                     int g2 = p2.G;

                     int avga = (a + a2) / 2;
                     int avgb = (b + b2) / 2;
                     int avgr = (r + r2) / 2;
                     int avgg = (g + g2) / 2;

                     bmp3.SetPixel(x, y, Color.FromArgb(avga, avgb, avgr, avgg));
                }
            }

            Image imgF = bmp3;
            pictureBox3.Image = imgF;
        }

        //Generar Fusion
        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            panel2.Visible = true;
            MakeFusion(pictureBox1.Image, pictureBox2.Image);
            button3.Visible = true;
        }

        //Guardar Fusion
        private void Button3_Click(object sender, EventArgs e)
        {
            Image finalImage = pictureBox3.Image;
            finalImage.Save(dir + @"\" + "FusionResult-" + x.ToString() + ".png");
            IFormatter formatter = new BinaryFormatter();

            Imagen p = new Imagen();

            p.Nombre = "FusionResult-" + x.ToString() + ".png";
            p.Direccionmemoria = dir + @"\" + "FusionResult-" + x.ToString() + ".png";
            string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
            string paths = pathi + @"\" + Path.GetFileNameWithoutExtension("FusionResult-.png") + x.ToString() + ".bin";
            Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();
            label4.Visible = true;
        }
    }
}
