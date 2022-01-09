using NetworkModules.GameSettings.Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NetworkModules.GameSettings.UI
{
    public class GameSettingsOptionController : MonoBehaviour
    {
        public GameObject NameLabel, ValueLabel;

        string nameLabel;
        int value;
        Backend.GameSettings options;
        OneSettingsLimits limits = new OneSettingsLimits(true);

        float requiredTimeToStack = 1f;
        float pointerTimeDown = 0f;

        // 200ms is one tick 50/10 = 5 per second
        int updateTick = 0;
        int updateCount = 0;

        public void SetNameLabel(string label)
        {
            nameLabel = label;
        }

        public void SetValue(int value)
        {
            Debug.Log(value);
            this.value = value;
        }

        public void SetLimits(OneSettingsLimits limits)
        {
            this.limits = limits;
        }

        public void SetUnsavedOptions(Backend.GameSettings options)
        {
            this.options = options;
        }

        public void UpdateData()
        {
            int newValue;

            if (Backend.GameSettings.GetInstance().GetSettingsValue(nameLabel, out newValue))
                value = newValue;

            NameLabel.GetComponent<Text>().text = TranslationSystem.GetText("GS_" + nameLabel);
            UpdateValue();
        }

        public void UpdateValue()
        {
            options.SetSettingsValue(nameLabel, value);
            ValueLabel.GetComponent<Text>().text = value.ToString();
        }

        bool minusPress = false;
        bool plusPress = false;

        public void OnMinusDown()
        {
            UpdateMinus();
            minusPress = true;
        }

        public void OnMinusUp()
        {
            minusPress = false;
            pointerTimeDown = 0;
            updateTick = 0;
            updateCount = 0;
        }

        public void OnPlusDown()
        {
            UpdatePlus();
            plusPress = true;
        }

        public void OnPlusUp()
        {
            plusPress = false;
            pointerTimeDown = 0;
            updateTick = 0;
            updateCount = 0;
        }

        public void FixedUpdate()
        {
            if (minusPress)
            {
                pointerTimeDown += Time.fixedDeltaTime * 10;
                if (pointerTimeDown >= requiredTimeToStack)
                {
                    if (updateTick >= 10)
                    {
                        updateTick = 0;

                        UpdateMinus();
                    }
                    else
                        updateTick++;
                }
            }

            if (plusPress)
            {
                pointerTimeDown += Time.fixedDeltaTime * 10;
                if (pointerTimeDown >= requiredTimeToStack)
                {
                    if (updateTick >= 10)
                    {
                        updateTick = 0;

                        UpdatePlus();
                    }
                    else
                        updateTick++;
                }
            }
        }

        void UpdateMinus()
        {
            if (value <= limits.MinValue)
                return;

            int valueAdd = limits.Step * StepMultiple();

            if (value - valueAdd <= limits.MinValue)
                value -= limits.Step;
            else
                value -= limits.Step * StepMultiple();

            UpdateValue();
        }

        void UpdatePlus()
        {
            if (value >= limits.MaxValue)
                return;

            int valueAdd = limits.Step * StepMultiple();

            if (valueAdd + value >= limits.MaxValue)
                value += limits.Step;
            else
                value += limits.Step * StepMultiple();

            UpdateValue();
        }

        int StepMultiple()
        {
            if (updateCount >= 5)
            {
                return 2;
            }
            else
            {
                updateCount++;

                return 1;
            }
        }
    }
}