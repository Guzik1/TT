using MessagePack;
using NetworkModules.GameSettings.Backend.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkModules.GameSettings.Backend
{
    [Union(5, typeof(GameSettingsChangeCommand))]
    [Union(3, typeof(GameSettingsSetCommand))]
    [MessagePackObject]
    public abstract class SettingsCommand
    {
        public abstract void Execute();
    }
}
