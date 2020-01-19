using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Updaters
{
    public class ManaComponent : IUpdate, IRender
    {
        public int Left { get; set; } = 51;
        public int Top { get; set; } = 2;

        public void Update(GameTime gameTime)
        {
            Mana?.Update(gameTime);
        }
        public RegenerateAttribute Mana { get; set; }
        public void Render(GameTime gameTime)
        {
            if (Math.Abs(Mana.OldCurrent - Mana.Current) > 0.001)
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;

                var manaString = $"| Mana  : {Convert.ToInt32(Mana.Current), 4}/{Mana.Max, 4} |";
                Console.SetCursorPosition(Left,Top);Console.Write(manaString);
                Mana.OldCurrent = Mana.Current;

                Console.SetCursorPosition(prevPositionLeft, prevPositionTop);
            }
        }
    }
}
