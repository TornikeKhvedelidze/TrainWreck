using System;
using System.Collections.Generic;
using LutorGames.SaveSystem;
using UnityEngine;

[Serializable]
public class ChestInfo
{
    public ChestRarity chestRarity;
    public int chestCount;
}
[Serializable]
public class ChestInfos_Saveable : Base_Saveable<List<ChestInfo>>
{
    
}

public class ChestManager : Singleton<ChestManager>
{
    [SerializeField] private ChestInfos_Saveable _data;
    [SerializeField] ChestData chestData;
    

    public static List<ChestSO> GetAllChests()
    {
        List<ChestSO> result = new List<ChestSO>();
        
        foreach (var chestInfo in Instance._data.Value)
        {
            var chest = Instance.chestData.GetChestByRarity(chestInfo.chestRarity);
            if (chest == null) return null;
            
            result.Add(chest);
        }
        return result;
    }

    public static void AddChest(ChestSO chest, int chestCount)
    {
        var data = Instance._data.Value;
        
        var existingData =  data.Find(x => x.chestRarity == chest.ChestRarity);
        if (existingData != null)
        {
            existingData.chestCount += chestCount;
        }
        else
        {
            data.Add(new ChestInfo
            {
                chestRarity = chest.ChestRarity,
                chestCount = chestCount
            });
        }
    }
    public static void RemoveChest(ChestSO chest)
    {
        var data = Instance._data.Value;
        var existingData = data.Find(x => x.chestRarity == chest.ChestRarity);
        existingData.chestCount--;
    }
}
