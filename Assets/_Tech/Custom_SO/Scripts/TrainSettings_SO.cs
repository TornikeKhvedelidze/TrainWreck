using LutorGames.SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrainSetting
{
    public Int_Saveable Level;
    public List<float> Levels;
    public string Name => Level.Id;
    public float Default_Value => Levels[0];
    public float Current_Value => Levels[Level.Value];
    public float Next_Value => Levels[Level.Value + 1];
}

[CreateAssetMenu(fileName = "TrainUpgradesSO", menuName = "Scriptable Objects/TrainUpgradesSO")]
public class TrainSettings_SO : ScriptableObject
{
    public string Name;
    public TrainSetting MaxSpeed;
    public TrainSetting Acceleration;
    public TrainSetting Steering;

}
