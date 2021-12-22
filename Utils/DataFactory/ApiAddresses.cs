
namespace IFlow.Testing.Utils.DataFactory
{
    public static class ApiAddresses
    {
        private static string BaseApiUrl => "https://community-open-weather-map.p.rapidapi.com/";
        public static string CurrentWeatherDataApiUrl => BaseApiUrl + "weather";
        public static string MonthWeatherDataApiUrl => BaseApiUrl + "climate/month";
    }
}
