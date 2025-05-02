using System;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[Serializable]
public class ChestRewardInfo : WeightedElements<RewardSO>
{
    
}

[CreateAssetMenu(fileName = "Chest_SO", menuName = "Scriptable Objects/Rewards/Chest_SO")]
public class ChestSO : ScriptableObject
{
    public Rarity rarity;
    public ChestRewardInfo  chestRewardInfo;
}
