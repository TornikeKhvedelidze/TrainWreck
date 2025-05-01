using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{
    [SerializeField] private float _speed = 60f;
    [SerializeField] private float _railDuplicantDistance = 80f;
    [SerializeField] private int _railDuplicantAmount = 3;
    [SerializeField] private int _railwayDistance = 6;
    [SerializeField] private int _railwayAmount = 3;
    [SerializeField] private Transform _railsparent;
    [SerializeField] private GameObject _rail;
    //[SerializeField] private GameObject _obstacle;

    private List<Transform> _rails = new();
    private Vector3 _railsPosition;

    private void Start()
    {
        Initialise();
    }

    void Update()
    {
        _railsPosition += Vector3.forward * -_speed * Time.deltaTime;

        _railsparent.position = _railsPosition;

        if (_railsPosition.z > -_railDuplicantDistance) return;

        _railsPosition.z += _railDuplicantDistance;
    }

    private void Initialise()
    {
        for (int i = 0; i < _railwayAmount; i++)
        {
            for (int r = 0; r < _railDuplicantAmount; r++)
            {
                var index = i - Mathf.FloorToInt(_railwayAmount / 2);

                var postiion = new Vector3(_railwayDistance * index, 0, _railDuplicantDistance * r);

                var rail = Instantiate(_rail, postiion, Quaternion.identity, _railsparent).transform;

                _rails.Add(rail);
            }

        }
    }

}
