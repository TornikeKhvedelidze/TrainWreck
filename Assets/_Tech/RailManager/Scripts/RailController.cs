using System.Collections.Generic;
using UnityEngine;

public interface ITest
{
    void Testme();
}

public class RailController : MonoBehaviour, ITest
{
    [SerializeField] private float _speed = 60f;
    [SerializeField] private float _railDuplicantDistance = 80f;
    [SerializeField] private int _railDuplicantAmount = 3;
    [SerializeField] private Transform _railsparent;
    [SerializeField] private Rails _rail;
    //[SerializeField] private GameObject _obstacle;

    private List<Rails> _rails = new();

    private void Start()
    {
        Initialise();
        Testme();

    }

    void Update()
    {
        for (int i = 0; i < _rails.Count; i++)
        {
            var rail = _rails[i];

            var railPosition = rail.transform.position;

            railPosition += Vector3.forward * -_speed * Time.deltaTime;

            if (railPosition.z <= -_railDuplicantDistance)
            {
                railPosition.z += _railDuplicantDistance * _railDuplicantAmount;

                rail.UpdateObstacle();
            }

            rail.transform.position = railPosition;
        }
    }

    private void Initialise()
    {
        var position = Vector3.zero;

        for (int i = 0; i < _railDuplicantAmount; i++)
        {
            position.z = _railDuplicantDistance * i;

            var rail = Instantiate(_rail, position, Quaternion.identity, _railsparent);

            _rails.Add(rail);
        }
    }

    public void Testme()
    {
    }
}
