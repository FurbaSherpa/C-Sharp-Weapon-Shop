using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public int numItems;
        public double money;

        Weapon head;
        private static Backpack b;

        public Player(string n, double m)
        {
            name = n;
            money = m;
            numItems = 0;
           
            b = new Backpack(80, 0);
        }
        public void buy(Weapon w)
        {
            Weapon newWeapon = new Weapon(w.weaponName, w.range, w.damage, w.weight, w.cost);
            if(head == null)
            {
                b.insert(w.weaponName, w.range, w.damage, w.weight, w.cost);
                money = money-w.cost;
                Console.WriteLine("Added");
                head = newWeapon;
                numItems++;
            }
            Weapon curr = head;
            while(curr != null)
            {
                if (curr.weaponName == w.weaponName)
                {
                    b.insert(w.weaponName, w.range, w.damage, w.weight, w.cost);
                    withdraw(w.cost);
                    curr = newWeapon;
                    numItems++;
                }
                curr = curr.next;
            }
            b.insert(w.weaponName, w.range, w.damage, w.weight, w.cost);
            money -= w.cost;
            curr = newWeapon;
            numItems++;
        }

        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (numItems == 10) full = true;
            return full;
        }
        
        public void printCharacter()
        {
            Console.WriteLine(" Name:"+name+"\n Money:"+money);
            printBackpack();
        }

        public void printBackpack()
        {
            b.inOrder();
        }
    }
}
