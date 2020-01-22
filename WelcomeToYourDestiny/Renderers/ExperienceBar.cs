using System;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Renderers
{
    public class ExperienceBar : IRender
    {
        private int _xpPoints = 0;
        private int _oldXpPoints = -1;
        public int Left { get; set; } = 51;
        public int Top { get; set; } = 3;
        public int XpNeededForLevel { get; set; } = 100;

        
        public void Render(GameTime gameTime)
        {
            if (_oldXpPoints != _xpPoints)
            {
                _oldXpPoints = _xpPoints;
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;

                var xpString = $"| XP    : {_xpPoints, 4}/{XpNeededForLevel, 4} |";
                Console.SetCursorPosition(Left,Top);Console.Write(xpString);

                Console.SetCursorPosition(prevPositionLeft, prevPositionTop);
            }
        }

        public bool GainedExperience(int experience)
        {
            _xpPoints += experience;
            if (_xpPoints > XpNeededForLevel)
            {
                XpNeededForLevel = XpNeededForLevel * 2 + 10;

                return true;
            }

            return false;
        }
    }
}
