using UnityEngine;

public class Testing : MonoBehaviour
{
    public AchievementController controller;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            controller.UpdateProgress(1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            controller.UpdateProgress(-1);
        }
    }
}
