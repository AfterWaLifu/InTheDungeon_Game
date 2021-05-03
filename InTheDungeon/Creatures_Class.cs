using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InTheDungeon
{
    public abstract class Creature
    {
        public string Name;
        public double Health;
        public int Strength;
        public int Agility;
        //=================Боевые и тд=======================
        public double Attack(int STR, double DMGSpecial)
        {
            return Convert.ToDouble(STR) *DMGSpecial;
        }
        public bool Dodge()
        {
            Random random = new Random();
            if (random.Next(0, 101) < Agility)
            {
                return true;
            }
            else { return false; }
        }
        public void ChangeHP(double value)
        {
            this.Health += value;
        }
    }
    class _Monster : Creature
    {
        public double Resist;
        public int expForKilling;
        public int ico;
        public _Monster(int num)
        {
            ico = num;
            toConfigMonster(ico);
            expForKilling = (int)Strength + (int)Resist/3 + (int)Health/10;
        }
        public double Attack()
        {
            return Strength;
        }
        void toConfigMonster(int num)
        {
            Random r = new Random();
            switch (num)
            {
                case 5:
                    Name = "Слизень, похож на желе";
                    Health = 10;
                    Strength = 1;
                    Agility = 0;
                    Resist = 0;
                    break;
                case 6:
                    Name = "Волк, но откуда он в пещере?";
                    Health = 30;
                    Strength = 5;
                    Agility = 10;
                    Resist = 20;
                    break;
                case 7:
                    Name = "Людоящер, наверное";
                    Health = 100;
                    Strength = 30;
                    Agility = 50;
                    Resist = 50;
                    break;
                case 8:
                    Name = "Злой, очень злой дракон";
                    Health = 500;
                    Strength = 0;
                    Agility = 10;
                    Resist = 50;
                    break;
            }
        }
    }
    public class _Character : Creature
    {

        public int Level;
        public int Experience;
        public __Armor CurrentArmor;
        public __Weapon CurrentWeapon;
        public _Inventory inventory = new _Inventory();
        public _Character()
        {
            Name = "Иван Тёмный Холм";
            Health = 10;
            Strength = 3;
            Agility = 3;
            Level = 1;
            Experience = 0;
            CurrentArmor = new __Armor("Тельняшка",1);
            CurrentWeapon = new __Weapon("Деревянный меч", 1);
        }
        //====================================
        public void Use(int num)
        {
            switch (this.inventory.I[num].GetType().Name)
            {
                case "__Armor":
                    __Armor toUse1 = (__Armor)this.inventory.I[num];
                    this.inventory.I[num] = CurrentArmor;
                    CurrentArmor = toUse1;
                    break;
                case "__Weapon":
                    __Weapon toUse2 = (__Weapon)this.inventory.I[num];
                    this.inventory.I[num] = CurrentWeapon;
                    CurrentWeapon = toUse2;
                    break;
                case "__Potion":
                    __Potion toUse3 = (__Potion)this.inventory.I[num];
                    this.ChangeHP(toUse3.GetHV());
                    this.inventory.InventoryTurf(num);
                    break;
            }
        }
        public double Attack()
        {
            return Strength * (1.0+(CurrentWeapon.GetDamage()/100.0));
        }
        //==================Уровни, опыт, рост характеристик=======
        private void Progeresser()
        {
            if (Experience > Level*10 && Level < 10)
            {
                ImproveStrength(Level);
                ImproveAgility(Level);
                LevelUp();
                Experience -= (Level-1)*10;
            }
            else if (Level >= 10 && Experience >= 100)
            {
                ImproveStrength(1);
                ImproveAgility(1);
                if (Strength > 60) Strength = 60;
                if (Agility > 66) Agility = 66;
                Experience -= (Level) * 10;
            }
        }
        public void ExperienceAdd(int exp) 
        {
            Experience+=exp;
            Progeresser();
        }
        private void LevelUp()
        {
            Level++;
        }
        private void ImproveStrength(int value)
        {
            Strength +=value;
        }
        private void ImproveAgility(int value)
        {
            Agility += value;
        }
    }
}
