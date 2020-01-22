using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Monsters
{
    public class MonsterMoveController : IUpdate
    {
        public TimeSpan MonsterMoveInterval => TimeSpan.FromSeconds(_interval);
        private double _interval;
        public TimeSpan PreviousMonster;
        public readonly MonsterPosition MonsterPosition;
        readonly Random _random = new Random();
        public MonsterStats MonsterStats;

        public MonsterMoveController(MonsterPosition monsterPosition, MonsterStats monsterStats)
        {
            MonsterStats = monsterStats;
            MonsterPosition = monsterPosition;

            _interval = _random.Next(1, 6);
        }

        public void Update(GameTime gameTime)
        {
            int nextMove = _random.Next(0, 4);
            _interval = _random.Next(20, 50) / 10.0;
            switch (nextMove)
            {
                case 0:
                    MonsterPosition.MoveUp(MonsterStats);
                    break;
                case 1:
                    MonsterPosition.MoveRight(MonsterStats);
                    break;
                case 2:
                    MonsterPosition.MoveDown(MonsterStats);
                    break;
                case 3:
                    MonsterPosition.MoveLeft(MonsterStats);
                    break;
            }
        }
    }
}
