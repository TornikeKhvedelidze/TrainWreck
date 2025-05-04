using System.Collections.Generic;
using UnityEngine;


public class EndlessSpawner : MonoBehaviour
{
    [SerializeField] private float _speed = 60f;
    [SerializeField] private float _duplicantDistance = 80f;
    [SerializeField] private int _duplicantAmount = 3;
    [SerializeField] private Transform _objectsparent;
    [SerializeField] private EndlessSpawnObjects_Data _endlessSpawnObjects_Data;

    //private Dictionary<GameObject, List<EndlessSpawnObject>> _endlessSpawnObjectsPool;
    private List<EndlessSpawnObject> _endlessSpawnObjects = new();

    private void Start()
    {
        Initialise();
    }

    void Update()
    {
        for (int i = 0; i < _endlessSpawnObjects.Count; i++)
        {
            var endlessObject = _endlessSpawnObjects[i];

            var endlessObjectPosition = endlessObject.transform.localPosition;

            endlessObjectPosition.z -= _speed * Time.deltaTime;

            if (endlessObjectPosition.z <= -_duplicantDistance)
            {
                endlessObjectPosition.z += _duplicantDistance * _duplicantAmount;

                endlessObject.Respawn();
            }

            endlessObject.transform.localPosition = endlessObjectPosition;
        }
    }

    private void Initialise()
    {
        //_endlessSpawnObjectsPool = new();

        var position = Vector3.zero;

        for (int i = 0; i < _duplicantAmount; i++)
        {
            position = transform.forward * _duplicantDistance * i;

            var endlessObject = Instantiate(_endlessSpawnObjects_Data.GetRandomObject(), _objectsparent);

            endlessObject.transform.localPosition = position;

            _endlessSpawnObjects.Add(endlessObject);
        }
    }


    //private EndlessSpawnObject GetRandomObject()
    //{
    //    var randomObject = _endlessSpawnObjects_Data.GetRandomObject();
    //    EndlessSpawnObject chosenObject = null;

    //    if (_endlessSpawnObjectsPool.TryGetValue(randomObject.gameObject, out var objects))
    //    {
    //        chosenObject = objects[0];

    //        _endlessSpawnObjectsPool[randomObject.gameObject].Remove(chosenObject);
    //    }
    //    else
    //    {
    //        chosenObject = Instantiate(randomObject, _objectsparent);
    //    }

    //    _endlessSpawnObjects.Add(chosenObject);

    //    return chosenObject;
    //}
}
