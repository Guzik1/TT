using Assets.Scripts.Network;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetworkModules.GameSettings.Backend.Commands
{
    /// <summary>
    /// [IN] Recived from server.
    /// </summary>
    [MessagePackObject]
    public class GameSettingsSetCommand : SettingsCommand
    {
        [Key(0)]
        public DictionaryList Dictionary;

        public override void Execute()
        {
            Dictionary<string, int> settings;

            settings = DictionaryToListConverter.Deserialize(Dictionary);

            GameSettings.GetInstance().SetSettings(settings);
        }
    }
}
