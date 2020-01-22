using System;
using WelcomeToYourDestiny.Renderers;
using WelcomeToYourDestiny.Updaters;

namespace WelcomeToYourDestiny.Player
{
    public class PlayerStats
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public double Speed { get; set; }
        public bool InCombat { get; set; }
        public HealthComponent HealthComponent { get; set; }
        public ManaComponent ManaComponent { get; set; }
        public ExperienceBar XpBar { get; set; }
        public PlayerStats(string name, HealthComponent healthComponent, ManaComponent mana, ExperienceBar xpBar)
        {
            Name = name;
            Level = 1;
            Strength = 11;
            Speed = 11;
            HealthComponent = healthComponent;
            ManaComponent = mana;
            XpBar = xpBar;
            InCombat = false;
        }

        public void LevelUp()
        {
            this.HealthComponent.Health.Max += 8;
            this.ManaComponent.Mana.Max += 4;
            Strength += 1;
            Speed += 1;
            Level += 1;
        }
    }
}
