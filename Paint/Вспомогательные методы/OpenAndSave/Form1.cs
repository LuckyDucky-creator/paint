using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public partial class Form1 : Form
    {
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pic.Save("картинка", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void сохранитьКакToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (saveFileDialog1.FileName != "")
                pic.Save(saveFileDialog1.FileName);
        }
        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }

        }
    }
}
