// <copyright file="DynamicListTTest.cs" company="Microsoft">Copyright © Microsoft 2014</copyright>

using System;
using CustomLinkedList;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Tests
{
    [TestClass]
    [PexClass(typeof(DynamicList<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DynamicListTTest
    {

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]DynamicList<T> target, T item)
        {
            target.Add(item);
            // TODO: add assertions to method DynamicListTTest.Add(DynamicList`1<!!0>, !!0)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int Remove<T>([PexAssumeUnderTest]DynamicList<T> target, T item)
        {
            int result = target.Remove(item);
            return result;
            // TODO: add assertions to method DynamicListTTest.Remove(DynamicList`1<!!0>, !!0)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int IndexOf<T>([PexAssumeUnderTest]DynamicList<T> target, T item)
        {
            int result = target.IndexOf(item);
            return result;
            // TODO: add assertions to method DynamicListTTest.IndexOf(DynamicList`1<!!0>, !!0)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]DynamicList<T> target, T item)
        {
            bool result = target.Contains(item);
            return result;
            // TODO: add assertions to method DynamicListTTest.Contains(DynamicList`1<!!0>, !!0)
        }
    }
}
