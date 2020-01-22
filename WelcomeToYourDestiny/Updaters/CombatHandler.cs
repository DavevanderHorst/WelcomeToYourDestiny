using System;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;
using WelcomeToYourDestiny.Player;
using WelcomeToYourDestiny.PlayerMessagesBox;

namespace WelcomeToYourDestiny.Updaters
{
    public class CombatHandler : IUpdate
    {
        private bool _startUpdate;
        private readonly World _world;
        private MonsterStats _monster;
        private PlayerStats _player;
        private TimeSpan _previousPlayerAttackGameTime;
        private TimeSpan _previousMonsterAttackGameTime;
        private TimeSpan _howFastPlayerHits;
        private TimeSpan _howFastMonsterHits;
        private readonly CombatMessages _messages;
        readonly Random _random = new Random();

        public CombatHandler(World world)
        {
            _world = world;
            _messages = new CombatMessages(world);
        }
        public void ExchangeBlowsTillDeath(MonsterStats monsterStat, PlayerStats playerStats)
        {
            _player = playerStats;
            _monster = monsterStat;
            _startUpdate = true;
            _howFastPlayerHits = TimeSpan.FromSeconds(3-(_player.Speed*0.08));
            _howFastMonsterHits = TimeSpan.FromSeconds(3-(_monster.Speed*0.08));
            _messages.StartFightMessage(_monster.Name);
        }

        public void Update(GameTime gameTime)
        {
            if (_startUpdate)
            {
                var elapsedTimeSincePreviousPlayerAttack = gameTime.Elapsed.Subtract(_previousPlayerAttackGameTime);
                if (elapsedTimeSincePreviousPlayerAttack >= _howFastPlayerHits)
                {
                    int damage = _random.Next(3, 6) + (int)(_player.Strength * 0.4); // player attacks
                    _monster.CurrentHitPoints -= damage;
                    if (_monster.CurrentHitPoints <= 0)
                    {
                        _messages.VictoryMessage(_monster.Name);
                        int experience = (_monster.Speed + _monster.Strength) * 3;
                        if(_player.XpBar.GainedExperience(experience))       // if true, player gained level.
                        {
                            _player.LevelUp();
                        }
                        _messages.GainedExperienceMessage(experience);
                        _player.InCombat = false;
                        _startUpdate = false;

                    }
                    else
                    {
                        _messages.PlayerDamageMessage(damage, _monster.CurrentHitPoints);
                        _previousPlayerAttackGameTime = gameTime.Elapsed;
                    }
                }

                if (_monster.CurrentHitPoints > 0)          //monster attacks if still alive
                {
                    var elapsedTimeSincePreviousMonsterAttack = gameTime.Elapsed.Subtract(_previousMonsterAttackGameTime);
                    if (elapsedTimeSincePreviousMonsterAttack >= _howFastMonsterHits)
                    {
                        int damage = _random.Next(3, 6) + (int)(_monster.Strength * 0.4);
                        _player.HealthComponent.Health.Current -= damage;
                        _messages.MonsterDamageMessage(damage, _monster.Name, (int)_player.HealthComponent.Health.Current);
                        _previousMonsterAttackGameTime = gameTime.Elapsed;
                    }

                    if (_player.HealthComponent.Health.Current <= 0)
                    {
                        _messages.DefeatMessage(_monster.Name);
                        _startUpdate = false;
                    }
                }
            }
        }
    }
}
