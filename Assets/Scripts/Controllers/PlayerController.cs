using eskemagames.eskemagames.data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Inventory _inventory = new Inventory();

    private int strength = 10;
    //other stats for your player character
    
    
    public Inventory GetInventory
    {
        get { return _inventory; }
    }
    
    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        //other init stuff for your player goes here...
    }


    
    #region inventory management
    
    public GameEnums.InventoryCodeStatus AddItemsToInventory(Item item)
    {
        return _inventory.AddItem(item);
    }
    
    public void DeleteItemsFromInventory(Item item)
    {
        _inventory.DeleteItem(item);
    }
    
    public void DeleteAllItemsFromInventory()
    {
        _inventory.DeleteAllItems();
    }

    public void EquipItem(uint id)
    {
        for (var i = 0; i < _inventory.items.Count; ++i)
        {
            if (_inventory.items[i].objectId == id)
            {
                _inventory.items[i].SetEquipped(true);
                break;
            }
        }
    }
    
    public void UnEquipItem(uint id)
    {
        for (var i = 0; i < _inventory.items.Count; ++i)
        {
            if (_inventory.items[i].objectId == id)
            {
                _inventory.items[i].SetEquipped(false);
                break;
            }
        }
    }
    
    #endregion
    
}
