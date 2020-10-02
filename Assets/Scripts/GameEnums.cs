
public class GameEnums
{
    [System.Serializable]
    public enum Quality {
        BROKEN,
        DAMAGED,
        NORMAL,
        GOOD,
        EPIC,
        MAX
    }

    [System.Serializable]
    public enum Modifier {
        ADDITION,
        PERCENTAGE,
        MAX
    }

    [System.Serializable]
    public enum AttributesType {
        STRENGTH,
        MIND,
        DEFENSE,
        AGILITY,
        HEALTH,
        MOVEMENTPOINTS,
        ATTACKRANGE,
        VIEWRANGE,
        BLUNT,
        PIERCING,
        SLASH,
        PHYSICAL,
        MAGICAL,
        OBJECT,
        MAX
    };



    //add a new object to the inventory
    //return 0 if it's not possible to add the object because the inventory is full
    //return 1 if the object was added to the proper category
    //return 2 if the object doesn't belong to the same category type of the player
    //return 3 coins added
    [System.Serializable]
    public enum InventoryCodeStatus {
        OBJECTNOTADDED = 0,
        OBJECTADDED = 1,
        MAX
    };


}
