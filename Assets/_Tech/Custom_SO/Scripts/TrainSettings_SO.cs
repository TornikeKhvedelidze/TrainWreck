using UnityEngine;

[CreateAssetMenu(fileName = "TrainUpgradesSO", menuName = "Scriptable Objects/TrainUpgradesSO")]
public class TrainSettings_SO : ScriptableObject
{
    public string Name;
    public UpgradeSettings_Data UpgradeSettings;
}
