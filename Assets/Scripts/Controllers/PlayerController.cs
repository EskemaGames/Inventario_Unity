using eskemagames.eskemagames.data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Inventory _inventory = new Inventory();

    private int strength = 10;
    
    public Inventory GetInventory
    {
        get { return _inventory; }
    }
    
    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        //other stuff for your player
    }


    public GameEnums.InventoryCodeStatus AddItemsToInventory(Item item)
    {
        return _inventory.AddItem(item);
    }
    
    public void DeleteItemsFromInventory(Item item)
    {
        _inventory.DeleteItem(item);
    }


    public void UpdateInventory()
    {
        for (int i = 0; i < _inventory.items.Count; i++)
        {
            
        }
    }
}
