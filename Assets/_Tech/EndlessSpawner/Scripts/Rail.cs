using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private GameObject _railVisual;
    [SerializeField] private Transform _obstaclePointStart;
    [SerializeField] private Transform _obstaclePointEnd;

    private Obstacle _obstacle;

    public void Clear()
    {
        SetRailActive(true);

        _obstacle?.ReturnToPool();

        _obstacle = null;
    }

    public void InitialiseObstacle(Obstacle obstacle)
    {
        _obstacle = obstacle;

        if (obstacle.DoRemoveRail)
        {
            SetRailActive(false);
            obstacle.Initialsie(_obstaclePointStart.position, transform);

            return;
        }

        SetRailActive(true);

        obstacle.Initialsie(_obstaclePointStart.position.RandomBetweenVector3(_obstaclePointEnd.position), transform);
    }

    public void SetRailActive(bool value)
    {
        _railVisual.SetActive(value);
    }
}
