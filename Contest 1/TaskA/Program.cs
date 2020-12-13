using System;
using System.IO;

namespace ProgKonsa
{
    class ProgKonsa
    {
        public static void Workshop()
        {

            Shape Y = new Shape();
        }

        public static void Main()
        {
            Workshop();

            // AllArraysExamples();
            // AllStringExamples();
            // AllRefValueExamples();
            // AllFilesExamples();
            // OOPExample();
            // Constructors.ConstructorsOrder();
            // AllExceptionExamples();

            Console.ReadLine();
        }

        #region Arrays

        class MyClass { }

        public static void AllArraysExamples()
        {
            Action[] examples = { ArraysIndexing, ArrayMethods,
                                  RectangularArrays, JaggedArrays };

            PrintDelimeter();
            Console.WriteLine("ARRAYS");
            InvokeAllExamples(examples);
        }

        public static void ArraysInitialization()
        {
            // Способы инициализации массивов
            int[] ints1 = new int[5];
            int[] ints2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] ints3 = new int[] { 1, 2, 3, 4, 5 };
            int[] ints4 = { 1, 2, 3, 4, 5 };
            // var ints5 = { 1, 2, 3, 4, 5 } <- так нельзя -- компилятор не понимает, что за тип элементов (int? long? double?)

            // Тип элементов массива может быть любым, в том числе ваш кастомный.
            MyClass[] myClasses = new MyClass[10];
        }

