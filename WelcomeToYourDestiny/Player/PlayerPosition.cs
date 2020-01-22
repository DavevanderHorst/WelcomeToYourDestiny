using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;
using WelcomeToYourDestiny.PlayerMessagesBox;

namespace WelcomeToYourDestiny.Player
{
    public class PlayerPosition
    {
        private readonly World _world;
        public MapLevelDetails Map { get; set; }
        public int NumberOfArrayPlayerIsIn { get; set; }
        public int OldNumberOfArrayPlayerIsIn { get; set; }
        public bool Changed { get; set; }

        public PlayerPosition(MapLevelDetails map, World world)
        {
            _world = world;
            Map = map;
        }

        public void MoveDown()
        {
            MoveTo(Map.MapWidth);
        }

        public void MoveUp()
        {
            MoveTo(-Map.MapWidth);
        }

        public void MoveLeft()
        {
            MoveTo(-1);
        }

        public void MoveRight()
        {
            MoveTo(+1);
        }

        public void MoveTo(int movement)
        {
            DirectionChecker checker = new DirectionChecker(_world);
            if (checker.CanPlayerMoveInDirection(Map.Map[NumberOfArrayPlayerIsIn + movement]))
            {
                Changed = true;
                OldNumberOfArrayPlayerIsIn = NumberOfArrayPlayerIsIn;
                NumberOfArrayPlayerIsIn += movement;
                MonsterMoveController[] monsters;
                if (_world.Has<MonsterMoveController[]>())
                {
                    monsters = _world.Get<MonsterMoveController[]>();
                }
                else
                {
                    monsters = new MonsterMoveController[1];
                }

                if (monsters.Length > 1)
                {
                    foreach (var monster in monsters)
                    {
                        if (monster.MonsterPosition.NumberOfArrayMonsterIsIn == NumberOfArrayPlayerIsIn)
                        {
                            _world.LinesTypedInMessageBox++;
                            MoveMessages message = new MoveMessages(_world);
                            message.MonstersInRoomMessage(monster.MonsterStats.Name);
                        }
                    }
                }
            }
        }
    }
}
