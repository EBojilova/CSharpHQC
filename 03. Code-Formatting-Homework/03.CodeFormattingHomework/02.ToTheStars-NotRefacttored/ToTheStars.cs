using System;

class ToTheStars
{
    static void Main(string[] args)
    {
        string[] input;
        string[] names = new string[3];
        double[,] planetXY = new double[3, 2];
        for (int i = 0; i < 3; i++)
        {
            input = Console.ReadLine().Split(' ');
            names[i] = input[0].ToLower();
            planetXY[i, 0] = double.Parse(input[1]);
            planetXY[i, 1] = double.Parse(input[2]);
        }
        input = Console.ReadLine().Split(' ');
        double x = double.Parse(input[0]);
        double y = double.Parse(input[1]);
        int n = int.Parse(Console.ReadLine());
        bool infield;
        bool inSpace;
        for (int i = 0; i < n + 1; i++)
        {
            inSpace = true;
            for (int j = 0; j < 3; j++)
            {
                infield = (planetXY[j, 0] - 1 <= x && x <= planetXY[j, 0] + 1 && planetXY[j, 1] - 1 <= y && y <= planetXY[j, 1] + 1);
                if (infield)
                {
                    Console.WriteLine(names[j]);
                    inSpace = false;
                }
            }
            if (inSpace)
            {
                Console.WriteLine("space");
            }
            y++;
        }
    }
}
