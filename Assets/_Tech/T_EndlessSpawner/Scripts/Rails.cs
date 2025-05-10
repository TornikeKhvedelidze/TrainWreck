using System.Collections.Generic;
using UnityEngine;

public class Rails : EndlessSpawnObject
{
    [SerializeField] private List<Rail> _rails;

    public override void Respawn()
    {
        base.Respawn();

        UpdateObstacle();
    }

    public void UpdateObstacle()
    {
        _rails.ForEach(x => x.Clear());

        var obstacleAmount = Random.Range(0, _rails.Count);

        var chosenRails = _rails.RandomElementsFromList(obstacleAmount);

        foreach (var rail in chosenRails)
        {
            var obstacle = ObstaclesManager.GetRandomObstacle();

            rail.InitialiseObstacle(obstacle);
        }
    }
}
