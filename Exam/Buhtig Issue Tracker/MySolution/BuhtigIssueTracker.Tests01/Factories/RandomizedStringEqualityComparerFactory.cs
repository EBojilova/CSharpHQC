// <copyright file="RandomizedStringEqualityComparerFactory.cs">Copyright ©  2015</copyright>

using System;
using Microsoft.Pex.Framework;

namespace System.Collections.Generic
{
    /// <summary>A factory for System.Collections.Generic.RandomizedStringEqualityComparer instances</summary>
    public static partial class RandomizedStringEqualityComparerFactory
    {
        /// <summary>A factory for System.Collections.Generic.RandomizedStringEqualityComparer instances</summary>
        [PexFactoryMethod(typeof(GC), "System.Collections.Generic.RandomizedStringEqualityComparer")]
        public static object Create()
        {
            throw new NotImplementedException();

            // TODO: Edit factory method of RandomizedStringEqualityComparer
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
