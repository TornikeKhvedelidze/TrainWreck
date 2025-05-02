using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeAndWeatherData", menuName = "Scriptable Objects/TimeAndWeatherData")]
public class TimeAndWeatherData_SO : ScriptableObject
{
    public List<WeatherData_SO> WeatherDataList;
    public TimeInterval[] TimeIntervalsArray;
}
