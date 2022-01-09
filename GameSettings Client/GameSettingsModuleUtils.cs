using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using NetworkModules.GameSettings.Backend;
using NetworkModules.GameSettings.Backend.Commands;

namespace NetworkModules.GameSettings
{
    public static class GameSettingsModuleUtils
    {
        public static void SendSettingsToServer()
        {
            SettingsCommand cmd = new GameSettingsChangeCommand(Backend.GameSettings.GetInstance().GetSettings());
            Send(cmd);
        }

        static void Send(SettingsCommand cmd)
        {
            GameSettingsController.GetInstance().Send(cmd);
        }
    }
}
