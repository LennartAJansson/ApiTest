﻿namespace Contracts;

using Refit;

public interface IWeatherForecastsApi
{
    [Get("/WeatherForecast/GetAll")]
    Task<IEnumerable<WeatherForecast>> GetForecasts();
    [Get("/WeatherForecast/GetById/{id}")]
    Task<WeatherForecast> GetForecast(int id);
}

//https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude={part}&appid={API key}