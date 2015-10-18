// <copyright file="ViewTest.cs">Copyright ©  2015</copyright>

using System;
using BULS.Infrastructure;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Infrastructure
{
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
            Assert.IsNotNull(result);
            return result;
        }
    }
}
