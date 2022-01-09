using NetworkModules.GameSettings.Backend;
using TroubleInTheCityCommon;
using UnityEngine;

namespace Assets.Scripts.Shop
{
    public class ItemShopController: MonoBehaviour
    {
        int pointCount;

        #region Singleton
        static ItemShopController _instance;

        public static ItemShopController GetInstance()
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
            }
        }
        #endregion

        void Start()
        {
            GameSettings gs = GameSettings.GetInstance();
            ClassType _class = GameController.GetInstance().PlayerClass;

            pointCount = 0;

            if (gs == null)
                return;

            if(_class == ClassType.DETECTIVE)
            {
                gs.GetSettingsValue("StartDetectivePoint", out pointCount);
            }
            else if (_class == ClassType.IMPOSTOR)
            {
                gs.GetSettingsValue("StartImpostorPoint", out pointCount);
            }
        }

        public int GetPlayerPoint() => pointCount;

        public void RemovePlayerPoint(int count)
        {
            pointCount -= count;
        }
    }
}
