using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class WeightedElements<T>
{
    public List<WeightedElement<T>> elements = new();

    public T GetRandomElement()
    {
        return elements.GetRandomElement();
    }
}

[Serializable]
public class WeightedElement<T>
{
    public T Element;
    [Range(0f, 100f)]
    public float Weight;
}

public static class Attributes
{
    public static T RandomElementFromList<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandomElement<T>(this List<WeightedElement<T>> elements)
    {
        float totalWeight = 0f;
        foreach (var element in elements)
        {
            totalWeight += element.Weight;
        }

        if (totalWeight <= 0f)
        {
            Debug.LogWarning("Total weight is zero or negative.");
            return default;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        foreach (var element in elements)
        {
            cumulative += element.Weight;
            if (randomValue <= cumulative)
            {
                return element.Element;
            }
        }

        return elements[elements.Count - 1].Element;
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
