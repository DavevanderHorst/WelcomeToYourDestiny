using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Player;


namespace WelcomeToYourDestiny.Updaters
{
    public class ConsoleInputSystem : IUpdate
    {
        private readonly World _world;

        public ConsoleInputSystem(World world)
        {
            _world = world;
        }

        public void Update(GameTime gameTime)
        {
            PlayerInput playerConsoleInput;

            if (_world.Has<PlayerInput>())
            {
                playerConsoleInput = _world.Get<PlayerInput>();
            }
            else
            {
                playerConsoleInput = new PlayerInput();
                _world.Set(playerConsoleInput);
            }
            if (Console.KeyAvailable)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                playerConsoleInput.SetCurrentInput(consoleKeyInfo);
            }
            else
            {
                playerConsoleInput.SetCurrentInput(default);
            }
        }
    }
}
