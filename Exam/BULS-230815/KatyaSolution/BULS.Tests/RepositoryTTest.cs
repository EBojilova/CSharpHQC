// <copyright file="RepositoryTTest.cs">Copyright ©  2015</copyright>

using System;
using BULS.Data;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Data
{
    [TestClass]
    [PexClass(typeof(Repository<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RepositoryTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T Get<T>([PexAssumeUnderTest]Repository<T> target, int id)
        {
            T result = target.Get(id);
            Assert.IsNotNull(result);
            return result;
        }
    }
}
