using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : Singleton<ObstaclesManager>
{
    [SerializeField] private Obstacles_Data _obstaclesData;
    private static Dictionary<string, Queue<Obstacle>> _obstaclesPool;

    protected override void Awake()
    {
        base.Awake();

        Initialise();
    }

    public static Obstacle GetRandomObstacle()
    {
        var obstacle = Instance._obstaclesData.GetRandomObstacle();

        if (_obstaclesPool.ContainsKey(obstacle.Id) && _obstaclesPool[obstacle.Id].Count > 0)
        {
            obstacle = _obstaclesPool[obstacle.Id].Dequeue();

            return obstacle;
        }

        return Instantiate(obstacle);
    }

    public static void ReturnObstacleToPool(Obstacle obstacle)
    {

        if (!_obstaclesPool.ContainsKey(obstacle.Id))
        {
            _obstaclesPool[obstacle.Id] = new();
        }

        _obstaclesPool[obstacle.Id].Enqueue(obstacle);
    }

    private void Initialise()
    {
        _obstaclesPool = new();
    }
}
