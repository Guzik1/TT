using Modules.InventoryAndItems.Backend;
using System.Collections.Generic;
using TroubleInTheCityCommon;
using UnityEngine;

namespace Assets.Shop
{
	[CreateAssetMenu(fileName = "BitSec/shop item", menuName = "BitSec/Shop Item")]
	public class ShopItem: ScriptableObject
	{
		public string TitleLabel;
		public string DescLabel;
		[HideInInspector] public int Id;
		public string ItemLabel;
		public Sprite Icon;
		public ActionOnBuy ActionOnBuy;
		public List<ClassType> ForClass = new List<ClassType>();

		public ShopItem(int id, string titleLabel, string descLabel, ActionOnBuy action, params ClassType[] forClass) 
		{
			Inicialize(id, titleLabel, descLabel, null, action, "", forClass);
		}

		public ShopItem(int id, string titleLabel, string descLabel, ActionOnBuy action, string itemLabel, params ClassType[] forClass)
		{
			Inicialize(id, titleLabel, descLabel, null, action, itemLabel, forClass);
		}

		public ShopItem(int id, string titleLabel, string descLabel, Sprite icon, ActionOnBuy action, params ClassType[] forClass) 
		{
			Inicialize(id, titleLabel, descLabel, icon, action, "", forClass);
		}

		public int GetItemId()
        {
			if (!string.IsNullOrEmpty(ItemLabel))
				return ItemDatabase.GetInstance().GetItem(ItemLabel).Id;
			else
				return -1;
		}

		public bool ItemForClass(ClassType _class)
        {
            foreach (var item in ForClass)
            {
				if (item == _class)
					return true;
            }

			return false;
        }

		void Inicialize(int id, string titleLabel, string descLabel, Sprite icon, ActionOnBuy action, string itemLabel, params ClassType[] forClass)
		{
			TitleLabel = titleLabel;
			DescLabel = descLabel;
			Id = id;
			Icon = icon;
			ActionOnBuy = action;

			foreach (ClassType _class in forClass)
			{
				ForClass.Add(_class);
			}
		}
	}

	public enum ActionOnBuy
    {
		ADD_ITEM,
		ADD_PERK
    }
}