using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ITD_Map_Editor
{
    public partial class Form1 : Form
    {
        char[,] mapInText;
        PictureBox[,] mapInImages;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Открыть":
                    break;
                case "Сохранить":
                    break;
                case "Новая карта":
                    NewMap();
                    break;
            }
        }

        void OpenMap()
        {
            
        }

        void SaveMap()
        {

        }

        void NewMap()
        {
            string[] temp = new string[3] {"111","101","111" };
            richTextBox1.Lines = temp;
            DrawMap();
        }

        void DrawMap()
        {
            textMapFiller();
            boxesCreator(mapInText.GetLength(0), mapInText.GetLength(1));

            for (int x = 0; x < mapInText.GetLength(0); x++)
            {
                for (int y = 0; y < mapInText.GetLength(1); y++)
                {
                    switch (mapInText[x, y])
                    {
                        case '0':
                            mapInImages[x,y].Image = Properties.Resources._0;
                            break;
                        case '1':
                            mapInImages[x,y].Image = Properties.Resources._1;
                            break;
                        case '2':
                            mapInImages[x,y].Image = Properties.Resources._2;
                            break;
                        case '3':
                            mapInImages[x,y].Image = Properties.Resources._3;
                            break;
                        case '4':
                            mapInImages[x,y].Image = Properties.Resources._4;
                            break;
                        case '5':
                            mapInImages[x,y].Image = Properties.Resources._5;
                            break;
                        case '6':
                            mapInImages[x,y].Image = Properties.Resources._6;
                            break;
                        case '7':
                            mapInImages[x,y].Image = Properties.Resources._7;
                            break;
                        case '8':
                            mapInImages[x,y].Image = Properties.Resources._8;
                            break;
                        default:
                            mapInImages[x,y].Image = Properties.Resources._2;
                            break;
                    }
                }
            }
        }

        void textMapFiller()
        {
            string[] lines= richTextBox1.Lines;

            int maxI, maxVal = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > maxVal)
                {
                    maxI = i;
                    maxVal = lines[i].Length;
                }
            }

            mapInText = new char[maxVal, lines.Length];

            for (int x = 0; x < maxVal; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    mapInText[x, y] = lines[x][y];
                }
            }
        }

        void boxesCreator(int x, int y)
        {
            mapInImages = new PictureBox[mapInText.GetLength(0), mapInText.GetLength(1)];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    PictureBox temp = new PictureBox();
                    temp.Size = new Size(20, 20);
                    temp.Location = new Point(220 + i * 20, 28 + j * 20);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    mapInImages[i, j] = temp;
                    this.Controls.Add(mapInImages[i, j]);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DrawMap();
        }
    }
}
