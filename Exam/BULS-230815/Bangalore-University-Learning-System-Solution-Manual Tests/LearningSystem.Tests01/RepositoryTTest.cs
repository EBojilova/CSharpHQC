// <copyright file="RepositoryTTest.cs">Copyright ©  2015</copyright>

using System;
using LearningSystem.Data;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearningSystem.Data.Tests
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
            return result;
            // TODO: add assertions to method RepositoryTTest.Get(Repository`1<!!0>, Int32)
        }
    }
}
