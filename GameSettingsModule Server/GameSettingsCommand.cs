using GameSettingsModule.Commands;
using MessagePack;
using ServerCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSettingsModule
{
    [Union(3, typeof(GameSettingsSetCommand))]
    [Union(5, typeof(GameSettingsChangeCommand))]
    [MessagePackObject]
    public abstract class GameSettingsCommand
    {
        public abstract void Execute(GameSettingsController controller, Connection con);
    }
}
