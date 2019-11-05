using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class AddText : Form
    {
        public static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        private PictureBox selectedPicture;
        public static Image cleanPhoto;
        string textSize = "100";
        string xPosition = "0";
        string yPosition = "0";
        string color = "Black";
        public static int x = 1;

        public AddText()
        {
            InitializeComponent();
        }

        //Mostrar fotos
        private void AddText_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            panel1.Visible = false;
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

        //Seleccionar foto
        void picture_click(object sender, EventArgs e)
        {
            if (selectedPicture != null)
                selectedPicture.BorderStyle = BorderStyle.None;
            selectedPicture = (PictureBox)sender;
            selectedPicture.BorderStyle = BorderStyle.FixedSingle;
            panel1.Visible = true;
            pictureBox1.Image = selectedPicture.Image;
            cleanPhoto = (Image)selectedPicture.Image.Clone();
            panel2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            pictureBox2.Image = cleanPhoto;
            textBox2.Text = selectedPicture.Name;
        }

        //Agregar Texto
        private void addText(Image img, string text, string textSize, string xPosition, string yPosition, string color)
        {
            Image img1 = img;
            int TextSizeF = Convert.ToInt32(textSize);
            int xPositionF = Convert.ToInt32(xPosition);
            int yPositionF = Convert.ToInt32(yPosition);
            var font = new Font("TimeNewToman", TextSizeF, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(img1);
            if (color == "White")
            {
                graphics.DrawString(text, font, Brushes.White, new Point(xPositionF, yPositionF));
            }
            else if (color == "Black")
            {
                graphics.DrawString(text, font, Brushes.Black, new Point(xPositionF, yPositionF));
            }
            else if (color == "Blue")
            {
                graphics.DrawString(text, font, Brushes.Blue, new Point(xPositionF, yPositionF));
            }
            else if (color == "Red")
            {
                graphics.DrawString(text, font, Brushes.Red, new Point(xPositionF, yPositionF));
            }
            else if (color == "Green")
            {
                graphics.DrawString(text, font, Brushes.Green, new Point(xPositionF, yPositionF));
            }
            this.pictureBox1.Image = img1;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            addText(this.pictureBox1.Image, textBox1.Text,textSize, xPosition, yPosition, color);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = (Image)cleanPhoto.Clone();
            textBox1.Text = "";
        }

        //Volver a menu principal
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Image finalImage = pictureBox1.Image;
            Imagen p = new Imagen();
            
            string t = textBox2.Text;
            finalImage.Save(dir + @"\" + Path.GetFileNameWithoutExtension(t) +"-Textedition"+ x.ToString() + Path.GetExtension(t) );
            label1.Visible = true;
            label1.Text = "Image saved successfully";
            p.Nombre = Path.GetFileNameWithoutExtension(t) + "-Textedition" + x.ToString() + Path.GetExtension(t);
            p.Direccionmemoria = dir + @"\" + Path.GetFileNameWithoutExtension(t) + "-Textedition" + x.ToString() + Path.GetExtension(t);
            string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
            string paths = pathi + @"\" + Path.GetFileNameWithoutExtension(t) + "-Textedition" + x.ToString() + ".bin";
            Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();
            x += 1;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            if (textBox3.Text.Length > 0)
            {
                textSize = textBox3.Text;
            }
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            if (textBox4.Text.Length > 0)
            {
                xPosition = textBox4.Text;
            }
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            if (textBox5.Text.Length > 0)
            {
                yPosition = textBox5.Text;
            }
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            color = "White";
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            color = "Black";
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            color = "Blue";
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            color = "Red";
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Image editImage = (Image)cleanPhoto.Clone();
            color = "Green";
            addText(editImage, textBox1.Text, textSize, xPosition, yPosition, color);
        }
    }
}
