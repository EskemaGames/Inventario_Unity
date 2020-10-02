using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace eskemagames
{
    namespace eskemagames.data
    {
        //this class will store an inventory "sorted" by categories, armors, weapons and items   
        [Serializable]
        public class Inventory
        {
            [SerializeField] private List<Item> _items = new List<Item>();
            
            //id to identify this inventory in a pool hold by some manager, obviously not here...
            //let's pretend that we are working on an RPG and we have 4 characters
            //we want each one of them to have its own inventory, so this id will the character id
            //that owns this particular inventory
            public int idCharacterAttached { get; private set; }
            
            //limit our inventory to a certain amount of objects for all categories
            private int _totalItems = 45;
            
            
            public ReadOnlyCollection<Item> items
            {
                get { return _items.AsReadOnly(); }
            } 



            #region init and destroy

            public void Init(int aId, List<Item> aList)
            {
                idCharacterAttached = aId;

                _items.Clear();

                for (var i = 0; i < aList.Count; i++)
                {
                    _items.Add(aList[i]);
                }
            }

            public void Destroy()
            {
                _items.Clear();
            }

            #endregion



            //in case of restart the level, we need to restore the value of the objects
            //like arrows, etc
            public void RestoreMaxValue()
            {
                for (var i = 0; i < _items.Count; i++)
                {
                    _items[i].RestoreInitialValue();
                }
            }

            
            #region public API
            public void DeleteItem(Item item)
            {
                for (var i = 0; i < _items.Count; i++)
                {
                    if (_items[i].objectId != item.objectId) continue;
                    
                    _items.RemoveAt(i);
                    
                    break;
                }
            }


            //add a new object to the inventory
            //return 0 if it's not possible to add the object because the inventory is full
            //return 1 if the object was added to the proper category
            //return 2 if the object doesn't belong to the same category type of the player
            public GameEnums.InventoryCodeStatus AddItem(Item objToAdd)
            {
                var inventoryStatus = GameEnums.InventoryCodeStatus.OBJECTNOTADDED;
                
                //stack object
                if (objToAdd.data.maxAmount > 1)
                {
                    inventoryStatus = AddObjectToStack(objToAdd)
                        ? GameEnums.InventoryCodeStatus.OBJECTADDED
                        : GameEnums.InventoryCodeStatus.OBJECTNOTADDED;

                    if (inventoryStatus == GameEnums.InventoryCodeStatus.OBJECTNOTADDED)
                    {
                        inventoryStatus = AddObject(objToAdd);
                    }
                }
                else
                {
                    inventoryStatus = AddObject(objToAdd);
                }

                Debug.Log("" + inventoryStatus + " Data= " + objToAdd.ToString());
                return inventoryStatus;
            }

            #endregion
            

            
            
            
            private GameEnums.InventoryCodeStatus AddObject(Item objToAdd)
            {
                if (_items.Count >= _totalItems)
                {
                    return GameEnums.InventoryCodeStatus.OBJECTNOTADDED;
                }
                
                _items.Add(objToAdd);
                
                return GameEnums.InventoryCodeStatus.OBJECTADDED;
            }
            
            private bool AddObjectToStack(Item objToAdd)
            {
                var wasAdded = false;
                    
                for (var i = 0; i < _items.Count; i++)
                {
                    var o = _items[i];

                    if (o.objectId != objToAdd.objectId) continue;

                    o.data.amount += objToAdd.data.amount;
                    wasAdded = true;
                    break;
                }

                return wasAdded;
            }
        }

    }
}