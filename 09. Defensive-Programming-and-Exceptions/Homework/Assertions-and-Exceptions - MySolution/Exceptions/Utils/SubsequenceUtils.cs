namespace Exceptions_Homework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class SubsequenceUtils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex < 0 || arr.Length <= startIndex)
            {
                throw new ArgumentOutOfRangeException(
                    "startIndex", 
                    "The start index should be in the range [0 ... arr.Length).");
            }

            if (count < 0 || count + startIndex > arr.Length)
            {
                throw new ArgumentOutOfRangeException(
                    "count", 
                    "The count should be in the range [0 ... arr.Length - startIndex).");
            }

            var result = new List<T>();
            for (var i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("count", "Count should be in the range [0 ... str.Length].");
            }

            var result = new StringBuilder();
            for (var i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}