using System;
using static System.Console;
using System.Threading;

namespace Asd.Lab3
{
    class Program
    {        
        static double[,] MatrixA;
        static double[,] MatrixB;

        static void Main(string[] args)
        {
            int N, M, K, L;
            int choise;
            Random rnd = new Random();

            WriteLine("Згенерувати рандомнi числа для N, M, K, L? Якщо ТАК, натиснiть 1, якщо НI натиснiть 0");
            
            try
            {
                choise = int.Parse(ReadLine());
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message);
                return;
            }

            if (choise == 1)
            {
                N = rnd.Next(2, 11); WriteLine($"N = {N}");
                M = rnd.Next(2, 11); WriteLine($"M = {M}");
                K = rnd.Next(2, 11); WriteLine($"K = {K}");
                L = rnd.Next(2, 11); WriteLine($"L = {L}");
            }
            else if (choise == 0)
            {
                try
                {
                    Write("Введiть кiлькiсть рядкiв (N): "); N = int.Parse(ReadLine());
                    Write("Введiть кiлькiсть стовпцiв (M): "); M = int.Parse(ReadLine());
                    Write("Введiть K: "); K = int.Parse(ReadLine());
                    if (K == 0)
                    {
                        WriteLine("Дiлення на 0");
                        return;
                    }
                    Write("Введiть L: "); L = int.Parse(ReadLine());
                }
                catch (Exception exception)
                {
                    WriteLine(exception.Message);
                    return;
                }
            }
            else
            {
                WriteLine("Try Again...");
                return;
            }

            Thread.Sleep(1500);
            WriteLine();
            MatrixA = new double[N, M];
            MatrixB = new double[N, M];
                        
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    MatrixA[i, j] = rnd.Next(1, 9);
                    MatrixB[i, j] = MatrixA[i, j];
                    Write(MatrixB[i, j] + "   ");
                }
                WriteLine();
            }

            Thread.Sleep(1000);
            Sorting(N, M, K, L);
            Thread.Sleep(1000);
            Clear();

            WriteLine("До сортування:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Write(MatrixB[i, j] + " ");
                }
                WriteLine();
            }
            WriteLine("\nПiсля сортування:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Write(MatrixA[i, j] + " ");
                }
                WriteLine();
            }
        }

        static void Sorting(int N, int M, int K, int L)
        {
            int gap = N * M;
            bool swap = true;

            while (gap > 1 || swap)
            {
                swap = false;
                gap = Gap(gap);

                for (int i = 0; i < N * M - gap; i++)
                {
                    int a = i / M;
                    int b = M - i % M - 1;
                    int c = (i + gap) / M;
                    int d = M - (i + gap) % M - 1;
                    if (MatrixA[a, b] / K >= L || MatrixA[c, d] / K >= L)
                        continue;
                    if (MatrixA[a, b] > MatrixA[c, d])
                    {
                        Color(i, i + gap, N, M, false);
                        Swap(ref MatrixA[a, b], ref MatrixA[c, d]);
                        Color(i, i + gap, N, M, true);
                        swap = true;
                        continue;
                    }
                    Color(i, i + gap, N, M, false);
                }
            }
        }

        static int Gap(int gap)
        {
            double x = gap;
            x = x / 1.3;
            if (x < 1)
                return 1;
            gap = (int)x;
            return gap;
        }

        static void Color(int x, int y, int N, int M, bool swap)
        {
            Thread.Sleep(600);
            Clear();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if ((i == x / M && j == M - x % M - 1) || (i == y / M && j == M - y % M - 1))
                    {
                        if (!swap)
                        {
                            BackgroundColor = ConsoleColor.Cyan;
                            ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            BackgroundColor = ConsoleColor.Red;
                            ForegroundColor = ConsoleColor.Yellow;
                        }
                    }                        
                    Write(MatrixA[i, j]);

                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.White;
                    Write(" ");
                }
                WriteLine();
            }
        }

        static void Swap<S>(ref S big, ref S small)
        {
            S memory;
            memory = big;
            big = small;
            small = memory;
        }
    }
}
