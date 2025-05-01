using DG.Tweening;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    //კონკრეტული მანძილი ლიანდაგებს შორის
    private float _railDistance = 2;
    //ლიანდაგის ინდექსი რომელზეადაც მატარებელი დგას
    private int _currentLineIndex = 1;
    //დრო ერთი ზოლიდან მეორე გადასასვლელად
    private float _moveDuration = 0.5f;

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
        transform.DOMove(targetPosition, _moveDuration).SetEase(Ease.OutQuad);
    }
}
