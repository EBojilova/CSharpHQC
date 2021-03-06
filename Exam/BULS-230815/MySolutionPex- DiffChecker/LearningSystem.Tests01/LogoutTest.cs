using LearningSystem.Models;
using System.Text;
// <copyright file="LogoutTest.cs">Copyright ©  2015</copyright>

using System;
using LearningSystem.Views;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearningSystem.Views.Tests
{
    using LearningSystem.Views.Users;

    [TestClass]
    [PexClass(typeof(Logout))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class LogoutTest
    {

        [PexMethod]
        internal void BuildViewResult([PexAssumeUnderTest]Logout target, StringBuilder viewResult)
        {
            target.BuildViewResult(viewResult);
            // TODO: add assertions to method LogoutTest.BuildViewResult(Logout, StringBuilder)
        }

        [PexMethod]
        public Logout Constructor(User user)
        {
            Logout target = new Logout(user);
            return target;
            // TODO: add assertions to method LogoutTest.Constructor(User)
        }
    }
}
