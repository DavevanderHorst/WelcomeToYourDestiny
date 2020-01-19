using System;
using System.Diagnostics;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Renderers;

namespace WelcomeToYourDestiny.GameCoreComponents
{
    public class GameEngine
    {
        private readonly IUpdate[] _updateSystems;
        private readonly IRender[] _renderSystems;
        private readonly Stopwatch _gameStopWatch = new Stopwatch();
        private readonly bool _shouldRun = true;
        private TimeSpan _previousElapsedTime;
        public GameTime GameTime { get; } = new GameTime();

        public GameEngine()
        {
        }

        public GameEngine(IUpdate[] updateSystems, IRender[] renderSystems, PlayerRenderSystem player, MonsterRenderSystem monster): this() // what does this 'this' do ??? Lower framerate when removed.
        {
            player.Render(GameTime);
            monster.Render(GameTime);
            _updateSystems = updateSystems;
            _renderSystems = renderSystems;
        }

        public void Start()
        {
            _gameStopWatch.Start();
           
            while (_shouldRun)
            {
                Tick();
            }
        }

        public void Tick()
        {
            var gameTimeElapsed = _gameStopWatch.Elapsed;
            GameTime.RelativeElapsedTime = gameTimeElapsed.Subtract(_previousElapsedTime);

            GameTime.Elapsed = gameTimeElapsed;
            _previousElapsedTime = gameTimeElapsed;

            DoUpdate(GameTime);
            DoRender(GameTime);
        }

        private void DoUpdate(GameTime gameTime)
        {
            foreach (var updateSystem in _updateSystems)
            {
                updateSystem.Update(gameTime);
            }
        }

        private void DoRender(GameTime gameTime)
        {
            foreach (var renderSystem in _renderSystems)
            {
                renderSystem.Render(gameTime);
            }
        }
    }
}
