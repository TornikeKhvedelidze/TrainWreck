using CustomInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class AchievementController
{
    [ValueDropdown(AchievementManager.achievementsNameQuery)]
    public string achievementName;
    private AchievementInfo _achievementInfo;
    public void UpdateProgress(float num)
    {
        //if (_achievementInfo == null && AchievementManager.TryGetAchievementByName(achievementName, out _achievementInfo)) return;
        InitializeAchievement();
        _achievementInfo.UpdateProgression(num);
    }
    public void Claim()
    {
        InitializeAchievement();
        _achievementInfo.Claim();
    }
    private void InitializeAchievement()
    {
        if (_achievementInfo != null) return;
        AchievementManager.TryGetAchievementByName(achievementName, out _achievementInfo);
    }
}
public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private AchievementData _data;
    public const string achievementsNameQuery =
#if UNITY_EDITOR
        "AchievementManager.GetAllAchievementsName";
#else
        "";
#endif

    public static Action OnSomethingChanged;

    public static bool TryGetAchievementByName(string name, out AchievementInfo info) => Instance._data.TryGetAchievementByName(name, out info);
    public static List<AchievementInfo> GetAllAchievements() => Instance._data.Achievements;
    public static string[] GetAllAchievementsName() => Instance._data.GetAllAchievementNames();
    public static bool TryGetCurrentAchievement(out AchievementInfo info) => Instance._data.TryGetCurrentAchievement(out info);
}
