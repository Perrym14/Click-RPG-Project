﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Trader : BaseNotificationClass
    {
        public string Name { get; set; }

        public ObservableCollection<GameItem> Inventory { get; set; }

        public Trader(string name)
        {
            Name = name;
            Inventory = new ObservableCollection<GameItem>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
        }
    }
}
