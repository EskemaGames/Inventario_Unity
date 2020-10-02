using UnityEngine;
using System.Collections.Generic;

using eskemagames.eskemagames.data;


namespace eskemagames
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private GameObject itemUIPrefab = null;
        [SerializeField] private UIGrid grid = null;


        //ESTE OBJETO NO ES PARTE DE ESTA CLASE
        private ItemsCreator _itemsCreator = new ItemsCreator();



        public void SetInventory(Inventory inventory)
        {
            List<Transform> inventoryGameobjects = grid.GetChildList();
            
            for (var i = inventoryGameobjects.Count-1; i > -1; i--)
            {
                GameObject.Destroy(inventoryGameobjects[i].gameObject);
            }
            
            grid.GetChildList().Clear();
            
            FillItemsFromInventoryScreen(inventory);
        }



        private void FillItemsFromInventoryScreen(Inventory inventory)
        {
            // fill inventory on screen from the objects passed around
            for (var i = 0; i < inventory.items.Count; i++)
            {
                var g = NGUITools.AddChild(grid.gameObject, itemUIPrefab);
                
                //we want to add the quality in front of the name
                //but normal won't be displayed
                var quality = inventory.items[i].quality == GameEnums.Quality.NORMAL
                    ? ""
                    : "[" + inventory.items[i].quality + "]";
                
                var title = "[" + NGUIText.EncodeColor(_itemsCreator.GetColor(inventory.items[i].quality)) + "]" +
                            quality +
                            "[-]" + " Item " + i;

                var description = inventory.items[i].GetType().Name;

                g.GetComponent<ItemUI>().Init(title, description,
                    inventory.items[i].price.ToString() + "$",
                    inventory.items[i].data.amount.ToString(), "NGUI");
            }
            
            Invoke("RepositionGrid", 0.1f);
        }

        
        private void RepositionGrid()
        {
            grid.Reposition();
        }
        
        
        
        
        //TODO 
        //
        // add methods to add remove items from the screen inventory, equip, etc, and add them to the player
        //
        //

        public void EquipItem()
        {
        }

        public void UnequipItem()
        {
        }
        
        public void SelectItem()
        {
        }
        
        public void DeselectItem()
        {
        }

    }

}
