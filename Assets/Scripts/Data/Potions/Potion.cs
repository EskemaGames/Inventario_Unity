using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class Potion : Item, ICategoryItems
        {

            public Potion(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
                : base(aPrice, aLevel, id, aQuality, anItem) { }

            public Potion() { }

            public override Item Clone()
            {
                return new Potion(this);
            }

            public Potion(Item sk) : base(sk) { }

        }
    }
}