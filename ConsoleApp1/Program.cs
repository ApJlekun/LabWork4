using System;

class MainClass
{
    public static void Main(string[] args)
    {
        int[,] map = {
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0}
        };
        int goalX = 4;
        int goalY = 4;
        int[,] heuristic = new int[map.GetLength(0), map.GetLength(1)];

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                heuristic[x, y] = Math.Abs(x - goalX) + Math.Abs(y - goalY);
                Console.Write(heuristic[x, y] + " ");
            }
            Console.WriteLine();
        }
    }
}