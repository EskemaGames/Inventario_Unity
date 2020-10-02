using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class Coin : Item, ICategoryCoins
        {

            public Coin(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
                : base(aPrice, aLevel, id, aQuality, anItem) { }

            public Coin() { }

            public override Item Clone()
            {
                return new Coin(this);
            }

            public Coin(Item sk) : base(sk) { }

        }
    }
}