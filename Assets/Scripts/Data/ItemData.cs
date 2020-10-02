using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class ItemData
        {
            //how many objects do we have like this one?, some objects can be a stack, like arrows, or potions of the same type
            //some others can be created to hold only 1 item, let's say a sword...
            [SerializeField] private int _amount = 0;

            //the stats of this item, private, no one can alter the stats after being set
            [SerializeField] private List<ItemStats> _stats = new List<ItemStats>();

            //max number of items for stack purposes
            public int maxAmount { get; private set; }
            
            //the amount max of items in case of a stack
            public int amount
            {
                set { _amount = Mathf.Min(value, maxAmount); }
                get { return _amount; }
            }

            public ReadOnlyCollection<ItemStats> stats
            {
                get { return _stats.AsReadOnly(); }
            }


            public ItemData(int anAmount,
                int aMaxAmount,
                List<ItemStats> aStats)
            {
                maxAmount = aMaxAmount;
                amount = anAmount;
                
                for (int i = 0; i < aStats.Count; i++)
                {
                    _stats.Add(aStats[i]);
                }
            }
            
        }



    }
}