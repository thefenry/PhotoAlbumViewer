using PhotoAlbumViewer.Helpers;
using PhotoAlbumViewer.Services;
using System.Text.RegularExpressions;

namespace PhotoAlbumViewer
{
    internal class Program
    {
        private static PhotoAlbumService _photoAlbumService;

        private static async Task Main()
        {
            _photoAlbumService = new PhotoAlbumService(DataClient.Instance);

            bool exitProgram = false;

            do
            {
                Console.WriteLine("Welcome to the Album Searcher. Please indicate which photo album number you wish to view. \nEx: photo-album 2");
                var providedOption = Console.ReadLine();

                if (providedOption != null)
                {
                    await DisplayAlbumInfo(providedOption);
                }

                Console.WriteLine("Press Enter to try again or type 'q' to quit");

                var response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response) && string.Equals(response, "q", StringComparison.InvariantCultureIgnoreCase))
                {
                    exitProgram = true;
                }

            } while (!exitProgram);
        }

        private static async Task DisplayAlbumInfo(string providedOption)
        {
            var resultString = Regex.Match(providedOption, @"\d+").Value;

            if (!int.TryParse(resultString, out var albumId))
            {
                Console.WriteLine("Unable to read the provided album Id. Please make sure your request contains an actual number");
                return;
            }

            var albumPhotos = await _photoAlbumService.GetAlbumInfo(albumId);

            if (albumPhotos != null)
            {
                _photoAlbumService.PrintData(albumPhotos);
            }
        }
    }
}