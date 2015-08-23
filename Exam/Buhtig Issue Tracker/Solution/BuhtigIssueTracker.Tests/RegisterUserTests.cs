namespace BuhtigIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterUserTests : TestBootstrapper
    {
        [TestMethod]
        public void RegisterUser_WithValidData_ShouldRegisterTheUser()
        {
            string message = this.tracker.RegisterUser("username", "pass123", "pass123");
            Assert.AreEqual("User username registered successfully", message);
        }

        [TestMethod]
        public void RegisterUser_WithNonMatchingPasswords_ShouldReturnErrorMessage()
        {
            string message = this.tracker.RegisterUser("username", "pass123", "pass1234");
            Assert.AreEqual("The provided passwords do not match", message);
        }

        [TestMethod]
        public void RegisterUser_ExistingUser_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("newUser", "pass123", "pass123");
            string message = this.tracker.RegisterUser("newUser", "pass123", "pass123");
            Assert.AreEqual("A user with username newUser already exists", message);
        }

        [TestMethod]
        public void RegisterUser_LoggedInUser_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("newUser", "pass123", "pass123");
            this.tracker.LoginUser("newUser", "pass123");
            string message = this.tracker.RegisterUser("anotherUser", "pass123", "pass123");
            Assert.AreEqual("There is already a logged in user", message);
        }
    }
}