        public static void ArraysIndexing()
        {
            object[] objects = { new object(), new object(), new object() };
            // Если вы указали индекс, выходящий за границы массива, вы получите в лицо IndexOutOfRangeException.
            try
            {
                Console.WriteLine("Trying to get element at [-1]...");
                Console.WriteLine(objects[-1]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Trying to get element at [Length]...");
                Console.WriteLine(objects[objects.Length]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ArrayMethods()
        {
            Console.WriteLine("Array methods: " + Environment.NewLine);

            int[] array = { 4, 7, 5, 2, 12 };
            Console.Write("Initial array: ");
            PrintArray(array);

            // Увеличивает размер массива на 1.
            Array.Resize(ref array, array.Length + 1);
            Console.Write("Resized array: ");
            PrintArray(array); // 4 7 5 2 12 0

            // Сортирует массив по возрастанию.
            Array.Sort(array);
            Console.Write("Sorted array: ");
            PrintArray(array); // 0 2 4 5 7 12

            // Ищет указанный элемент в массиве. 
            // Если не найден, возвращает отрицательное число (причём отнюдь не случайное, можете чекнуть документацию).
            int index = Array.BinarySearch(array, 2);
            if (index >= 0)
            {
                Console.WriteLine($"Result of searching 2: {array[index]}");
            }
        }

        public static void RectangularArrays()
        {
            Console.WriteLine("Rectangular arrays:");
            // Двумерный массив
            double[,] twoD = new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            double[] analog = new double[6] { 1, 2, 3, 4, 5, 6 };
            // В сущности, под двумерным массивом скрывается одномерный массив с двойной индексацией. 
            // На данном примере twoD[1,1] = analog[1 * 3 + 1].

            Console.WriteLine("2D array: { { 1, 2, 3 }, { 4, 5, 6 } }");

            // Именно потому, что двумерный массив технически является одномерным, 
            // .Length будет возвращать произведение длин всех измерений.
            Console.WriteLine($"Length of 2D array: {twoD.Length}");                // 6

            // Чтобы получить длину i-ого измерения, используем .GetLength(i - 1) [индексация с нуля, по классике].
            Console.WriteLine($"Length of first dimension: {twoD.GetLength(0)}");   // 2
            Console.WriteLine($"Length of second dimension: {twoD.GetLength(1)}");  // 3

            // Вывод двумерного массива
            for (int i = 0; i < twoD.GetLength(0); ++i)
            {
                for (int j = 0; j < twoD.GetLength(1); ++j)
                {
                    Console.Write(twoD[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }

            // Можно указать сколько угодно измерений с помощью запятой.
            double[,,,] fourD = new double[1, 2, 3, 4];
        }

        public static void JaggedArrays()
        {
            Console.WriteLine("Jagged arrays:" + Environment.NewLine);
            // Зубчатые (jagged) массивы являются массивами массивов. Это уже true-многомерные массивы.

            // Создаём массив, содержащий 3 массива строк.
            string[][] arrayOfArrays = new string[3][];
            // string[][] arrayOfArrays1 = new string[3][4]; <- это не скомпилится

            // Каждый массив может иметь свою длину -- отсюда название "зубчатый массив". 
            arrayOfArrays[0] = new string[2] { "Two", "strings" };
            arrayOfArrays[1] = new string[3] { "Have", "three", "strings" };
            arrayOfArrays[2] = new string[4] { "Four", "strings", "in", "array" };

            // Размер самого массива массивов -- 3.
            Console.WriteLine($"Length of array of arrays = {arrayOfArrays.Length}");   // 3
            for (int i = 0; i < arrayOfArrays.Length; ++i)
            {
                Console.WriteLine($"Length of element {i} is {arrayOfArrays[i].Length}");
            }
        }

        #endregion

        #region Strings

        public static void AllStringExamples()
        {
            Action[] examples = { StringConstructors, StringsAreImmutable,
                                  StringsIndexing, StringsFormattingAndInterpolation };

            PrintDelimeter();
            Console.WriteLine("STRINGS");
            InvokeAllExamples(examples);
        }

        public static void StringConstructors()
        {
            Console.WriteLine("String constructor examples:" + Environment.NewLine);

            // Строковые литералы имеют тип string (он же System.String).
            string line1 = "Hello, world!";
            System.String line2 = line1;

            string line3 = new string(new char[] { 'C', 'H', 'A', 'R', 'S' });          // CHARS
            // Этот фокус с долларом называется интерполяция строки.
            Console.WriteLine($"new string(new char[] {{ 'C','H', 'A', 'R', 'S' }}) -> {line3}");

            string line4 = new string('A', 5);                                          // AAAAA
            Console.WriteLine($"new string('A', 5) -> {line4}");

            string line5 = new string(new char[] { 'C', 'H', 'A', 'R', 'S' }, 2, 3);    // ARS
            Console.WriteLine($"new string(new char[] {{ 'C','H', 'A', 'R', 'S' }}, 2, 3) -> {line5}");
        }

        public static void StringsAreImmutable()
        {
            Console.WriteLine("Strings are immutable:" + Environment.NewLine);

            string example = "Example";
            // Здесь возвращается новая строка, начальная остаётся неизменной!
            example.Substring(startIndex: 0, length: 4);
            Console.WriteLine(example); // Example
            example = example.Substring(startIndex: 0, length: 4);
            Console.WriteLine(example); // Exam

            example = "Example";
            // Здесь возвращается новая строка, начальная остаётся неизменной!
            example.Remove(4);
            Console.WriteLine(example);     // Example
            example = example.Remove(4);
            Console.WriteLine(example);     // Exam

            // То же самое с прочими методами: Concat, Format, Insert, Replace, ToLower, ToUpper ...
        }

        public static void StringsIndexing()
        {
            Console.WriteLine("You can get a char at certain index:" + Environment.NewLine);
            string example = "Example";
            // Вы можете обращаться с символам строки по индексу. 
            Console.WriteLine($"First char of {example} is {example[0]}");                  // E
            Console.WriteLine($"Last char of {example} is {example[example.Length - 1]}");  // e
            // Доступно только чтение, но не запись!
            // example[1] = 's';
        }

        public static void StringsFormattingAndInterpolation()
        {
            Console.WriteLine("Interpolation and formatting:" + Environment.NewLine);

            string format = "Max score: {0}; Min score {1}; Average: {2}";
            int max = 33, min = 0;
            double average = 18.23456;

            // Составное форматирование
            string text = string.Format(format, max, min, average);
            Console.WriteLine(text);

            // Тот же результат можно получить, передав строку и аргументы
            // прямиком в Console.WriteLine
            Console.WriteLine(format, max, min, average);

            // Можно также указывать разные спецификаторы форматов 
            // (https://docs.microsoft.com/ru-ru/dotnet/standard/base-types/standard-numeric-format-strings).
            // Единственный полезный имхо FX, где X - число знаков после запятой (напр. F3).
            Console.WriteLine("Initial: {0}; Two digits rounding: {0:F2}", average);

            // Можно передать спецификатор формата прям в ToString для double значений.
            Console.WriteLine("Two digits rounding: " + average.ToString("F2"));

            // Можно повторять один и тот же элемент, и даже применять к нему разное форматирование.
            string date = string.Format("It is now {0:d} at {0:t}", DateTime.Now);
            Console.WriteLine(date);

            // Более удобный вариант интерполяции строк. Тоже можно указывать спецификаторы.
            // Фигурные скобки экранируются удваиванием.
            Console.WriteLine($"It is now {DateTime.Now:d} at {DateTime.Now:t}. {{Curly braces}}.");
        }

        public static void EscapeSequences()
        {
            // Эскейп-последовательности - специальные символы в строках, начинающиеся с \.
            // Основные эскейп-последовательности

            // Перевод строки (НО в Windows используется \r\n для перевода строки).
            char newLine = '\n';
            // Платформонезависимый перевод строки.
            string goodNewLine = Environment.NewLine;

            // Знак табуляции.
            char tab = '\t';

            // Возврат каретки.
            char carriageReturn = '\r';

            // Можно задать символ в юникоде: \uXXXX.
            char unicodeChar = '\u0042'; // B

            // Есть и другие, но они используются реже: https://docs.microsoft.com/ru-ru/cpp/c-language/escape-sequences?view=msvc-160

            // Специальные символы (' для символов, " для строк, \) должны экранироваться:
            char quote = '\''; // '
            string doubleQuote = "\"This is a \\quote\\.\""; // "This is a \quote\."

            // Можно задать строку "буквальной" с помощью значка @. 
            // Тогда эскейп-последовательности в ней будут игнорироваться.
            string mess = @"\t\n\r"; // \t\n\r

            // Чаще всего это используется в путях.
            string straightforwardPath = "\\\\servername\\share\\folder";
            string path = @"\\servername\share\folder";

            string serverName = "my-server";
            string share = "my-share";
            string folder = "data";
            // Можно комбинировать @ и $ (с C#8 - в любом порядке, до этого $ должен был быть первым).
            string newPath = $@"\\{serverName}\{share}\{folder}";
        }

        #endregion

        #region Reference and value types + ref, out

        public static void AllRefValueExamples()
        {
            Action[] examples = { ReferenceAndValueTypesAsParameters,
                                  SwapExample, RefOutExample };

            PrintDelimeter();
            Console.WriteLine("REF VALUE");
            InvokeAllExamples(examples);
        }

        public static void ReferenceAndValueTypesAsParameters()
        {
            Console.WriteLine("Reference and value types as parameters: " + Environment.NewLine);

            int @int = 15;
            Console.WriteLine("Initial int value: " + @int.ToString());
            ValueTypeChange(@int);
            Console.WriteLine("After changing int: " + @int.ToString());

            int[] ints = { 1, 2, 3 };
            Console.Write("Initial array elements: ");
            PrintArray(ints);
            ReferenceTypeChange(ints);
            Console.Write("After changing first value: ");
            PrintArray(ints);

            ReferenceTypeReassign(ints);
            Console.Write("After reassigning: ");
            PrintArray(ints);
        }

        public static void ValueTypeChange(int @int) => @int = 100;

        public static void ReferenceTypeChange(int[] ints) => ints[0] = 100;

        public static void ReferenceTypeReassign(int[] ints) => ints = new int[] { 4, 5, 6 };


        public static void SwapExample()
        {
            Console.WriteLine("Swap example: " + Environment.NewLine);

            int a = 1, b = 2;
            Console.WriteLine($"Initial: a = {a}, b = {b}");
            WrongSwap(a, b);
            Console.WriteLine($"After wrong swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap with ref: a = {a}, b = {b}");
        }

        public static void WrongSwap(int a, int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


        public static void RefOutExample()
        {
            int refInt, outInt;
            // Значение, которое передаётся через ref обязано быть проинициализировано.
            refInt = 42;
            // Значение, которое передаётся через out может быть не проинициализировано (значение энивей будет изменено в методе).
            // outInt = 24;
            RefOut(ref refInt, out outInt);
            // Можно даже объявлять переменную прямо при вызове метода (сахар).
            RefOut(ref refInt, out int myOutInt);
        }

        public static void RefOut(ref int refInt, out int outInt)
        {
            // out гарантирует, что в теле метода этому параметру будет присвоено значение.
            outInt = 42;
        }

        #endregion

        #region Files

        public static void AllFilesExamples()
        {
            Action[] examples = { FileReadingWriting, StreamReaderEncodingExample };

            PrintDelimeter();
            Console.WriteLine("FILES");
            InvokeAllExamples(examples);
        }

        private static string loremIpsum = "Lorem ipsum dolor sit amet, " +
                "consectetur adipiscing elit, sed do eiusmod tempor " +
                "incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation " +
                "ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit " +
                "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint " +
                "occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static void FileReadingWriting()
        {
            Console.WriteLine("Class File: " + Environment.NewLine);

            // Класс File из неймспейса System.IO предоставляет тупенькие методы для простого чтения из файла и записи в файл.

            string non_existing_path = "file_does_not_exist";
            Console.WriteLine($"File {non_existing_path} exists: {File.Exists(non_existing_path)}");

            string path = "test.txt";
            File.Delete(path);
            string content = string.Join(Environment.NewLine, loremIpsum.Split());

            File.WriteAllText(path, content);

            string allText = File.ReadAllText(path);
            Console.WriteLine(allText);
        }

        public static void StreamReaderEncodingExample()
        {
            Console.WriteLine("StreamWriter/StreamReader: " + Environment.NewLine);

            string inputPath = "test.txt", outputPath = "output.txt";
            string content = string.Join(Environment.NewLine, loremIpsum.Split());
            File.WriteAllText(inputPath, content, System.Text.Encoding.UTF32);

            // Более гибкий способ работы с файлами -- объекты StreamReader / StreamWriter.
            StreamReader streamReader = new StreamReader(inputPath, System.Text.Encoding.GetEncoding("utf-32"));
            StreamWriter streamWriter = new StreamWriter(outputPath, append: false, System.Text.Encoding.UTF32);
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                streamWriter.WriteLine(line);
                Console.WriteLine(line);
                // Читаем не весь файл, а лишь пока не встретим строку "do" (включительно).
                if (line == "do")
                {
                    break;
                }
            }

            // Освобождаем все ресурсы, связанные с потоками.
            streamReader.Dispose();
            streamWriter.Dispose();
        }

        #endregion

        #region Class members

        // Класс по умолчанию имеет модификатор доступа internal - доступ внутри сборки.
        class FieldsAndAccess
        {
            // Приватное статическое поле. "Принадлежит" всему классу, а не отдельным экземплярам.
            static string staticField = "Same for all instances";

            // Модификатор readonly позволяет объявить поле доступным только для чтения.
            // Может быть инициализировано в конструкторе! Этим отличается от const.
            private readonly string instanceField = "Can be unique for every instance.";

            public FieldsAndAccess(string instance)
            {
                instanceField = instance + " " + FieldsAndAccess.staticField;
            }

            // Забудьте про публичные поля - их у вас быть не должно.
            // public string publicField; 

            // Константное поле может быть публичным. Оно является статическим (неявно).
            // Во время компиляции значение этого поля подставляется в точки вызова (оптимизиция).
            // Поэтому обязано быть проинициализировано значением, известным на момент компиляции.
            public const int Answer = 42;

            // Доступ только для потомков (в том числе в другой сборке).
            protected double protectedField;

            // Экзотические модификаторы доступа:

            // Доступ внутри сборки (assembly).
            internal double internalField;
            // Доступ всем внутри сборки + в наследниках в других сборках.
            protected internal double protectedInternalField;
            // Доступ только наследникам только внутри сборки.
            private protected double privateProtectedField;
        }

        public class Properties
        {
            // !!!!!!!!!!!!!!
            // Свойства это НЕ ПОЛЯ, а два метода (или один).
            // !!!!!!!!!!!!!!

            // java/C++ style
            private string password;
            public string getPassword()
            {
                return password;
            }
            public void setPassword(string newPassword)
            {
                password = newPassword;
            }

            // C# аналог написанного выше
            public string Password { get; set; }

            // Свойства позволяют контроллировать доступ к данным.
            // Например, можно сделать проверку внутри сеттера:
            private int age;
            public int Age
            {
                get => age;
                set
                {
                    // value - неявный параметр сеттера.
                    if (value <= 0)
                    {
                        throw new ArgumentException("Age cannot be negative: " + age);
                    }
                    age = value;
                }
            }

            // Можно (и обычно нужно) ограничить доступ к одному из аксессоров.
            // Можно навесить модификатор, СУЖАЮЩИЙ область видимости, причем лишь на 1 из аксессоров.
            public int Money { get; private set; }
            // public int Money { protected get; private set; } // ERROR
            // protected int Money { ; private set; } // ERROR

            // Можно вообще опустить один из аксессоров (обычно set). 
            public int MagicNumber { get; }

            // Всё ещё можно проинициализировать внутри конструктора.
            public Properties(int magicNumber)
            {
                MagicNumber = magicNumber;
            }

            // Автосвойства обязаны иметь get аксессор! 
            // Логично: как использовать автосвойство только с сеттером?
            // public decimal WrongPercentage { set; }

            // А вот обычные свойства вполне могут иметь только сеттер.
            public decimal Percentage
            {
                set
                {
                    Console.WriteLine("I literally do nothing");
                }
            }

            // Можно, например, сделать так.
            public decimal WriteOnlyPercentage { private get; set; }

            // Так как свойство - это ДВА МЕТОДА, оно может быть виртуальным/абстрактным.
            public virtual int Count { get; }

            public int Number => Count;
            // Такая запись равносильна
            /*public int Number
            {
                get
                {
                    return Count;
                }
            }*/
        }

        class Indexers
        {
            // Индексатор - считайте безымянное свойство с параметром.
            // Синтаксис следующий:
            public int this[int index]
            {
                get => 42;
                private set => Console.WriteLine("You set number " + value);
            }

            // Автоиндексаторов не бывает (непонятно, как они бы работали).
            // В остальном - то же свойство по своим свойствам :/

            // Может иметь несколько параметров (но хотя бы один нужен, очев).
            // Тип параметра - любой
            public string this[int index, string message]
            {
                get => $"{index}: {message}";
            }
            // Может быть несколько индексаторов в одном классе (с разным набором параметров).

            // Можно даже так писать (эквивалентно предыдущему).
            // public string this[int index, double accuracy] => $"{index}: {accuracy}";
        }

        public class Constructors
        {


            private readonly int age;
            public string Name { get; }
            // В конструкторах можно инициализировать readonly поля и свойства.
            public Constructors(int age, string name)
            {
                // this используется для обращения к члену класса.
                this.age = age;
                Name = name;
            }

            // Конструкторы могут иметь любые модификаторы доступа, в том числе private.
            private Constructors(int age)
            {
                this.age = age;
            }

            // Статический конструктор вызывается 1 раз при первом обращении к классу.
            // Не имеет модификатора доступа и параметров.
            static Constructors()
            {
                // Можно использовать для инициализации статических членов класса.
                Console.WriteLine("I am alive!");
            }

            class InlineExample
            {
                // inline инициализация производится ДО вызова конструктора, даже статического.
                private static string staticField = "Initial";
                static InlineExample()
                {
                    Console.WriteLine("Static start: " + staticField);
                    staticField = "Changed";
                    Console.WriteLine("Static end: " + staticField);
                }

                public static void Stub() { }
            }

            #region Constructors order
            class Base
            {
                static Base() => Console.WriteLine("Static Base");

                public Base(string fullname) => Console.WriteLine("Instance Base");
            }

            class Derived : Base
            {
                static Derived() => Console.WriteLine("Static Derived");

                public Derived(string name, string surname) : this(name + " " + surname)
                {
                    Console.WriteLine("Instance Derived with 2 parameters");
                }

                public Derived(string fullname) : base(fullname)
                {
                    Console.WriteLine("Instance Derived with 1 parameter");
                }
            }

            public static void ConstructorsOrder()
            {
                PrintDelimeter();
                Console.WriteLine("Constructors order: " + Environment.NewLine);

                Console.WriteLine("Creating first instance:");
                Derived derived = new Derived("Ivan", "Ivanov");

                Console.WriteLine();
                Console.WriteLine("Creating second instance:");
                // Здесь уже не вызовутся статические конструкторы!
                Derived derived2 = new Derived("Petr", "Petrov");
            }
            #endregion
        }

        class NestedClasses
        {
            private string superSecuredPassword = "password123";

            // Только вложенный класс может иметь модификатор private/protected/...
            public class Rat
            {
                public static string Message { get; } = "I am nested class!";

                // Вложенный класс имеет доступ к ПРИВАТНЫМ членам внешего класса.
                public void ChangePassword(NestedClasses @class, string newPassword)
                {
                    // Ого! Нагло влезли в другой класс.
                    @class.superSecuredPassword = newPassword;
                }
            }

            // Итого фичи вложенных классов:
            // 1. Модификаторы доступа private, protected итп
            //    (обычный класс - только public или internal)
            // 2. Внешний класс играет роль неймспейса: 
            //    доступ через NestedClass.Nested.Message
            // 3. Доступ к приватным членам внешнего класса (самое сочное).
        }

        #endregion

        #region OOP

        abstract class Shape
        {
            public string Name { get; private set; }

            // Абстрактные классы могут иметь конструкторы! 
            // Они вызываются при конструировании объектов базового класса.
            public Shape(string name)
            {
                Name = name;
            }

            // Этот метод обязан определить наследник, ЕСЛИ наследник НЕ является абстрактным классом.
            public abstract double GetArea();

            // Этот метод МОЖЕТ быть переопределён в наследнике.
            public virtual string GetInfo() => $"My name is {Name}.";
        }

        class Circle : Shape
        {
            public double Radius { get; }

            // Вызываем конструктор базового класса, чтобы проинициализировать Name (напрямую не можем!).
            public Circle(string name, double radius) : base(name)
            {
                Radius = radius;
            }

            // Этот метод выполнится, даже если объект будет находиться по ссылке Shape!
            // Модификатор sealed означает, что этот метод не может быть переопределён в наследнике.
            public sealed override double GetArea() => Math.PI * Radius * Radius;

            // Этот метод выполнится, даже если объект будет находиться по ссылке Shape!
            public override string GetInfo() => base.GetInfo() + " I am circle.";
        }

        class Triangle : Shape
        {
            public double Side1 { get; }
            public double Side2 { get; }
            public double Side3 { get; }

            public Triangle(string name, double side1, double side2, double side3) : base(name)
            {
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }

            // Этот метод выполнится, даже если объект будет находиться по ссылке Shape!
            public override double GetArea()
            {
                // Полупериметр.
                double p = (Side1 + Side2 + Side3) * 0.5;
                // Формула Герона.
                return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            }

            // Этот метод выполнится, даже если объект будет находиться по ссылке Shape!
            public override string GetInfo() => base.GetInfo() + " I am triangle.";
        }

        // Модификатор sealed запрещает наследование от этого класса. 
        // По этой причине sealed несовместим с abstract.
        sealed class RightTriangle : Triangle
        {
            // Псевдонимы, созданные для удобства.
            public double Catet1 { get => Side1; }
            public double Catet2 { get => Side2; }

            public RightTriangle(string name, double catet1, double catet2)
                : base(name, catet1, catet2, Math.Sqrt(catet1 * catet1 + catet2 * catet2)) { }

            // Этот метод выполнится, даже если объект будет находиться по ссылке Shape или Triangle!
            public override double GetArea() => (Catet1 * Catet2) / 2;

            // Этот метод НЕ выполнится, если объект будет находиться по ссылке Shape или Triangle!
            public new string GetInfo() => base.GetInfo() + " I am a shy right triangle.";
        }

        public static void OOPExample()
        {
            // Нельзя создавать объекты типа Shape!
            // Shape shape = new Shape("Abstract");

            Circle circle = new Circle("Adam", radius: 5.5);
            Console.WriteLine("Circle circle = new Circle(\"Adam\", radius: 5.5): \t" + circle.GetInfo());

            Triangle triangle = new Triangle("Bethany", 3, 4, 5);
            Console.WriteLine("Triangle triangle = new Triangle(\"Bethany\", 2, 3, 4): \t" + triangle.GetInfo());

            var rightTriangle = new RightTriangle("Connor", 3, 4);
            Console.WriteLine("var rightTriangle = new RightTriangle(\"Connor\", 3, 4): \t" + rightTriangle.GetInfo());

            // Ключевой момент: выводим информацию о каждой фигуру, "смотря" на неё через ссылку типа Shape.
            Shape[] shapes = { circle, triangle, rightTriangle };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine();
                Console.WriteLine($"Looking at {shape.GetType().Name} from Shape reference: \t" + shape.GetInfo());
                Console.WriteLine("Area: " + shape.GetArea());
            }
        }

        #endregion

        #region Exceptions

        // Сниппет "exce + Tab-Tab"
        [Serializable]
        public class MyException : Exception
        {

            public MyException() { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception inner) : base(message, inner) { }
            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public static void AllExceptionExamples()
        {
            Action[] examples = { TryCatchException,
                                  TryCatchSpecified,
                                  TryCatchFinally };

            PrintDelimeter();
            Console.WriteLine("EXCEPTIONS");
            InvokeAllExamples(examples);
        }

        public static void TryCatchException()
        {
            try
            {
                throw new ArgumentException("Аргументы?");
            }
            catch // Плохой способ - не можете получить информации об ошибке!
            {
                Console.WriteLine("Программа крашнулась, но я даже не знаю, по какой причине");
            }

            Console.WriteLine();
            try
            {
                int zero = 0;
                int y = 1 / zero; // DivideByZeroException
            }
            catch (Exception e) // Ловит все исключения по ссылке на базовый класс.
            {
                Console.WriteLine(e);
            }
        }

        public static void TryCatchSpecified()
        {
            // Можно ловить разные типы исключений. 
            // Порядок: от наиболее специфицированного типа к наиболее общему.
            try
            {
                int zero = 0;
                int y = 1 / zero; // DivideByZeroException
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divided by zero!");
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void TryCatchFinally()
        {
            // Блок finally предназначен для выполнения кода, который должен
            // выполниться в любом случае (напр. освобождение ресурсов).
            try
            {
                string line = null;
                char first = line[0]; // NullReferenceException
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return; // <-- обратите внимание на это
            }
            finally
            {
                Console.WriteLine("FINALLY!");
            }
        }

        #endregion

        #region Utils
        public static void PrintDelimeter() => Console.WriteLine(new string('=', 10));

        public static void PrintArray<T>(T[] array) => Console.WriteLine(string.Join(" ", array));

        public static void InvokeAllExamples(Action[] examples)
        {
            foreach (var example in examples)
            {
                PrintDelimeter();
                example.Invoke();
            }
            PrintDelimeter();
            Console.WriteLine();
        }
        #endregion
    }
}
