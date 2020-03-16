using UnityEngine;

public class GetPosition
{
    public static Vector3 GetRandomStartPosition(int minimum, int maximum)
    {
        Vector3 newTransform;
        var x = GetRandomAmount(minimum, maximum);
        var y = GetRandomAmount(minimum, maximum);
        var z = GetRandomAmount(minimum, maximum);
        newTransform = new Vector3(x, y, z);
        return newTransform;
    }

    private static  int GetRandomAmount(int minimum, int maximum) { return Random.Range(minimum, maximum); }
}