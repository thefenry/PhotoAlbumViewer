using Newtonsoft.Json;

namespace PhotoAlbumViewer.Helpers
{
    public static class DataClient
    {
        private static readonly HttpClient _httpClient = new();

        public static async Task<T> GetData<T>(string requestUri)
        {

            try
            {
                var responseMessage = await _httpClient.GetStringAsync(requestUri);

                if (string.IsNullOrWhiteSpace(responseMessage))
                {
                    Console.WriteLine($"Error retrieving Data from the following url: {requestUri}");
                    return default;
                }

                return JsonConvert.DeserializeObject<T>(responseMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong when trying to access the following url: {requestUri}");
                Console.WriteLine($"Exception message: {ex.Message}");
                return default;
            }
        }
    }
}
