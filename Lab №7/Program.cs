using System.Text;
using static System.Console;
namespace Asd_lab7
{
    class Program
    {
        static void Main()
        {
            OutputEncoding = Encoding.UTF8;
            Hashtable hashtable = new Hashtable();
            hashtable.Notify += Hashtable_Notify;

            WriteLine("Запустити контрольний приклад?\nТак - 1\nНі - 0");
            int.TryParse(ReadLine(), out int input);
            if (input == 1)
            {
                hashtable = ControlFilling();
                ControleExample(hashtable);
            }

            WriteLine("\nНатисніть Enter, щоб продовжити...");
            ReadLine();
            Clear();

            WriteLine("Заповнити геш-таблицю контрольними значеннями?\nТак - 1\nНі - 0");
            int.TryParse(ReadLine(), out input);
            if (input == 1)
            {
                hashtable = ControlFilling();
            }
            else
            {
                Write("Введіть розмір геш-таблиці: ");
                int.TryParse(ReadLine(), out input);
                while (input <= 0)
                {
                    Write("Введіть розмір геш-таблиці (size > 0): ");
                    int.TryParse(ReadLine(), out input);
                }
                hashtable.InitHashtable(input);
            }
            while (true)
            {
                Write("1. Додати новий елемент\n2. Видалити елемент за ключем\n3. Знайти елемент за ключем\n4. Вивести геш-таблицю\n5. Оновити предмет\n6. Вихід\nВаш вибір: ");

                int.TryParse(ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        {
                            Key key = GetKey();
                            Clear();
                            Value value = GetValue();
                            Clear();
                            hashtable.InsertEntry(key, value);
                            break;
                        }
                    case 2:
                        {
                            Key key = GetKey();
                            Clear();
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Видалений елемент:");
                            ForegroundColor = ConsoleColor.Gray;
                            WriteLine(hashtable.RemoveEntry(key));
                            break;
                        }
                    case 3:
                        {
                            Key key = GetKey();
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("\nЗнайдений елемент:");
                            ForegroundColor = ConsoleColor.Gray;
                            WriteLine(hashtable.FindEntry(key));
                            break;
                        }
                    case 4:
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("\nHashTable:");
                            ForegroundColor = ConsoleColor.Gray;
                            WriteLine(hashtable);
                            break;
                        }
                    case 5:
                        {
                            WriteLine("У кого змінюємо дисципліну:");
                            Key key = GetKey();
                            Clear();
                            Entry person = hashtable.FindEntry(key);

                            WriteLine("1. Додати нову дисципліну\n2. Видалити наявну дисципліну\n3. Оновити бал");
                            int.TryParse(ReadLine(), out int input2);
                            switch (input2)
                            {
                                case 1:
                                    {
                                        Write("Введіть назву дисципліни: ");
                                        string name = ReadLine();
                                        name = name.Trim();
                                        name = name.Replace('?', 'і');
                                        if (name.StartsWith('і'))
                                        {
                                            name = name.Substring(1, name.Length - 1);
                                            name = "І" + name;
                                        }
                                        while (person.Value.Discilines.Contains(name))
                                        {
                                            Write("Назва не може повторюватися\nВведіть назву дисципліни: ");
                                            name = ReadLine();
                                            name = name.Trim();
                                            name = name.Replace('?', 'і');
                                            if (name.StartsWith('і'))
                                            {
                                                name = name.Substring(1, name.Length - 1);
                                                name = "І" + name;
                                            }
                                        }
                                        Write("Введіть оцінку: ");
                                        int.TryParse(ReadLine(), out int grade);
                                        person.Value.Discilines.UpdateDisciplinesList(name, grade);
                                        break;
                                    }
                                case 2:
                                    {
                                        Write("Введіть назву дисципліни: ");
                                        string name = ReadLine();
                                        while (!person.Value.Discilines.Contains(name))
                                        {
                                            Write("Такої дисципліни немає\nВведіть назву дисципліни: ");
                                            name = ReadLine();
                                        }
                                        person.Value.Discilines.UpdateDisciplinesList(name);
                                        break;
                                    }
                                case 3:
                                    {
                                        Write("Введіть назву дисципліни: ");
                                        string name = ReadLine();
                                        name = name.Trim();
                                        name = name.Replace('?', 'і');
                                        if (name.StartsWith('і'))
                                        {
                                            name = name.Substring(1, name.Length - 1);
                                            name = "І" + name;
                                        }
                                        while (!person.Value.Discilines.Contains(name))
                                        {
                                            Write("Такої дисципліни немає\nВведіть назву дисципліни: ");
                                            name = ReadLine();
                                            name = name.Trim();
                                            name = name.Replace('?', 'і');
                                            if (name.StartsWith('і'))
                                            {
                                                name = name.Substring(1, name.Length - 1);
                                                name = "І" + name;
                                            }
                                        }
                                        Write("Введіть оцінку: ");
                                        int.TryParse(ReadLine(), out int grade);
                                        person.Value.Discilines.UpdateDisciplinesList(name, grade);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 6:
                        {
                            WriteLine("Програму завершено");
                            return;
                        }
                    default:
                        break;
                }

                ReadLine();
                Clear();
            }

        }
        public static Key GetKey()
        {
            Write("Введіть ім'я: ");
            string firstName = ReadLine();
            firstName = firstName.Trim();
            firstName = firstName.Replace('?', 'і');
            Write("Введіть прізвище: ");
            string lastName = ReadLine();
            lastName = lastName.Trim();
            lastName = lastName.Replace('?', 'і');

            if (firstName.StartsWith('і'))
            {
                firstName = firstName.Substring(1, firstName.Length - 1);
                firstName = "І" + firstName;
            }
            if (lastName.StartsWith('і'))
            {
                lastName = lastName.Substring(1, lastName.Length - 1);
                lastName = "І" + lastName;
            }
            return new Key(firstName, lastName);
        }
        public static Value GetValue()
        {
            Write("Введіть дату народження:\nДень: ");
            int.TryParse(ReadLine(), out int day);
            Write("Місяць (словом): ");
            string month = ReadLine();
            month = month.Trim();
            month = month.Replace('?', 'і');
            Write("Рік: ");
            int.TryParse(ReadLine(), out int year);
            Date date = new Date(year, month, day);

            Write("Введіть адресу проживання: ");
            string address = ReadLine();
            address = address.Trim();
            address = address.Replace('?', 'і');
            if (address.StartsWith('і'))
            {
                address = address.Substring(1, address.Length - 1);
                address = "І" + address;
            }

            Write("Введіть рік вступу: ");
            int.TryParse(ReadLine(), out year);

            DiscilinesList discilines = GetDiscilines();

            return new Value(date, address, year, discilines);
        }
        public static DiscilinesList GetDiscilines()
        {
            DiscilinesList discilines = new DiscilinesList();
            Write("Введіть назву дисципліни: ");
            string name = ReadLine();
            Write("Введіть оцінку (0 - 100): ");
            int.TryParse(ReadLine(), out int grade);
            discilines.AddNode(new Node(name, grade));

            while (true)
            {
                WriteLine("1. Додати дисципліну\n2. Завершити додавання");
                int.TryParse(ReadLine(), out int input);
                if (input == 2)
                {
                    break;
                }
                Write("Введіть назву дисципліни: ");
                name = ReadLine();

                name = name.Trim();
                name = name.Replace('?', 'і');
                if (name.StartsWith('і'))
                {
                    name = name.Substring(1, name.Length - 1);
                    name = "І" + name;
                }

                while (discilines.Contains(name))
                {
                    Write("Назва не може повторюватися\nВведіть назву дисципліни: ");
                    name = ReadLine();
                    name = name.Trim();
                    name = name.Replace('?', 'і');
                    if (name.StartsWith('і'))
                    {
                        name = name.Substring(1, name.Length - 1);
                        name = "І" + name;
                    }
                }

                Write("Введіть оцінку (0 - 100): ");
                int.TryParse(ReadLine(), out grade);
                discilines.AddNode(new Node(name, grade));
            }
            return discilines;
        }
        public static Hashtable ControlFilling()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Notify += Hashtable_Notify;
            hashtable.InitHashtable(5);

            {
                DiscilinesList discilines1 = new DiscilinesList(new Node("Math", 97));
                discilines1.AddNode(new Node("English", 99));
                discilines1.AddNode(new Node("PE", 100));
                discilines1.AddNode(new Node("Germany", 93));

                Value value1 = new Value(new Date(2004, "липня", 8), "Kyiv", 2021, discilines1);
                hashtable.InsertEntry(new Key("Софія", "Єфімова"), value1);
            }
            {
                DiscilinesList discilines2 = new DiscilinesList(new Node("Math", 79));
                discilines2.AddNode(new Node("French", 79));
                discilines2.AddNode(new Node("Informatic", 92));
                discilines2.AddNode(new Node("Spanish", 40));

                Value value2 = new Value(new Date(2003, "жовтня", 17), "Lviv", 2021, discilines2);
                hashtable.InsertEntry(new Key("Петро", "Петров"), value2);
            }
            {
                DiscilinesList discilines3 = new DiscilinesList(new Node("French", 92));
                discilines3.AddNode(new Node("English", 89));
                discilines3.AddNode(new Node("Informatic", 63));
                discilines3.AddNode(new Node("Germany", 83));

                Value value3 = new Value(new Date(2002, "березня", 23), "Kyiv", 2019, discilines3);
                hashtable.InsertEntry(new Key("В`ячеслав", "Адамс"), value3);
            }
            {
                DiscilinesList discilines4 = new DiscilinesList(new Node("Math", 43));
                discilines4.AddNode(new Node("French", 79));
                discilines4.AddNode(new Node("Informatic", 27));
                discilines4.AddNode(new Node("Germany", 49));

                Value value4 = new Value(new Date(2003, "листопада", 6), "Dnipro", 2020, discilines4);
                hashtable.InsertEntry(new Key("Анна", "Бандера"), value4);
            }
            {
                DiscilinesList discilines3 = new DiscilinesList(new Node("French", 92));
                discilines3.AddNode(new Node("English", 88));
                discilines3.AddNode(new Node("Informatic", 97));
                discilines3.AddNode(new Node("Math", 80));

                Value value3 = new Value(new Date(2004, "січня", 10), "Kyiv", 2021, discilines3);
                hashtable.InsertEntry(new Key("Ігор", "Чорновіл"), value3);
            }
            {
                DiscilinesList discilines4 = new DiscilinesList(new Node("Math", 100));
                discilines4.AddNode(new Node("French", 97));
                discilines4.AddNode(new Node("English", 57));
                discilines4.AddNode(new Node("Germany", 69));

                Value value4 = new Value(new Date(2003, "лютого", 14), "Kherson", 2020, discilines4);
                hashtable.InsertEntry(new Key("Валерія", "Кравець"), value4);
            }

            return hashtable;
        }
        public static void ControleExample(Hashtable hashtable)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Геш-таблиця:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable);

