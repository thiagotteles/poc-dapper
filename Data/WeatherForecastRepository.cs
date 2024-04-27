
using Dapper;

namespace poc_dapper.Data
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private DatabaseConnection _connection;

        public WeatherForecastRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<WeatherForecast> Get(DateTime date)
        {
            using (var conn = _connection.Connection)
            {
                var qry = "select \"date\", temperature, summary from log where  \"date\" = @date";
                var results = await conn.QueryFirstAsync<WeatherForecast>(qry, param: new { date });
                return results;
            }
            
        }

        public async Task<List<WeatherForecast>> GetAll()
        {
            using (var conn = _connection.Connection)
            {
                var qry = "select \"date\", temperature, summary from log";
                var results = (await conn.QueryAsync<WeatherForecast>(qry)).ToList();
                return results;   
            }
        }

        public async Task<WeatherForecast> InsertOrUpdate(WeatherForecast weatherForecast)
        {
            using(var conn = _connection.Connection)
            {

                var command = "INSERT INTO log (\"date\", temperature, summary) VALUES (@Date, @Temperature, @Summary) ON CONFLICT (\"date\") DO UPDATE SET temperature = EXCLUDED.temperature, summary = EXCLUDED.summary;";
                var result = await conn.ExecuteAsync(command, weatherForecast);
                return weatherForecast;
            }
        }
    }
}
