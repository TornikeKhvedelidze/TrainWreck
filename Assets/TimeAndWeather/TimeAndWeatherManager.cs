using Unity.Mathematics;
using UnityEngine;

public class TimeAndWeatherManager : MonoBehaviour
{
    [SerializeField] TimeAndWeatherData_SO Data;
    [SerializeField] private Vector3 particleOffset;

    private ITimeProvider _timeProvider;
    private IWeatherProvider _weatherProvider;
    private Transform _cameraTransform; 
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
        _cameraTransform = Camera.main.transform;
        _currentTime = _timeProvider.GetCurrentTime().Hour;

        InitializeWeather();
        UpdateTimeOfDayVisuals(DetermineTimeOfDay(_currentTime));
    }
    #endregion

    #region Weather
    private void InitializeWeather()
    {
        SetWeather(_weatherProvider.GetCurrentWeather(Data.WeatherDataList));
    }

    private void SetWeather(WeatherType weatherType)
    {
        WeatherData_SO weatherData = Data.WeatherDataList.Find(x => x.WeatherType == weatherType);
        if (weatherData != null)
        {
            RenderSettings.skybox = weatherData.SkyBoxMaterial;
            if(weatherData.WeatherParticles == null) return;
            Instantiate(weatherData.WeatherParticles, _cameraTransform.position + particleOffset,quaternion.identity, _cameraTransform);
        }
    }
    #endregion

    #region TimeOfDay
    private TimeOfDay DetermineTimeOfDay(int currentTimeOfDay)
    {
        foreach (TimeInterval interval in Data.TimeIntervalsArray)
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
            case TimeOfDay.evening:
                Debug.Log("Switch to afternoon visuals");
                RenderSettings.skybox.SetFloat("_Exposure", 0.3f);
                break;
        }
    }
    #endregion
}
