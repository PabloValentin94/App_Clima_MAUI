namespace App_Clima_MAUI.Model
{
    public class Weather
    {
        public WeatherCoordinates coord { get; set; } = new WeatherCoordinates();

        public WeatherData[] weather { get; set; } = Array.Empty<WeatherData>();

        public WeatherMainData main { get; set; } = new WeatherMainData();

        public WeatherCountryData sys { get; set; } = new WeatherCountryData();

        private int timezone { get; set; } = 0;

        public DateTime normalized_timezone
        {
            get => new DateTime().AddSeconds(this.timezone);
        }
    }
}
