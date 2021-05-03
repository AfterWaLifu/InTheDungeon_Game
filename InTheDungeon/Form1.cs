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
    public partial class Form1 : Form
    {
        PictureBox[,] Map;
        MapWritter MW;
        static public _Character Hero;
        FormMap FM;
        static public bool ifUNeedADrop;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(keyPressed);

            MW = new MapWritter();
            Map = new PictureBox[7,7];
            Image[,] imTemp = MW.Draw();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    PictureBox temp = new PictureBox();
                    temp.Size = new Size(80,80);
                    temp.Location = new Point(i * 80,j*80);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    temp.Image = imTemp[i,j];
                    Map[i, j] = temp;
                    this.Controls.Add(Map[i,j]);
                    toolTip1.SetToolTip(Map[i,j],"Карта");
                }
            }
            ifUNeedADrop = false;
            Hero = new _Character();
            updInterface();
            toolTip1.SetToolTip(button1,"Для передвижения также можно использовать клавиши WASD");
            toolTip1.SetToolTip(button2, "Для передвижения также можно использовать клавиши WASD");
            toolTip1.SetToolTip(button3, "Для передвижения также можно использовать клавиши WASD");
            toolTip1.SetToolTip(button4, "Для передвижения также можно использовать клавиши WASD");
            toolTip1.SetToolTip(buttonMap, "Разернуть карту");
            gameStart();
        }

        //кнопки ============================================
        private void button1_Click(object sender, EventArgs e)
        {
            MakeStep("u");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MakeStep("l");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MakeStep("d");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MakeStep("r");
        }
        private void buttonMap_Click(object sender, EventArgs e)
        {
            FM = new FormMap();
            FM.ShowDialog();
        }
        private void buttonUse_Click(object sender, EventArgs e)
        {
            try
            {
                Hero.Use(listBoxInv.SelectedIndex);
                updInterface();
            }
            catch
            {
                MessageBox.Show("Вы не выбрали предмета для использования");
            }
        }
        private void buttonTurf_Click(object sender, EventArgs e)
        {
            try
            {
                Hero.inventory.InventoryTurf(listBoxInv.SelectedIndex);
                updInterface();
            }
            catch
            {
                MessageBox.Show("Вы не выбрали предмета того, чтобы выбросить");
            }
        }
        //Для карты что-то====================================
        private void MakeStep(string direction)
        {
            Image[,] temp;
            switch (direction)
            {
                case "u":
                    temp = MW.Step("u");
                    for (int i = 0; i < 49; i++) Map[i / 7, i % 7].Image = temp[i / 7, i % 7];
                    break;
                case "d":
                    temp = MW.Step("d");
                    for (int i = 0; i < 49; i++) Map[i / 7, i % 7].Image = temp[i / 7, i % 7];
                    break;
                case "r":
                    temp = MW.Step("r");
                    for (int i = 0; i < 49; i++) Map[i / 7, i % 7].Image = temp[i / 7, i % 7];
                    break;
                case "l":
                    temp = MW.Step("l");
                    for (int i = 0; i < 49; i++) Map[i / 7, i % 7].Image = temp[i / 7, i % 7];
                    break;
            }
            if (FormBattle.result) addPotion();
            FormBattle.result = false;
            addAOrWTo();
        }
        static public bool Battle(int enemy)
        {
            FormBattle fb = new FormBattle(enemy);
            DialogResult dr = fb.ShowDialog();
            return FormBattle.result;
        }
        private void keyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    MakeStep("u");
                    break;
                case Keys.A:
                    MakeStep("l");
                    break;
                case Keys.S:
                    MakeStep("d");
                    break;
                case Keys.D:
                    MakeStep("r");
                    break;
            }
        }

        //взаимодействие с героем ============================
        private void updInterface()
        {
            listBoxInv.Items.Clear();
            listBoxCur.Items.Clear();

            labelHP.Text = Math.Round(Hero.Health,2).ToString();
            labelLvl.Text = Hero.Level.ToString();
            labelExp.Text = Hero.Experience.ToString();
            labelStr.Text = Hero.Strength.ToString();
            labelAgi.Text = Hero.Agility.ToString();

            for (int i = 0; i < Hero.inventory.I.Count; i++)
            {
                listBoxInv.Items.Add(Hero.inventory.I[i].Name);
            }
            listBoxCur.Items.Add(Hero.CurrentWeapon.Name);
            listBoxCur.Items.Add(Hero.CurrentArmor.Name);
        }
        private void addAOrWTo()
        {
            if (ifUNeedADrop)
            {
                _Item temp = _Item.Drop();
                Hero.inventory.InventoryAdd(temp);
                ifUNeedADrop = false;
            }
            updInterface();
        }
        private void addPotion()
        {
            Random r = new Random();
            Hero.inventory.InventoryAdd(new __Potion("Зелье лечения",Hero.Level));
            updInterface();
        }
        //сюжужет--------------------------------------------
        public static void gameStart()
        {
            MessageBox.Show(
                "\tЗдравствуй, странник!\n  Проходи в пещеру быстрее, ведь здесь ты " +
                "с одной целью - убить злобного дракона, что поселился рядом с твоей родной" +
                " деревней. Может твои снаряжение и умения оставляют желать лучшего, но что может" +
                " быть важнее веры в себя?\n\tУДАЧИ, СТРАНИК!",
                "Добро пожаловать в InTheDungeon!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }
        public static void gameOver()
        {
            MessageBox.Show("Наконец! Победа!","*где-то в твоих мыслях*");
            MessageBox.Show("..наконец?", "*где-то в твоих мыслях*");
            MessageBox.Show("СТОП СТОП СТОП, так всё и закончится?!" +
                "\nТо есть я просто пришёл и убил за ради повышения самомнения" +
                " орду невинных зверей, что лишь мирно существовали, просто потому что они - " +
                "не такие как я?", "*где-то в твоих мыслях*");
            MessageBox.Show("Странно конечно, но кто я такой, чтобы решать, когда " +
                "мной управляет такой же человек перед монитором, что делает, что ему сказали." +
                "\nИнтересно, а он хоть раз задумывался, не водят ли его так же за нос, " +
                "заставляя делать что-то глупое?", "*где-то в твоих мыслях*");
            MessageBox.Show("Поздравляем! Вы прошли игру! Всего лучшего!", "ИГРА");
            Environment.Exit(0);
        }
    }
}
