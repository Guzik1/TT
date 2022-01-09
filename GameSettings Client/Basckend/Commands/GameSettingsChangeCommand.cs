using Assets.Scripts.Network;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetworkModules.GameSettings.Backend.Commands
{
    /// <summary>
    /// [OUT]
    /// </summary>
    [MessagePackObject]
    public class GameSettingsChangeCommand : SettingsCommand
    {
        [Key(0)]
        public DictionaryList Dictionary;

        public GameSettingsChangeCommand() { }

        public GameSettingsChangeCommand(Dictionary<string, int> dictionary) {
            Dictionary = DictionaryToListConverter.Serialize(dictionary);
        }

        public override void Execute(){ }
    }
}
