using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestManager : Singleton<ChestManager>
{
    [SerializeField] private ChestData _chestData;
    public static Action<ChestSO> OnChestOpen;

    public static List<ChestSO> GetAllAvailableChests()
    {
        return Instance._chestData.GetChests();
    }

    public void addChest(ChestSO chest)
    {
        Debug.Log("test");
        AddChest(chest, 1);
    }

    public void RemoveCHest(ChestSO chest)
    {
        RemoveChest(chest);
    }

    public static void AddChest(ChestSO chest, int addAmount = 1)
    {
        chest.Amount.Value += addAmount;
    }
    public static void RemoveChest(ChestSO chest)
    {
        chest.Amount.Value--;
    }
}
