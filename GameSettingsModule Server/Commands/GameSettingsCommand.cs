using MessagePack;
using ServerCommands;
using ServerDataStruct.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSettingsModule.Commands
{
    /// <summary>
    /// [OUT]
    /// </summary>
    [MessagePackObject]
    public class GameSettingsSetCommand : GameSettingsCommand
    {
        [Key(0)] public DictionaryList Dictionary;

        public GameSettingsSetCommand() { }

        public GameSettingsSetCommand(DictionaryList dictionary)
        {
            Dictionary = dictionary;
        }

        public GameSettingsSetCommand(Dictionary<string, int> dictionary)
        {
            Dictionary = DictionaryToListConverter.Serialize(dictionary);

            /*Console.WriteLine("Setings list count: " + Dictionary.Dictionary.Count);

            foreach(DictionaryObject pair in Dictionary.Dictionary)
                Console.WriteLine(pair.Key + ": " + pair.Value);*/
        }

        public override void Execute(GameSettingsController controller, Connection con)
        {
            
        }
    }
}
