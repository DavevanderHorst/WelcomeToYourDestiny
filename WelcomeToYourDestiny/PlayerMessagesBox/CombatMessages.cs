using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;

namespace WelcomeToYourDestiny.PlayerMessagesBox
{
    public class CombatMessages
    {
        private readonly World _world;
        private readonly List<string> _combatMessages;

        public CombatMessages(World world)
        {
            _world = world;
            _combatMessages = _world.Get<List<string>>();
        }

        public void StartFightMessage()
        {
            _combatMessages.Add("You charge towards the monster. ATTACK!!");
        }
        public void PlayerDamageMessage(int damage, int monsterHitPoints)
        {
            _combatMessages.Add($"You swing and hit for {damage} damage. The monster has {monsterHitPoints} hp left.");
        }

        public void MonsterDamageMessage(int damage)
        {
            _combatMessages.Add($"The monster swings at you and hits you for {damage} damage.");
        }

        public void VictoryMessage()
        {
            _combatMessages.Add($"You kill the monster. You feel strong.");
        }

        public void DefeatMessage()
        {
            _combatMessages.Add($"The monster lands a devestating blow. You die!");
        }

        internal void GainedExperienceMessage(int experience)
        {
            _combatMessages.Add($"You gained {experience} experience.");
        }
    }
}
