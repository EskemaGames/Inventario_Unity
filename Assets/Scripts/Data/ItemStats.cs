using System;

namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class ItemStats
        {
            //an attribute
            public AttributeType attributeType { get; private set; }

            //the object adds a raw value or adds a percentage value?
            public GameEnums.Modifier modifier { get; private set; }

            public ItemStats(AttributeType anAttributeType, GameEnums.Modifier aModifier)
            {
                attributeType = anAttributeType;
                modifier = aModifier;
            }
        }

    }
}