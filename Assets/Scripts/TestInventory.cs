using System;
using eskemagames;
using eskemagames.eskemagames.data;
using UnityEngine;


public class TestInventory : MonoBehaviour
{
    
    [SerializeField] private InventoryViewController inventoryViewController = null;
    [SerializeField] private int totalObjects = 15;
    [SerializeField] private PlayerController _playerController = null;
    
    private ItemsCreator _itemsCreator = new ItemsCreator();
    private Item _itemArrow = null;


    private void Start()
    {
        inventoryViewController.SetCallbacks(OnItemEquipped);
    }



    #region callbacks from inventory view controller
    private void OnItemEquipped(uint id, bool isEquipped)
    {
        if (isEquipped)
        {
            _playerController.EquipItem(id);
        }
        else
        {
            _playerController.UnEquipItem(id);
        }
    }
    #endregion
    

    [ContextMenu("Fill inventory with random items")]
    private void FillItemsScreen()
    {
        var _playerLevelExample = 2;
        
        _playerController.DeleteAllItemsFromInventory();
        
        //let's create 15 items to fill the inventory on screen
        for (var i = 0; i < totalObjects; i++)
        {
            //create the rand item
            Item item = null;
            if (i < 3)
            {
                item = _itemsCreator.CreateRandItem("Sword", _playerLevelExample, 100, 1, 1);
            }
            else if (i >= 3 && i < 6)
            {
                item = _itemsCreator.CreateRandItem("Shield", _playerLevelExample, 100, 1, 1);
            }
            else if (i >= 6 && i < 9)
            {
                item = _itemsCreator.CreateRandItem("Arrow", _playerLevelExample, 100, 10, 50);
                
                //copy the first object to add to stack later
                if (_itemArrow == null)
                {
                    _itemArrow = item.Clone();
                }
            }
            else if (i >= 9 && i < totalObjects)
            {
                item = _itemsCreator.CreateRandItem("Potion", _playerLevelExample, 100, 1, 1);
            }
            
            _playerController.AddItemsToInventory(item);
        }
        
        inventoryViewController.SetInventory(_playerController.GetInventory);
    }


    [ContextMenu("Add new sword")]
    private void AddNewSword()
    {
        Item item = _itemsCreator.CreateRandItem("Sword", 10, 100, 1, 100);
        
        GameEnums.InventoryCodeStatus result = _playerController.AddItemsToInventory(item);
        
        if (result == GameEnums.InventoryCodeStatus.OBJECTADDED)
        {
            inventoryViewController.SetInventory(_playerController.GetInventory);
        }
    }
    
    [ContextMenu("Add new shield")]
    private void AddNewShield()
    {
        Item item = _itemsCreator.CreateRandItem("Shield", 10, 100, 1, 100);
        
        GameEnums.InventoryCodeStatus result = _playerController.AddItemsToInventory(item);
        
        if (result == GameEnums.InventoryCodeStatus.OBJECTADDED)
        {
            inventoryViewController.SetInventory(_playerController.GetInventory);
        }
    }
    
    [ContextMenu("Add new arrow")]
    private void AddNewArrow()
    {
        GameEnums.InventoryCodeStatus result = _playerController.AddItemsToInventory(_itemArrow);
        
        if (result == GameEnums.InventoryCodeStatus.OBJECTADDED)
        {
            inventoryViewController.SetInventory(_playerController.GetInventory);
        }
    }
    
}



