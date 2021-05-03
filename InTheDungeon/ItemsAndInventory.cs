using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace InTheDungeon
{
    public abstract class _Item
    {
        public string Name;
        static public _Item Drop()
        {
            Random r = new Random();
            if (r.Next(0, 2) == 1)
            {
                int chance = r.Next(0, 101);
                if (chance <= 10) return new __Weapon("Острый меч", r.Next(75, 100));
                if (chance <= 40 && chance > 10) return new __Weapon("Хороший меч", r.Next(30, 75));
                if (chance > 40) return new __Weapon("Очередной меч", r.Next(1, 30));
                return new __Weapon("Зубочистка", 1);
            }
            else
            {
                int chance = r.Next(0,101);
                if (chance <= 10) return new __Armor("Крепкий доспех", r.Next(75,100));
                if (chance <= 40 && chance > 10) return new __Armor("Хороший доспех", r.Next(30, 75));
                if (chance > 40) return new __Armor("Очередной доспех", r.Next(1, 30));
                return new __Armor("Тряпка-доспех", 1);
            }
        }
    }

    public class __Armor : _Item
    {
        private double resist;
        public __Armor(string NM, double RST)
        {
            Name = NM+$", з-{RST}";
            resist = RST;
        }
        public double GetResist()
        {
            return resist;
        }
    }
    public class __Weapon : _Item
    {
        private double damage;
        public __Weapon(string NM, double WP)
        {
            Name = NM+$", у-{WP}";
            damage = WP;
        }
        public double GetDamage()
        {
            return damage;
        }
    }
    public class __Potion : _Item
    {
        double healingValue;
        public __Potion(string NM, double HV)
        {
            Name = NM+$", л-{HV}";
            healingValue = HV;
        }
        public double GetHV()
        {
            return healingValue;
        }
    }

    public class _Inventory
    {
        public List<_Item> I = new List<_Item>();

        //===================Публичные методы===========================
        public void InventoryAdd(_Item item)
        {
            if (TestForSpace())
            {
                MessageBox.Show("Инвентарь полон","Уведомление");
                return;
            }
            MessageBox.Show($"Вы нашли {item.Name}", "Поздравляем");
            I.Add(item);
            if (TestForSpace())
            {
                MessageBox.Show("Инвентарь заполнен, выбросите что-нибудь, иначе следующий предмет испарится", "Уведомление");
                return;
            }
        }
        public void InventoryTurf(int num)
        {
            I.RemoveAt(num);
        }
        //====================Приватные методы===========================
        private bool TestForSpace()
        {
            if (I.Count <= 20)
            {
                return false;
            }
            return true;
        }
    }
}
