using System.Data;

namespace Paint
{
    public partial class Form1 : Form
    {
        string mode = "";
        Bitmap pic;                                             //Bitmap - ����������� � ������ ���������� (pic - ���������� ��� ��� ���� ����������
        Bitmap pic1;                                            //��������� ��������� ����� ��� ������������ ����������� � pic(��������������, ������ �����)
        int x1, y1;
        int mNx, mNy, mx, my;
        int xclick1, yclick1;
        Pen p = new Pen(Color.Black);                           //�����
        SolidBrush b = new SolidBrush(Color.White);
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
            Setsize();
            pic = new Bitmap(2000, 1000);
            pic1 = new Bitmap(2000, 1000);
            x1 = y1 = 0;
            saveFileDialog1.Filter = "Picture files(*.jpg)|*.jpg|All files(*.*)|*.*";
            trackBar1.Value = 2;
        }
        public void Setsize()
        {

            pictureBox1.Width = panel2.Width;                             //panel2 - ��������� ������� ������, ����������� � �����. �����
            pictureBox1.Height = panel2.Height;                           //�� ������� ����������� pictureBox �� ������� �����
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                trackBar1.Maximum = 50;
                trackBar1.Width = 350;
            }
            else
            {
                trackBar1.Maximum = 25;
                trackBar1.Width = 200;
            }
            if (mode == "�������")
            {
                Cursor = default;
            }
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;                                   //������������� ����� ������ �����, ������� ����� �������� ������ Pen. � ������ ������, ������ ����� ����� ��������.

            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;                                     //������������� ����� ����� �����, ������� ����� �������� ������ Pen. � ������ ������, ����� ����� ����� ����� ��������.

            p.Width = trackBar1.Value;                                                             //������������� ������� �����, ������� ����� �������� ������ Pen. ������� ����� ����� ����� ��������, ���������� �� �������� trackBar1.
            if (mode == "������")
            {
                if (b9Cl)
                {
                    p.Width = trackBar1.Value * 2;
                }
                if (b10Cl)
                {
                    p.Width = trackBar1.Value * 4;
                }
            }
            Graphics g = Graphics.FromImage(pic);                                                  //������� ����� ������ Graphics �� ���������� �����������. !!�� ������������ ��� ��������� �� �����������.
            Graphics g1 = Graphics.FromImage(pic1);                                                //������� ������ ����� ������ Graphics

