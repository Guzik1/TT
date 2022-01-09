using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetworkModules.GameSettings.Backend
{
    public class GameSettings : MonoBehaviour
    {
        Dictionary<string, int> settings = new Dictionary<string, int>();

        bool updated = false;

        #region Singleton
        static GameSettings _instance;

        public static GameSettings GetInstance()
        {
            return _instance;
        }

        public void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;

                DontDestroyOnLoad(this);
            }
        }
        #endregion

        public void SetSettings(Dictionary<string, int> newSettings)
        {
            settings = newSettings;
            updated = true;
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

            updated = true;
        }

        public bool IsUpdated()
        {
            return updated;
        }

        public void UpdateRead()
        {
            updated = false;
        }
    }
}
