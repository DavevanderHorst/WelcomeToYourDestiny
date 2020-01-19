using System;
using System.Collections.Generic;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.MapCreators;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;
using WelcomeToYourDestiny.Player;
using WelcomeToYourDestiny.Renderers;
using WelcomeToYourDestiny.Updaters;

namespace WelcomeToYourDestiny
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSetupScreen();

            var world = new World();
            LevelOne levelOne = new LevelOne();

            var fpsCounter = new FramesPerSecondCounter(world);
            var fpsWriter = new FpsRenderer(world);

            MapLevelDetails map = new MapLevelDetails(25,11); // initialize map
            world.Set(map);
            MapRenderer mapRenderer = new MapRenderer(world);

            Queue<string> playerMessageQueue = new Queue<string>(2);
            world.Set(playerMessageQueue);
            MessageBoxRenderer messageBoxRenderer = new MessageBoxRenderer(world);

            HealthComponent health = new HealthComponent()
            {
                Health = new RegenerateAttribute()
                {
                    Current = 50, Max = 100, Name = "Health", RegenRatePerSecond = 1
                }
            };
            ManaComponent mana = new ManaComponent()
            {
                Mana = new RegenerateAttribute()
                {
                    Current = 30, Max = 60, Name = "Mana", RegenRatePerSecond = 0.2
                }
            };
            ExperienceBar xpBar = new ExperienceBar();

            PlayerStats playerStats = new PlayerStats("Dave", health, mana, xpBar);
            world.Set(playerStats);
            ConsoleInputSystem playerInput = new ConsoleInputSystem(world);
            PlayerMovementSystem playerMovementSystem = new PlayerMovementSystem(world);
            PlayerRenderSystem player = new PlayerRenderSystem(world);
            PlayerPosition playerStartPosition = new PlayerPosition(map, world);  //initialize player
            playerStartPosition.MoveTo(27);
            world.Set(playerStartPosition);

            MonsterMoveController[] monsters = levelOne.CreateMonsters(world, map); //initialize monsters
            world.Set(monsters);
            MonsterMovementSystem monsterMovement = new MonsterMovementSystem(world);
            MonsterRenderSystem monstersRenderer = new MonsterRenderSystem(world);

            List<string> combatMessagesQueue = new List<string>(3);
            world.Set(combatMessagesQueue);
            CombatHandler combatHandler = new CombatHandler(world);
            world.Set(combatHandler);
            CombatMessages combatMessages = new CombatMessages(world);

            var updateSystems = new IUpdate[] {playerInput, playerMovementSystem, combatHandler, monsterMovement, fpsCounter, health, mana}; //Order is important!
            var renderSystems = new IRender[] {player,monstersRenderer, mapRenderer, messageBoxRenderer, combatMessages, fpsCounter, fpsWriter, health, mana, xpBar };

            GameEngine gameEngine = new GameEngine(updateSystems, renderSystems, player, monstersRenderer);
            mapRenderer.PrintMap(map.Map);
            gameEngine.Start();
        }

        public static void StartSetupScreen()
        {
            Console.SetWindowSize(120, 35);
            Console.CursorVisible = false;
        }
    }
}
