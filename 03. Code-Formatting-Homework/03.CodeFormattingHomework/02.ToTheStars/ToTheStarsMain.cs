namespace _02.ToTheStars
{
    using System;

    internal class ToTheStarsMain
    {
        private const int NumberOfStarSystems = 3;

        private static void Main(string[] args)
        {
            string[] input;
            var starSystems = new StarSystem[NumberOfStarSystems];
            for (var i = 0; i < starSystems.Length; i++)
            {
                input = Console.ReadLine().Split(' ');
                starSystems[i] = new StarSystem(input[0].ToLower(), double.Parse(input[1]), double.Parse(input[2]));
            }

            input = Console.ReadLine().Split(' ');
            var normandyX = double.Parse(input[0]);
            var normandyY = double.Parse(input[1]);
            var numberOfMovements = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfMovements + 1; i++)
            {
                var inSpace = true;
                foreach (var starSystem in starSystems)
                {
                    var inStarSystem = starSystem.X - 1 <= normandyX && normandyX <= starSystem.X + 1
                                       && starSystem.Y - 1 <= normandyY && normandyY <= starSystem.Y + 1;
                    if (inStarSystem)
                    {
                        Console.WriteLine(starSystem.Name);
                        inSpace = false;
                    }
                }

                if (inSpace)
                {
                    Console.WriteLine("space");
                }

                normandyY++;
            }
        }
    }
}