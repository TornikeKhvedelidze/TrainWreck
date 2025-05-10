using System;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class TimeAndWeatherManager : Singleton<TimeAndWeatherManager>
{
    [SerializeField] TimeAndWeather_Data _timeAndWeather_Data;
    [SerializeField] private Vector3 _particleOffset;

    private Transform _cameraTransform;
    private int _currentHour => GetCurrentTime().Hour;

    #region Initialization
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _cameraTransform = Camera.main.transform;

        InitializeWeather();

        UpdateTimeOfDayVisuals(DetermineTimeOfDay(_currentHour));
    }
    #endregion

    public static DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }

    public static WeatherType GetCurrentWeather()
    {
        var watherList = Instance._timeAndWeather_Data.WeatherList;

        return watherList.GetRandomElement().WeatherType;
    }

    #region Weather
    private void InitializeWeather()
    {
        SetWeather(GetCurrentWeather());
    }

    private void SetWeather(WeatherType weatherType)
    {
        Weather_SO weatherData = _timeAndWeather_Data.WeatherList.Elements.Find(x => x.Element.WeatherType == weatherType).Element;


        if (weatherData != null)
        {
            RenderSettings.skybox = weatherData.SkyBoxMaterial;

            if (weatherData.WeatherParticles == null) return;

            //TODO: Implement object pool
            Instantiate(weatherData.WeatherParticles, _cameraTransform.position + _particleOffset, quaternion.identity, _cameraTransform);

            return;
        }

        Debug.LogError($"Couldn't found wather with type: {weatherType}");
    }
    #endregion

    #region TimeOfDay
    private TimeOfDay DetermineTimeOfDay(int currentTimeOfDay)
    {
        var time = _timeAndWeather_Data.TimeIntervals.FirstOrDefault(x => currentTimeOfDay >= x.IntervalStart && currentTimeOfDay <= x.IntervalEnd)?.TimeOfDay;

        return time ?? TimeOfDay.morning;
    }

    private void UpdateTimeOfDayVisuals(TimeOfDay timeOfDay)
    {
        switch (timeOfDay)
        {
            case TimeOfDay.morning:
                Debug.Log("Switch to Morning visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 1.5f);
                break;
            case TimeOfDay.evening:
                Debug.Log("Switch to afternoon visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 0.3f);
                break;
        }
    }
    #endregion
}
