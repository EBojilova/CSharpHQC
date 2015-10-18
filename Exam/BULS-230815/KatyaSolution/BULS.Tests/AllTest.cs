using System.Collections.Generic;
using BULS.Models;
// <copyright file="AllTest.cs">Copyright ©  2015</copyright>

using System;
using BULS.Views;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Views
{
    [TestClass]
    [PexClass(typeof(All))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AllTest
    {
        [PexMethod]
        public All Constructor(IEnumerable<Course> courses)
        {
            All target = new All(courses);
            Assert.IsNotNull(target);
            return target;
        }
    }
}
