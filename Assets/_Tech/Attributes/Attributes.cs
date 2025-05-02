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
        var distance = Vector3.Distance(start, end);
        var direction = (end - start).normalized;

        var randomValue = Random.Range(0, distance);

        return start + direction * randomValue;
    }
}
