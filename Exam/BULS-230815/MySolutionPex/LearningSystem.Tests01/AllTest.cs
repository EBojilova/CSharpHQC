using System.Text;
// <copyright file="AllTest.cs">Copyright ©  2015</copyright>

using System;
using LearningSystem.Views;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearningSystem.Views.Tests
{
    using LearningSystem.Views.Courses;

    [TestClass]
    [PexClass(typeof(All))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AllTest
    {

        [PexMethod]
        internal void BuildViewResult([PexAssumeUnderTest]All target, StringBuilder viewResult)
        {
            target.BuildViewResult(viewResult);
            // TODO: add assertions to method AllTest.BuildViewResult(All, StringBuilder)
        }
    }
}
