using Assets.Scripts.UI;
using NetworkModules.GameSettings.Backend;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkModules.GameSettings.UI
{
    public class GameSettingsUIController : RecursiveUIController
    {
        public GameObject OptionContentObject;

        public GameObject IntOptionObject;

        List<GameSettingsOptionController> settingsObject = new List<GameSettingsOptionController>();

        Backend.GameSettings options;

        public override void OnUIEnable()
        {
            base.OnUIEnable();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (OptionContentObject.transform.childCount == 0)
            {
                BuildView();
            }
        }

        public void OnCancelButtonClick()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            OnUIDisable();
        }

        public void SaveOption()
        {
            if (options.IsUpdated())
            {
                GameSettingsModuleUtils.SendSettingsToServer();

                options.UpdateRead();
            }
        }

        void BuildView()
        {
            GameSettingsLimits limits = GameSettingsLimits.GetInstance();

            options = Backend.GameSettings.GetInstance();
            Dictionary<string, int> settings = options.GetSettings();

            foreach (KeyValuePair<string, int> pair in settings)
            {
                OneSettingsLimits limit;
                limits.GetLimitValue(pair.Key, out limit);

                if (limit != null)
                    if (!limit.Visible)
                        continue;

                GameObject instance = Instantiate(IntOptionObject, OptionContentObject.transform);
                GameSettingsOptionController controller = instance.GetComponent<GameSettingsOptionController>();

                controller.SetNameLabel(pair.Key);
                controller.SetUnsavedOptions(options);

                if (limit != null)
                    controller.SetLimits(limit);

                controller.UpdateData();

                settingsObject.Add(controller);
            }
        }
    }
}
