namespace LearningSystem
{
    using System;
    using System.IO;

    using LearningSystem.Core;

    public class Program
    {
        public static void Main()
        {
            var egine = new Egine();
            using (var writher = new StreamWriter(@"../../OUTPUT.txt", false))
            {
                Console.SetOut(writher);
                egine.Run();
            }
        }
    }
}