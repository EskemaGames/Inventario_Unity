using UnityEngine;
using System.Collections.Generic;
using System;
using eskemagames.eskemagames.data;
using Random = UnityEngine.Random;


namespace eskemagames
{

    public class ItemsCreator
    {
        //create an item based on the level passed
        public Item CreateRandItem(string objClassName, int aLevel, int priceBase, int minToGenerateInStack, int maxToGenerateInStack)
        {
            //set a quality for this item
            var quality = (GameEnums.Quality) Random.Range(0, (int) GameEnums.Quality.MAX);

            //just create a level between 2 less and 2 more than the actual level of the player
            //this is the base attribute, for example 10 strength, if the character doesn't have that strength
            //he won't be able to yield this sword until he raises the level of strength
            var tmpLevel = Mathf.Clamp(Random.Range(aLevel - 2, aLevel + 2), 1, aLevel + 2);

            //a price for buy and sell
            var price = GeneratePrice(tmpLevel, priceBase, quality);

            var itData = CreateItemData(tmpLevel, quality, minToGenerateInStack, maxToGenerateInStack);

            uint id = IdGenerator.GetId();
            var argTypeInstruction = new object[] {price, tmpLevel, id,  quality, itData};
            
            //set the namespace path, otherwise the class will not be instantiated
            var item = CreateInstance<Item>("eskemagames.eskemagames.data.", objClassName, argTypeInstruction);

            return item;
        }
        
        private int GeneratePrice(int level, int priceBase, GameEnums.Quality quality)
        {
            var price = 0;
            
            var multiplier = GenerateMultiplier(level, quality);

            price = Mathf.CeilToInt(Random.Range(priceBase * multiplier, ((priceBase * multiplier) + (priceBase * 2))));

            return price;
        }

        private List<ItemStats> GenerateRandomStats(int level, int maxAmount, GameEnums.Quality quality)
        {
            //the list to store the stats
            var stats = new List<ItemStats>();

            //this item will have between 1 and maxamount stats attached
            var randStatsAmount = Random.Range(1, maxAmount);

            var prevAttribute = GameEnums.AttributesType.MAX;
            var attributeType = GameEnums.AttributesType.MAX;

            //generate the stats we need
            for (var i = 0; i < randStatsAmount; i++)
            {
                attributeType = (GameEnums.AttributesType) Random.Range(0, (int) GameEnums.AttributesType.MAX);

                //make sure we do not duplicate attributes
                while (attributeType == prevAttribute)
                {
                    attributeType = (GameEnums.AttributesType) Random.Range(0, (int) GameEnums.AttributesType.MAX);
                }

                prevAttribute = attributeType;

                var modifier = (GameEnums.Modifier) Random.Range(0, (int) GameEnums.Modifier.MAX);

                var value = modifier == GameEnums.Modifier.PERCENTAGE
                    ? GenerateMultiplier(level, quality)
                    : Random.Range(1, level);

                var attr = new AttributeType(value, attributeType);

                var itStats = new ItemStats(attr, modifier);

                stats.Add(itStats);
            }

            return stats;
        }

        
        private ItemData CreateItemData(int aLevel,  GameEnums.Quality aQuality, int aMintogenerate, int aMaxtogenerate)
        {
            //the list to store the stats, up to 5 stats for this item
            var stats = GenerateRandomStats(aLevel, 5, aQuality);

            ItemData itData = new ItemData(aMintogenerate, Random.Range(aMintogenerate, aMaxtogenerate) , stats);

            return itData;
        }
        
        private I CreateInstance<I>(string namespaceName, string name, object[] someParams) where I : class
        {
            var typeClass = System.Type.GetType(namespaceName + name);
            return Activator.CreateInstance(typeClass, someParams) as I;
        }

        private float GenerateMultiplier(int level, GameEnums.Quality quality)
        {
            var mult = 0f;

            switch (quality)
            {
                case GameEnums.Quality.BROKEN:
                    mult = 0f;
                    break;
                case GameEnums.Quality.DAMAGED:
                    mult = 0.25f;
                    break;
                case GameEnums.Quality.NORMAL:
                    mult = 1f;
                    break;
                case GameEnums.Quality.GOOD:
                    mult = 1.75f;
                    break;
                case GameEnums.Quality.EPIC:
                    mult = 2.5f;
                    break;
            }

            //Take level into account with a capped level of 100
            var linear = level / 100f;

            //Add a curve for more interesting results
            mult *= Mathf.Lerp(linear, linear * linear, 0.5f);

            return mult;
        }

        public Color GetColor(GameEnums.Quality quality)
        {
            var c = Color.white;

            switch (quality)
            {
                case GameEnums.Quality.BROKEN:
                    c = new Color(0.4f, 0.2f, 0.2f);
                    break;
                case GameEnums.Quality.DAMAGED:
                    c = new Color(0.4f, 0.4f, 0.4f);
                    break;
                case GameEnums.Quality.NORMAL:
                    c = new Color(1.0f, 1.0f, 1.0f);
                    break;
                case GameEnums.Quality.GOOD:
                    c = NGUIMath.HexToColor(0x00baffff);
                    break;
                case GameEnums.Quality.EPIC:
                    c = NGUIMath.HexToColor(0x9600ffff);
                    break;
            }

            return c;
        }
    }
    
}
