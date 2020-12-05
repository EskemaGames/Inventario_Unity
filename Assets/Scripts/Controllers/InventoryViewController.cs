using UnityEngine;
using System.Collections.Generic;
using eskemagames.eskemagames.data;


namespace eskemagames
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private GameObject itemUIPrefab = null;
        [SerializeField] private UIGrid grid = null;
        [SerializeField] private int totalItemsPooled = 18;
        
        private List<ItemUI> itemsUI = new List<ItemUI>();
        private System.Action<uint, bool> onItemEquipped = null;
        
        //THIS OBJECT IS NOT PART OF THIS CLASS
        //in a regular game this object will lie elsewhere in your code
        //probably with the resourcespool, where you will get the images for the inventory items
        private ItemsCreator _itemsCreator = new ItemsCreator();


        
        #region monobehaviour
        private void Start()
        {
            for (var i = 0; i < totalItemsPooled; ++i)
            {
                var g = NGUITools.AddChild(grid.gameObject, itemUIPrefab);
                ItemUI item = g.GetComponent<ItemUI>();
                item.InitEmpty();
                itemsUI.Add(item);
            }
        }

        private void OnDestroy()
        {
            onItemEquipped = null;
            
            if (grid != null)
            {
                List<Transform> inventoryGameobjects = grid.GetChildList();
                
                for (var i = inventoryGameobjects.Count - 1; i > -1; --i)
                {
                    if (inventoryGameobjects[i] != null)
                    {
                        GameObject.Destroy(inventoryGameobjects[i].gameObject);
                    }
                }
            }
        }
        #endregion


        public void SetCallbacks(System.Action<uint, bool> onItemEquipped)
        {
            this.onItemEquipped = onItemEquipped;
        }


        public void SetInventory(Inventory inventory)
        {
            //first clean up previous objects from our view
            for (var i = 0; i < itemsUI.Count; ++i)
            {
                itemsUI[i].SetInactive();
                itemsUI[i].ResetItem();
            }
            
            //now fill in the new inventory
            for (var i = 0; i < inventory.items.Count; ++i)
            {
                Item itemInventory = inventory.items[i];

                //do not exceed our pool range..
                if (i >= itemsUI.Count) break;
                
                ItemUI item = itemsUI[i];

                var quality = itemInventory.quality == GameEnums.Quality.NORMAL
                    ? ""
                    : "[" + itemInventory.quality + "]";

                var title = "[" + NGUIText.EncodeColor(_itemsCreator.GetColor(itemInventory.quality)) + "]" +
                            quality +
                            "[-]" + " Item " + i;

                var description = itemInventory.GetType().Name;

                item.Init(
                    itemInventory.objectId,
                    title,
                    description,
                    itemInventory.price.ToString() + "$",
                    itemInventory.data.amount.ToString(),
                    "NGUI");

                item.SetActive();
            }

            Invoke("RepositionGrid", 0.1f);
        }
        
        

        
        
        #region public methods

        //supposed method suscribed to the "touch/click/keyboard entry"
        // we can assume for this tutorial that a gameobject will be read from our click on screen
        public void EquipButtonPressed(GameObject go)
        {
            ItemUI itemUI = go.GetComponent<ItemUI>();

            if (itemUI != null)
            {
                EquipItem(itemUI.GetId);
            }
        }
        
        //supposed method suscribed to the "touch/click/keyboard entry"
        // we can assume for this tutorial that a gameobject will be read from our click on screen
        public void UnEquipButtonPressed(GameObject go)
        {
            ItemUI itemUI = go.GetComponent<ItemUI>();

            if (itemUI != null)
            {
                UnequipItem(itemUI.GetId);
            }
        }
        
        
        public void SelectItem()
        {
        }
        
        public void DeselectItem()
        {
        }
        #endregion
    
        
        
        #region private methods
        
        private void RepositionGrid()
        {
            grid.Reposition();
        }

        private void EquipItem(uint id)
        {
            onItemEquipped?.Invoke(id, true);
        }

        private void UnequipItem(uint id)
        {
            onItemEquipped?.Invoke(id, false);
        }
        
        #endregion
        

    }

}
