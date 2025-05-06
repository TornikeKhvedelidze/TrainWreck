using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] ChestSO chestData;

    private void OpenChest(ChestSO chestSO)
    {
        List<WeightedElement<RewardSO>> rewards = chestSO.ChestRewardInfo.elements;

        int amountToOpen = chestSO.Amount.Value;
        Debug.Log(amountToOpen);

        for (int i = 0; i < amountToOpen; i++)
        {
            RewardSO rewardData = Attributes.GetRandomElement(rewards);
            GiveReward(rewardData);
        }
    }

    private void GiveReward(RewardSO rewardSO)
    {
        rewardSO.ApplyReward();
    }
}
