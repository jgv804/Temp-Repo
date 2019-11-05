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
    public partial class Importer : Form
    {
        public static string diro = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\Docs";
        public Form1 f1= new Form1();
        public Importer()
        {
            InitializeComponent();
            //GoFullscreen(false);//
            
         }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;

            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All filles(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    image.ImageLocation = imageLocation;
                    textBox1.Text = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred while uploading the picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button2.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            File.Copy(textBox1.Text, Path.Combine(diro,Path.GetFileName(textBox1.Text)),true);
            addBox(f1, Path.Combine(diro, Path.GetFileName(textBox1.Text)));
            label2.Text = "Image upload successfully";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Form1 f1 = new Form1();//
            f1.ShowDialog();
            this.Close();
        }
        public void addBox(Form1 ff, string path)
        {
            int CX = 0;
            int CY = 0;

            Imagen k = new Imagen();


            IFormatter formatter = new BinaryFormatter();
            string pathi = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Entrega3\BinObjects";
            string paths = pathi + @"\" + Path.GetFileNameWithoutExtension(path) + ".bin";
            
            //PictureBox Temp = new PictureBox();//
            k.Direccionmemoria = path;
            k.Nombre = Path.GetFileName(path);
            /*Temp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Temp.ImageLocation = k.Direccionmemoria;
            Temp.Location = new Point(CX, CY);
            Temp.Name = k.Nombre;
            Temp.Size = new System.Drawing.Size(126, 81);
            Temp.TabIndex = 0;
            Temp.TabStop = false;
            Temp.SizeMode = PictureBoxSizeMode.StretchImage;
            Temp.MouseHover += new System.EventHandler(ff.MouseHoveringPictureBox);
            Temp.MouseLeave += new System.EventHandler(ff.MouseLeavingPictureBox);
            CX += 128;
            if (CX > 512)
            {
                CY += 83;
                CX = 0;
            }*/
            Stream stream = new FileStream(paths, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, k);
            stream.Close();
            //ff.DirectoryflowLayoutPanel1.Controls.Add(Temp);//
           
            

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
    }
}

