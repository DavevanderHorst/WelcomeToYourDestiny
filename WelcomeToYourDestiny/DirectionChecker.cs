using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Player;
using WelcomeToYourDestiny.PlayerMessagesBox;

namespace WelcomeToYourDestiny
{
    public class DirectionChecker
    {
        private readonly World _world;
        private readonly MoveMessages _message;

        public DirectionChecker(World world)
        {
            _world = world;
            _message = new MoveMessages(_world);

        }
        public bool CanPlayerMoveInDirection(MapPointDetails mapPointDetails)
        {
            var player = _world.Get<PlayerStats>();
            if (player.InCombat == true)
            {
                _message.InCombatMessage();
                _world.LinesTypedInMessageBox++;
                return false;
            }
            if (mapPointDetails.Description == "Impenetrable terrain!")
            {
                _message.WrongDirectionMessage(_world.WrongDirectionCount++);
                _world.LinesTypedInMessageBox++;
                return false;
            }
            if (mapPointDetails.LevelNeededToEnter > player.Level)
            {
                _message.LevelTooLowMessage();
                _world.LinesTypedInMessageBox++;
                return false;
            }
            if (_world.LinesTypedInMessageBox > 0)
            {
                RemoveExtraText();
                _world.LinesTypedInMessageBox = 0;
                _world.WrongDirectionCount = 0;
            }

            if (_world.LinesTypedInCombatBox > 0)
            {
                RemoveCombatText();
                _world.LinesTypedInCombatBox = 0;
            }
            return true;
        }
        public void RemoveExtraText()
        {
            var prevPositionTop = Console.CursorTop;
            var prevPositionLeft = Console.CursorLeft;
            Console.SetCursorPosition(0,12);
            for (int i = 0; i < _world.LinesTypedInMessageBox; i++)
            {
                Console.Write(new String(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
        }

        public void RemoveCombatText()
        {
            var prevPositionTop = Console.CursorTop;
            var prevPositionLeft = Console.CursorLeft;
            Console.SetCursorPosition(51,6);
            for (int i = 0; i < _world.LinesTypedInCombatBox; i++)
            {
                Console.SetCursorPosition(51,6 + i);
                Console.Write("                                                           ");
            }
            Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
        }

        internal bool CanMonsterMoveInDirection(MapPointDetails mapPointDetails)
        {
            if (mapPointDetails.Description == "Impenetrable terrain!"||mapPointDetails.MonsterCanPass == false)
            {
                return false;
            }
            return true;
        }
    }
}
