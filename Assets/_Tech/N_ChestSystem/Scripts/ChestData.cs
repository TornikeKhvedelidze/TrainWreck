using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestInfo
{
    public ChestSO chestSO;
}

[CreateAssetMenu(fileName = "ChestData", menuName = "Scriptable Objects/Rewards/ChestsData")]
public class ChestData : ScriptableObject
{
    public List<ChestSO> chests;

    public ChestSO GetChestByName(string name)
    {
        return chests.FirstOrDefault(x => x.Name == name);
    }

    public List<ChestSO> GetChests()
    {
        return chests.Where(x => x.Amount.Value > 0).ToList();
    }
}
