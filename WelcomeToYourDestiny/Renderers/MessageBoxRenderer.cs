using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Renderers
{
    public class MessageBoxRenderer : IRender
    {
        private readonly World _world;
        private readonly int startTypingFromTop = 11;

        public MessageBoxRenderer(World world)
        {
            _world = world;
        }

        public void Render(GameTime gameTime)
        {
            Queue<string> messages;
            if (_world.Has<Queue<string>>())
            {
                messages = _world.Get<Queue<string>>();
            }
            else
            {
                messages = new Queue<string>(2);
            }

            if (messages.Count > 0)
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;
                
                Console.SetCursorPosition(1,startTypingFromTop + _world.LinesTypedInMessageBox);
                Console.Write(messages.Dequeue());

                Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
            }
        }
    }
}
