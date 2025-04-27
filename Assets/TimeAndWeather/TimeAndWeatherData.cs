using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeAndWeatherData", menuName = "Scriptable Objects/TimeAndWeatherData")]
public class TimeAndWeatherData : ScriptableObject
{
    public List<WeatherData> WeatherDataList;
    public TimeInterval[] TimeIntervalsArray;
}
