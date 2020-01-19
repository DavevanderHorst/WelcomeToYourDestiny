using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Monsters
{
    public class MonsterMovementSystem : IUpdate
    {
        private readonly World _world;

        public MonsterMovementSystem(World world)
        {
            _world = world;
        }

        public void Update(GameTime gameTime)
        {
            MonsterMoveController[] monsterMoveControllers;
            if (_world.Has<MonsterMoveController[]>())
            {
                monsterMoveControllers = _world.Get<MonsterMoveController[]>();
            }
            else
            {
                monsterMoveControllers = new MonsterMoveController[1];
            }

            foreach (var monsterMoveController in monsterMoveControllers)
            {
                if (!monsterMoveController.MonsterStats.InCombat)
                {
                    var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(monsterMoveController.PreviousMonster);
                    if (elapsedTimeSincePrevious >= monsterMoveController.MonsterMoveInterval)
                    {
                        monsterMoveController.PreviousMonster = gameTime.Elapsed;
                        monsterMoveController.Update(gameTime);
                    }
                    else
                    {
                        monsterMoveController.MonsterPosition.Changed = false;
                    }
                }
            }
        }
    }
}
