﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Engine.Models
{
    public class Monster : LivingBeing
    {
        
        public string ImageName { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int currentHitPoints,
             int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int gold) : base(name, maximumHitPoints, currentHitPoints, gold)
        { 
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
