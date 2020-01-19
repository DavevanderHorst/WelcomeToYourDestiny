using System;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Updaters
{
    public class RegenerateAttribute : IUpdate
    {
        public string Name { get; set; }
        public double Current { get; set; }
        public double OldCurrent { get; set; }
        public int Max { get; set; }
        public double RegenRatePerSecond { get; set; }
        private TimeSpan RegenInterval => TimeSpan.FromSeconds(1);

        private TimeSpan _previousRegenUpdateGameTime;

        public void Update(GameTime gameTime)
        {
            var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(_previousRegenUpdateGameTime);
            if (elapsedTimeSincePrevious >= RegenInterval)
            {
                //Every Second
                Current = Math.Min(Current + (RegenRatePerSecond * elapsedTimeSincePrevious.Seconds), Max);
                _previousRegenUpdateGameTime = gameTime.Elapsed;
            }
        }
    }
}
