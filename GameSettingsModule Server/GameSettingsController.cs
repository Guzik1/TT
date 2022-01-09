using GameSettingsModule.Commands;
using MessagePack;
using ServerCommands;
using System;

namespace GameSettingsModule
{
    public class GameSettingsController : ChannelController
    {
        GameSettings settings = new GameSettings();

        public GameSettingsController(int chanelId, GameController controller) : base(chanelId, controller) {
            GameSettingsEvents events = (GameSettingsEvents)controller;
            events?.OnGameSettingsInicjalized(settings);
        }

        public override void OnChanelDataRecived(Connection con, byte[] byteArray)
        {
            GameSettingsCommand cmd = MessagePackSerializer.Deserialize<GameSettingsCommand>(byteArray);
            cmd.Execute(this, con);
        }
        
        public override void OnRestart(){ }

        public override void OnPlayerConnect(Connection con)
        {
            GameSettingsCommand gameSettings = new GameSettingsSetCommand(GetGameSettings().GetSettings());
            base.Send(con, gameSettings);
        }

        protected override byte[] Serialize(object obj)
        {
            GameSettingsCommand objCast = (GameSettingsCommand)obj;
            return MessagePackSerializer.Serialize(objCast);
        }

        internal GameSettings GetGameSettings()
        {
            return settings;
        }

        internal void SetGameSettings(GameSettings settings)
        {
            this.settings = settings;
        }
    }
}
