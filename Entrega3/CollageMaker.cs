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
using Models;

namespace Entrega3
{
    public partial class CollageMaker : Form
    {
        public static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        public static int x=1;
        private PictureBox selectedPicture;
        PictureBox pieceSelected;
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;

        public CollageMaker()
        {
            InitializeComponent();
        }
        
        //Volver a Main
        private void Button3_Click(object sender, EventArgs e)
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
        public void obtainFinalPicture(PictureBox pB1, PictureBox pB2, int resizeLength, int resizeWidth, int posX, int posY, int preview)
        {
            Image img1 = pB1.Image;
            Image img2 = pB2.Image;
            Bitmap img3 = new Bitmap(500, 300);

            Bitmap resizedImg1 = ResizeImage(img1, resizeLength, resizeWidth);
            Bitmap resizedImg2 = ResizeImage(img2, resizeLength, resizeWidth);

            Graphics g = Graphics.FromImage(img3);
            g.DrawImage(resizedImg1, new Rectangle(0, 0, resizeLength, resizeWidth));
            g.DrawImage(resizedImg2, new Rectangle(posX, posY, resizeLength, resizeWidth));

            Image temp = img3;
            pictureBox3.Image = temp;

            if(preview == 0)
            {
                Image finalImage = pictureBox3.Image;
                finalImage.Save(dir + @"\" + "CollageResult-" + x.ToString() + ".png");
                IFormatter formatter = new BinaryFormatter();

                Imagen p = new Imagen();



                p.Nombre = "CollageResult-" + x.ToString() + ".png";
                p.Direccionmemoria = dir + @"\" + "CollageResult-" + x.ToString() + ".png";
                string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
                string paths = pathi + @"\" + Path.GetFileNameWithoutExtension("CollageResult-.png") + x.ToString() + ".bin";
                Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, p);
                stream.Close();
            }
        }

        public void obtainFinalPicture2(PictureBox pB1, PictureBox pB2, PictureBox pB3, int resizeLength1, int resizeWidth1, int resizeLength2, int resizeWidth2, int posX1, int posY1, int posX2, int posY2, int preview)
        {
            Image img1 = pB1.Image;
            Image img2 = pB2.Image;
            Image img3 = pB3.Image;
            Bitmap img4 = new Bitmap(500, 300);

            Bitmap resizedImg1 = ResizeImage(img1, resizeLength1, resizeWidth1);
            Bitmap resizedImg2 = ResizeImage(img2, resizeLength1, resizeWidth1);
            Bitmap resizedImg3 = ResizeImage(img3, resizeLength2, resizeWidth2);

            Graphics g = Graphics.FromImage(img4);
            g.DrawImage(resizedImg1, new Rectangle(0, 0, resizeLength1, resizeWidth1));
            g.DrawImage(resizedImg2, new Rectangle(posX1, posY1, resizeLength1, resizeWidth1));
            g.DrawImage(resizedImg3, new Rectangle(posX2, posY2, resizeLength2, resizeWidth2));

            Image temp = img4;
            pictureBox3.Image = temp;

            if (preview == 0)
            {
                Image finalImage = pictureBox3.Image;
                finalImage.Save(dir + @"\"+ "CollageResult-" + x.ToString() + ".png");
                IFormatter formatter = new BinaryFormatter();

                Imagen p = new Imagen();

                p.Nombre = "CollageResult-"+x.ToString()+".png";
                p.Direccionmemoria = dir + @"\" + "CollageResult-" + x.ToString() + ".png";
                string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
                string paths = pathi + @"\" + Path.GetFileNameWithoutExtension("CollageResult-.png") + x.ToString() + ".bin";
                Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, p);
                stream.Close();
            }
        }

        // Boton Guardado
        private void Button2_Click(object sender, EventArgs e)
        {
            if (counter >= 2)
            {
                obtainFinalPicture(pictureBox1, pictureBox2, 250, 300, 250, 0,0);
                label2.Visible = true;
            }
            if (counter2 >= 2)
            {
                obtainFinalPicture(pictureBox4, pictureBox5, 500, 150, 0, 150,0);
                label2.Visible = true;
            }
            if (counter3 >= 2)
            {
                obtainFinalPicture2(pictureBox6, pictureBox7, pictureBox8, 250, 150, 250, 300, 0, 150, 250, 0, 0);
                label2.Visible = true;
            }
            
        }
        
        //CheckBox Preview
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                if (counter >= 2)
                {
                    obtainFinalPicture(pictureBox1, pictureBox2, 250, 300, 250, 0, 1);
                    pictureBox3.Visible = true;
                }
                if (counter2 >= 2)
                {
                    obtainFinalPicture(pictureBox4, pictureBox5, 500, 150, 0, 150, 1);
                    pictureBox3.Visible = true;
                }
                if (counter3 >= 2)
                {
                    obtainFinalPicture2(pictureBox6, pictureBox7, pictureBox8, 250, 150, 250, 300, 0, 150, 250, 0, 1);
                    pictureBox3.Visible = true;
                }
            }
            else
            {
                pictureBox3.Visible = false;
            }
        }

        // Opcion 1
        private void Option1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox3.Visible = false;
            button2.Visible = false;
            checkBox1.Visible = false;
            label2.Visible = false;
            panel1.Visible = true;
            panel1.BringToFront();
            panel2.SendToBack();
            panel3.SendToBack();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox1;
            counter += 1;
            if (counter >= 2)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox2;
            counter += 1;
            if (counter >= 2)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        //opcion 2
        private void Option2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox3.Visible = false;
            button2.Visible = false;
            checkBox1.Visible = false;
            label2.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
        }
        
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox4;
            counter2 += 1;
            if (counter2 >= 2)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox5;
            counter2 += 1;
            if (counter2 >= 2)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        //Opcion 3
        private void Option3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox3.Visible = false;
            button2.Visible = false;
            checkBox1.Visible = false;
            panel1.Visible = true;
            panel3.Visible = true;
            label2.Visible = false;
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.BringToFront();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox6;
            counter3 += 1;
            if (counter3 >= 3)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox7;
            counter3 += 1;
            if (counter3 >= 3)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            displayFlowPanel();
            pieceSelected = pictureBox8;
            counter3 += 1;
            if (counter3 >= 3)
            {
                button2.Visible = true;
                checkBox1.Visible = true;
            }
        }
    }

}
