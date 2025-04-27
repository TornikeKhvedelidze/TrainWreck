using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform _camera;

    void Start()
    {
        _camera = Camera.main.transform;

        if (_camera != null) return;

        Debug.LogError("I can't find camera");
    }

    private void Update()
    {
        if (_camera == null) return;

        transform.LookAt(_camera);
    }
}
