using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Player
{
    public class PlayerMovementSystem : IUpdate
    {
        private readonly World _world;

        public PlayerMovementSystem(World world)
        {
            _world = world;
        }

        public void Update(GameTime gameTime)
        {
            if (_world.Has<PlayerInput>())
            {
                var input = _world.Get<PlayerInput>();

                PlayerPosition playerPosition;
                if (_world.Has<PlayerPosition>())
                { 
                    playerPosition = _world.Get<PlayerPosition>();
                }
                else
                {
                    playerPosition = new PlayerPosition(_world.Get<MapLevelDetails>(), _world);
                }

                if (input.Current != default)
                {
                    switch (input.Current.Key)
                    {
                        case ConsoleKey.DownArrow:
                            playerPosition.MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            playerPosition.MoveUp();
                            break;
                        case ConsoleKey.LeftArrow:
                            playerPosition.MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            playerPosition.MoveRight();
                            break;
                        case ConsoleKey.F:
                            CombatController combat = new CombatController();
                            combat.StartFighting(_world);
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    playerPosition.Changed = false;
                }
            }
        }
    }
}