            if (e.Button == MouseButtons.Left)                                                     //���� ������������ ����� �� ����� ������� ����
            {
                if (mode == "�����")
                {
                    g1.Clear(Color.White);                                                         //������� ��� � ������� g1(���������� ���������� �����, ����� ����� ����)
                    g1.DrawLine(p, xclick1, yclick1, e.X, e.Y);                                    //������ ������ ����� (pen, ���������� ����, ��� �� ������ ����� ������ ����(x,y), ���������� ������� ��� (x, y)
                    g1.DrawImage(pic, 0, 0);                                                       //����������� �������� pic ������ pic1
                    pictureBox1.Image = pic1;                                                      //������������ pic1 � pictureBox1 (��������� ������� ��� �� �������� ��������� �����)
                }
                if (mode == "�������������")
                {
                    g1.Clear(Color.White);
                    if (e.X > xclick1 && e.Y > yclick1)
                        g1.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);       //������ �������������(pen, ������ ���������, ��� �� ������ ���(x, y), ����� �� OX � OY)
                    else if (e.X < xclick1 && e.Y < yclick1)                                       //P.S. ������ ������� ��� 4 ��������� ������� ���������
                        g1.DrawRectangle(p, e.X, e.Y, xclick1 - e.X, yclick1 - e.Y);
                    else if (e.X > xclick1 && e.Y < yclick1)
                        g1.DrawRectangle(p, xclick1, e.Y, e.X - xclick1, yclick1 - e.Y);
                    else if (e.X < xclick1 && e.Y > yclick1)
                        g1.DrawRectangle(p, e.X, yclick1, xclick1 - e.X, e.Y - yclick1);
                    g1.DrawImage(pic, 0, 0);                                                       //����������� �������� pic ������ pic1
                    pictureBox1.Image = pic1;                                                      //���������� pic1 �� picturebox1
                }
                if (mode == "������")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);            //������ ������ ������� � ������� ��������������
                    g1.DrawImage(pic, 0, 0);
                    pictureBox1.Image = pic1;
                }
                if (mode == "" || mode == "������")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);                                               //������ ������ �� ������� ��������� �� ���, ��� ��������� ����� ����� �������� �����
                    pictureBox1.Image = pic;                                                       //���������� pic �� picturebox1
                }
                if (mode == "�������������")
                {
                    if (mNx != 0 && mNy != 0)
                    {
                        g1.Clear(Color.White);
                        g1.DrawLine(p, mNx, mNy, e.X, e.Y);
                        g1.DrawImage(pic, 0, 0);
                        pictureBox1.Image = pic1;
                    }
                }
            }
            x1 = e.X; y1 = e.Y;                                                                    //����������� ��������� ����������� �������
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)                        //���������� ������ ���
        {
            xclick1 = e.X;                                                                         //�������� ������� ���������� ���� � ��������� ����������
            yclick1 = e.Y;
            if (mode == "�������")
            {
                Fill(e.X, e.Y);
            }
            void Fill(int x, int y)
            {
                Stack<Point> points = new Stack<Point>();
                points.Push(new Point(x, y));
                Point currentPoint;
                while (points.Count != 0)
                {
                    currentPoint = points.Pop();
                    pic.SetPixel(currentPoint.X, currentPoint.Y, button7.BackColor);
                    if (currentPoint.X < pictureBox1.Width)
                        if (pic.GetPixel(currentPoint.X + 1, currentPoint.Y).ToArgb() != button7.BackColor.ToArgb())
                        {
                            points.Push(new Point(currentPoint.X + 1, currentPoint.Y));
                        }
                    if (currentPoint.X > 0)
                        if (pic.GetPixel(currentPoint.X - 1, currentPoint.Y).ToArgb() != button7.BackColor.ToArgb())
                        {
                            points.Push(new Point(currentPoint.X - 1, currentPoint.Y));
                        }
                    if (currentPoint.Y < pictureBox1.Height)
                        if (pic.GetPixel(currentPoint.X, currentPoint.Y + 1).ToArgb() != button7.BackColor.ToArgb())
                        {
                            points.Push(new Point(currentPoint.X, currentPoint.Y + 1));
                        }
                    if (currentPoint.Y > 0 + menuStrip1.Height)
                        if (pic.GetPixel(currentPoint.X, currentPoint.Y - 1).ToArgb() != button7.BackColor.ToArgb())
                        {
                            points.Push(new Point(currentPoint.X, currentPoint.Y - 1));
                        }
                }
                pictureBox1.Image = pic;

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)                         //���������� ������� ���
        {                                                                                         //�� ��������� ��������� ����������� �� �������� (pic)
            Graphics g = Graphics.FromImage(pic);
            if (mode == "�������������")
            {
                if (e.X > xclick1 && e.Y > yclick1)
                    g.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                else if (e.X < xclick1 && e.Y < yclick1)
                    g.DrawRectangle(p, e.X, e.Y, xclick1 - e.X, yclick1 - e.Y);
                else if (e.X > xclick1 && e.Y < yclick1)
                    g.DrawRectangle(p, xclick1, e.Y, e.X - xclick1, yclick1 - e.Y);
                else if (e.X < xclick1 && e.Y > yclick1)
                    g.DrawRectangle(p, e.X, yclick1, xclick1 - e.X, e.Y - yclick1);
            }
            if (mode == "������")
            {
                g.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
            if (mode == "�����")
            {
                g.DrawLine(p, xclick1, yclick1, e.X, e.Y);
            }
            if (mode == "�������������")
            {
                if (mNx == 0 && mNy == 0)
                {
                    mNx = e.X; mNy = e.Y; mx = e.X; my = e.Y;
                    g.DrawLine(p, mNx, mNy, e.X, e.Y + 0.5f);
                }
                else
                {
                    g.DrawLine(p, mNx, mNy, e.X, e.Y);
                    mNx = e.X; mNy = e.Y;
                    if ((e.X == mx && e.Y == my) || (e.X == mx + 1 && e.Y == my) || (e.X == mx - 1 && e.Y == my) || (e.X == mx && e.Y == my + 1)
                        || (e.X == mx && e.Y == my - 1) || (e.X == mx + 1 && e.Y == my + 1) || (e.X == mx - 1 && e.Y == my - 1) || (e.X == mx + 1 && e.Y == my - 1) || (e.X - 1 == mx && e.Y == my + 1))
                    {
                        g.DrawLine(p, e.X, e.Y, mx, my);
                        MessageBox.Show("������������� ��������!", "����������!", MessageBoxButtons.OK);
                        mNx = mNy = mx = my = 0;
                        mode = "";
                    }

                }
                g.DrawImage(pic, 0, 0);
            }

            pictureBox1.Image = pic;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(pic);
            if (mode == "" && e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, e.X, e.Y, e.X, e.Y + 1);
                pictureBox1.Image = pic;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mode = "�������";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mode = "�������������";
        }
    }
}