using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndWeatherManager : MonoBehaviour
{
    [SerializeField] List<WeatherData> _weatherDataList;
    [SerializeField] TimeInterval[] _timeIntervalsArray;
    TimeOfDay _currentTimeOfDay;
    
    
    private ITimeProvider _timeProvider;
    private IWeatherProvider _weatherProvider;
    private int _currentTime;

    #region Initialization
    private void Start()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        _timeProvider = new PhoneClockTimeProvider();
        _weatherProvider = new RandomWeatherProvider();
        _currentTime = _timeProvider.GetCurrentTime().Hour;

        InitializeWeather();
        UpdateTimeOfDayVisuals(DetermineTimeOfDay(7));
    }
    #endregion

    #region Weather
    private void InitializeWeather()
    {
        SetWeather(_weatherProvider.GetCurrentWeather(_weatherDataList));
    }
    
    private void SetWeather(WeatherType weatherType)
    {
        WeatherData weatherData = _weatherDataList.Find(x => x.WeatherType == weatherType);
        if (weatherData != null)
        {
            RenderSettings.skybox = weatherData.SkyBoxMaterial;
        }
    }
    #endregion

    #region TimeOfDay
    private TimeOfDay DetermineTimeOfDay(int currentTimeOfDay)
    {
        foreach (TimeInterval interval in _timeIntervalsArray)
        {
            if (currentTimeOfDay >= interval.IntervalStart && currentTimeOfDay <= interval.IntervalEnd)
            {
                return interval.TimeOfDay;
            }
        }
        return TimeOfDay.morning;
    }
    private void UpdateTimeOfDayVisuals(TimeOfDay timeOfDay)
    {
        switch (timeOfDay)
        {
            case TimeOfDay.morning:
                Debug.Log("Switch to Morning visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 1.5f); 
                break;
            case TimeOfDay.midday:
                Debug.Log("Switch to midday visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 1f); 
                break;
            case TimeOfDay.afternoon:
                Debug.Log("Switch to afternoon visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 0.3f); 
                break;
        }
    }
    #endregion
}
