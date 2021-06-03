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
        string path;
        string name;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Открыть":
                    OpenMap();
                    break;
                case "Сохранить":
                    SaveMap();
                    break;
                case "Новая карта":
                    NewMap();
                    break;
            }
        }

        void OpenMap()
        {
            FileInfo f = new FileInfo(this.ToString());
            path = f.DirectoryName;

            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.InitialDirectory = path;
                opf.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                opf.RestoreDirectory = true;

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    path = opf.FileName;
                    name = path.Substring(path.LastIndexOf("\\")+1);

                    StreamReader sr = new StreamReader(path);
                    string line;
                    richTextBox1.Text = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        richTextBox1.Text += line + "\n";
                    }
                    sr.Close();
                }
            }
            DrawMap();
        }

        void SaveMap()
        {
            CheckNames();

            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            svd.FileName = name;
            svd.DefaultExt = ".txt";
            svd.InitialDirectory = path;

            if (svd.ShowDialog() == DialogResult.Cancel) return;

            File.WriteAllText(svd.FileName, richTextBox1.Text);
        }

        void CheckNames()
        {
            if (string.IsNullOrEmpty(path))
            {
                FileInfo fi = new FileInfo(this.ToString());
                path = fi.DirectoryName;
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "Map.txt";
            }
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
            int countOfLines = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > maxVal)
                {
                    maxI = i;
                    maxVal = lines[i].Length;
                }
            }

            mapInText = new char[maxVal, lines.Length];
            
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    mapInText[x, y] = lines[y][x];
                }
            }
        }

        void boxesCreator(int x, int y)
        {
            if (mapInImages != null)
            {
                foreach (PictureBox p in mapInImages) p.Dispose();
            }

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
            bool test = false;

            foreach (string s in richTextBox1.Lines)
            {
                if (string.IsNullOrEmpty(s))
                {
                    test = true;
                    break;
                }
            }

            if (!test) DrawMap();
        }
    }
}
