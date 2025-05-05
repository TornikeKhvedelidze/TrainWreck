using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestManager : Singleton<ChestManager>
{
    [SerializeField] private ChestData _chestData;

    public static List<ChestSO> GetAllAvailableChests()
    {
        return Instance._chestData.chests.Where(x => x.Amount.Value > 0).ToList();
    }

    public static void AddChest(ChestSO chest, int addAmount)
    {
        chest.Amount.Value += addAmount;
    }
    public static void RemoveChest(ChestSO chest)
    {
        chest.Amount.Value--;
    }
}
