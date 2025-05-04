using LutorGames.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AchievementStatus_Saveable : Base_Saveable<AchievementStatus_Saveable>
{
    public bool IsComplete;
    public bool IsClamed;
}

[Serializable]
public class AchievementInfo
{
    public string Description;
    public Sprite Icon;
    public Color Color;
    public string Name => Status.Id;
    public bool IsCompleted => Status.IsComplete;
    public bool IsClaimed => Status.IsClamed;

    public AchievementStatus_Saveable Status;
}


[CreateAssetMenu(fileName = "AchievementData", menuName = "Scriptable Objects/AchievementData")]
public class AchievementData : ScriptableObject
{
    public List<AchievementInfo> Achievements;

    public bool TryGetCurrentAchievement(out AchievementInfo info)
    {
        info = Achievements.FirstOrDefault(x => !x.IsClaimed);

        return info != null;
    }
}

