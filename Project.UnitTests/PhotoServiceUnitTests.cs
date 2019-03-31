using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITAcademy.Gallery.Bl;
using ITAcademy.Gallery.Dal;
using System.Collections.Generic;
using Moq;

namespace ITAcademy.Gallery.UnitTests
{
    /*
    [TestClass]
    public class PhotoServiceUnitTests
    {
        [TestMethod]
        public void TestPhotos_GetPhotos_ShouldReturnPhotos()
        {
            // arrange
            var mockContext = new Mock<IContext>();
            var photos = new List<Photo> {
                new Photo { Name = "Photo 1", Url = "url" },
                new Photo { Name = "Photo 3", Url = "url" }
            };

            // usersetting

            mockContext.Setup(m => m.GetPhotos()).Returns(photos);

            var ps = new PhotoService(mockContext.Object);
            //var ps = new PhotoService(new FakeContext());

            // act
            var result = ps.GetPhotos();

            // assert
            Assert.AreEqual(true, result.Count > 2); // stub
            //mockContext.Verify(m => m.GetPhotos(), Times.Once); // behavioural
        }
    }

    class FakeContext : IContext
    {
        public List<Photo> GetPhotos()
        {
            return new List<Photo> {
                new Photo { Name = "Photo 1", Url = "url" },
                new Photo { Name = "Photo 3", Url = "url" }
            };
        }
    }
    */

}
