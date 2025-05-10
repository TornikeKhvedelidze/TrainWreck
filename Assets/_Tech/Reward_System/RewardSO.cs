using UnityEngine;

public class RewardSO : ScriptableObject
{
    public string rewardName;
    public GameObject RewardPrefab;

    public virtual void ApplyReward()
    {
        Debug.Log("Applied Reward" + rewardName);

    }
}
