using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : Singleton<ChestManager>
{
    [SerializeField] private ChestData _chestData;
    [SerializeField] private ChestInvoker_ESO _chestInvoker_ESO;
    public static Action<ChestSO> OnChestOpen;

    public static List<ChestSO> GetAllAvailableChests()
    {
        return Instance._chestData.GetChests();
    }

    public static void OpenChest(ChestSO chest)
    {
        Instance._chestInvoker_ESO.Value = chest;
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
