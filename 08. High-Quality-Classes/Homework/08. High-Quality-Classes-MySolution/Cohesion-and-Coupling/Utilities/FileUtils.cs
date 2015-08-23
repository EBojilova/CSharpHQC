namespace CohesionAndCoupling.Utilities
{
    using System;

    internal static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException(
                    "The file name does not contain an extension.",
                    "fileName");
            }

            var extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            var extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}