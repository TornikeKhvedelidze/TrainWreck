using UnityEngine;

public class EndlessSpawnObject : MonoBehaviour
{
    public virtual void Respawn()
    {
        SetActive(true);
    }

    public virtual void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
