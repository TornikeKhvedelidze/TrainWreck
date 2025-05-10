using System;
using UnityEngine;

public enum TimeOfDay
{
    morning,
    evening,
};
public enum WeatherType
{
    Sunny,
    Rainy,
    Snowy
};


[Serializable]
public class TimeInterval
{
    public TimeOfDay TimeOfDay;
    public int IntervalStart;
    public int IntervalEnd;
}

[Serializable]
public class WeightedWeathers : WeightedElements<Weather_SO>
{

}

[CreateAssetMenu(fileName = "TimeAndWeatherData", menuName = "Scriptable Objects/TimeAndWeatherData")]
public class TimeAndWeather_Data : ScriptableObject
{
    public WeightedWeathers WeatherList;
    public TimeInterval[] TimeIntervals;
}
