using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        double maxWeight;
        double presentWeight;
        
        public Weapon root;

        public Weapon head;//Linked List

        public Backpack(double maxWeight, double presentWeight)
        {
            this.maxWeight = maxWeight;
            this.presentWeight = presentWeight;
            
            root = null;
            head = null;
        }

        //INSERT
        public void insert(string n, int rang, int dam, double w, double c)
        {
            root = insertWorker(root, n, rang, dam, w, c);
        }
        private Weapon insertWorker(Weapon curr, string n, int rang, int dam, double w, double c)
        {
            if(maxWeight <= w)
            {
                Console.WriteLine("Bag full can not buy");
                return curr;
            }
            if (curr == null)
            {
                presentWeight += w;
                return new Weapon(n, rang, dam, w, c);
            }
            if (string.Compare(curr.weaponName, n) > 0) curr.left = insertWorker(curr.left, n, rang, dam, w, c);
            if (string.Compare(curr.weaponName, n) < 0) curr.right = insertWorker(curr.right, n, rang, dam, w, c);
            return curr;
        }

        //SEARCH
        public string searchNonRec(string n)
        {
            Weapon curr = root;
            while (curr != null)
            {
                if (curr.weaponName == n) return n;
                if (string.Compare(curr.weaponName, n) < 0) curr = curr.right;
                else curr = curr.left;
            }
            return "not found";
        }

        //InOrder Traversal
        public void inOrder()
        {
            inOrderTrav(root);
            Console.WriteLine("\nENd of the list");
        }
        private void inOrderTrav(Weapon curr)
        {
            if (curr == null) return;
            inOrderTrav(curr.left);
            Console.Write("{0} ", curr.weaponName);
            inOrderTrav(curr.right);
        }
    }
}
