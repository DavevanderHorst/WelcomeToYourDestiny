using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;
using WelcomeToYourDestiny.Player;
using WelcomeToYourDestiny.PlayerMessagesBox;
using WelcomeToYourDestiny.Updaters;

namespace WelcomeToYourDestiny.GameCoreComponents
{
    public class CombatController
    {
        public void StartFighting(World world)
        {
            var playerPos = world.Get<PlayerPosition>();
            var monsters = world.Get<MonsterMoveController[]>();
            MonsterStats monster = null;
            foreach (var monsterMove in monsters)
            {
                if (playerPos.NumberOfArrayPlayerIsIn == monsterMove.MonsterPosition.NumberOfArrayMonsterIsIn)
                {
                    monster = monsterMove.MonsterStats;
                    break;
                }
            }

            if (monster == null)
            {
                MoveMessages message = new MoveMessages(world);
                message.NoMonsterToFightMessage();
                world.WrongDirectionCount++;
            }
            else
            {
                PlayerStats player = world.Get<PlayerStats>();
                player.InCombat = true;
                monster.InCombat = true;
                CombatHandler handler = world.Get<CombatHandler>();
                handler.ExchangeBlowsTillDeath(monster, player);
            }
        }
    }
}
