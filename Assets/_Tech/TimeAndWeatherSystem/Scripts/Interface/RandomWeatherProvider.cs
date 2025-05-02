using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeatherProvider : IWeatherProvider
{
    public WeatherType GetCurrentWeather(List<WeatherData_SO> weatherDataList)
    {
        int randomWeatherIndex = UnityEngine.Random.Range(0, weatherDataList.Count);
        return weatherDataList[randomWeatherIndex].WeatherType;
    }
}
