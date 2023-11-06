using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public partial class Form1 : Form
    {
        bool b9Cl, b10Cl; 
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Эта программа создана БОГОМ", "сообщение всем мирянам", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (res == DialogResult.Cancel) { Close(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            p.Color = colorDialog.Color;
            button7.BackColor = colorDialog.Color;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button3_Click(object sender, EventArgs e) //линия
        {
            mode = "Линия";
            p.Color = button7.BackColor;
        }
        private void button2_Click(object sender, EventArgs e) //прямоугольник
        {
            mode = "Прямоугольник";
            p.Color = button7.BackColor;
        }
        private void button4_Click(object sender, EventArgs e) //кисть
        {
            mode = "";
            p.Color = button7.BackColor;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            mode = "Эллипс";
            p.Color = button7.BackColor;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            mode = "Ластик";
            p.Color = Color.White;
            button9.Visible = true;
            button10.Visible = true;
            
        }
        private void button9_Click(object sender, EventArgs e)
        {
            b9Cl = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            b10Cl = true;
        }
    }
}
