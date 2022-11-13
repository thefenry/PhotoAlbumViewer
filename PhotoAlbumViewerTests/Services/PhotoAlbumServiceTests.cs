using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoAlbumViewer.Helpers;
using PhotoAlbumViewer.Models;
using PhotoAlbumViewer.Services;

namespace PhotoAlbumViewerTests.Services
{
    [TestClass]
    public class PhotoAlbumServiceTests
    {
        private readonly IPhotoAlbumService _photoAlbumService;
        private readonly Mock<IDataClient> _dataClientMoq;

        public PhotoAlbumServiceTests()
        {
            _dataClientMoq = new Mock<IDataClient>();
            _photoAlbumService = new PhotoAlbumService(_dataClientMoq.Object);
        }

        [TestMethod]
        public async Task GetAlbumInfoTest_Success()
        {
            var expectedAlbums = new List<AlbumContent> { new() { Id = 1 }, new() { Id = 2 } };

            _dataClientMoq.Setup(s => s.GetData<List<AlbumContent>>(It.IsAny<string>()))
                .ReturnsAsync(expectedAlbums);

            var result = await _photoAlbumService.GetAlbumInfo(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAlbums.Count, result.Count);
            Assert.AreEqual(expectedAlbums[0].Id, result[0].Id);
        }

        [TestMethod]
        public async Task GetAlbumInfoTest_InvalidAlbumId()
        {
            var result = await _photoAlbumService.GetAlbumInfo(1);

            Assert.IsNull(result);
        }
    }
}