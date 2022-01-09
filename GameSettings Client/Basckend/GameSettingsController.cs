using Assets.Scripts.NetworkModules;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetworkModules.GameSettings.Backend
{
    public class GameSettingsController : ChannelController
    {
        public GameSettingsController(int chanelId) : base(chanelId) {
            _instance = this;
        }

        #region Singleton
        static ChannelController _instance;

        public static ChannelController GetInstance()
        {
            return _instance;
        }
        #endregion

        public override void OnChanelDataRecived(byte[] byteArray)
        {
            SettingsCommand cmd = MessagePackSerializer.Deserialize<SettingsCommand>(byteArray);

            try
            {
                cmd.Execute();
            }
            catch (Exception e)
            {
                Debug.LogError("Error in " + GetType() + ": " + e.Message);
            }
        }

        protected override byte[] SerialzeCommand(object obj)
        {
            SettingsCommand objCast = (SettingsCommand)obj;
            return MessagePackSerializer.Serialize(objCast);
        }
    }
}
