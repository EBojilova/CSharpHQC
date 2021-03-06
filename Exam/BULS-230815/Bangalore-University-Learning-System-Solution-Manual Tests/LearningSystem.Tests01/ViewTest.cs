// <copyright file="ViewTest.cs">Copyright ©  2015</copyright>

using System;
using LearningSystem.Views;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearningSystem.Views.Tests
{
    using LearningSystem.Views.Courses;

    [TestClass]
    [PexClass(typeof(View))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ViewTest
    {

        [PexMethod]
        public string Display([PexAssumeNotNull]View target)
        {
            string result = target.Display();
            return result;
            // TODO: add assertions to method ViewTest.Display(View)
        }
    }
}
