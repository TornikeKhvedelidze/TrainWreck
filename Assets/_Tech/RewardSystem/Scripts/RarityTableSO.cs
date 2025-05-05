using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "RarityTableSO", menuName = "Scriptable Objects/Rewards/Rarity Table")]
public class RarityTableSO : ScriptableObject
{
    public RarityInfo[] rarityInfos;

    public RarityInfo GetRarityInfo(ChestRarity chestRarity)
    {
        var info = rarityInfos.FirstOrDefault(x => x.chestRarity == chestRarity);
        if (info == null)
            Debug.LogWarning($"Rarity {chestRarity} not found in RarityTableSO.");
        return info;
    }
}
