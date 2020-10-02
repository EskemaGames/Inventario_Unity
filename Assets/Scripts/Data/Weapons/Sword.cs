using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class Sword : Item, ICategoryWeapon
        {

            public Sword(int aPrice, int aLevel, uint id, GameEnums.Quality aQuality, ItemData anItem)
                : base(aPrice, aLevel, id, aQuality, anItem) { }

            public Sword() { }

            public override Item Clone()
            {
                return new Sword(this);
            }

            public Sword(Item sk) : base(sk) { }

        }
    }
}