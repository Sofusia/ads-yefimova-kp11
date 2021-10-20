using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    
    {
        Random rnd = new Random();
        long n = rnd.Next(2, 1000000001); WriteLine(" n = " + n);
        double a = 4, p = 2, k = 2;
        for (double Merc = 2; Merc < n; p++)
        {
            if (p == 2)
            {
                Merc = a - 1;
                WriteLine(" Число Мерсена = " + Merc);
            }
            else if (k <= p && p % k != 0)
            {
                Merc = a - 1;
                WriteLine(" Число Мерсена = " + Merc);
            }
            else
                WriteLine(" Число p не просте: p =  " + p);
            a *= 2;
            
        }
    }
}
