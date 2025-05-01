using System.Collections.Generic;
using UnityEngine;
public static class Attributes
{
    public static T RandomList<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
