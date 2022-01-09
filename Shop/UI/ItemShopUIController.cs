using Assets.Scripts.Shop;
using Assets.Shop;
using Modules.PointShop;
using System.Collections.Generic;
using TroubleInTheCityCommon;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameUI
{
    public class ItemShopUIController : MonoBehaviour, UIController
    {
        public GameObject UIGroup;

        public GameObject ItemContentParent;
        public GameObject OneItemObj;

        public Text TitleText;
        public Text DescText;
        public Text PointCountText;
        public Button BuyButton;

        ItemShopController shopController;
        ShopItem selectedItem;

        void Start()
        {
            UIGroup.SetActive(false);

            GameUIController.GetInstance().SetUIController(this);

            shopController = ItemShopController.GetInstance();

            PointCountText.text = "";
            DescText.text = "";
            TitleText.text = "";
        }

        public void OnCloseButtonClick()
        {
            OnUIDisable();
        }

        public void OnUIEnable()
        {
            if (UIGroup.activeSelf)
                return;

            UIGroup.SetActive(true);

            ClassType _class = GameController.GetInstance().PlayerClass;

            List<ShopItem> classItems = ShopItemDatabase.GetInstance().GetItemsForClass(_class);

            foreach (var item in classItems)
            {
                GameObject newObj = Instantiate(OneItemObj, ItemContentParent.transform);

                newObj.GetComponentInChildren<Text>().text = TranslationSystem.GetText(item.TitleLabel);

                ItemShopItemUI shopItem = newObj.GetComponent<ItemShopItemUI>();
                shopItem.SetShopItem(item);
                shopItem.ItemShopController = this;
            }

            PointCountText.text = $"{ TranslationSystem.GetText("IS_Point") }: { shopController.GetPlayerPoint() }";

            BuyButton.interactable = false;
        }

        public void OnItemShopClick(ShopItem item)
        {
            TitleText.text = TranslationSystem.GetText(item.TitleLabel);
            DescText.text = TranslationSystem.GetText(item.DescLabel);

            BuyButton.interactable = true;

            selectedItem = item;
        }

        public void OnBuyButtonClick()
        {
            if(shopController.GetPlayerPoint() > 0)
            {
                if(selectedItem.ActionOnBuy == ActionOnBuy.ADD_ITEM)
                {
                    PointShopUtil.BuyItem(selectedItem.GetItemId(), 1);
                }
                else if(selectedItem.ActionOnBuy == ActionOnBuy.ADD_PERK)
                {
                    PointShopUtil.BuyPerk(selectedItem.Id, 1);
                }
            }
            else
            {
                GlobalChatController.GetInstance().WriteSystemErrorMessage(TranslationSystem.GetText("IS_NoPoint"));
            }
        }

        public void OnUIDisable()
        {
            UIGroup.SetActive(false);

            foreach (Transform item in ItemContentParent.transform)
            {
                Destroy(item.gameObject);
            }
        }

        public string GetControllerType()
        {
            return "itemShop";
        }
    }
}
