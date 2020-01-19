using System;
using System.Collections.Generic;
using System.Text;

namespace WelcomeToYourDestiny.Monsters
{
    public class MonsterStats
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public bool InCombat { get; set; } = false;
        public int GivesXp { get; set; }

        public MonsterStats(string name)
        {
            Name = name;
            SetOtherStats();
        }

        private void SetOtherStats()
        {
            Random random = new Random();
            switch (Name)
            {
                case "rabbit":
                    Strength = random.Next(2,5);
                    Speed = random.Next(5, 8);
                    MaxHitPoints = random.Next(20, 30);
                    CurrentHitPoints = MaxHitPoints;
                    GivesXp = 20;
                    break;
                case "cat":
                    Strength = random.Next(4,7);
                    Speed = random.Next(6, 9);
                    MaxHitPoints = random.Next(40, 50);
                    CurrentHitPoints = MaxHitPoints;
                    GivesXp = 30;
                    break;
                case "dog":
                    Strength = random.Next(5,9);
                    Speed = random.Next(5, 10);
                    MaxHitPoints = random.Next(40, 60);
                    CurrentHitPoints = MaxHitPoints;
                    GivesXp = 40;
                    break;
            }
        }
    }
}
