using App_Clima_MAUI.Model;

using Newtonsoft.Json;

namespace App_Clima_MAUI.Service
{
    public static class WeatherService
    {
        public static async Task<Weather?> GetWeather(string city)
        {
            string response_json = await ApiService.Get($"/weather?q={city}&units=metric");

            Weather? response = JsonConvert.DeserializeObject<Weather>(response_json);

            return response;
        }
    }
}
