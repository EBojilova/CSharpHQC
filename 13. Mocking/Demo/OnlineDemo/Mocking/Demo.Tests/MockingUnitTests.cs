// ReSharper disable InconsistentNaming
namespace Demo.Tests
{
    using System.Collections.Generic;

    using DependencyInjectionVideo;
    using DependencyInjectionVideo.Interfaces;
    using DependencyInjectionVideo.Sorters;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class MockingUnitTests
    {
        [TestMethod]
        public void Test_ListAddsWorksCorrectly_ShouldAddTheItem()
        {
            var mock = new Mock<IList<int>>();
            var isAdded = false;
            mock.Setup(list => list.Add(3)).Callback(() => isAdded = true);

            var fakeItems = new[] { 3, 4 };
            mock.Setup(list => list[0]).Returns(fakeItems[0]);
            var mockedObject = mock.Object;
            mockedObject.Add(3);
            mockedObject.Add(5);

            //// Verify zamestva Assert
            //////mock.Verify(list => list.Add(7), Times.Exactly(1));
            //////mock.Verify(list => list.Add(5), Times.Exactly(4));
            mock.Verify(list => list.Add(3), Times.Exactly(1));
            mock.Verify(list => list.Add(5), Times.Exactly(1));
            mock.Verify(list => list.Add(It.IsAny<int>()), Times.Exactly(2));
            Assert.AreEqual(fakeItems[0], mockedObject[0]);
        }

        [TestMethod]
        public void Test_StudentsSorterSortByFirstNaeCorrectly()
        {
            // Arrange
            var mock = new Mock<IArraySorter<Student>>();
            var mockedSorter = mock.Object;

            //// We will avoid Custom ArraySorter class
            ////var studentSorter = new StudentsSorter(new CustomArraySorter<Student>());
            var studentSorter = new StudentsSorter(mockedSorter);

            // Act
            studentSorter.OrderStudentsByFirstName();

            // Assert
            mock.Verify(sorter => sorter.Sort(It.IsAny<Student[]>()), Times.AtLeastOnce);
        }
    }
}