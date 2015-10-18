namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.IO;

    using BangaloreUniversityLearningSystem.Core;

    public class Program
    {
        public static void Main()
        {
            var engine = new Engine();
            using (var writher = new StreamWriter(@"../../OUTPUT.txt", false))
            {
                Console.SetOut(writher);
                engine.Run();
            }
        }
    }
}