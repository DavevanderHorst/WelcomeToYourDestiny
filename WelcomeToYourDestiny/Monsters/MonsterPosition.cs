using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Player;
using WelcomeToYourDestiny.PlayerMessagesBox;

namespace WelcomeToYourDestiny.Monsters
{
    public class MonsterPosition
    {
        public MapLevelDetails Map { get; set; }
        public int NumberOfArrayMonsterIsIn { get; set; }
        public int OldNumberOfArrayMonsterIsIn { get; set; }
        public bool Changed { get; set; }
        private readonly DirectionChecker _checker;
        private readonly World _world;

        public MonsterPosition(MapLevelDetails map, World world)
        {
            _world = world;
            Map = map;
            _checker = new DirectionChecker(world);
        }

        public void MoveUp(MonsterStats monster)
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn -Map.MapWidth]))
            {
                MoveTo(-Map.MapWidth, monster);
            }
            else
            {
                MoveRight(monster);
            }
        }

        public void MoveRight(MonsterStats monster)
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn + 1]))
            {
                MoveTo(+1, monster);
            }
            else
            {
                MoveDown(monster);
            }
        }
        public void MoveDown(MonsterStats monster)
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn + Map.MapWidth]))
            {
                MoveTo(Map.MapWidth, monster);
            }
            else
            {
                MoveLeft(monster);
            }
        }
        public void MoveLeft(MonsterStats monster)
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn - 1]))
            {
                MoveTo(-1, monster);
            }
            else
            {
                MoveUp(monster);
            }
        }

        public void MoveTo(int movement, MonsterStats monster)
        {
            var player = _world.Get<PlayerPosition>();
            if (player.NumberOfArrayPlayerIsIn == NumberOfArrayMonsterIsIn)
            {
                MoveMessages message = new MoveMessages(_world);
                message.MonsterMoveOutMessage(monster.Name);
                _world.LinesTypedInMessageBox++;
            }
            Changed = true;
            OldNumberOfArrayMonsterIsIn = NumberOfArrayMonsterIsIn;
            NumberOfArrayMonsterIsIn += movement;
            
            if (player.NumberOfArrayPlayerIsIn == NumberOfArrayMonsterIsIn)
            {
                MoveMessages message = new MoveMessages(_world);
                message.MonsterMoveInMessage(monster.Name);
                _world.LinesTypedInMessageBox++;
            }
        }
    }
}
