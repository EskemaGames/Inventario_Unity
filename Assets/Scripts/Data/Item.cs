using System;

namespace eskemagames
{
    
    namespace eskemagames.data
    {
        [Serializable]
        public abstract class Item
        {
            public GameEnums.Quality quality { protected set; get; }
            public int initialValue { get; protected set; }
            public int price { protected set; get; }
            public int level { protected set; get; }
            public ItemData data { protected set; get; }
            public bool equipped { protected set; get; }
            public uint objectId { protected set; get; }

            
            #region constructor
            
            public Item() { }

            public virtual Item Clone()
            {
                return null;
            }

            public Item(Item item)
            {
                equipped = false;
                price = item.price;
                data = item.data;
                quality = item.quality;
                level = item.level;
                initialValue = item.data.maxAmount;
                objectId = item.objectId;
            }

            public Item(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
            {
                equipped = false;
                price = aPrice;
                data = anItem;
                quality = aQuality;
                level = aLevel;
                initialValue = anItem.maxAmount;
                objectId = id;
            }

            #endregion
            

            public void SetEquipped(bool value)
            {
                equipped = value;
            }

            public void RestoreInitialValue()
            {
                data.amount = initialValue;
            }

            public override string ToString()
            {
                return "Type " + GetType().Name
                               + " Id " + objectId
                               + " Price " + price
                               + " Amount " + data.amount
                               + " Quality " + quality
                               + " Level " + level
                               + " Total Stats " + data.stats.Count;
            }

        }
    }
}