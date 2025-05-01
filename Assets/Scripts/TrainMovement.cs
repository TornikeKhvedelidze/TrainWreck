using DG.Tweening;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    //კონკრეტული მანძილი ლიანდაგებს შორის
    private float[] linesX = new float[] { -2f, 0f, 2f };
    //ლიანდაგის ინდექსი რომელზეადაც მატარებელი დგას
    private int currentLineIndex = 1;
    //დრო ერთი ზოლიდან მეორე გადასასვლელად
    private float moveDuration = 0.5f;

    //მარჯვენა/მარცხენა ღილაკებით კონტროლი
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
    void MoveLeft()
    {
        if (currentLineIndex > 0)
        {
            currentLineIndex--;
            MoveToCurrentLine();
        }
    }
    void MoveRight()
    {
        if (currentLineIndex < 2)
        {
            currentLineIndex++;
            MoveToCurrentLine();
        }
    }
    //dotween-ის გამოყენება გადაადგილებისთვის
    void MoveToCurrentLine()
    {
        Vector3 targetPosition = new Vector3(linesX[currentLineIndex], transform.position.y, transform.position.z);
        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.OutQuad);
    }
}
