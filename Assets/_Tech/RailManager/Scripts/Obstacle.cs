using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public string Id;
    public bool DoRemoveRail;

    public void Initialsie(Vector3 position, Transform parent = null)
    {
        transform.SetPositionAndRotation(position, parent.rotation);
        transform.parent = parent;

        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        ObstaclesManager.ReturnObstacleToPool(this);

        gameObject.SetActive(false);
    }
}
