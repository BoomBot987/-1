using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lab1tsos
{
    public partial class Form1 : Form
    {
        public String bfType;
        public Int32 bfSize;
        public Int16 bfReserved1;
        public Int16 bfreserved2;
        public Int32 bfOffBits;
        public Int32 bfSizeheader;
        public Int32 bfShirinaImage;
        public Int32 bfVisotaImage;
        public Int16 bfNumberPlosk;
        public Int16 bfBitPixel;
        public Int32 bfCompress;
        public Int32 bfSizeRastMass;
        public Int32 bfGorSize;
        public Int32 bfVertSize;
        public Int32 bfNumberColors;
        public Int32 bfMainColors;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp |*.bmp";
            openFileDialog1.ShowDialog();
            BinaryReader bReader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open));
            bfType = new string(bReader.ReadChars(2));
            bfSize = bReader.ReadInt32();
            bfReserved1 = bReader.ReadInt16();
            bfreserved2 = bReader.ReadInt16();
            bfOffBits = bReader.ReadInt32();
            bfSizeheader = bReader.ReadInt32();
            bfShirinaImage = bReader.ReadInt32();
            bfVisotaImage = bReader.ReadInt32();
            bfNumberPlosk = bReader.ReadInt16();
            bfBitPixel = bReader.ReadInt16();
            bfCompress = bReader.ReadInt32();
            bfSizeRastMass = bReader.ReadInt32();
            bfGorSize = bReader.ReadInt32();
            bfVertSize = bReader.ReadInt32();
            bfNumberColors = bReader.ReadInt32();
            bfMainColors = bReader.ReadInt32();


            bReader.Close();

            String CompressType = 0.ToString();
            if (bfCompress == 0 || bfCompress == 3 || bfCompress == 6)
                CompressType = "Без сжатия";
            else if (bfCompress == 1 || bfCompress == 2)
                CompressType = "RLE";
            else if (bfCompress == 4)
                CompressType = "JPEG";
            else if (bfCompress == 5)
                CompressType = "PNG";

            Bitmap original_image = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = original_image;
            pictureBox1.Show();


            String message = "Сигнатура файла: " + bfType + "\n Размер файла: " + bfSize.ToString() +
                             "\n Местонахождение данных растрового массива: " + bfOffBits.ToString() +
                             "\n Длина заголовка растрового массива: " + bfSizeheader.ToString() +
                             "\n Ширина изобрадения: " + bfShirinaImage.ToString() + "\n Высота изображения: " +
                             bfVisotaImage.ToString() + "\n Число цевтовых плоскостей: " + bfNumberPlosk +
                             "\n Бит/пиксел: " + bfBitPixel + "\n Метод сжатия: " + CompressType +
                             "\n Длина растрового массива: " + bfSizeRastMass + "\n Горизонтальное разрешение: " +
                             bfGorSize + "\n Вертикальное разрешение: " + bfVertSize +
                             "\n Количество цветов изображения: " + bfNumberColors + "\n Количество основных цветов: " +
                             bfMainColors;

            MessageBox.Show(message);


        }
    }
}
