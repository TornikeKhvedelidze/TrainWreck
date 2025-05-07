using LutorGames.SaveSystem;
using System;
using UnityEngine;


[Serializable]
public class ChestRewardInfo : WeightedElements<RewardSO>
{

}

[CreateAssetMenu(fileName = "Chest_SO", menuName = "Scriptable Objects/Rewards/Chest_SO")]
public class ChestSO : ScriptableObject
{
    [TextArea]
    public string Description;
    [Range(0, 50)]
    public int RewardAmount;
    public Sprite Icon;
    public Chest chestPrefab;
    public ChestRewardInfo ChestRewardInfo; //List of WeightedElements with type of rewardSo
    public Int_Saveable Amount;
    public string Name => Amount.Id;
}


