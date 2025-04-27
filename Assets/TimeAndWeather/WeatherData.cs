using UnityEngine;

public enum WeatherType
{
    Sunny,
    Rainy,
    Snowy
};

[CreateAssetMenu(fileName = "WeatherData", menuName = "WeatherData", order = 1)]
public class WeatherData : ScriptableObject
{
    public WeatherType WeatherType;
    public Material SkyBoxMaterial;
}
