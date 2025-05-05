using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "Scriptable Objects/Rewards/ChestsData")]
public class ChestData : ScriptableObject
{
    public List<ChestSO> chests;

    public ChestSO GetChestByRarity(ChestRarity rarity)
    {
        return chests.FirstOrDefault(x => x.ChestRarity == rarity);
    }
}
