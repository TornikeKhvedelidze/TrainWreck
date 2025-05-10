using UnityEngine;

[CreateAssetMenu(fileName = "WeatherData", menuName = "Scriptable Objects/WeatherData", order = 1)]
public class Weather_SO : ScriptableObject
{
    public WeatherType WeatherType;
    public Material SkyBoxMaterial;
    public GameObject WeatherParticles;
}
