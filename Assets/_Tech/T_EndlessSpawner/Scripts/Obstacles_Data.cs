using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesData", menuName = "Scriptable Objects/ObstaclesData")]
public class Obstacles_Data : ScriptableObject
{
    public List<Obstacle> obstacles;

    public Obstacle GetRandomObstacle()
    {
        var obstacle = obstacles.RandomElementFromList();

        if (obstacle == null)
        {
            Debug.LogError("Couldn't found Obstacle");
        }

        return obstacles.RandomElementFromList();
    }
}
