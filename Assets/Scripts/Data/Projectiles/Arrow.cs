using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class Arrow : Item, ICategoryProjectiles
        {

            public Arrow(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
                : base(aPrice, aLevel, id, aQuality, anItem) { }

            public Arrow() { }

            public override Item Clone()
            {
                return new Arrow(this);
            }

            public Arrow(Item item) : base(item) { }

        }
    }
}