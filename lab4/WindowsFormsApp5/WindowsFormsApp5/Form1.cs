using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Width;
        int Height;
        Bitmap picture;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp|*.bmp";
            openFileDialog1.ShowDialog();
            picture = (Bitmap)Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = picture;
            pictureBox1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double l;
            l = Convert.ToDouble(textBox1.Text);
            Random rand = new Random();
            for (int i = 0; i < l; i++)
            {
                picture.SetPixel(rand.Next(picture.Width), rand.Next(picture.Height), Color.White);
            }
            pictureBox2.Image = picture;
            pictureBox2.Invalidate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color color;
            Width = Convert.ToInt32(textBox2.Text);
            Height = Convert.ToInt32(textBox3.Text);
            int X = Convert.ToInt32(textBox4.Text);
            int Y = Convert.ToInt32(textBox5.Text);

            int H1 = (Height - 1) / 2;
            int W1 = (Width - 1) / 2;

            int[] temp = new int[(Height + Width - 1)];
            progressBar1.Step = 1;


            progressBar1.Maximum = picture.Width * picture.Height;

            for (int i = Y; i < picture.Height - H1; i++)
                for (int j = X; j < picture.Width - W1; j++)
                {
                    color = picture.GetPixel(j, i);
                    temp[0] = Convert.ToInt32(color.R);
                    int k = 1;
                    while (k <= H1)
                    {
                        color = picture.GetPixel(j + k, i);
                        temp[k] = Convert.ToInt32(color.R);
                        k++;
                    }
                    k = 1;
                    while (k <= H1)
                    {
                        color = picture.GetPixel(j - k, i);
                        temp[H1 + k] = Convert.ToInt32(color.R);
                        k++;
                    }
                    k = 1;
                    while (k <= W1)
                    {
                        color = picture.GetPixel(j, i + k);
                        temp[2 * H1 + k] = Convert.ToInt32(color.R);
                        k++;
                    }
                    k = 1;
                    while (k <= W1)
                    {
                        color = picture.GetPixel(j, i - k);
                        temp[W1 + H1 + H1 + k] = Convert.ToInt32(color.R);
                        k++;
                    }

                    Sort(temp);
                    int color1 = temp[((Height + Width) / 2) - 1];
                    picture.SetPixel(j, i, Color.FromArgb(color1, color1, color1));
                    progressBar1.PerformStep();


                }
            pictureBox2.Image = picture;
            progressBar1.Value = 0;

        }
        void Sort(int[] a)
        {
            int top = Height + Width - 2;
            while (top != 0)
            {
                for (int i = 0; i < top; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        int temp;
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
                top--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] sb = new int[4];            
            for (int x = 1; x < picture.Width - 1; x++)
            {            
                for (int y = 1; y < picture.Height - 1; y++)
                {
                    int tx = x, ty = y;
                    Color c = picture.GetPixel(tx, ty);
                    sb[0] = Convert.ToInt32(c.GetBrightness());
                    c = picture.GetPixel(tx +1, ty);
                    sb[1] = Convert.ToInt32(c.GetBrightness());
                    c = picture.GetPixel(tx, ty + 1);
                    sb[2] = Convert.ToInt32(c.GetBrightness());
                    c = picture.GetPixel(tx + 1, ty + 1);
                    sb[3] = Convert.ToInt32(c.GetBrightness());                                        
                        int s = sb[0] - sb[3];
                        int t = sb[1] - sb[2];
                        double G = Math.Sqrt((t * t) + (s * s));
                    if (G < 1)                       
                        picture.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    else                        
                       picture.SetPixel(x, y, Color.FromArgb(255, 255, 255));                    
                }                
            }
            pictureBox2.Image = picture;            
        }
    }
}
    