            ForegroundColor = ConsoleColor.Red;
            WriteLine("Видалений елемент:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable.RemoveEntry(new Key("Софія", "Єфімова")));

            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nЗнайдений елемент:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable.FindEntry(new Key("Ігор", "Чорновіл")));

            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nHashTable:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable);

            ForegroundColor = ConsoleColor.Red;
            WriteLine("До оновлення дисципліни:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable.FindEntry(new Key("Ігор", "Чорновіл")) + "\n");

            hashtable.FindEntry(new Key("Ігор", "Чорновіл")).Value.Discilines.UpdateDisciplinesList("Math", 97);
            hashtable.FindEntry(new Key("Ігор", "Чорновіл")).Value.Discilines.UpdateDisciplinesList("English");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nПісля оновлення дисципліни:");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(hashtable.FindEntry(new Key("Ігор", "Чорновіл")) + "\n");
        }
        private static void Hashtable_Notify(string message)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(message);
            ForegroundColor = ConsoleColor.Gray;
        }
    }
    class Hashtable
    {
        public delegate void Handler(string message);
        public event Handler Notify;

        Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            ['а'] = 1,
            ['б'] = 2,
            ['в'] = 3,
            ['г'] = 4,
            ['ґ'] = 5,
            ['д'] = 6,
            ['е'] = 7,
            ['є'] = 8,
            ['ж'] = 9,
            ['з'] = 10,
            ['и'] = 11,
            ['і'] = 12,
            ['ї'] = 13,
            ['й'] = 14,
            ['к'] = 15,
            ['л'] = 16,
            ['м'] = 17,
            ['н'] = 18,
            ['о'] = 19,
            ['п'] = 20,
            ['р'] = 21,
            ['с'] = 22,
            ['т'] = 23,
            ['у'] = 24,
            ['ф'] = 25,
            ['х'] = 26,
            ['ц'] = 27,
            ['ч'] = 28,
            ['ш'] = 29,
            ['щ'] = 30,
            ['ь'] = 31,
            ['ю'] = 32,
            ['я'] = 33,
            ['`'] = 34
        };
        public MyLinkedList[] Table { get; private set; }
        public int Loadness { get; private set; }
        public int Size { get; private set; }

        public void InitHashtable(int size)
        {
            Table = new MyLinkedList[size];
            for (int i = 0; i < size; i++)
            {
                Table[i] = new MyLinkedList();
            }
            Loadness = 0;
            Size = size;
            Notify?.Invoke("Геш-таблицю створено\n");
        }
        public void InsertEntry(Key key, Value value)
        {
            Entry entry = new Entry(key, value);
            int index = GetHash(key);
            Table[index].AddFirst(entry);
            Loadness++;

            if (Loadness / Size >= 1)
            {
                Rehashing();
            }
            Notify?.Invoke("Додано новий елемент\n");
        }
        public Entry RemoveEntry(Key key)
        {
            Entry removed = null;
            int index = GetHash(key);
            Entry node;
            if (Table[index].Head.Key.FirstName.Equals(key.FirstName) && Table[index].Head.Key.LastName.Equals(key.LastName))
            {
                removed = Table[index].Head;
                Table[index].Size--;
                if (Table[index].Size > 0)
                {
                    Table[index].Head = Table[index].Head.Next;
                }
                else
                {
                    Table[index].Head = null;
                }
                Loadness--;
            }
            else
            {
                for (node = Table[index].Head; node != null; node = node.Next)
                {
                    if (node.Next.Key.FirstName.Equals(key.FirstName) && node.Next.Key.LastName.Equals(key.LastName))
                    {
                        removed = node.Next;
                        Table[index].Size--;
                        if (Table[index].Size > 0)
                        {
                            node.Next = node.Next.Next;
                        }
                        else
                        {
                            node.Next = null;
                        }
                        Loadness--;
                        break;
                    }
                }
            }
            Notify?.Invoke("Видалено елемент\n");
            if (removed != null)
            {
                return removed;
            }
            throw new Exception("Wrong key");
        }
        public Entry FindEntry(Key key)
        {
            int index = GetHash(key);
            for (Entry node = Table[index].Head; node != null; node = node.Next)
            {
                if (node.Key.FirstName.Equals(key.FirstName) && node.Key.LastName.Equals(key.LastName))
                {
                    return node;
                }
            }
            throw new Exception("Wrong key");
        }
        public void Rehashing()
        {
            MyLinkedList[] helpTable = new MyLinkedList[Size];
            int size = Size;
            Entry entry;
            for (int i = 0; i < size; i++)
            {
                helpTable[i] = new MyLinkedList();
                while (!Table[i].IsEmpty())
                {
                    entry = Table[i].RemoveFirst();
                    helpTable[i].AddFirst(entry);
                }
            }

            InitHashtable(size * 2);

            int index;
            for (int i = 0; i < size; i++)
            {
                while (!helpTable[i].IsEmpty())
                {
                    entry = helpTable[i].RemoveFirst();
                    InsertEntry(entry.Key, entry.Value);
                }
            }
            Notify?.Invoke("Відбулося перегешування геш-таблиці\n");
        }
        public int HashCode(Key key)
        {
            int num = 0;
            for (int i = 0; i < key.LastName.Length; i++)
            {
                num += (int)(letters[char.ToLower(key.LastName[i])] * Math.Pow(Size, key.LastName.Length - 1 - i));
            }
            for (int i = 0; i < key.FirstName.Length; i++)
            {
                num += (int)(letters[char.ToLower(key.FirstName[i])] * Math.Pow(Size, key.FirstName.Length - 1 - i));
            }
            return num;
        }
        public int GetHash(Key key)
        {
            int num = HashCode(key);
            int index = num % Size;
            return index;
        }
        public override string ToString()
        {
            string info = String.Empty;

            Entry node;
            for (int i = 0; i < Size; i++)
            {
                for (node = Table[i].Head; node != null; node = node.Next)
                {
                    info += node.ToString() + "\n\n";
                }
            }

            return info;
        }
    }
    class MyLinkedList
    {
        public Entry Head { get; set; }
        public int Size { get; set; }
        public void AddFirst(Entry node)
        {
            if (Size < 1)
            {
                Head = node;
                Size++;
            }
            else
            {
                node.Next = Head;
                Head = node;
                Size++;
            }
        }
        public Entry RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("LinkedList is empty");
            }
            Entry entry = Head;
            if (Size > 1)
            {
                Head = Head.Next;
            }
            else
            {
                Head = null;
            }
            Size--;
            return entry;
        }
        public bool IsEmpty() => Size == 0 ? true : false;
    }
    class Entry
    {
        public Entry(Key key, Value value)
        {
            Key = key;
            Value = value;
        }
        public Key Key { get; set; }
        public Value Value { get; set; }
        public Entry Next { get; set; }
        public override string ToString() => $"Key: {Key}, Value:\n{Value}";
    }
    class Key
    {
        public Key(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
    class Value
    {
        double avg;
        Random rnd = new Random();
        public Value(Date birthDate, string address, int yearOfEntry, DiscilinesList discilines)
        {
            string id = ((char)rnd.Next('A', 'Z')).ToString() + ((char)rnd.Next('A', 'Z')).ToString();
            id += "-" + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString();
            StudentId = id;

            BirthDate = birthDate;
            Address = address;
            YearOfEntry = yearOfEntry;
            Discilines = discilines;
            avg = AverageGrade;
        }
        public string StudentId { get; private set; }
        public Date BirthDate { get; private set; }
        public string Address { get; set; }
        public int YearOfEntry { get; private set; }
        public DiscilinesList Discilines { get; set; }
        public double AverageGrade
        {
            get
            {
                if (Discilines.IsEmpty())
                {
                    return 0;
                }
                double avg = 0;
                Node node;
                for (node = Discilines.Head; node != null; node = node.Next)
                {
                    avg += node.Grade;
                }
                return avg / Discilines.Size;
            }
        }
        public override string ToString()
        {
            return $"BirthDate - {BirthDate}\nAdress - {Address}\nYearOfEntry - {YearOfEntry}\nDiscilines - {Discilines}\nAverageGrade - {Math.Round(AverageGrade, 2)}";
        }
    }
    class Date
    {
        public Date(int year, string month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public int Year { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public override string ToString() => $"{Day} {Month} {Year}";
    }
    class Node
    {
        public Node(string disciplineName, int grade)
        {
            DisciplineName = disciplineName;
            if (grade >= 0 && grade <= 100)
            {
                Grade = grade;
            }
            else
            {
                throw new Exception("Grade must be between 0 and 100");
            }
        }
        public string DisciplineName { get; set; }
        public int Grade { get; set; }
        public Node Next { get; set; }
        public override string ToString() => $"{DisciplineName} ({Grade})";
    }
    class DiscilinesList
    {
        public DiscilinesList()
        {
            Size = 0;
        }
        public DiscilinesList(Node node)
        {
            AddNode(node);
            Size = 1;
        }
        public Node Head { get; set; }
        public int Size { get; set; }
        public bool IsEmpty() => Size == default ? true : false;
        public void AddNode(Node node)
        {
            if (Head is null)
            {
                Head = node;
                Size++;
                return;
            }
            Node current;
            for (current = Head; current.Next != null; current = current.Next)
            {

            }
            current.Next = node;
            Size++;
        }
        public void DeleteNode(string disciplineName)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty");
            }
            if (disciplineName == Head.DisciplineName)
            {
                Head = Head.Next;
                Size--;
                return;
            }
            Node current;
            for (current = Head; current != null; current = current.Next)
            {
                if (disciplineName == current.Next.DisciplineName)
                {
                    current.Next = current.Next.Next is null ? null : current.Next.Next;
                    Size--;
                    return;
                }
            }
            throw new InvalidOperationException("Wrong node");
        }
        public void UpdateDisciplinesList(string disciplineName, int grade)
        {
            bool flag = false;
            for (Node node = Head; node != null; node = node.Next)
            {
                if (node.DisciplineName.Equals(disciplineName))
                {
                    node.Grade = grade;
                    flag = true;
                }
            }
            if (flag == false)
            {
                AddNode(new Node(disciplineName, grade));
            }
        }
        public void UpdateDisciplinesList(string disciplineName)
        {
            DeleteNode(disciplineName);
        }
        public bool Contains(string disciplineName)
        {
            for (Node node = Head; node != null; node = node.Next)
            {
                if (node.DisciplineName.Equals(disciplineName))
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Empty";
            }
            string info = String.Empty;
            Node node;
            for (node = Head; node is not null; node = node.Next)
            {
                info += node.ToString() + ", ";
            }
            return info;
        }
    }
}