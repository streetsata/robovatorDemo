using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robovator1._3
{
    public partial class ToTakePicture : Form
    {
        public ToTakePicture()
        {
            InitializeComponent();
        }

        public ToTakePicture(Bitmap bmp)
            : this()
        {
            pictureBox1.Image = (Image)bmp;
            pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
        }

        List<Color> arrColor = new List<Color>();
        public List<Color> ArrColor { get { return this.arrColor; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;
            Color tmpColor = new Bitmap(pictureBox1.Image).GetPixel(arg.X, arg.Y);
            arrColor.Add(tmpColor);
            listBox1.Items.Add(String.Format("R:{0} | G:{1} | B:{2}", tmpColor.R, tmpColor.G, tmpColor.B));
        }
    }
}
