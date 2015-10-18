using BULS.Models;
// <copyright file="LogoutTest.cs">Copyright ©  2015</copyright>

using System;
using BULS.Views.Users;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Views.Users
{
    [TestClass]
    [PexClass(typeof(Logout))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class LogoutTest
    {
        [PexMethod]
        public Logout Constructor(User user)
        {
            Logout target = new Logout(user);
            Assert.IsNotNull(target);
            return target;
        }
    }
}
