using Flurl.Http;
using IFlow.Testing.Utils.DataFactory;
using System.Threading.Tasks;

namespace IFlow.Testing.Utils.Api
{
    public static class WeatherApi
    {
        public static async Task<dynamic> GetCurrentWeatherData(string city, string units = "metric")
        {
            return (await ApiAddresses.CurrentWeatherDataApiUrl
                .WithHeader(UserData.CorrectApiUser.Header, UserData.CorrectApiUser.Key)
                .SetQueryParam("q", city)
                .SetQueryParam("units", units)
                .GetJsonAsync());
        }

        public static async Task<dynamic> GetMonthWeatherData(string city, string units = "metric")
        {
            return (await ApiAddresses.MonthWeatherDataApiUrl
                .WithHeader(UserData.CorrectApiUser.Header, UserData.CorrectApiUser.Key)
                .SetQueryParam("q", city)
                .SetQueryParam("units", units)
                .GetJsonAsync());
        }
    }
}
