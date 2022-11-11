using PhotoAlbumViewer.Helpers;
using PhotoAlbumViewer.Models;

namespace PhotoAlbumViewer.Services
{
    internal class PhotoAlbumService : IPhotoAlbumService
    {
        public async Task<List<AlbumContent>> GetAlbumInfo(int albumId)
        {
            string requestUri = $"https://jsonplaceholder.typicode.com/photos?albumId={albumId}";

            return await DataClient.GetData<List<AlbumContent>>(requestUri);
        }

        public void PrintData(IList<AlbumContent> albumPhotos)
        {
            foreach (var albumPhoto in albumPhotos)
            {
                Console.WriteLine($"[{albumPhoto.Id}] {albumPhoto.Title}");
            }
        }
    }

    internal interface IPhotoAlbumService
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
