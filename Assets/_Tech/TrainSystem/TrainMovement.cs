using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    //კონკრეტული მანძილი ლიანდაგებს შორის
    [SerializeField] private float _railDistance = 2;
    //დრო ერთი ზოლიდან მეორე გადასასვლელად
    [SerializeField] private float _turnAngle = 15f;
    [SerializeField] private float _moveDuration = 0.15f;
    [SerializeField] private float _delay = 0.02f;
    [SerializeField] private int _railwayAmount;
    [SerializeField] private Ease _ease;
    [SerializeField] List<Transform> _wagons;

    //ლიანდაგის ინდექსი რომელზეადაც მატარებელი დგას
    private int _currentLineIndex = 0;

    private void Start()
    {
        Initialise();
    }

    //მარჯვენა/მარცხენა ღილაკებით კონტროლი
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1);
        }
    }

    private void Initialise()
    {
        MoveToCurrentLine();
    }

    private void Move(int value)
    {
        if (Mathf.Abs(_currentLineIndex + value) > 1) return;

        _currentLineIndex += value;

        MoveToCurrentLine(_turnAngle * value);
    }

    //dotween-ის გამოყენება გადაადგილებისთვის
    void MoveToCurrentLine(float turn = 0)
    {
        Vector3 targetPosition = new Vector3(_currentLineIndex * _railDistance, transform.position.y, transform.position.z);

        for (int i = 0; i < _wagons.Count; i++)
        {
            Transform wagon = _wagons[i];
            Vector3 targetPos = new Vector3(targetPosition.x, wagon.position.y, wagon.position.z);

            DOTween.Sequence()
                .AppendCallback(() => wagon.DOKill())
                .AppendInterval((_delay) * i)
                .Append(wagon.DOLocalRotate(new Vector3(0, turn, 0), _moveDuration).SetEase(Ease.InOutSine))
                .AppendInterval(_moveDuration / 2)
                .Join(wagon.DOMove(targetPos, _moveDuration).SetEase(Ease.InOutSine))
                .Join(wagon.DOLocalRotate(Vector3.zero, _moveDuration).SetEase(Ease.InOutSine));
        }

        //transform.DOMove(targetPosition, _moveDuration).SetEase(Ease.OutQuad);
    }
}
