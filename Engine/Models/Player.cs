using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : LivingBeing
    {
        private string _characterClass;
        private int _experiencePoints;
        private int _currentHitPoints;


        public Player(string name, string characterClass, int experiencePoints,
            int maximumHitPoinrs, int currentHitPoints, int gold) :
            base(name, maximumHitPoinrs, currentHitPoints, gold)
        {
            _characterClass = characterClass;
            _experiencePoints = experiencePoints;
            _currentHitPoints = currentHitPoints;

            Quests = new ObservableCollection<QuestStatus>();
        }

        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }

        }

        public int ExperiencePoints

        {
            get { return _experiencePoints; }
            private set
            {
                _experiencePoints = value;

                OnPropertyChanged();

                SetLevelAndMaximumHitPoints();
            }
        }

        public ObservableCollection<QuestStatus> Quests { get; }

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

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        //Handle level up
        public event EventHandler OnLeveledUp;

        private void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 50) + 1;

            if (Level != originalLevel)
            {
                MaximumHitPoints = Level * 10;

                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }

    }
}
