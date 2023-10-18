using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Top_Sektirme_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int artisX = 10, artisY = 10, raket = 20, puanSayaci = 0, zorluk = 1;
        bool bitir = false;
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            top.Location = new Point(rnd.Next(10, this.Width - 10), rnd.Next(10, panel1.Location.Y - this.Height / 2));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bitir = false;
            timer1.Enabled = true;
            top.Visible = true;
            label1.Visible = true;
            panel1.Visible = true;
            label4.Visible = false;
            button1.Visible = false;
            label1.Width = 250;
            top.Location = new Point(rnd.Next(10, this.Width - 10), rnd.Next(10, panel1.Location.Y - this.Height / 2));
            timer1.Interval = 50;
            puanSayaci = 0;
            zorluk = 1;
            label2.Text = "Puan: 0";
            label3.Text = "Zorluk: 1";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (label1.Location.X > 0 && label1.Location.X < (this.Width - label1.Width))
            {
                if (e.KeyCode == Keys.Right)
                {
                    raket = 20;
                    label1.Location = new Point(label1.Location.X + raket, label1.Location.Y);
                }
                if (e.KeyCode == Keys.Left)
                {
                    raket = -20;
                    label1.Location = new Point(label1.Location.X + raket, label1.Location.Y);
                }
            }
            else if (label1.Location.X <= 0 && e.KeyCode == Keys.Right)
            {
                label1.Location = new Point(label1.Location.X + 20, label1.Location.Y);
            }
            else if (label1.Location.X >= this.Width - label1.Width && e.KeyCode == Keys.Left)
            {
                label1.Location = new Point(label1.Location.X - 20, label1.Location.Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (top.Bottom >= label1.Top && top.Bottom < label1.Bottom)
            {
                if (top.Right >= label1.Left && top.Left <= label1.Right)
                {
                    artisY = -10;
                    label1.Width -= 10;
                    puanSayaci += 5;
                    zorluk += 1;
                    label2.Text = "Puan: " + puanSayaci;
                    label3.Text = "Zorluk:" + zorluk;
                    if (timer1.Interval > 50)
                    {
                        timer1.Interval -= 50;
                    }
                    else if (timer1.Interval > 10 && timer1.Interval <= 50)
                    {
                        timer1.Interval -= 10;
                    }
                }
                else
                {
                    artisY = 10;
                }
            }
            else if (top.Bottom > label1.Bottom + 8)
            {
                bitir = true;
            }
            else
            {
                if (top.Location.Y > panel1.Location.Y - top.Height)
                {
                    artisY = -10;
                }
                else if (top.Location.Y < 20)
                {
                    artisY = 10;
                }
                if (top.Location.X > this.Width - 100)
                {
                    artisX = -10;
                }
                else if (top.Location.X < 20)
                {
                    artisX = 10;
                }
            }

            if (bitir == true)
            {
                timer1.Enabled = false;
                top.Visible = false;
                label1.Visible = false;
                panel1.Visible = false;
                label4.Visible = true;
                button1.Visible = true;
                label4.Text = "Oyun Bitti!\nPuanınız: " + puanSayaci;
            }
            else
            {
                top.Location = new Point(top.Location.X + artisX, top.Location.Y + artisY);
            }
        }
    }
}

