using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace PaintPPL
{
    public partial class Form1 : Form
    {
        int[][] map = new int[4][];
        Button opened = null;
        List<Button> ToBeClosed = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                map[i] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i][j] = 0;
                }
            }
            Random r = new Random();
            for (int i = 1; i < 9; i++)
            {
                int x = r.Next(0, 4);
                int y = r.Next(0, 4);
                while (map[x][y] != 0)
                {
                    x = r.Next(0, 4);
                    y = r.Next(0, 4);
                }
                map[x][y] = i;

                x = r.Next(0, 4);
                y = r.Next(0, 4);
                while (map[x][y] != 0)
                {
                    x = r.Next(0, 4);
                    y = r.Next(0, 4);
                }
                map[x][y] = i;
            }
        }

        private void click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            string tag = b.Tag.ToString();
            int i = Convert.ToInt32(tag[0])-48;
            int j = Convert.ToInt32(tag[1])-48;
            if (map[i][j] == 1) b.BackgroundImage = Properties.Resources._1;
            if (map[i][j] == 2) b.BackgroundImage = Properties.Resources._2;
            if (map[i][j] == 3) b.BackgroundImage = Properties.Resources._3;
            if (map[i][j] == 4) b.BackgroundImage = Properties.Resources._4;
            if (map[i][j] == 5) b.BackgroundImage = Properties.Resources._5;
            if (map[i][j] == 6) b.BackgroundImage = Properties.Resources._6;
            if (map[i][j] == 7) b.BackgroundImage = Properties.Resources._7;
            if (map[i][j] == 8) b.BackgroundImage = Properties.Resources._8;

            if (opened == null)
            {
                opened = b;
            }
            else
            {
                int i1 = Convert.ToInt32(opened.Tag.ToString()[0]) - 48;
                int j1 = Convert.ToInt32(opened.Tag.ToString()[1]) - 48;
                if (map[i][j] != map[i1][j1])
                {
                    ToBeClosed.Add(opened);
                    ToBeClosed.Add(b);
                    opened = null;

                }
                else
                {
                    textBox1.Text = "Good Job";
                    opened = null;
                }

            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Control con in this.Controls)
            {
                if (con is Button) 
                { 
                    con.BackgroundImage = null;
                    con.Enabled = true;
                }
            }
            opened = null;
            for (int i = 0; i < 4; i++)
                map[i] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i][j] = 0;
                }
            }
            Random r = new Random();
            for (int i = 1; i < 9; i++)
            {
                int x = r.Next(0, 4);
                int y = r.Next(0, 4);
                while (map[x][y] != 0)
                {
                    x = r.Next(0, 4);
                    y = r.Next(0, 4);
                }
                map[x][y] = i;

                x = r.Next(0, 4);
                y = r.Next(0, 4);
                while (map[x][y] != 0)
                {
                    x = r.Next(0, 4);
                    y = r.Next(0, 4);
                }
                map[x][y] = i;
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ToBeClosed.Count == 0) return;
            timer.Enabled = false;
            for (int i = 0; i < ToBeClosed.Count; i++)
            {
                ToBeClosed[i].Enabled = true;
                ToBeClosed[i].BackgroundImage = null;
                ToBeClosed.Remove(ToBeClosed[i]);
            }
            timer.Enabled = true;
        }
    }
}
