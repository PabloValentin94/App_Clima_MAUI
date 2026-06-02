using System.Text;

using App_Clima_MAUI.Model;

using App_Clima_MAUI.Service;

namespace App_Clima_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		private async void LoadCity(double lat, double lon)
		{
			try
			{
				IEnumerable<Placemark> places = await Geocoding.Default.GetPlacemarksAsync(lat, lon);

				Placemark? place = places.FirstOrDefault();

				if (place != null)
				{
					txt_city.Text = place.Locality;
				}
			}
			catch (Exception ex)
			{
				await DisplayAlertAsync("Erro!", ex.Message, "OK");
			}
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
                    raw_link.Append($"product=ecmwf&level=surface&lat={normalized_lat}&lon={normalized_lon}");

                    wbview_localization.Source = new Uri(raw_link.ToString());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro!", ex.Message, "OK");
            }
        }

        private async void btn_current_locality_Clicked(object sender, EventArgs e)
        {
            try
            {
                GeolocationRequest current_locality_request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                Location? current_locality = await Geolocation.Default.GetLocationAsync(current_locality_request);

                if (current_locality != null)
                {
                    LoadCity(current_locality.Latitude, current_locality.Longitude);
                }
                else
                {
                    throw new Exception("Localização atual não encontrada!");
                }
            }
            catch (FeatureNotEnabledException)
            {
                await DisplayAlertAsync("Erro!", "Uso de localização não habilitado no dispositivo.", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlertAsync("Erro!", "Uso de localização não suportado pelo dispositivo.", "OK");
            }
            catch (PermissionException)
            {
				await DisplayAlertAsync("Erro!", "Uso de localização não permitido.", "OK");
			}
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro!", ex.Message, "OK");
            }
		}
	}
}
