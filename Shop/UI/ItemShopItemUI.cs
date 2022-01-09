using Assets.Shop;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.GameUI
{
    public class ItemShopItemUI : MonoBehaviour, IPointerClickHandler
    {
        public ItemShopUIController ItemShopController { set { controller = value; } }

        ShopItem shopItem;
        ItemShopUIController controller;

        public void SetShopItem(ShopItem item)
        {
            shopItem = item;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            controller.OnItemShopClick(shopItem);
        }
    }
}
