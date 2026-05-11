namespace App_Clima_MAUI.Model
{
    public class WeatherCountryData
    {
        private int sunrise { get; set; } = 0;

        private int sunset { get; set; } = 0;

        public DateTime normalized_sunrise
        {
            get => new DateTime().AddSeconds(this.sunrise);
        }

        public DateTime normalized_sunset
        {
            get => new DateTime().AddSeconds(this.sunset);
        }
    }
}
