using FluentAssertions;
using IFlow.Testing.Utils.Api;
using IFlow.Testing.Utils.DataFactory;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    class WeatherApiSteps : BaseSteps
    {
        private dynamic weatherData;
        private string city = WeatherData.City;

        [When(@"User check the weather today in imperial units by Api")]
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public async Task WhenUserCheckTheWeatherTodayInImperialUnitsByApi()
        {
            weatherData = await WeatherApi.GetCurrentWeatherData(city, "imperial");
        }

        [Then (@"Imperial temperature and city are visible and correct")]
        public void ImperialTemperatureAndCityAreVisibleAndCorrect()
        {
            ((string)weatherData.name).Equals(city).Should().BeTrue();
            ((double)weatherData.main.temp).Should().BeInRange(0, 100);
        }

        [When(@"User check the weather today in metric units by Api")]
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public async Task WhenUserCheckTheWeatherTodayInMetricUnitsByApi()
        {
            weatherData = await WeatherApi.GetCurrentWeatherData(city);
        }

        [Then(@"Metric temperature and city are visible and correct")]
        public void MetricTemperatureAndCityAreVisibleAndCorrect()
        {
            ((string)weatherData.name).Equals(city).Should().BeTrue();
            ((double)weatherData.main.temp).Should().BeInRange(-30, 50);
        }

        [When(@"User check the climate forecast for 30 days in imperial units by Api")]
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public async Task WhenUserCheckTheClimateForecastInImperialUnitsByApi()
        {
            weatherData = await WeatherApi.GetMonthWeatherData(city, "Imperial");
        }

        [Then(@"Imperial temperature list and city are visible and correct for 30 days")]
        public void ImperialTemperatureListAndCityAreVisibleAndCorrect()
        {
            foreach (var item in weatherData.list)
            {
                foreach (var temp in item.temp)
                {
                    if ((string)temp.Key == "average")
                    {
                       ((double)temp.Value).Should().BeInRange(0, 100); ;
                    }
                }
            }

            ((string)weatherData.city.name).Equals(city).Should().BeTrue();
        }
    }
}
