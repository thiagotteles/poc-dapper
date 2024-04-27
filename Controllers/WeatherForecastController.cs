using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using poc_dapper.Data;

namespace poc_dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _repository;
        public WeatherForecastController(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<WeatherForecast>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet]
        [Route("{date}")]
        public async Task<WeatherForecast> Get(DateTime date)
        {
            return await _repository.Get(date);
        }

        [HttpPost]
        public async Task<WeatherForecast> Post(WeatherForecast weather)
        {
            return await _repository.InsertOrUpdate(weather);
        }

    }
}
