using static System.Console;
using System;
class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int N = rnd.Next(5, 6); WriteLine(" N = " + N);
        double k = rnd.Next(1, 11); WriteLine(" k = " + k);
        int min = 1000000, max = -1, x = 0, y = 0, c = 0;


        int[,] Matrix = new int[N, N];

        WriteLine("Для того, щоб побачити контрольний приклад (матриця, що заповнюється елементами вiд 0 до N*N-1) натиснiть 1");
        WriteLine("Для того, щоб згенерувати рандомну матрицю натиснiть 2");
        Write("Ваш вибiр: "); int a = int.Parse(Console.ReadLine());
        WriteLine();
        if (a == 1)
        {
            for (int i = 0; i < N; i++) //Generate matrix 0 to N*N-1
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = c;
                    Write(Matrix[i, j] + "\t");
                    c++;
                }
                WriteLine();
            }
        }
        if (a == 2)
        {
            for (int i = 0; i < N; i++) //Generate random matrix
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = rnd.Next(1, 21);
                    Write(Matrix[i, j] + "\t");
                }
                WriteLine();
            }
        }



        WriteLine("\n" + "ПОСЛIДОВНIСТЬ:");

        WriteLine("\n" + " Над дiагоналлю: ");
        for (int i = 0; i < N; i++) //Над діагоналлю
        {

            if (i == 0 || i % 2 == 0)
            {
                for (int j = N - 1; j > 0; j--)
                {
                    if (i < j)
                    {
                        Write(Matrix[i, j] + ", ");
                        if (Matrix[i, j] % k == 0) //Пошук min елементу
                        {
                            if (Matrix[i, j] < min)
                            {
                                min = Matrix[i, j];
                                x = i;
                                y = j;
                            }
                        }
                    }
                }
            }
            if (i == 1 || i % 2 == 1)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i < j)
                    {
                        Write(Matrix[i, j] + ", ");
                        if (Matrix[i, j] % k == 0) //Пошук min елементу
                        {
                            if (Matrix[i, j] < min)
                            {
                                min = Matrix[i, j];
                                x = i;
                                y = j;
                            }
                        }
                    }
                }
            }
        }
        if (min != 1000000)
            WriteLine("\n" + "Matrix[" + x + ", " + y + "]" + " = min = " + min + "\n Над головною дiагоналлю");
        else
            WriteLine("\n Немає елементiв кратних k");


        min = 1000000;
        WriteLine();
        WriteLine("\n" + " Дiагональ: ");
        for (int i = N - 1; i >= 0; i--) //Діагональ
        {
            Write(Matrix[i, i] + ", ");
            if (Matrix[i, i] > max)      //Пошук min та max елементів 
            {
                max = Matrix[i, i];
                x = i;
            }
            if (Matrix[i, i] < min)
            {
                min = Matrix[i, i];
                y = i;
            }
        }
        WriteLine("\n" + "Matrix[" + x + ", " + x + "]" + " = max = " + max);
        WriteLine("Matrix[" + y + ", " + y + "]" + " = min = " + min + "\n На головнiй дiагоналi");

        max = -1;
        min = 1000000;

        WriteLine("\n" + " Пiд дiагоналлю: ");
        for (int j = 0; j < N; j++) //Пiд дiагоналлю
        {
            if (j == 0 || j % 2 == 0)
            {
                for (int i = 0; i < N; i++)
                {
                    if (i > j)
                    {
                        Write(Matrix[i, j] + ", ");
                        if (Matrix[i, j] > max)      //Пошук min та max елементів 
                        {
                            max = Matrix[i, j];
                        }
                        if (Matrix[i, j] < min)
                        {
                            min = Matrix[i, j];
                        }
                    }
                }
            }
            if (j == 1 || j % 2 == 1)
            {
                for (int i = N - 1; i > 0; i--)
                {
                    if (i > j)
                    {
                        Write(Matrix[i, j] + ", ");
                        if (Matrix[i, j] > max)      //Пошук min та max елементів 
                        {
                            max = Matrix[i, j];
                        }
                        if (Matrix[i, j] < min)
                        {
                            min = Matrix[i, j];
                        }
                    }
                }
            }
        }
        double number = Math.Abs(max - min) * 1.0 / 2;
        max = -1;

        for (int j = 0; j < N; j++)
        {
            if (j == 0 || j % 2 == 0)
            {
                for (int i = 0; i < N; i++)
                {
                    if (i > j)
                    {
                        if (Matrix[i, j] % number == 0)  //Пошук max елем кратного числу number
                        {
                            if (Matrix[i, j] > max)
                            {
                                max = Matrix[i, j];
                                x = i;
                                y = j;
                            }
                        }
                    }
                }
            }
            if (j == 1 || j % 2 == 1)
            {
                for (int i = N - 1; i > 0; i--)
                {
                    if (i > j)
                    {
                        if (Matrix[i, j] % number == 0)  //Пошук max елем кратного числу number
                        {
                            if (Matrix[i, j] > max)
                            {
                                max = Matrix[i, j];
                                x = i;
                                y = j;
                            }
                        }
                    }
                }
            }
        }
        if (max != -1)
            WriteLine("\n" + "Matrix[" + x + ", " + y + "]" + " = max = " + max + "\n Пiд головною дiагоналлю");
        else
            WriteLine("\n Немає елементiв кратних напiв рiзницi за модулем мiнiмального  та  максимального  елементiв");
    }
}
