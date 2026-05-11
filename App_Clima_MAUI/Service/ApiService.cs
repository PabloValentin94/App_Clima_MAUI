using System.Diagnostics;

namespace App_Clima_MAUI.Service
{
    public abstract class ApiService
    {
        private static string api_key = "7d5a06bd2b057419afb2233bfb2fd696";

        private static Uri api_host = new Uri($"https://api.openweathermap.org/data/2.5");

        private static void DisplayResponse(string response)
        {
            Debug.WriteLine("--------------------------------------------------");
            Debug.WriteLine($"\n{response}\n");
            Debug.WriteLine("--------------------------------------------------");
        }

        public static async Task<string> Get(string endpoint)
        {
            string response_json = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{api_host}{endpoint}&appid={ApiService.api_key}");

                    response.EnsureSuccessStatusCode();

                    response_json = await response.Content.ReadAsStringAsync();

                    DisplayResponse(response_json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao se conectar com o serviço!", ex);
            }

            return response_json;
        }
    }
}
