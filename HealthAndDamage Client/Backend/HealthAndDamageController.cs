using Assets.Scripts.NetworkModules;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Modules.HealthAndDamage.Backend
{
    public class HealthAndDamageController : ChannelController
    {
        public HealthAndDamageController(int chanelId) : base(chanelId)
        {
            _instance = this;
        }

        #region Singleton
        static HealthAndDamageController _instance;

        public static HealthAndDamageController GetInstance()
        {
            return _instance;
        }
        #endregion

        public override void OnChanelDataRecived(byte[] byteArray)
        {
            HealthAndDamageCommand cmd = MessagePackSerializer.Deserialize<HealthAndDamageCommand>(byteArray);

            try
            {
                cmd.Execute();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error in { GetType() }: { e.Message }");
            }
        }

        protected override byte[] SerialzeCommand(object obj)
        {
            HealthAndDamageCommand objCast = (HealthAndDamageCommand)obj;
            return MessagePackSerializer.Serialize(objCast);
        }
    }
}
