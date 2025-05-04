using System;
using UnityEngine;


[Serializable]
public class EndlessSpawnObjectsWieght : WeightedElements<EndlessSpawnObject>
{
}

[CreateAssetMenu(fileName = "EndlessSpawnObjects_Data", menuName = "Scriptable Objects/EndlessSpawnObjects_Data")]
public class EndlessSpawnObjects_Data : ScriptableObject
{
    public EndlessSpawnObjectsWieght _spawnObject;

    public EndlessSpawnObject GetRandomObject()
    {
        return _spawnObject.GetRandomElement();
    }
}
