namespace poc_dapper.Data
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecast>> GetAll();

        Task<WeatherForecast> Get(DateTime date);

        Task<WeatherForecast> InsertOrUpdate(WeatherForecast weatherForecast);
    }
}
