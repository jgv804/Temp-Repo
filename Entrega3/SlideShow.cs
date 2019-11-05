using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    public partial class SlideShow : Form
    {
        public static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public static string[] diro = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs");
        private PictureBox selectedPicture;
        List<PictureBox> pictureBoxesSelected = new List<PictureBox>();
        int imagIndex = 0;

        public SlideShow()
        {
            InitializeComponent();
        }

        private void SlideShow_Load(object sender, EventArgs e)
        {
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

        public void loadPicturesSelected(List<PictureBox> list)
        {
            int counterX = 0;
            int counterY = 0;
            foreach (PictureBox picture in list)
            {
                PictureBox Temp = picture;
                Temp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Temp.Location = new Point(counterX, counterY);
                Temp.Size = new System.Drawing.Size(126, 81);
                Temp.TabIndex = 0;
                Temp.TabStop = false;
                Temp.SizeMode = PictureBoxSizeMode.StretchImage;
                counterX += 128;
                if (counterX > 512)
                {
                    counterY += 83;
                    counterX = 0;
                }
                this.flowLayoutPanel2.Controls.Add(Temp);
            }
        }

        void picture_click(object sender, EventArgs e)
        {
            if (selectedPicture != null)
                selectedPicture.BorderStyle = BorderStyle.None;
            selectedPicture = (PictureBox)sender;
            selectedPicture.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxesSelected.Add(selectedPicture);
            loadPicturesSelected(pictureBoxesSelected);
            flowLayoutPanel2.Visible = true;
            button2.Visible = true;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox1.BringToFront();
        }

        public void LoadNextImages()
        {
            if (imagIndex == pictureBoxesSelected.Count)
            {
                imagIndex = 0;
                timer1.Stop();
                pictureBox1.Image = null;
                pictureBox1.SendToBack();
            }
            else
            {
                pictureBox1.Image = pictureBoxesSelected[imagIndex].Image;
                imagIndex += 1;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImages();
        }
    }
}
