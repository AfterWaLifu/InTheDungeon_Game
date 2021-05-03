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
    public partial class FormBattle : Form
    {
        static public bool result;
        PictureBox pictureBoxH = new PictureBox();
        PictureBox pictureBoxA = new PictureBox();
        PictureBox pictureBoxM = new PictureBox();
        _Monster monster;
        Image[] mimages;
        bool monsterMove;
        double startHp;
        bool timerFlag;
        public FormBattle(int num)
        {
            InitializeComponent();
            //пикчербоксы
            pictureBoxH.Size = new Size(80,80);
            pictureBoxA.Size = new Size(80, 80);
            pictureBoxM.Size = new Size(80, 80);
            pictureBoxH.Location = new Point(0,0);
            pictureBoxA.Location = new Point(80, 0);
            pictureBoxM.Location = new Point(160, 0);
            pictureBoxH.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxA.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxM.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH.Image = Properties.Resources.h0;
            pictureBoxA.Image = Properties.Resources.middle;
            this.Controls.Add(pictureBoxH);
            this.Controls.Add(pictureBoxA);
            this.Controls.Add(pictureBoxM);

            monster = new _Monster(num);
            imagesFiller();

            startHp = Form1.Hero.Health;
            pictureBoxM.Image = mimages[0];
            this.Text = monster.Name;
            updHealth();
        }
        //=====кнопки==========================================
        private void buttonAttack_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            timerFlag = true;
            timer1.Start();
            if (monsterMove)
            {
                monster.ChangeHP(-Form1.Hero.Attack() * (1 - (monster.Resist / 100.0)));
                Form1.Hero.ChangeHP(-monster.Attack() * (1 - (Form1.Hero.CurrentArmor.GetResist() / 100.0)));
            }
            else
            {
                if (!monster.Dodge())
                {
                    monster.ChangeHP(-Form1.Hero.Attack() * (1 - (monster.Resist / 100.0)));
                }
            }
            monsterMove = Convert.ToBoolean(r.Next(0, 2));
            updHealth();
            checkHP();
        }
        private void buttonDodge_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            if (monsterMove || monster.ico == 8)
            {
                timerFlag = true;
                timer2.Start();
                if (!Form1.Hero.Dodge())
                {
                    Form1.Hero.ChangeHP(-monster.Attack() *(1-( Form1.Hero.CurrentArmor.GetResist() / 100.0)));
                }
            }
            monsterMove = Convert.ToBoolean(r.Next(0, 2));
            updHealth();
            checkHP();
        }
        private void buttonRun_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //====методы остальные===================================
        //---связанное с интерфейсом----------------
        private void updHealth()
        {
            labelHPHero.Text = (Math.Round(Form1.Hero.Health,2)).ToString();
            labelHPMonstr.Text = (Math.Round(monster.Health, 2)).ToString();
        }
        private void imagesFiller()
        {
            switch (monster.ico)
            {
                case 5:
                    mimages = new Image[2];
                    mimages[0] = Properties.Resources.s0;
                    mimages[1] = Properties.Resources.s1;
                    break;
                case 6:
                    mimages = new Image[2];
                    mimages[0] = Properties.Resources.w0;
                    mimages[1] = Properties.Resources.w1;
                    break;
                case 7:
                    mimages = new Image[2];
                    mimages[0] = Properties.Resources.l0;
                    mimages[1] = Properties.Resources.l1;
                    break;
                case 8:
                    mimages = new Image[4];
                    mimages[0] = Properties.Resources.d0;
                    mimages[1] = Properties.Resources.d1;
                    mimages[2] = Properties.Resources.d2;
                    mimages[3] = Properties.Resources.d3;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerFlag) 
            {
                timerFlag = false;
                pictureBoxH.Image = Properties.Resources.left;
                pictureBoxA.Image = Properties.Resources.h1;
            }
            else
            {
                pictureBoxH.Image = Properties.Resources.h0;
                pictureBoxA.Image = Properties.Resources.middle;
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timerFlag)
            {
                if (monster.ico == 8)
                {
                    Random r = new Random();
                    pictureBoxA.Image = mimages[r.Next(2,4)];
                    pictureBoxM.Image = mimages[1];
                    timerFlag = false;
                }
                else
                {
                    timerFlag = false;
                    pictureBoxM.Image = Properties.Resources.right;
                    pictureBoxA.Image = mimages[1];
                }
            }
            else
            {
                if (monster.ico == 8)
                {
                    Random r = new Random();
                    pictureBoxA.Image = Properties.Resources.middle;
                    pictureBoxM.Image = mimages[0];
                    timer2.Stop();
                }
                else
                {
                    pictureBoxM.Image = mimages[0];
                    pictureBoxA.Image = Properties.Resources.middle;
                    timer2.Stop();
                }
            }
        }

        //---бойй-----------------------------------
        private void checkHP()
        {
            if (Form1.Hero.Health <= 0)
            {
                Form1.Hero.Health = startHp;
                result = false;
                this.Close();
            }
            else if (monster.Health <= 0)
            {
                Form1.Hero.ExperienceAdd(monster.expForKilling);
                result = true;
                if (monster.ico == 8)
                {
                    labelHPMonstr.Text = 0.ToString();
                    Form1.gameOver();
                }
                this.Close();
            }
        }
    }
}
