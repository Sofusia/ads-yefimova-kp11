using static System.Console;
using System.Numerics;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Runtime.Serialization;

namespace Asd_lab6
{
    class Program
    {
        static void Main()
        {
            OutputEncoding = Encoding.UTF8;

            MyQueue queue = new MyQueue();
            queue.Notify += Queue_Notify;

            Write("Введіть розмір черги: ");
            int.TryParse(ReadLine(), out int size);
            while (size < 1)
            {
                Write("Введіть розмір черги: ");
                int.TryParse(ReadLine(), out size);
            }
            Clear();

            queue.InitQueue(size);
            string str = String.Empty;

            WriteLine("Введення з клавіатури:\n");
            while (true)
            {
                WriteLine("1. Введіть рядок, щоб додати його до черги\n2. Введіть 'out', щоб видалити елемент з черги\n3. Введіть 'quit', щоб завершити");
                Write("\nВведіть: ");
                str = ReadLine();
                while (String.IsNullOrEmpty(str))
                {
                    Write("\nВедений рядок порожній! Введіть знову: ");
                    str = ReadLine();
                }
                if (str == "out")
                {
                    queue.Dequeue();
                    WriteLine(queue.Show());
                }
                else if (str == "quit")
                {
                    WriteLine(queue.Show());
                    Thread.Sleep(2000);
                    Clear();
                    WriteLine("Ви завершили введення");
                    break;
                }
                else
                {
                    queue.Enqueue(str);
                    WriteLine(queue.Show());
                }
                WriteLine("\nPress Enter to continue...");
                ReadLine();
                Clear();
            }
            



            // Контрольний приклад
            Thread.Sleep(2500);
            Clear();
            WriteLine("Контрольний приклад:");
            {
                string[] words = { "apple", "pear", "cherry", "peach", "lemon" };


                queue.DestroyQueue(); // Знищуємо попередню чергу
                WriteLine("Попередню чергу знищено\n");

                queue.InitQueue(4); // Ініціалізовуємо чергу                

                WriteLine($"\nIsQueueEmpty: {queue.IsQueueEmpty()}"); // Перевіряємо чергу на порожність

                for (int i = 0; i < words.Length; i++)
                {
                    WriteLine($"\nEnqueue: {words[i]}");
                    queue.Enqueue(words[i]); // Додаємо новий елемент у чергу
                    WriteLine(queue.Show());
                    Thread.Sleep(2000);
                }

                WriteLine($"Dequeue: {queue.Dequeue()}"); // Видаляємо та повергтаємо елемент з черги
                WriteLine(queue.Show());
                Thread.Sleep(2000);

                WriteLine($"\nIsQueueEmpty: {queue.IsQueueEmpty()}"); // Перевіряємо чергу на порожність
                Thread.Sleep(2000);
                WriteLine($"\nГолова черги: {queue.Head()}");
            }
        }

        private static void Queue_Notify(string message)
        {
            WriteLine(message);
        }
    }
    class MyQueue
    {
        public delegate void Info(string message);
        public event Info Notify;

        string[] array;
        public string head { get; private set; }
        public string tail { get; private set; }
        public int size { get; private set; }

        public void InitQueue(int size) // Створення черги:
        {
            array = new string[size];
            this.size = size;
            Notify($"Черга ініціалізована! Розмір: {size}");
        }
        public void DestroyQueue() // знищення черги:
        {
            array = null;
            head = null;
            tail = null;
            size = 0;
        }
        public void Enqueue(string str) // Додавання елементу:
        {
            if (IsQueueEmpty())
            {
                head = str;
                array[0] = str;
                tail = head;
                Notify("Елемент додано");
            }
            else
            {
                if (Free())
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i] == tail)
                        {
                            array[(i + 1) % size] = str;
                            tail = str;
                            Notify("Елемент додано");
                            return;
                        }
                    }
                }
                else
                {
                    Notify("Черга переповнилася!");

                    int index = size;
                    Double();

                    array[index] = str;
                    tail = str;

                    Notify("Елемент додано");
                    return;
                }

            }
        }
        public string Dequeue() // видалення елементу:
        {
            string deleted;
            if (!IsQueueEmpty())
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i] == head)
                    {
                        deleted = array[i];
                        array[i] = null;
                        Notify("\nЕлемент видалено");

                        if (!IsQueueEmpty())
                        {
                            head = array[(i + 1) % size];
                        }
                        else
                        {
                            Notify("Черга порожня!");
                        }
                        return deleted;
                    }
                }
            }
            throw new Exception("Черга порожня!");
        }
        public string Head() => head; // Визначення голови черги
        public bool IsQueueEmpty() // Перевірка, чи є черга порожньою:
        {
            if (array == null)
            {
                return true;
            }
            for (int i = 0; i < size; i++)
            {
                if (array[i] != null)
                {
                    return false;
                }
            }
            return true;
        }
        void Double() // Подвоєння черги
        {
            string[] arrHelp = new string[size * 2];

            int headIndex = 0;
            for (int i = 0; i < size; i++)
            {
                if (array[i] == Head())
                {
                    headIndex = i;
                    break;
                }
            }

            for (int i = 0, j = 0; i < size; i++, j++, headIndex++)
            {
                arrHelp[j] = array[headIndex % size];
            }

            array = arrHelp;
            size = arrHelp.Length;

            Notify("Чергу подвоєно!");
        }
        public string Show() // Інформація про чергу
        {
            if (!IsQueueEmpty())
            {
                int headIndex = 0;
                string show = "Head -> ";
                for (int i = 0; i < size; i++)
                {
                    if (array[i] == Head())
                    {
                        headIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    if (array[i] != null)
                    {
                        show += array[headIndex % size] + " ";
                        headIndex++;
                    }                    
                }
                show += "<- Tail";
                return show;
            }
            return "Черга порожня";
        }

        bool Free() // Додатковий метод, який перевіряє, чи є порожні комірки
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}