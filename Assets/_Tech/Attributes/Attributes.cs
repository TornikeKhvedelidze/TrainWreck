using System.Collections.Generic;
using UnityEngine;
public static class Attributes
{
    public static T RandomElementFromList<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static List<T> RandomElementsFromList<T>(this List<T> sourceList, int amountToChoose)
    {
        if (sourceList == null) return null;

        amountToChoose = Mathf.Clamp(amountToChoose, 0, sourceList.Count);

        List<T> copy = new(sourceList);
        List<T> selected = new();

        for (int i = 0; i < amountToChoose; i++)
        {
            int index = Random.Range(0, copy.Count);
            selected.Add(copy[index]);
            copy.RemoveAt(index);
        }

        return selected;
    }

    public static Vector3 RandomBetweenVector3(this Vector3 start, Vector3 end)
    {
        Vector3 min = Vector3.Min(start, end);
        Vector3 max = Vector3.Max(start, end);

        return new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );
    }
}
