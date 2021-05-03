using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InTheDungeon
{
    public partial class FormMap : Form
    {
        MapWritter MW;
        PictureBox[,] pbs;
        public FormMap()
        {
            InitializeComponent();
            MW = new MapWritter();
            UpdMap();
            this.Size = new Size(pbs.GetLength(0)*30+12, pbs.GetLength(1)*30+38+40);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            button1.Size = new Size(pbs.GetLength(0) * 30 + 8,40);
            button1.Location = new Point(0, pbs.GetLength(1) * 30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdMap()
        {
            Image[,] images = MW.UltimateMap();
            pbs = new PictureBox[images.GetLength(0), images.GetLength(1)];

            for (int i = 0; i < images.GetLength(0); i++)
            {
                for (int j = 0; j < images.GetLength(1); j++)
                {
                    PictureBox temp = new PictureBox();
                    temp.Size = new Size(30, 30);
                    temp.Location = new Point(i * 30, j * 30);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    temp.Image = images[i, j];
                    pbs[i, j] = temp;
                    this.Controls.Add(pbs[i, j]);
                }
            }
        }
    }
}
