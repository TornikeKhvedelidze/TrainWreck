using LutorGames.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AchievementStatus_Saveable : Base_Saveable<AchievementStatus_Saveable>
{
    //public bool IsComplete;
    public bool IsClamed;

    public float Progress;
}

[Serializable]
public class AchievementInfo
{
    public string Description;
    public Sprite Icon;
    public Color Color;
    public float goal;

    public float progress => Status.Progress;
    public float progressRatio => Status.Progress / goal;
    public string Name => Status.Id;
    public bool IsCompleted => Status.Progress >= goal;
    public bool IsClaimed => Status.IsClamed;

    public AchievementStatus_Saveable Status;

    public void Claim()
    {
        if (!IsCompleted) return;
        Status.IsClamed = true;
        AchievementManager.OnSomethingChanged?.Invoke();
    }

    public void UpdateProgression(float num)
    {
        if (IsClaimed) return;
        Status.Progress += num;
        AchievementManager.OnSomethingChanged?.Invoke();
    }
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

    public bool TryGetAchievementByName(string name, out AchievementInfo info)
    {
        info = Achievements.FirstOrDefault(x => x.Name == name);

        if (info == null)
        {
            Debug.Log($"Could not find achievement by name : {name}");
        }
        return info != null;
    }

    public string[] GetAllAchievementNames()
    {
        return Achievements.Select(x => x.Name).ToArray();
    }
}

