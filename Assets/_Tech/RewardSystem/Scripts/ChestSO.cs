using System;
using System.Collections.Generic;
using System.Linq;
using LutorGames.SaveSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum ChestRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
[Serializable]
public class RarityInfo
{
    [FormerlySerializedAs("rarity")] public ChestRarity chestRarity;
    public int itemCount;
}

[Serializable]
public class ChestRewardInfo : WeightedElements<RewardSO>
{
    
}

[CreateAssetMenu(fileName = "Chest_SO", menuName = "Scriptable Objects/Rewards/Chest_SO")]
public class ChestSO : ScriptableObject
{
    public ChestRarity ChestRarity; //affects number of items you get from chest
    [TextArea] 
    public string Description;
    public Sprite Icon;
    public RarityTableSO RarityInfos;  
    public ChestRewardInfo  ChestRewardInfo; //List of WeightedElements with type of rewardSo
    public int amount;
}


