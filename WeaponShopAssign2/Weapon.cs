using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Weapon
    {
        public string weaponName;
        public int range;
        public int damage;
        public double weight;
        public double cost;

        public Weapon left;
        public Weapon right;

        public Weapon next;

        public Weapon(string n, int rang, int dam, double w, double c)
        {
            weaponName = n;
            damage = dam;
            range = rang;
            weight = w;
            cost = c;

            //my code
            left = null;
            right = null;
            next = null;
        }
    }
}
