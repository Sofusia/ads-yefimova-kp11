using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Asd_Lab4
{
    public class DLNode<T>
    {
        public DLNode(T data)
        {
            this.data = data;
        }
        public T data { get; set; }
        public DLNode<T> prev { get; set; }
        public DLNode<T> next { get; set; }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            int pos = 0, num = 0, n = 0, count = 0;
            string ans = "";
            Random rnd = new Random();
            CircularDLList<int> circularList = new CircularDLList<int>();
            WriteLine("Створення списку:   ");
            Write("Кiлькiсть елементiв у списку:   ");
            try
            {                
                n = Convert.ToInt32(ReadLine());
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            
            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    circularList.Add(rnd.Next(-10, 31));
                    count++;
                }
            }
            
            circularList.Print(circularList);


            WriteLine("Додавання першого елемента:   ");
            try
            {
                Write("Введiть значення:   ");
                num = Convert.ToInt32(ReadLine());
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            circularList.AddFirst(num);
            count++;
            circularList.Print(circularList);
            Write("Додати ще один перший елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                try
                {
                    Write("Введiть значення:   ");
                    num = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                circularList.AddFirst(num);
                count++;
                circularList.Print(circularList);
                Write("Додати ще один перший елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            WriteLine("Додавання останнього елемента:   ");
            try
            {
                Write("Введiть значення:   ");
                num = Convert.ToInt32(ReadLine());
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            circularList.AddLast(num);
            count++;
            circularList.Print(circularList);
            Write("Додати ще один останнiй елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                try
                {
                    Write("Введiть значення:   ");
                    num = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                circularList.AddLast(num);
                count++;
                circularList.Print(circularList);
                Write("Додати ще один останнiй елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            WriteLine("Додавання елемента на позицiю:   ");
            while (pos <= 0)
            {
                try
                {
                    Write("Введiть позицiю:   ");
                    pos = Convert.ToInt32(ReadLine());
                    Write("Введiть значення:   ");
                    num = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            if (pos > count + 1)
            {
                pos = count + 1;
            }
            circularList.AddAtPosition(num, pos);
            count++;
            circularList.Print(circularList);
            Write("Додати ще один елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                try
                {
                    Write("Введiть позицiю:   ");
                    pos = Convert.ToInt32(ReadLine());
                    Write("Введiть значення:   ");
                    num = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                if (pos > count + 1)
                {
                    pos = count + 1;
                }
                circularList.AddAtPosition(num, pos);
                count++;
                circularList.Print(circularList);
                Write("Додати ще один елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            WriteLine("Видалення першого елемента:   ");
            circularList.DeleteFirst();
            count--;
            circularList.Print(circularList);
            Write("Видалити ще один перший елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                circularList.DeleteFirst();
                count--;
                circularList.Print(circularList);
                Write("Видалити ще один перший елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            WriteLine("Видалення останнього елемента:   ");
            circularList.DeleteLast();
            count--;
            circularList.Print(circularList);
            Write("Видалити ще один останнiй елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                circularList.DeleteLast();
                count--;
                circularList.Print(circularList);
                Write("Видалити ще один останнiй елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            pos = 0;
            WriteLine("Видалення елемента з позицiї:   ");
            while (pos <= 0)
            {
                try
                {
                    Write("Введiть позицiю:   ");
                    pos = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }                
            }
            if (pos > count)
            {
                pos = count;
            }
            circularList.DeleteAtPosition(pos);
            count--;
            circularList.Print(circularList);
            Write("Видалити ще один елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                try
                {
                    Write("Введiть позицiю:   ");
                    pos = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                if (pos > count + 1)
                {
                    pos = count;
                }
                circularList.DeleteAtPosition(pos);
                count--;
                circularList.Print(circularList);
                Write("Видалити ще один елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            //*****************************************************************************//
            //Завдання 16-го варіанта

            WriteLine("Додавання нового вузла пiсля вузла з найменшим парним значенням:   ");
            int min = circularList.FindMinNum(circularList);
            pos = circularList.FindPosition(min, circularList);
            try
            {
                Write("Введiть значення:   ");
                num = Convert.ToInt32(ReadLine());
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            circularList.AddAfterMin(num, pos);
            count++;
            circularList.Print(circularList);
            Write("Додати ще один елемент?  ТАК(YES)/НI(NO)  ");
            try
            {
                ans = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            while (ans == "ТАК" || ans == "YES" || ans == "так" || ans == "yes")
            {
                min = circularList.FindMinNum(circularList);
                pos = circularList.FindPosition(min, circularList);
                try
                {                    
                    Write("Введiть значення:   ");
                    num = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                circularList.AddAfterMin(num, pos);
                count++;
                circularList.Print(circularList);
                Write("Додати ще один елемент?  ТАК(YES)/НI(NO)  ");
                try
                {
                    ans = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }


            WriteLine("\nДякую!");
        }
    }

    public class CircularDLList<T> : IEnumerable<T>  // Кільцевий двозв'язний список
    {
        DLNode<T> head; // Голова
        int count;  // Кількість елементів у списку

        // Добавлення елемента
        public void Add(T data)
        {
            DLNode<T> node = new DLNode<T>(data);

            if (head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }
            else
            {
                node.prev = head.prev;
                node.next = head;
                head.prev.next = node;
                head.prev = node;
            }
            count++;
        }

        public void AddFirst(T data) //Додавання першого елемента
        {
            DLNode<T> node = new DLNode<T>(data);

            if (head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }
            else
            {
                node.prev = head.prev;
                node.next = head;
                head.prev.next = node;
                head.prev = node;
                head = node;
            }
            count++;
        }

        public void AddLast(T data) //Додавання останнього елемента
        {
            DLNode<T> node = new DLNode<T>(data);

            if (head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }
            else
            {
                node.prev = head.prev;
                node.next = head;
                head.prev.next = node;
                head.prev = node;
            }
            count++;
        }

        public void AddAtPosition(T data, int pos) //Додавання елемента на позицiю
        {
            DLNode<T> node = new DLNode<T>(data);
            int position = pos;
            var current = head;

            if (head == null || position == 1)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }
            else
            {
                for (int i = 1; i < position; i++)
                {
                    current = current.next;
                }
                node.prev = current.prev;
                node.next = current;
                current.prev.next = node;
                current.prev = node;
            }
                        
            count++;
        }

        public void DeleteFirst()  //Видалення першого елемента
        {
            if (count == 0)
            {
                WriteLine("Немає елементів");
            }
            else if (count == 1)
            {
                head = null;
                count--;
            }
            else
            {
                head.prev.next = head.next;
                head.next.prev = head.prev;
                head = head.next;                
                count--;
            }            
        }

        public void DeleteLast()  //Видалення останнього елемента
        {
            if (count == 0)
            {
                WriteLine("Немає елементів");
            }
            else if (count == 1)
            {
                head = null;
                count--;
            }
            else
            {
                head.prev.prev.next = head.prev.next;
                head.prev = head.prev.prev;
                count--;
            }
        }

        public void DeleteAtPosition(int pos) //Видалення елемента з позицiї
        {            
            int position = pos;
            var current = head;

            if (count == 0)
            {
                WriteLine("Немає елементів");
            }
            else if (count == 1)
            {
                head = null;
                count--;
            }
            else
            {
                for (int i = 1; i < position; i++)
                {
                    current = current.next;
                }
                current.prev.next = current.next;
                current.next.prev = current.prev;
                count--;
            }
        }

        public void Print(CircularDLList<int> circularList)  //Виведення вмісту списку
        {
            foreach (var item in circularList)
            {
                Write(item + "   ");
            }
            WriteLine("\n");
            ReadKey();
        }

        public int FindMinNum(CircularDLList<int> circularList) //Пошук найменшого парного елемента
        {
            int min = 1000;
            foreach (var item in circularList)
            {
                if (item % 2 == 0)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }
            }                
            return min;
        }

        public int FindPosition(int min, CircularDLList<int> circularList)
        {
            int pos = 1;
            if (min != 1000)
            {
                foreach (var item in circularList)
                {
                    if (item == min)
                    {
                        return pos;
                    }
                    pos++;
                }
            }
            return 1;
        }

        public void AddAfterMin(T data, int pos) //Додавання елемента на позицiю
        {
            DLNode<T> node = new DLNode<T>(data);
            int position = pos;
            var current = head;
            

            if (head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }           
            else
            {
                for (int i = 1; i <= position; i++)
                {
                    current = current.next;
                }
                node.prev = current.prev;
                node.next = current;
                current.prev.next = node;
                current.prev = node;
            }

            count++;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DLNode<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.data;
                    current = current.next;
                }
            }
            while (current != head);
        }        
    }    
}
