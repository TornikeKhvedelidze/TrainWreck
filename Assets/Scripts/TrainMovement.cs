using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TrainMovement : MonoBehaviour
{
    //კონკრეტული მანძილი ლიანდაგებს შორის
    private float _railDistance = 2;
    //ლიანდაგის ინდექსი რომელზეადაც მატარებელი დგას
    private int _currentLineIndex = 1;
    //დრო ერთი ზოლიდან მეორე გადასასვლელად
    private float _moveDuration = 0.15f;
    private float _delay = 0.02f;
    [SerializeField] List<Transform> _wagons;

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

    private void Move(int value)
    {
        if (Mathf.Abs(_currentLineIndex + value) > 1) return;

        _currentLineIndex += value;

        MoveToCurrentLine();
    }

    //dotween-ის გამოყენება გადაადგილებისთვის
    void MoveToCurrentLine()
    {
        Vector3 targetPosition = new Vector3(_currentLineIndex * _railDistance, transform.position.y, transform.position.z);

        Sequence moveSequence = DOTween.Sequence();

        for (int i = 0; i < _wagons.Count; i++)
        {
            Transform wagon = _wagons[i];
            Vector3 targetPos = new Vector3(targetPosition.x, wagon.position.y, wagon.position.z);

            moveSequence.AppendCallback(() => wagon.DOKill());
            moveSequence.Append(wagon.DOMove(targetPos, _moveDuration).SetEase(Ease.OutQuad));
            moveSequence.AppendInterval(_delay);
        }

        //transform.DOMove(targetPosition, _moveDuration).SetEase(Ease.OutQuad);
    }
}
