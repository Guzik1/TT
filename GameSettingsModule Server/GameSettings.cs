using System;
using System.Collections.Generic;
using System.Text;

namespace GameSettingsModule
{
    public class GameSettings
    {
        Dictionary<string, int> settings = new Dictionary<string, int>();

        /*public GameSettings() {
            settings = DefaultGameSettings.GetSettings();
        }*/

        public void SetSettings(Dictionary<string, int> newSettings)
        {
            settings = newSettings;

            /*int prepareTimeInMinutes, apocalypseTimeInMinutes;

            GetSettingsValue("PrepareTimeInMinutes", out prepareTimeInMinutes);
            GetSettingsValue("ApocalypseTimeInMinutes", out apocalypseTimeInMinutes);

            int gameTimeInSeconds = 60 * prepareTimeInMinutes + 60 * apocalypseTimeInMinutes;
            SetSettingsValue("GameTimeInSeconds", gameTimeInSeconds);*/
        }

        public Dictionary<string, int> GetSettings()
        {
            return settings;
        }

        public bool GetSettingsValue(string key, out int value)
        {
            return settings.TryGetValue(key, out value);
        }

        public void SetSettingsValue(string key, int value)
        {
            if (settings.ContainsKey(key))
                settings[key] = value;
            else
                settings.Add(key, value);
        }
    }
}
