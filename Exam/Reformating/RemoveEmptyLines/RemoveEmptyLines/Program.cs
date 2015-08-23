namespace RemoveEmptyLines
{
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileName = "Program.cs";
            var lines = File.ReadAllLines(fileName).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(fileName, lines);
        }
    }
}