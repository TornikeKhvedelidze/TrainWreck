using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour
{
    [SerializeField] private List<Rail> _rails;

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
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
