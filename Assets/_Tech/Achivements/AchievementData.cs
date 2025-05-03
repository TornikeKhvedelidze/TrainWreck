using LutorGames.SaveSystem;
using LutorGames.Serializables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class AchievementStatus : Base_Saveable<AchievementStatus>
{
    public bool isComplete;
    public bool isClamed;
}
[Serializable]
public class AchievementInfo
{
    public string description;
    public string name => status.Id;
    public bool isCompleted => status.isComplete;
    public bool isClaimed => status.isClamed;
    public AchievementStatus status;
}
[CreateAssetMenu(fileName = "AchievementData", menuName = "Scriptable Objects/AchievementData")]
public class AchievementData : ScriptableObject
{
    public List<AchievementInfo> Achievements;

    public bool TryGetCurrentAchievement(out AchievementInfo info)
    {
        info = Achievements.FirstOrDefault(x => !x.isClaimed);
        return info != null;
    }
}

