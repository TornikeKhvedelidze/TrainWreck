using System.Collections.Generic;

public interface IWeatherProvider
{
    WeatherType GetCurrentWeather(List<WeatherData> weatherDataList);
}