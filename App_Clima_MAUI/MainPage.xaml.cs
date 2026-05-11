using App_Clima_MAUI.Model;

using App_Clima_MAUI.Service;
using System.Text;

namespace App_Clima_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_search_Clicked(object sender, EventArgs e)
        {
            try
            {
                string? city = txt_city.Text;

                if (String.IsNullOrWhiteSpace(city))
                {
                    throw new Exception("Preencha o campo corretamente!");
                }

                Weather? weather = await WeatherService.GetWeather(city);

                if (weather != null)
                {
                    StringBuilder raw_link = new StringBuilder();

                    string normalized_lat = weather.coord.lat.ToString().Replace(",", ".");
                    string normalized_lon = weather.coord.lon.ToString().Replace(",", ".");

                    raw_link.Append("https://embed.windy.com/embed.html?type=map&location=coordinates");
                    raw_link.Append("&metricRain=mm&metricTemp=°C&metricWind=km/h&zoom=5&overlay=wind&");
                    raw_link.Append($"product=ecmwf&level=surface&lat={weather.coord.lat}&lon={weather.coord.lon}");

                    wbview_localization.Source = new Uri(raw_link.ToString());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro!", ex.Message, "OK");
            }
        }
    }
}
