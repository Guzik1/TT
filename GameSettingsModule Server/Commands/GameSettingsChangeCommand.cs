using MessagePack;
using ServerCommands;
using ServerDataStruct.Tools;
using System.Collections.Generic;

namespace GameSettingsModule.Commands
{
    /// <summary>
    /// [IN] from host.
    /// </summary>
    [MessagePackObject]
    public class GameSettingsChangeCommand : GameSettingsCommand
    {
        [Key(0)] public DictionaryList Dictionary;

        public override void Execute(GameSettingsController controller, Connection con)
        {
            Dictionary<string, int> settings;
            settings = DictionaryToListConverter.Deserialize(Dictionary);

            controller.GetGameSettings().SetSettings(settings);

            GameSettingsCommand cmd = new GameSettingsSetCommand(settings);
            controller.SendToAllWithoutConnection(con, cmd);
        }
    }
}
