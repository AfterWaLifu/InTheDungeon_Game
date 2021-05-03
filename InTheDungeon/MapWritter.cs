using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace InTheDungeon
{
    class MapWritter
    {
        char[,] Map;
        int[] Coordinates = new int[2];
        string previousStep;
        string currentStep;

        public MapWritter()
        {
            FileInfo file = new FileInfo(this.ToString());
            try
            {
                List<string> lineS = new List<string>();
                using (StreamReader sr = new StreamReader(file.DirectoryName + "\\Map.txt", System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineS.Add(line);
                    }
                }
                Map = new char[lineS[0].Length,lineS.Count];
                for (int y = 0; y < lineS.Count; y++)
                {
                    for (int x = 0; x < lineS[y].Length; x++) 
                    {
                        Map[x,y] = lineS[y][x];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            }

            currentStep = "r";
            LookForHero();
        }

        public Image[,] Draw()
        {
            Image[,] Result = new Image[7,7];
            for (int i = 0; i < 7;i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Coordinates[0] - 3 + i < 0 || Coordinates[1] - 3 + j < 0 ||
                        Coordinates[0] - 3 + i >= Map.GetLength(0) || Coordinates[1] - 3 + j >= Map.GetLength(1))
                    {
                        Result[i, j] = Properties.Resources._2;
                        continue;
                    }
                    Result[i, j] = Choosing(i,j);
                }
            }
            return Result;
        }
        public Image[,] Step(string direction)
        {
            bool toDoOrNotToDo = true;
            if (currentStep != direction)
            {
                previousStep = currentStep;
                currentStep = direction;
            }

            //тест на монстра или сундук
            char next = '3';
            switch (currentStep)
            {
                case "u":
                    next = Map[Coordinates[0], Coordinates[1] - 1];
                    break;
                case "d":
                    try
                    {
                        next = Map[Coordinates[0], Coordinates[1] + 1];
                    }
                    catch
                    {
                        MessageBox.Show("Я не могу сбежать! Это мой священный долг!");
                        return Draw();
                    }
                    break;
                case "r":
                    next = Map[Coordinates[0] + 1, Coordinates[1]];
                    break;
                case "l":
                    next = Map[Coordinates[0] - 1, Coordinates[1]];
                    break;
            }
            switch (next)
            {
                case '4':
                    Form1.ifUNeedADrop = true;
                    break;
                case '5':
                    toDoOrNotToDo = Form1.Battle(5);
                    break;
                case '6':
                    toDoOrNotToDo = Form1.Battle(6);
                    break;
                case '7':
                    toDoOrNotToDo = Form1.Battle(7);
                    break;
                case '8':
                    toDoOrNotToDo = Form1.Battle(8);
                    break;
            }

            if (!toDoOrNotToDo)
            {
                MessageBox.Show("Попробуйте ещё раз, когда станете сильнее");
                return Draw();
            }

            //блок шага в стену
            switch (currentStep)
            {
                case "u":
                    if (Map[Coordinates[0], Coordinates[1] - 1] == '1' ||
                        Map[Coordinates[0], Coordinates[1] - 1] == '2') break;
                    Map[Coordinates[0], Coordinates[1]] = '3';
                    Map[Coordinates[0], Coordinates[1] - 1] = '0';
                    break;
                case "d":
                    if (Map[Coordinates[0], Coordinates[1] + 1] == '1' ||
                        Map[Coordinates[0], Coordinates[1] + 1] == '2') break;
                    Map[Coordinates[0], Coordinates[1]] = '3';
                    Map[Coordinates[0], Coordinates[1] + 1] = '0';
                    break;
                case "r":
                    if (Map[Coordinates[0] + 1, Coordinates[1]] == '1' ||
                        Map[Coordinates[0] + 1, Coordinates[1]] == '2') break;
                    Map[Coordinates[0], Coordinates[1]] = '3';
                    Map[Coordinates[0]+1, Coordinates[1]] = '0';
                    break;
                case "l":
                    if (Map[Coordinates[0] - 1, Coordinates[1]] == '1' ||
                        Map[Coordinates[0] - 1, Coordinates[1]] == '2') break;
                    Map[Coordinates[0], Coordinates[1]] = '3';
                    Map[Coordinates[0]-1, Coordinates[1]] = '0';
                    break;
            }
            
            LookForHero();
            return Draw();
        }

        private void LookForHero()
        {
            bool test = false;
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1) ; y++)
                {
                    if (Map[x,y] == '0' && !test)
                    {
                        test = true;
                        Coordinates[0] = x;
                        Coordinates[1] = y;
                    }
                    else if (Map[x, y] == '0' && test)
                    {
                        MessageBox.Show("На карте обнаружено более одного героя, проверьте её правильность", "Ошибка");
                        Environment.Exit(0);
                    }
                }
            }
            if (!test)
            {
                MessageBox.Show("На карте не обнаружено ни одного героя, проверьте её правильность", "Ошибка");
                Environment.Exit(0);
            }
        }
        private Image Choosing(int i,int j)
        {
            switch (Map[Coordinates[0]-3+i,Coordinates[1]-3+j])
            {
                case '0':
                    return ChoosingForHero();
                case '1':
                    return Properties.Resources._1;
                case '2':
                    return Properties.Resources._2;
                case '3':
                    return Properties.Resources._3;
                case '4':
                    return Properties.Resources._4;
                case '5':
                    return Properties.Resources._5;
                case '6':
                    return Properties.Resources._6;
                case '7':
                    return Properties.Resources._7;
                case '8':
                    return Properties.Resources._8;
                default:
                    return Properties.Resources._2;
            }
        }
        private Image ChoosingForHero()
        {
            switch (String.Concat(previousStep, currentStep))
            {
                case "ul":
                    return Properties.Resources._0bl;
                case "ud":
                    return Properties.Resources._0r;
                case "ur":
                    return Properties.Resources._0br;
                case "lu":
                    return Properties.Resources._0bl;
                case "ld":
                    return Properties.Resources._0l;
                case "lr":
                    return Properties.Resources._0r;
                case "du":
                    return Properties.Resources._0br;
                case "dl":
                    return Properties.Resources._0l;
                case "dr":
                    return Properties.Resources._0r;
                case "ru":
                    return Properties.Resources._0br;
                case "rl":
                    return Properties.Resources._0l;
                case "rd":
                    return Properties.Resources._0r;
            }
            return Properties.Resources._0r;
        }

        public Image[,] UltimateMap()
        {
            Image[,] result = new Image[Map.GetLength(0), Map.GetLength(1)];
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1); y++) 
                {
                    switch (Map[x,y])
                    {
                        case '0':
                            result[x,y] = Properties.Resources._3;
                            break;
                        case '1':
                            result[x, y] = Properties.Resources._1;
                            break;
                        case '2':
                            result[x, y] = Properties.Resources._2;
                            break;
                        case '3':
                            result[x, y] = Properties.Resources._3;
                            break;
                        case '4':
                            result[x, y] = Properties.Resources._4;
                            break;
                        case '5':
                            result[x, y] = Properties.Resources._5;
                            break;
                        case '6':
                            result[x, y] = Properties.Resources._6;
                            break;
                        case '7':
                            result[x, y] = Properties.Resources._7;
                            break;
                        case '8':
                            result[x, y] = Properties.Resources._8;
                            break;
                        default:
                            result[x, y] = Properties.Resources._2;
                            break;
                    }
                }
            }
            return result;
        }
    }
}
