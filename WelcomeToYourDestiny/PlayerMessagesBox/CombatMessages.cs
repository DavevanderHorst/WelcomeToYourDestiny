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

        public void StartFightMessage(string name)
        {
            _combatMessages.Add($"You charge towards the {name}. ATTACK!!");
        }
        public void PlayerDamageMessage(int damage, int monsterHitPoints)
        {
            _combatMessages.Add($"You swing and hit for {damage} damage. The monster has {monsterHitPoints} hp left.");
        }

        public void MonsterDamageMessage(int damage, string name, int playerHealth)
        {
            _combatMessages.Add($"The {name} hits you for {damage} damage. You have {playerHealth} hp left.");
        }

        public void VictoryMessage(string name)
        {
            _combatMessages.Add($"You kill the {name}. You feel strong.");
        }

        public void DefeatMessage(string name)
        {
            _combatMessages.Add($"The {name} lands a devestating blow. You die!");
        }

        internal void GainedExperienceMessage(int experience)
        {
            _combatMessages.Add($"You gained {experience} experience.");
        }
    }
}
