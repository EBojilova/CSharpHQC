namespace _03.CodeFormatting
{
    using System;
    using System.IO;

    internal class Program
    {
        public const string FileName = "example.bin";

        private static void Main()
        {
            ////Formated, but still not correct
            var fs = new FileStream(FileName, FileMode.CreateNew); // Create the writer for data  .
            var w = new BinaryWriter(fs); // Write data to Test.data.
            for (var i = 0; i < 11; i++)
            {
                w.Write(i);
            }

            w.Close();
            fs.Close(); // Create the reader    for data.
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            var r = new BinaryReader(fs); // Read data from  Test.data.
            for (var i = 0; i < 11; i++)
            {
                Console.WriteLine(r.ReadInt32());
            }

            r.Close();
            fs.Close();
        }
    }
}