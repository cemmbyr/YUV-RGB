//CEM BAYIR 160202066
//ÖZGÜR DEMİR 160202072
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab3
{
    public partial class Form1 : Form
    {

        public static int width;
        public static int height;
        public static int imgSize = width * height;
        public static int frameSize = imgSize * 3 / 2;
        public static int frameSayisi;


        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Start();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim"))
            {
                Directory.Delete(@"C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim", true);

            }
            Directory.CreateDirectory(@"C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim");


            openFileDialog1.FileName = "Dosya Seçiniz";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.Title = "Hızlı Resim";
            openFileDialog1.InitialDirectory = "C:\\";
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (comboBox1.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                {
                    label4.Text = "Bilgileri Eksiksiz Giriniz!";
                }
                else
                {
                label4.Text = "Yükleniyor....";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                FileStream fs = File.OpenRead(openFileDialog1.FileName);
                BinaryReader yeni = new BinaryReader(fs);
                String format = comboBox1.Text;
                height = Convert.ToInt32(textBox1.Text);
                width = Convert.ToInt32(textBox2.Text);
                Bitmap bm = new Bitmap(height, width);
                
                          
                //4-2-0 Formatı
                if (format.Equals("4-2-0"))
                {
                    int frameBoyut = height * width * 3 / 2;
                    frameSayisi = (int)fs.Length / frameBoyut;
                    int tampon, tmp = 0, tmp2 = 0, tmp3 = 0;
                    int[] y = new int[width * height * frameSayisi];
                    for (int i = 0; i < frameSayisi; i++)
                    {

                        for (int j = 0; j < height * width; j++)
                        {
                            tampon = fs.ReadByte();
                            y[tmp] = (byte)tampon;
                            tmp++;

                        }
                        for (int k = 0; k < width * height * 1 / 2; k++)
                        {
                            tampon = fs.ReadByte();
                        }


                    }
                    for (int i = 0; i < frameSayisi; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            for (int k = 0; k < height; k++)
                            {
                                bm.SetPixel(k, j, Color.FromArgb(y[tmp2], y[tmp2], y[tmp2]));
                                tmp2++;
                            }

                        }
                        bm.Save("C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim\\" + "gri" + tmp3 + ".bmp", ImageFormat.Bmp);
                        tmp3++;

                    }


                }
                //4-2-2 Formatı
                if (format.Equals("4-2-2"))
                {
                    int frameBoyutu = height * width * 2;
                    frameSayisi = (int)fs.Length / frameBoyutu;
                    int tampon, tmp = 0, tmp2 = 0, tmp3 = 0;
                    int[] y = new int[width * height * frameSayisi];
                    for (int i = 0; i < frameSayisi; i++)
                    {

                        for (int j = 0; j < width * height; j++)
                        {
                            tampon = fs.ReadByte();

                            y[tmp] = (byte)tampon;
                            tmp++;

                        }
                        for (int k = 0; k < width * height * 1; k++)
                        {
                            tampon = fs.ReadByte();
                        }

                    }
                    for (int i = 0; i < frameSayisi; i++)
                    {
                        for (int J = 0; J < width; J++)
                        {
                            for (int k = 0; k < height; k++)
                            {

                                bm.SetPixel(k, J, Color.FromArgb(y[tmp2], y[tmp2], y[tmp2]));
                                tmp2++;

                            }
                        }
                        bm.Save("C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim\\" + "gri" + tmp3 + ".bmp", ImageFormat.Bmp);
                        tmp3++;
                    }


                }
                //4-4-4 Formatı
                if (format.Equals("4-4-4"))
                {
                    int frameBoyutu = height * width * 3;
                    frameSayisi = (int)fs.Length / frameBoyutu;
                    int tampon, tmp = 0, tmp2 = 0, tmp3 = 0;
                    int[] y = new int[width * height * frameSayisi];
                    for (int i = 0; i < frameSayisi; i++)
                    {

                        for (int j = 0; j < width * height; j++)
                        {
                            tampon = fs.ReadByte();
                            y[tmp] = (byte)tampon;
                            tmp++;

                        }
                        for (int k = 0; k < width * height * 2; k++)
                        {
                            tampon = fs.ReadByte();
                        }

                    }
                    for (int i = 0; i < frameSayisi; i++)
                    {
                        for (int J = 0; J < width; J++)
                        {
                            for (int k = 0; k < height; k++)
                            {

                                bm.SetPixel(k, J, Color.FromArgb(y[tmp2], y[tmp2], y[tmp2]));
                                tmp2++;

                            }
                        }
                        bm.Save("C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim\\" + "gri" + tmp3 + ".bmp", ImageFormat.Bmp);
                        tmp3++;
                    }

                }
            }

        }
            



        }
        private void basla(int i)
        {
                
            if (File.Exists("C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim\\gri0.bmp") ==true)
            {
                pictureBox1.Refresh();
                pictureBox1.Image = new Bitmap("C:\\Users\\ASUS\\source\\repos\\YazLab3\\resim\\" + "gri" + i + ".bmp");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label4.Text = "";

            }
        }

        public static int tanp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            
            if (tanp > frameSayisi-1) {
                tanp = 1;
            }
            basla(tanp);
            tanp++;

            timer1.Start();
            
        }
    }
}