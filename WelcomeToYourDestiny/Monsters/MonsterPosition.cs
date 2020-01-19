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

        public void MoveUp()
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn -Map.MapWidth]))
            {
                MoveTo(-Map.MapWidth);
            }
            else
            {
                MoveRight();
            }
        }

        public void MoveRight()
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn + 1]))
            {
                MoveTo(+1);
            }
            else
            {
                MoveDown();
            }
        }
        public void MoveDown()
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn + Map.MapWidth]))
            {
                MoveTo(Map.MapWidth);
            }
            else
            {
                MoveLeft();
            }
        }
        public void MoveLeft()
        {
            if (_checker.CanMonsterMoveInDirection(Map.Map[NumberOfArrayMonsterIsIn - 1]))
            {
                MoveTo(-1);
            }
            else
            {
                MoveUp();
            }
        }

        public void MoveTo(int movement)
        {
            var player = _world.Get<PlayerPosition>();
            if (player.NumberOfArrayPlayerIsIn == NumberOfArrayMonsterIsIn)
            {
                MoveMessages message = new MoveMessages(_world);
                message.MonsterMoveOutMessage();
                _world.LinesTypedInMessageBox++;
            }
            Changed = true;
            OldNumberOfArrayMonsterIsIn = NumberOfArrayMonsterIsIn;
            NumberOfArrayMonsterIsIn += movement;
            
            if (player.NumberOfArrayPlayerIsIn == NumberOfArrayMonsterIsIn)
            {
                MoveMessages message = new MoveMessages(_world);
                message.MonsterMoveInMessage();
                _world.LinesTypedInMessageBox++;
            }
        }
    }
}
