using static System.Console;
using System.Text;

namespace Asd_lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rnd = new Random();

            int M, N;

            Write("Введіть M: ");
            M = Convert.ToInt32(ReadLine());
            Write("Введіть N: ");
            N = Convert.ToInt32(ReadLine());

            int[,] matrix = new int[M, N];

            Clear();
            Write("Введіть:\n(1) щоб ввести з клавіатури матрицю\n(2) щоб згенерувати матрицю з рандомних чисел\n(3) щоб згенерувати контрольну матрицю\n\nВаш вибір: ");
            int.TryParse(ReadLine(), out int input);

            switch (input)
            {
                case 1:
                    {
                        Clear();

                        string line;
                        string[] array;
                        int[] nums;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            WriteLine($"Введіть рядок ({i}) з {matrix.GetLength(1)} числами у такому форматі: 1, 2, 3, 4, 5");
                            line = ReadLine();
                            line = line.Replace(",", "");
                            array = line.Split(new char[] { ' ' });
                            nums = Array.ConvertAll(array, e => int.Parse(e));

                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                matrix[i, j] = nums[j];
                            }
                            Clear();
                        }
                        Clear();
                        Print(matrix);

                        break;
                    }
                case 2:
                    {
                        Clear();                        

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                matrix[i, j] = rnd.Next(10, 100);
                            }
                        }
                        Print(matrix);

                        break;
                    }
                case 3:
                    {
                        Clear();

                        matrix = new int[5, 5];

                        for (int i = 0, c = 10; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                matrix[i, j] = c++;
                            }
                        }
                        Print(matrix);

                        break;
                    }
                default:
                    break;
            }

            BackgroundColor = ConsoleColor.Blue;
            Write("   ");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(" - наскрізно за неспаданням (з лівого верху до правого низу, з правого верху до лівого низу)");

            BackgroundColor = ConsoleColor.Yellow;
            Write("   ");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(" - наскрізно за незростанням");



            // Сортування по рядках
            int[] arr = new int[matrix.Length];
            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr[k++] = matrix[i, j];
                }
            }

            arr = SortDown(arr);

            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[k++];
                }
            }



            // Діагоналі

            int count = 0;
            int lengthHelp = matrix.GetLength(0);
            int length = 0;

            if (matrix.GetLength(0) > matrix.GetLength(1))
            {
                lengthHelp = matrix.GetLength(1);
            }

            if (matrix.GetLength(1) > matrix.GetLength(0) || matrix.GetLength(1) % 2 == 0)
            {
                length = lengthHelp * 2;
            }
            else 
            {
                length = lengthHelp * 2 - 1;
            }


            arr = new int[length];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        arr[count++] = matrix[i, j];
                    }                    
                }                
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1 - i && i != j)
                    {
                        arr[count++] = matrix[i, j];
                    }
                }
            }

            arr = SortUp(arr);

            count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = arr[count++];
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1 - i && i != j)
                    {
                        matrix[i, j] = arr[count++];
                    }
                }
            }


            WriteLine("\n");
            Print(matrix);
                        
        }
        static int[] SortDown(int[] arr)
        {
            int pivot = arr[0];
            int i = 0;
            int eq = 0;
            int j = arr.Length - 1;
            while (i <= j)
            {
                if (arr[i] < pivot)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    j--;
                }
                else if (arr[i] > pivot)
                {
                    (arr[i], arr[eq]) = (arr[eq], arr[i]);
                    eq++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            int[] arrSorted = new int[j - eq + 1];
            Array.Copy(arr, eq, arrSorted, 0, arrSorted.Length);

            int[] arrLeft = new int[eq];
            if (arrLeft.Length > 0)
            {
                Array.Copy(arr, 0, arrLeft, 0, arrLeft.Length);
                if (arrLeft.Length > 1)
                {
                    arrLeft = SortDown(arrLeft);
                }
            }

            int[] arrRight = new int[arr.Length - j - 1];
            if (arrRight.Length > 0)
            {
                Array.Copy(arr, j + 1, arrRight, 0, arrRight.Length);
                if (arrRight.Length > 1)
                {
                    arrRight = SortDown(arrRight);
                }
            }

            Array.Copy(arrLeft, 0, arr, 0, arrLeft.Length);
            Array.Copy(arrSorted, 0, arr, eq, arrSorted.Length);
            Array.Copy(arrRight, 0, arr, j + 1, arrRight.Length);

            return arr;
        }
        static int[] SortUp(int[] arr)
        {
            int pivot = arr[0];
            int i = 0;
            int eq = 0;
            int j = arr.Length - 1;
            while (i <= j)
            {
                if (arr[i] > pivot)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    j--;
                }
                else if (arr[i] < pivot)
                {
                    (arr[i], arr[eq]) = (arr[eq], arr[i]);
                    eq++;
                    i++;
                }
                else
                {
                    i++;
                }                
            }

            int[] arrSorted = new int[j - eq + 1];
            Array.Copy(arr, eq, arrSorted, 0, arrSorted.Length);

            int[] arrLeft = new int[eq];
            if (arrLeft.Length > 0)
            {
                Array.Copy(arr, 0, arrLeft, 0, arrLeft.Length);
                if (arrLeft.Length > 1)
                {
                    arrLeft = SortUp(arrLeft);
                }
            }

            int[] arrRight = new int[arr.Length - j - 1];
            if (arrRight.Length > 0)
            {
                Array.Copy(arr, j + 1, arrRight, 0, arrRight.Length);
                if (arrRight.Length > 1)
                {
                    arrRight = SortUp(arrRight);
                }
            }

            Array.Copy(arrLeft, 0, arr, 0, arrLeft.Length);
            Array.Copy(arrSorted, 0, arr, eq, arrSorted.Length);
            Array.Copy(arrRight, 0, arr, j + 1, arrRight.Length);

            return arr;
        }
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    BackgroundColor = ConsoleColor.Yellow;
                    ForegroundColor = ConsoleColor.Black;
                    if (i == j || i == matrix.GetLength(1) - j - 1)
                    {
                        BackgroundColor = ConsoleColor.Blue;
                    }
                    
                    Write(matrix[i, j] + "\t");
                }
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Gray;
                WriteLine();
            }
            WriteLine();



            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
        }       
    }
}
