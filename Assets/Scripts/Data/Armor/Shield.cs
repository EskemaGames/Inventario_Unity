using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class Shield : Item, ICategoryArmor
        {

            public Shield(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
                : base(aPrice, aLevel, id, aQuality, anItem) { }

            public Shield() { }

            public override Item Clone()
            {
                return new Shield(this);
            }

            public Shield(Item sk) : base(sk) { }

        }
    }
}