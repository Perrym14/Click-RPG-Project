using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Player : LivingBeing
    {
        private string _characterClass;
        private int _experiencePoints;
        private int _level;

        public Player(string name, string characterClass, int experiencePoints,
            int maximumHitPoinrs, int currentHitPoints, int gold) :
            base(name, maximumHitPoinrs, currentHitPoints, gold)
        {
            _characterClass = characterClass;
            _experiencePoints = experiencePoints;

            Quests = new ObservableCollection<QuestStatus>();
        }
        
    

        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }

        }


        public int ExperiencePoints

        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public ObservableCollection<QuestStatus> Quests { get; set; }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if (Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
