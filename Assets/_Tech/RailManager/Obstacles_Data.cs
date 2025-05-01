using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObstacleInfo
{
    public string Name;
    public bool RemovesRail;
    public GameObject GameObject;
}

[CreateAssetMenu(fileName = "ObstaclesData", menuName = "Scriptable Objects/ObstaclesData")]
public class Obstacles_Data : ScriptableObject
{
    public List<ObstacleInfo> obstacles;

    public ObstacleInfo GetObstacleInfo()
    {
        return obstacles.RandomList();
    }
}
