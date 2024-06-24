class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int m = int.Parse(Console.ReadLine());

        int[,] array = new int[n, m];

        // Заполнение массива значениями -1
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = -1;
            }
        }

        // препятствия
        Random random = new Random();
        for (int k = 0; k < 5; k++)
        {
            int obstacleRow = random.Next(n);
            int obstacleCol = random.Next(m);
            array[obstacleRow, obstacleCol] = -2;
        }

        // Ввод координат 
        Console.Write("Введите координату строки исходной ячейки (0 - {0}): ", n - 1);
        int startX = int.Parse(Console.ReadLine());

        Console.Write("Введите координату столбца исходной ячейки (0 - {0}): ", m - 1);
        int startY = int.Parse(Console.ReadLine());

        array[startX, startY] = 0;
    }

    static void WaveAlgorithm(int[,] array, int startX, int startY)
    {
        int d = 0; // Длина пути от стартовой ячейки
        int finishValue = 99;
        array[startX, startY] = d;

        while (array.Cast<int>().Contains(finishValue) == false) // Пока финишная ячейка не помечена
        {
            bool hasPropagation = false; // Есть ли возможность распространения волны

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == d)
                    {
                        if (i - 1 >= 0 && array[i - 1, j] == 0) // Ячейка сверху
                        {
                            array[i - 1, j] = d + 1;
                            hasPropagation = true;
                        }

                        if (i + 1 < array.GetLength(0) && array[i + 1, j] == 0) // Ячейка снизу
                        {
                            array[i + 1, j] = d + 1;
                            hasPropagation = true;
                        }

                        if (j - 1 >= 0 && array[i, j - 1] == 0) // Ячейка слева
                        {
                            array[i, j - 1] = d + 1;
                            hasPropagation = true;
                        }

                        if (j + 1 < array.GetLength(1) && array[i, j + 1] == 0) // Ячейка справа
                        {
                            array[i, j + 1] = d + 1;
                            hasPropagation = true;
                        }
                    }
                }
            }

            if (hasPropagation == false) // Если нет возможности распространения волны
            {
                Console.WriteLine("Путь не найден");
                break;
            }

            d++; // Увеличиваем длину пути
        }

        if (array.Cast<int>().Contains(finishValue)) // Если достигнута финишная ячейка
        {
            Console.WriteLine("Путь найден за " + (d - 1) + " шагов");
        }
    }
}