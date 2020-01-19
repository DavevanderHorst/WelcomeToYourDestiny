using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Renderers
{
    public class CombatMessages : IRender
    {
        private readonly World _world;
        public int Left { get; set; } = 51;
        public int Top { get; set; } = 6;

        public CombatMessages(World world)
        {
            _world = world;
        }
        public void Render(GameTime gameTime)
        {
            List<string> messages;
            if (_world.Has<List<string>>())
            {
                messages = _world.Get<List<string>>();
            }
            else
            {
                messages = new List<string>(2);
            }

            if (messages.Count > 0)
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;
                
                Console.SetCursorPosition(Left,Top + _world.LinesTypedInCombatBox);
                Console.Write(messages[0]);
                messages.RemoveAt(0);
                _world.LinesTypedInCombatBox++;
                Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
            }
        }
    }
}
