using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;

namespace WelcomeToYourDestiny.PlayerMessagesBox
{
    public class MoveMessages
    {
        private readonly World _world;
        private readonly Queue<string> _messageBox;

        public MoveMessages(World world)
        {
            _world = world;
            _messageBox = _world.Get<Queue<string>>();
        }
        
        public void WrongDirectionMessage(int wrongDirectionCount) //for if your move is not possible
        {
            if (wrongDirectionCount == 0)
            {
                _messageBox.Enqueue("That direction is not possible");
            }
            else if (wrongDirectionCount == 1)
            {
                _messageBox.Enqueue("I said : That direction is not POSSIBLE!!!");
            }
            else if (wrongDirectionCount == 2)
            {
                _messageBox.Enqueue("OH MY GOD!!!!!!");
            }
            else
            {
                _messageBox.Enqueue("You must be the dumbest little fuck on earth...");
            }
        }

        public void LevelTooLowMessage()
        {
            _messageBox.Enqueue("Your too low level to enter here!!");
        }

        public void InCombatMessage()
        {
            _messageBox.Enqueue("You cant move when your in combat!  kuch*COWARD*kuch.");
        }

        public void MonsterMoveOutMessage()
        {
            _messageBox.Enqueue("A monster moves away from you...");
        }

        public void MonsterMoveInMessage()
        {
            _messageBox.Enqueue("A monster moves into your personal space...");
        }

        public void MonstersInRoomMessage(int monstersInSameRoom)
        {
            if (monstersInSameRoom == 1)
            {
                _messageBox.Enqueue("A monster patrols here.");
            }
            else
            {
                _messageBox.Enqueue($"{monstersInSameRoom} monsters patrols here.");
            }
        }

        public void NoMonsterToFightMessage()
        {
            _messageBox.Enqueue("There is no monster to fight here.");
        }
    }
}
