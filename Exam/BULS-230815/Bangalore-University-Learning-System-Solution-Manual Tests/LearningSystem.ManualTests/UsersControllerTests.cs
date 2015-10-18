// ReSharper disable All

namespace LearningSystem.ManualTests
{
    using System;

    using LearningSystem.Controllers;
    using LearningSystem.Data;
    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_NoUserLogged_TrowsArgumentException()
        {
            var userController = new UsersController(new BangaloreUniversityData(), null);

            userController.Logout();
        }

        [TestMethod]
        public void Logout_NoUserLogged_NoUser()
        {
            var userController = new UsersController(
                new BangaloreUniversityData(),
                new User("Pesho", "123456", Role.Lecturer));

            userController.Logout();

            Assert.AreEqual(null, userController.CurrentUser);
        }

        [TestMethod]
        public void Logout_NoUserLogged_ReturnsCorrectResult()
        {
            var userController = new UsersController(
                new BangaloreUniversityData(),
                new User("Pesho", "123456", Role.Lecturer));

            var result = userController.Logout();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        [TestMethod]
        public void Logout_NoUserLogged_ReturnsCorrectResultMock()
        {
            var user = new Mock<User>("Pesho", "123456", Role.Lecturer);
            var database = new Mock<IBangaloreUniversityData>();

            var userController = new UsersController(database.Object, user.Object);

            var result = userController.Logout();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        [TestMethod]
        public void Logout_WithNoLoggedInUser_ShouldThrowACorrectException()
        {
            var database = new Mock<IBangaloreUniversityData>();

            var userController = new UsersController(database.Object, null);

            var exception = NUnit.Framework.Assert.Catch<ArgumentException>(() => { userController.Logout(); });

            Assert.AreEqual("There is no currently logged in user.", exception.Message);
        }

        [TestMethod]
        public void Logout_WithValidInput_ShouldLogOutUser()
        {
            var user = new Mock<User>("Ivan Ivanov", "123456", Role.Student);

            var database = new Mock<IBangaloreUniversityData>();

            var userController = new UsersController(database.Object, user.Object);

            Assert.AreEqual(user.Object, userController.CurrentUser);

            userController.Logout();

            Assert.AreEqual(null, userController.CurrentUser);
        }
    }
}