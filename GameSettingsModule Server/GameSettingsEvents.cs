using System;
using System.Collections.Generic;
using System.Text;

namespace GameSettingsModule
{
    public interface GameSettingsEvents
    {
        public void OnGameSettingsInicjalized(GameSettings settings);
    }
}
