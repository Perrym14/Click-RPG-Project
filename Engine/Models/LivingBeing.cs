﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public abstract class LivingBeing : BaseNotificationClass
    {
        private string _name;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _gold;
        private int _level;

        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            private set
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }

        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            protected set
            {
                _maximumHitPoints = value;
                OnPropertyChanged(nameof(MaximumHitPoints));
            }
        }

        public int Gold
        {
            get { return _gold; }
            private set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public int Level
        {
            get { return _level; }
           protected set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public event EventHandler OnKilled;

        public ObservableCollection<GameItem> Inventory { get; set; }

        public ObservableCollection<GroupedInventoryItem> GroupedInventory { get; set; }

        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();

        public bool IsDead => CurrentHitPoints <= 0;

        protected LivingBeing(string name, int maximumHitPoints, 
            int currentHitPoints, int gold, int level = 1)
        {
            Name = name;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
            Gold = gold;
            Level = level;

            Inventory = new ObservableCollection<GameItem>();
            GroupedInventory = new ObservableCollection<GroupedInventoryItem>();
        }

        public void TakeDamage(int hitPointsOfDamage)
        {
            CurrentHitPoints -= hitPointsOfDamage;

            if(IsDead)
            {
                CurrentHitPoints = 0;
                RaiseOnKilledEvent();
            }
        }

        public void Heal(int hitPointsToHeal)
        {
            CurrentHitPoints += hitPointsToHeal;

            if(CurrentHitPoints > MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            }
        }

        public void CompletelyHeal()
        {
            CurrentHitPoints = MaximumHitPoints;
        }

        public void RecieveGold(int amountOfGold)
        {
            Gold += amountOfGold;
        }

        public void SpendGold(int amountOfGold)
        {
            if(amountOfGold > Gold)
            {
                throw new ArgumentOutOfRangeException($"{Name} only has {Gold} gold, and cannot spend {amountOfGold}");
            }

            Gold -= amountOfGold;
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            if (item.IsUnique)
            {
                GroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else
            {
                if (!GroupedInventory.Any(gi => gi.Item.ItemTypeID == item.ItemTypeID))
                {
                    GroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                GroupedInventory.First(gi => gi.Item.ItemTypeID == item.ItemTypeID).Quantity++;
            }

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            GroupedInventoryItem groupedInventoryItemToRemove = item.IsUnique ?
                GroupedInventory.FirstOrDefault(gi => gi.Item == item) :
                GroupedInventory.FirstOrDefault(gi => gi.Item.ItemTypeID == item.ItemTypeID);

            if (groupedInventoryItemToRemove != null)
            {
                if (groupedInventoryItemToRemove.Quantity == 1)
                {
                    GroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }

            OnPropertyChanged(nameof(Weapons));
        }

        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }


    }
}
