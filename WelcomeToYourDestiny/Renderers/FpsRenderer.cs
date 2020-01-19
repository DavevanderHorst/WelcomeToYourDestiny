using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Renderers
{
    public class FpsRenderer : IRender
    {
        private readonly World _world;

        public FpsRenderer(World world)
        {
            _world = world;
        }
        public void Render(GameTime gameTime)
        {
            if (_world.Has<FpsCount>())
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;
                
                Console.SetCursorPosition(109, 0);
                Console.Write($"[FPS: {_world.Get<FpsCount>().FramesPerSecond, 4}]");
                Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
            }
        }
    }
}
