using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Updaters
{
    public class HealthComponent : IUpdate, IRender
    {
        public int Left { get; set; } = 51;
        public int Top { get; set; } = 1;

        public RegenerateAttribute Health { get; set; }

        public void Update(GameTime gameTime)
        {
            Health?.Update(gameTime);
        }

        public void Render(GameTime gameTime)
        {
            //var oldBgColor = Console.BackgroundColor;
            //Console.BackgroundColor = Color.Silver;

            if (Math.Abs(Health.OldCurrent - Health.Current) > 0.001)
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;
                Console.SetCursorPosition(Left, Top);
                var currentHealthString = $"| Health: {Health.Current, 4}/{Health.Max, 4} |";
                Console.Write(currentHealthString);
                Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
            }
            // Console.BackgroundColor = oldBgColor;
        }
    }
}
