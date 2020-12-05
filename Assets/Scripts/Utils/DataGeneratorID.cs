using UnityEngine;

public static class IdGenerator
{
    private static uint _id = 0;

    public static uint GetId()
    {
        _id++;
        
        if (_id > uint.MaxValue)
        {
            _id = 1;
        }

        return _id;
    }

}
