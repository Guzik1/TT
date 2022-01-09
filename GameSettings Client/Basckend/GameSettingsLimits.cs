using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetworkModules.GameSettings.Backend
{
    public class GameSettingsLimits : MonoBehaviour
    {
        public Dictionary<string, OneSettingsLimits> SettingsLimits = new Dictionary<string, OneSettingsLimits>();

        #region Singleton
        static GameSettingsLimits _instance;

        public static GameSettingsLimits GetInstance()
        {
            return _instance;
        }

        public void Awake()
        {
            _instance = this;

            //GenerateLimits();
        }
        #endregion

        public Dictionary<string, OneSettingsLimits> GetLimits()
        {
            return SettingsLimits;
        }

        public bool GetLimitValue(string key, out OneSettingsLimits value)
        {
            return SettingsLimits.TryGetValue(key, out value);
        }

        public void AddLimits(string labelName, OneSettingsLimits limits)
        {
            SettingsLimits.Add(labelName, limits);
        }

        /*void GenerateLimits()
        {
            SettingsLimits.Add("GameTimeInSeconds", new OneSettingsLimits(false));
            // AcopsalipsTimeInMinutes
            SettingsLimits.Add("StartGameOffsetTimeInSeconds", new OneSettingsLimits(2, 30, 1));
            SettingsLimits.Add("PrepareTimeInMinutes", new OneSettingsLimits(1, 30, 1));
            SettingsLimits.Add("ApocalypseTimeInMinutes", new OneSettingsLimits(1, 30, 1));

            SettingsLimits.Add("CrewmatePercentChane", new OneSettingsLimits(0, 100, 5));
            SettingsLimits.Add("ImpostorPercentChane", new OneSettingsLimits(0, 100, 5));
        }*/
    }

    public class OneSettingsLimits
    {
        public int MaxValue;

        public int MinValue;

        public int Step;

        public bool Visible;

        public OneSettingsLimits(int minValue, int maxValue, int step, bool visible)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            Step = step;
            Visible = visible;
        }

        public OneSettingsLimits(int minValue, int maxValue, int step)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            Step = step;
            Visible = true;
        }

        public OneSettingsLimits(bool visible)
        {
            MaxValue = int.MaxValue;
            MinValue = 0;
            Step = 1;
            Visible = visible;
        }
    }
}