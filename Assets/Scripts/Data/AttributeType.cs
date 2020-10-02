using UnityEngine;
using System;


namespace eskemagames
{
    namespace eskemagames.data
    {
        [Serializable]
        public class AttributeType
        {
            public float value { get; private set; }

            //type will not change ever
            public GameEnums.AttributesType type { private set; get; }

            public AttributeType(float aValue, GameEnums.AttributesType aType)
            {
                //clamped to 100 for this example
                value = Mathf.Min(aValue, 100);
                type = aType;
            }
        }

    }

}
