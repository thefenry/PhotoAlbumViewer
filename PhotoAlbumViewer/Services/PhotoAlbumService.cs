using PhotoAlbumViewer.Helpers;
using PhotoAlbumViewer.Models;

namespace PhotoAlbumViewer.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IDataClient _dataClient;

        public PhotoAlbumService(IDataClient dataClient)
        {
            _dataClient = dataClient;
        }

        public async Task<List<AlbumContent>> GetAlbumInfo(int albumId)
        {
            if (albumId < 1)
            {
                return null;
            }

            string requestUri = $"https://jsonplaceholder.typicode.com/photos?albumId={albumId}";

            return await _dataClient.GetData<List<AlbumContent>>(requestUri);
        }

        public void PrintData(IList<AlbumContent> albumPhotos)
        {
            foreach (var albumPhoto in albumPhotos)
            {
                Console.WriteLine($"[{albumPhoto.Id}] {albumPhoto.Title}");
            }

            Console.WriteLine("\n");
        }
    }

    public interface IPhotoAlbumService
    {
        /// <summary>
        /// Gets the Album photos for the selected AlbumId
        /// </summary>
        /// <param name="albumId">Album id photos belong to</param>
        /// <returns></returns>
        Task<List<AlbumContent>> GetAlbumInfo(int albumId);

        /// <summary>
        /// Print the album content
        /// </summary>
        /// <param name="albumPhotos"></param>
        void PrintData(IList<AlbumContent> albumPhotos);
    }
}
