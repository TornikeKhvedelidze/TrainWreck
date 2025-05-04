using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private AchievementData _data;

    public static List<AchievementInfo> GetAllAchievements()
    {
        return Instance._data.Achievements;
    }

    public static bool TryGetCurrentAchievement(out AchievementInfo info) => Instance._data.TryGetCurrentAchievement(out info);
}
