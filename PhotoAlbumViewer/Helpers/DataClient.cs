using Newtonsoft.Json;

namespace PhotoAlbumViewer.Helpers
{
    public sealed class DataClient : IDataClient
    {
        private static DataClient _instance;

        private static readonly HttpClient HttpClient = new();

        public static DataClient Instance
        {
            get { return _instance ??= new DataClient(); }
        }

        public async Task<T> GetData<T>(string requestUri)
        {
            try
            {
                var responseMessage = await HttpClient.GetStringAsync(requestUri);

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

    public interface IDataClient
    {
        Task<T> GetData<T>(string requestUri);
    }
}
