Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine());

int[,] map = new int[rows, columns];

// Заполнение массива значениями -1
for (int i = 0; i < map.GetLength(0); i++)
{
    for (int j = 0; j < map.GetLength(1); j++)
    {
        map[i, j] = -1;
    }
}

// препятствия
Random random = new Random();
for (int i = 0; i < rows; i++)
{
    int obstacleRow = random.Next(rows);
    int obstacleCol = random.Next(columns);
    map[obstacleRow, obstacleCol] = -2;
}

// Ввод координат 
int startX;
int startY;
do
{
    Console.Write("Введите координату строки исходной ячейки: ");
    startX = int.Parse(Console.ReadLine())-1;

    Console.Write("Введите координату столбца исходной ячейки: ");
    startY = int.Parse(Console.ReadLine())-1;
} while (startX >= rows && startY >= columns);
map[startX, startY] = 0;

// финишнная ячейка
int finishX;
int finishY;
do
{
    finishX = random.Next(rows);
    finishY = random.Next(columns);
} while (map[finishX, finishY] != -1);
map[finishX, finishY] = 99;

// вывод 
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{map[i, j]}\t");
    }
    Console.WriteLine();
}
