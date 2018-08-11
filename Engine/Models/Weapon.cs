﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; }
        public int MaximumDamage { get; }

        public Weapon(int itemTypeID, string name, int price, int mininumDamage, int maximumDamage)
            : base(itemTypeID, name, price, true)
        {
            MinimumDamage = mininumDamage;
            MaximumDamage = maximumDamage;

        }

        public new Weapon Clone()
        {
           return  new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
        
    }
}
