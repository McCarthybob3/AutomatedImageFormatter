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

namespace test_image_editor_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.pictureBox1.Image = CreateBitmapAtRuntime2();
                this.pictureBox1.Visible = true;
            }
            else
            {
                this.pictureBox1.Image = CreateBitmapAtRuntime();
                this.pictureBox1.Visible = true;
            }
        }

        private Bitmap CreateBitmapAtRuntime()
        {

            Bitmap img;
            string input = textBox1.Text;
            Bitmap newImage;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (radioButton1.Checked == true)
            {
                img = Properties.Resources.chad;
            }
            else
            {
                img = Properties.Resources.wojak;
            }

            Bitmap bmp = img;
            newImage = bmp;
            Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 7, FontStyle.Regular);

            Graphics gr = Graphics.FromImage(newImage);
            gr.DrawImageUnscaled(bmp, 0, 0);
            gr.DrawString(input, bigFont, Brushes.Black,
            new RectangleF(400, ((bmp.Height / 2) - 50), 300, 300));
            string path = Path.Combine(desktop, "newimg.jpg");
            newImage.Save(path);
            return newImage;
            
        }


        private Bitmap CreateBitmapAtRuntime2()
        {

            Bitmap img;
            string input = textBox1.Text;
            Bitmap newImage;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (radioButton1.Checked == true)
            {
                img = Properties.Resources.chad;
            }
            else
            {
                img = Properties.Resources.wojak;
            }



            DialogResult result = openFileDialog1.ShowDialog();
     
            string img2;

            img2 = openFileDialog1.FileName;

            Bitmap bmp = img;
            newImage = bmp;

            Bitmap bmp2 = (Bitmap)Bitmap.FromFile(img2);
            Bitmap bmp3 = new Bitmap(bmp2.Width, bmp2.Height);



            Graphics gr = Graphics.FromImage(newImage);
            gr.DrawImage(bmp2, 400, ((bmp.Height / 2) - 50), bmp2.Width / 4, bmp2.Width / 4);
            string path = Path.Combine(desktop, "newimg.jpg");
            newImage.Save(path);
            return newImage;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
