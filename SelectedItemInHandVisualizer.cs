using Modules.InventoryAndItems.Backend;
using Modules.InventoryAndItems.Backend.DataStruct;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class SelectedItemInHandVisualizer : MonoBehaviour
    {
        public GameObject ScreenCenterPoint;

        ItemAbstraction selectedItem;

        void Start()
        {
            SceneLoader sc = SceneLoader.GetInstance();

            if(sc != null)
                sc.OnSceneLoadEveny += OnSceneLoad;
        }

        void OnDestroy()
        {
            SceneLoader sc = SceneLoader.GetInstance();

            if (sc != null)
                sc.OnSceneLoadEveny -= OnSceneLoad;
        }

        void OnSceneLoad(string sceneName)
        {
            if(sceneName == "MainMenu")
            {
                OnBackToMenu();
            }
            else
            {
                OnMapLoad();
            }
        }

        void OnMapLoad()
        {
            InventoryController inv = InventoryController.GetInstance();

            if (inv == null)
                return;

            inv.OnSelectedItemChangeEvent += OnChangeSelectedItemChange;
            inv.OnGunReloadingEvent += OnGunReloading;
            inv.OnItemAddEvent += OnItemAddOrRemove;
            inv.OnItemRemoveEvent += OnItemAddOrRemove;
        }

        void OnBackToMenu()
        {
            selectedItem = null;
            UpdateView();

            InventoryController inv = InventoryController.GetInstance();

            if (inv == null)
                return;

            inv.OnSelectedItemChangeEvent -= OnChangeSelectedItemChange;
            inv.OnGunReloadingEvent -= OnGunReloading;
            inv.OnItemAddEvent -= OnItemAddOrRemove;
            inv.OnItemRemoveEvent -= OnItemAddOrRemove;
        }

        void OnChangeSelectedItemChange(ItemAbstraction selectedItem)
        {
            this.selectedItem = selectedItem;

            UpdateView();
        }

        void OnGunReloading()
        {
            //UpdateView();
        }

        void OnItemAddOrRemove(ItemAbstraction item)
        {
            selectedItem = InventoryController.GetInstance().GetSelectedItem();

            if(item == selectedItem)
                UpdateView();
        }

        void UpdateView()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (selectedItem != null)
            {
                GameObject itemToSpawn = Resources.Load<GameObject>("Items/" + selectedItem.NameLabel);

                if (itemToSpawn != null)
                {
                    GameObject newObj = Instantiate(itemToSpawn, transform);

                    Vector3 vec = new Vector3();
                    vec.y = 90f;

                    newObj.transform.localEulerAngles = vec;
                }
                else
                    Debug.LogWarning("No item object to spawn");
            }
        }
    }
}
