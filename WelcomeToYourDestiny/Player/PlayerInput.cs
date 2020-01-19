﻿
using System;

namespace WelcomeToYourDestiny.Player
{
    public class PlayerInput
    {
        public ConsoleKeyInfo PreviousInput { get; set; }
        public ConsoleKeyInfo Current { get; set; }

        public void SetCurrentInput(in ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo != default)
            {
                PreviousInput = Current;
            }

            Current = consoleKeyInfo;
        }
    }
}
