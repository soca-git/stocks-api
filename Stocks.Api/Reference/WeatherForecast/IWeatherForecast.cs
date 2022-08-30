using System;
using System.Collections.Generic;
using Stocks.Api.Reference.WeatherForecast.Contracts;

namespace Stocks.Api.Reference.WeatherForecast
{
    public interface IWeatherForecast
    {
        IEnumerable<DayWeatherForecast> Get();
    }
}
