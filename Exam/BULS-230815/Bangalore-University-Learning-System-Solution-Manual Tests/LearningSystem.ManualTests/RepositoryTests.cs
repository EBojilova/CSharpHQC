// ReSharper disable All

namespace LearningSystem.ManualTests
{
    using LearningSystem.Data;
    using LearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Get_EmptyRepository_ReturnsDefault()
        {
            var repository = new Repository<Course>();
            var result = repository.Get(1);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Get_EmptyRepository_ReturnsCorrectResult()
        {
            var course = new Course("Java basics");
            var course2= new Course("C Sharp advanced");
            var repository = new Repository<Course>();
            repository.Add(course);
            repository.Add(course2);
            var result = repository.Get(1);
            var result2 = repository.Get(2);
            Assert.AreEqual(course, result);
            Assert.AreEqual(course2, result2);
        }
    }
}