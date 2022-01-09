using System.Collections.Generic;
using TroubleInTheCityCommon;
using UnityEngine;

namespace Assets.Shop
{
	public class ShopItemDatabase: MonoBehaviour
	{
		public List<ShopItem> Items;

        #region Singleton
        static ShopItemDatabase _instance;

        public static ShopItemDatabase GetInstance()
        {
            return _instance;
        }

        void Awake()
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
		
        public List<ShopItem> GetItemsForClass(ClassType _class)
        {
            List<ShopItem> listToReturn = new List<ShopItem>();

            foreach (var item in Items)
            {
                if(item.ItemForClass(_class))
                {
                    listToReturn.Add(item);
                }
            }

            return listToReturn;
        }

        public ShopItem GetShopItem(int itemId)
        {
            return Items.Find(n => n.Id == itemId);
        }

		void Start(){
			BuildDatabase();
		}

        void BuildDatabase(){
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Id = i;
            }

            /*Items = new List<ShopItem>() {
                //new ShopItem(0, "SIRadar", "SIRadarDesc", ActionOnBuy.ADD_PERK, ClassType.IMPOSTOR),
                //new ShopItem(1, "SIKnife", "SIKnifeDesc", ActionOnBuy.ADD_ITEM, "IKnife", ClassType.IMPOSTOR),
                /*new ShopItem(2, "SIArmor", "SIArmorDesc", ActionOnBuy.ADD_ITEM, 0, ClassType.DETECTIVE),
                new ShopItem(3, "SIHeavyArmor", "SIHeavyArmorDesc", ActionOnBuy.ADD_ITEM, 0, ClassType.DETECTIVE),
                new ShopItem(4, "SIBandage", "SIBandageDesc", ActionOnBuy.ADD_ITEM, 0, ClassType.IMPOSTOR, ClassType.DETECTIVE)
            };*/
        }
	}
}