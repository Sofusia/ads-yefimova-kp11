using System;
using static System.Console;
using static System.Math;
class Program
{
    static void Main()
    {
        double x, y, z, a, b;
        Random rnd = new Random();
        Write(" x = "); x = rnd.Next(-100, 101); WriteLine(x.ToString());
        Write(" y = "); y = rnd.Next(-100, 101); WriteLine(y.ToString());
        Write(" z = "); z = rnd.Next(-100, 101); WriteLine(z.ToString());

        if (Sqrt(Pow(x, 2) + x * Pow(y, 2) + Pow(x, 2) * z) >= 0)
        {
            a = 1 + Sin(x) / (Sqrt(Pow(x, 2) + x * Pow(y, 2) + Pow(x, 2) * z));

            if (y + z / a != 0 && a != 0)
            {
                b = Log(Pow(a, 3) + Pow(x, 2)) / (x + a / (y + z / a));
                WriteLine(" a = " + a.ToString());
                WriteLine(" b = " + b.ToString());
            }
        }
        else
            WriteLine(" Error...");

    }
}
