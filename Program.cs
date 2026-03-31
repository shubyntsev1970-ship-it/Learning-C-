using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;


namespace Learning
{
    internal static class Program
    {
        private static void Main()
        {
            Test001();  // Просто класс 1
            Test002();  // Просто класс 2
            Test003();  // Пример использования get и set
            Test004();  // Пример использования конструктора для инициализации поля и конструктора по умолчанию
            Test005();  // Передача экземпляра класса в качестве аргумента метода
            Test006();  // Автоматически реализуемые свойства для хранения имени автора и названия книги
            Test007();  // Создание экземпляра по слабой ссылке (weak reference) Анонимные объекты и анонимные типы
            Test008();  // Передача переменного количества аргументов в метод с помощью ключевого слова params  и параметры по умолчанию для первых двух аргументов
            Test009();  // Способы передачи аргументов в методы: по значению in, по ссылке (ref),
                        // с помощью указателя (unsafe) и с помощью ключевого слова out для возвращаемых значений
            Test010();  // Пример обработки исключения при рекурсии try-catch
            Test011();  // Пример реализации Palindrome метода для проверки, является ли строка палиндромом
                        // Когда строка читается одинаково в обоих направлениях, например "level" или "madam".
                        // Метод должен игнорировать пробелы и регистр букв.
            Test012();  // Пример преобразования массива без дубликатов
            Test013();  // Наследование и полиморфизм интерфейсов и классов
            Test014();  // Интерфейсы
            Test015();  // Абстрактные классы и методы
            Test016();  // Перегрузка операторов
                        // Пример неявного (implicit) преобразования типов (неявная конверсия)
                        // Пример явного (explicit) преобразования типов (явная конверсия)
            Test017();  // Индексаторы
            Test018();  // Обобщенные типы
            Test019();  // Работа с потоками сериализация и десериализация объектов
            Thread.Sleep(1000); // Задержка для завершения асинхронной операции в Test019, так как метод Test019 объявлен с async void, что не рекомендуется для методов, которые не являются обработчиками событий, так как это может привести к непредсказуемому поведению и затруднить отладку.
                                // В данном случае, задержка позволяет увидеть результат асинхронной операции перед завершением приложения.
            Test020();  // Работа с символами и строками
            Test021();  // Коллекции
            Test022();  // Использование LINQ
            Test100();  // Task без async/await
        }


        // Просто класс 1
        private static void Test001()
        {
            Butterfly mahaon = new()
            {
                Name = "Admiral"
            };
            Console.WriteLine($"Hello, World! From Test001 -  {mahaon.Name}");
            mahaon.Fly();
            Console.WriteLine(new string('-', 100));
        }

        // Просто класс 2
        private static void Test002()
        {
            MyClass instance = new()
            {
                field = "Hello world! From Test002"
            };
            Console.WriteLine(instance.field);
            instance.Method();
            Console.WriteLine(new string('-', 100));
        }

        // Пример использования get и set
        private static void Test003()
        {
            MyClass001 instance = new()
            {
                Field = "Hello world! From Test003"
            };
            Console.WriteLine(instance.Field);
            Console.WriteLine(new string('-', 100));
        }

        // Пример использования конструктора для инициализации поля и конструктора по умолчанию
        // При создании пользовательского конструктора, конструктор по умолчанию не создается компилятором,
        // его нужно создавать вручную, если он необходим
        private static void Test004()
        {
            // Применяем конструктор по умолчанию
            Console.WriteLine("Hello, World! From Test004");
            Point pointA = new();
            Console.WriteLine("pointA.X = {0}, pointA.Y = {1}", pointA.X, pointA.Y);
            Console.WriteLine(new string('-', 50));

            // Применяем конструктор для инициализации полей (с параметрами)
            Point pointB = new(100, 200);
            Console.WriteLine("pointB.X = {0}, pointB.Y = {1}", pointB.X, pointB.Y);
            Console.WriteLine(new string('-', 50));

            Point pointC = new("pointC");
            Console.WriteLine("{0}.X = {1}, {0}.Y = {2}", pointC.Name, pointC.X, pointC.Y);
            Console.WriteLine(new string('-', 50));

            Point pointD = new(100, 200, "pointD");
            Console.WriteLine("{0}.X = {1}, {0}.Y = {2}", pointD.Name, pointD.X, pointD.Y);
            Console.WriteLine(new string('-', 100));

        }

        // Передача экземпляра класса в качестве аргумента метода
        private static void Test005()
        {
            MyClass003 my = new();
            MyClass004 my2 = new();

            Console.WriteLine("Hello, World! From Test005");
            my2.CallMethod(my);
            Console.WriteLine(new string('-', 100));
        }

        // Автоматически реализуемые свойства для хранения имени автора и названия книги
        private static void Test006()
        {
            Author author1 = new()
            {
                Name = "John Doe",
                Book = "C# Programming"
            };
            Author author2 = new Author
            {
                Name = "Jane Smith",
                Book = "Learning C#"
            };
            Console.WriteLine("Hello, World! From Test006");
            Console.WriteLine($"Author: {author1.Name}, Book: {author1.Book}");
            Console.WriteLine($"Author: {author2.Name}, Book: {author2.Book}");
            Console.WriteLine(new string('-', 100));
        }

        // Создание экземпляра по слабой ссылке (weak reference) Анонимные объекты и анонимные типы
        private static void Test007()
        {
            Console.WriteLine("Hello, World! From Test007");
            new MyClass003().Method();
            Console.WriteLine(new string('-', 100));
        }

        // Передача переменного количества аргументов в метод с помощью ключевого слова params и параметры по умолчанию для первых двух аргументов
        private static void SendParams(int a = 1, int b = 2, params double[] c)
        {

            Console.WriteLine(a + b);
            foreach (var i in c)
            {
                Console.WriteLine(i);
            }
        }

        // Передача переменного количества аргументов в метод с помощью ключевого слова params
        private static void Test008()
        {
            Console.WriteLine("Hello, World! From Test008");
            SendParams(2, 3, 3.14, 2.71, 1.41);
            // Вызов с указанием имени параметра
            SendParams(b: 5);
            Console.WriteLine(new string('-', 100));
        }


        // Способы передачи аргументов в методы: по значению in, по ссылке (ref)
        // и с помощью ключевого слова out для возвращаемых значений
        private static void Increment(in int x, int y, ref int z, out int a)
        {
            Console.WriteLine($"Received (in) parameter: {x}");
            Console.WriteLine($"Received (without in) parameter: {y}");
            Console.WriteLine($"Received (ref) parameter: {z}");
            // Console.WriteLine($"Received (out) parameter: {a}"); // Значение out-параметра не инициализировано при входе в метод, его нужно присвоить внутри метода
            //x++; // Ошибка компиляции: нельзя изменять значение in-параметра
            // y++;   // Изменение значения обычного параметра не влияет на аргумент, переданный в метод
            z++;
            a = 11;
        }

        // Способы передачи аргументов в методы с помощью указателя (unsafe)
        unsafe private static void Increment1(int* number)
        {
            (*number)++;
        }

        // Способы передачи аргументов в методы: по значению in, по ссылке (ref),
        // с помощью указателя (unsafe) и с помощью ключевого слова out для возвращаемых значений
        private static void Test009()
        {
            int par = 9;
            int par2 = 5;

            Console.WriteLine("Hello, World! From Test009");
            Increment(10, par, ref par2, out int par3);
            Console.WriteLine(par);
            Console.WriteLine(par2);
            Console.WriteLine(par3);

            par = 5;

            unsafe
            {
                Increment1(&par);
            }

            Console.WriteLine(par); // 6
            Console.WriteLine(new string('-', 100));
        }

        // Пример обработки исключения (StackOverflowException) при рекурсии try-catch
        private static int F(int n)
        {
            // генерация собственного исключения
            if (n < 0)
            {
                //throw new ArgumentException("Аргумент не может быть отрицательным", nameof(n));
                //throw new Exception();
                throw new MyOwnException();
            }

            checked // Включаем проверку на переполнение для целочисленных операций,
                    // чтобы при достижении максимального значения int выбрасывалось исключение OverflowException
            {
                if (n == 1)
                    return 1;
                return n * F(n - 1);
            }
        }

        // Пример обработки исключения (StackOverflowException) при рекурсии try-catch
        private static void Test010()
        {
            Console.WriteLine("Hello, World! From Test010");

            try
            {
                int i = F(0);
                Console.WriteLine(i);
            }
            //catch (Exception ex)  // Это неправильный способ обработки исключения, так как StackOverflowException не может
            //быть пойман и обработан, он приведет к аварийному завершению приложения. Но для демонстрации
            //обработки исключения при переполнениицелочисленных операций можно использовать OverflowException.
            catch (OverflowException ex)
            {
                Console.WriteLine("Произошло переполнение при вычислении факториала: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Неверный аргумент: " + ex.Message);
            }
            catch (MyOwnException ex)
            {
                Console.WriteLine("Произошло собственное исключение: " + ex.Message);
            }
            // Всегда рекомендуется обрабатывать более специфичные исключения (например, OverflowException и ArgumentException)
            // до более общих (например, Exception), чтобы не перехватывать исключения, которые не предназначены для обработки
            // в данном блоке catch.
            catch (Exception ex)
            {
                Console.WriteLine("Произошло исключение: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполняется всегда, независимо от того, было ли исключение или нет.");
            }

            Console.WriteLine(new string('-', 100));
        }

        // Пример реализации Palindrome метода для проверки, является ли строка палиндромом
        // Когда строка читается одинаково в обоих направлениях, например "level" или "madam".
        // Метод должен игнорировать пробелы и регистр букв.
        private static void Test011()
        {
            string text = "A man a plan a canal Panama";


            Console.WriteLine("Hello, World! From Test011");
            if (IsPalindrome(text))
            {
                Console.WriteLine($"\"{text}\" is Palindrome");
            }
            else
            {
                Console.WriteLine($"\"{text}\" is not Palindrome");
            }
            Console.WriteLine(new string('-', 100));
        }

        // Пример реализации Palindrome метода для проверки, является ли строка палиндромом
        // Когда строка читается одинаково в обоих направлениях, например "level" или "madam".
        // Метод должен игнорировать пробелы и регистр букв.
        public static bool IsPalindrome(string text)
        {
            StringBuilder sb1 = new();
            StringBuilder sb2 = new();


            sb1.Append(text.ToUpper());
            sb1.Replace(" ", "");
            for (int i = sb1.Length - 1; i >= 0; i--)
            {
                sb2.Append(sb1[i]);
            }
            return sb1.ToString() == sb2.ToString();
        }

        // Пример преобразования массива без дубликатов
        private static void Test012()
        {
            int[] i = [1, 2, 2, 3, 1];

            Console.WriteLine("Hello, World! From Test012");
            Console.WriteLine("Original array: " + string.Join(", ", i));
            Console.WriteLine("Array without duplicates: " + string.Join(", ", RemoveDuplicates(i)));
            Console.WriteLine(new string('-', 100));
        }

        // Пример преобразования массива без дубликатов
        public static int[] RemoveDuplicates(int[] numbers)
        {
            // Это лаконично но без контроля над порядком элементов, так как Distinct()
            // не гарантирует сохранение порядка
            // в старых версиях C#. В C# 14.0 и выше Distinct() сохраняет порядок,
            // так что этот способ будет работать, если проект настроен на использование C# 14.0 или выше.
            // Distinct() — убирает дубликаты
            // [.....] — это collection expression(C# 12), превращает в массив
            //return [.. numbers.Distinct()];

            var set = new HashSet<int>();
            var result = new List<int>();

            foreach (var n in numbers)
            {
                if (set.Add(n))
                {
                    result.Add(n);
                }
            }

            return result.ToArray();
        }

        // Наследование и полиморфизм интерфейсов и классов-
        // Пример использования базового класса Animal и производного класса Dog, который переопределяет метод
        // MakeSound()
        private static void Test013()
        {
            Animal animal = new("Noname");
            Animal animal2 = new Dog("Baron");
            IDisposable disposable = new Dog("Rex");
            IComparable comparable = new Dog("Charlie");

            Console.WriteLine("Hello, World! From Test013");
            Console.WriteLine(animal2.GetName());
            animal.MakeSound();
            animal2.MakeSound();
            disposable.Dispose();

            try
            {
                comparable.CompareTo(new Dog("Buddy"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошло исключение при сравнении: " + ex.Message);
            }

            Console.WriteLine(new string('-', 100));
        }

        // Интерфейсы
        private static void Test014()
        {
            IAnimal animal = new Cat("Bars");
            // Это невозможно, так как интерфейсы не могут быть инстанцированы напрямую,
            // они должны быть реализованы классами.
            // IAnimal animal2 = new IAnimal()
            
            Console.WriteLine("Hello, World! From Test014");
            Console.WriteLine($"Cats name - {animal.GetName()}");
            Console.WriteLine($"Cat has {animal.GetLegs()} legs");
            animal.MakeSound();
            Console.WriteLine(new string('-', 100));
        }

        // Абстрактные классы и методы
        private static void Test015()
        {
            // Нельзя создать экземпляр абстрактного класса, так как он предназначен для
            // наследования и не может быть инстанцирован напрямую.
            //AbstractAnimal animal = new();
            NonAbstractAnimal animal = new();
            
            Console.WriteLine("Hello, World! From Test015");
            Console.WriteLine($"Animal has {animal.GetLegs()} legs");
            animal.MakeSound();
            animal.MakeSound1();
            Console.WriteLine(new string('-', 100));
        }

        // Перегрузка операторов
        private static void Test016()
        {
            SuperInt s = new(5);
            SuperInt s1 = new(10);
            MyNumber number = new(15);
            MyNumber number2 = new(20);
            MyNumber number3;

            // Пример неявного (implicit) преобразования типов (неявная конверсия)
            SuperInt d = 6; // Компилятор автоматически преобразует int в SuperInt с помощью неявного оператора преобразования,
                            // который должен быть определен в классе SuperInt

            // Пример явного (explicit) преобразования типов (явная конверсия)
            int n = (int)s; // Компилятор требует явного указания преобразования,
                            // так как может потеряться информация при преобразовании SuperInt в int

            Console.WriteLine("Hello, World! From Test016");
            SuperInt res = s.Add(s1);
            Console.WriteLine($"Работает метод Add {s.N} + {s1.N} = {res.N}");
            number3 = number + number2;
            Console.WriteLine($"Работает перегрузка оператора (+) {number.Value} + {number2.Value} = {number3.Value}");
            Console.WriteLine(new string('-', 100));
        }

        // Индексаторы
        private static void Test017()
        {
            Mylist list = new();
            // Заполнение списка
            for (int i = 0; i < 5; i++)
            {
                list[i] = i + 1; // Используем индексатор для добавления элементов в список
            }
            Console.WriteLine("Hello, World! From Test017");
            Console.WriteLine($"Third elements in Mylist: {list[2]}");
            Console.WriteLine(new string('-', 100));
        }

        // Обобщенные типы
        private static void Test018()
        {
            Console.WriteLine("Hello, World! From Test018");

            Tree<int> t1 = new Tree<int>();
            Tree<double> t2 = new Tree<double>();

            // Пример List<T> - обобщенного типа из стандартной библиотеки .NET
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();

            Console.WriteLine(new string('-', 100));
        }

        // Работа с потоками сериализация и десериализация объектов
        private async static void Test019()
        {
            Console.WriteLine("Hello, World! From Test019");

            WebClient web = new();
            // Скачиваем строку с RSS-каналом новостей с сайта censor.net
            //string s = await web.DownloadStringTaskAsync(new Uri("https://assets.censor.net/rss/censor.net/rss_uk_news.xml", UriKind.Absolute));
            // Скачиваем строку с локального файла
            //string s = await web.DownloadStringTaskAsync(new Uri("file:///D:/Project/rss_uk_news.xml", UriKind.Absolute));
            // или читаем строку из локального файла так          
            string s = await File.ReadAllTextAsync("D:/Project/Learning C#/rss_uk_news.xml"); 

            XmlSerializer xml = new(typeof(RssClass));
            RssClass? res = xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s))) as RssClass;

            res.Channel?.Items?.ForEach(item =>
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Link: {item.Link}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"PubDate: {item.PubDate}");
                Console.WriteLine(new string('-', 50));
            });

            Console.WriteLine(new string('-', 100));
        }

        // Работа с символами и строками
        private static void Test020()
        {
            Console.WriteLine("Hello, World! From Test020");

            // u(unsigned) означает, что символ задается в виде Unicode-экранированной последовательности,
            // а 0809 - это шестнадцатеричный код символа в стандарте Unicode. В данном случае,
            // \u0809 соответствует символу "SAMARITAN MARK SEPARATOR" (U+0809) из блока "Samaritan" в стандарте Unicode.
            char c = '\u0809';
            Console.WriteLine($"Символ: {c}");
            // s и s1 ссылаются на одну и ту же строку в пуле строк, так как строки являются неизменяемыми
            // и компилятор оптимизирует их хранение, помещая одинаковые строковые литералы
            // в пул строк для экономии памяти.
            string s = "Hello";
            string s1 = "Hello";
            Console.WriteLine(string.ReferenceEquals(s,s1));    // True, так как s и s1 ссылаются на одну и ту 
                                                                // же строку в пуле строк       
            s1.Replace('e', 'y');
            // s1 не изменится, так как строки являются неизменяемыми,
            // метод Replace возвращает новую строку с заменой, но не изменяет исходную строку s1.
            Console.WriteLine(s1); // Вывод: Hello, так как s1 не изменился после вызова Replace

            // Если мы хотим изменить строку, то нужно присвоить
            // результат метода Replace обратно переменной s1
            s1 = s1.Replace('e', 'y');
            Console.WriteLine(s1); // Вывод: Hyllo, так как s1 теперь ссылается на новую строку,
                                   // которая была возвращена методом Replace после замены 'e' на 'y'

            // Символ @ позволяет использовать строковые литералы в виде verbatim string literals,
            // которые сохраняют все символы, включая обратные слэши, без необходимости экранирования.
            Console.WriteLine("D:\\Project\\Learning C#\\rss_uk_news.xml");
            Console.WriteLine(@"D:\Project\Learning C#\rss_uk_news.xml");

            // StringBuilder используется для создания и изменения строк без создания новых объектов строк,
            // что может быть более эффективным при выполнении большого количества операций со строками,
            // таких как конкатенация или замена символов.
            // Любые операции, которые изменяют строку, будут выполняться на одном и том же объекте StringBuilder,
            // В отличие от строк операции со StringBuilder не создают новые объекты, а изменяют существующий
            StringBuilder sb = new("Hello");
            Console.WriteLine($"From StringBuilder {sb}"); // Вывод: Hello
            sb.Replace('e', 'y');
            // Символ $ позволяет использовать строковые литералы в виде interpolated string literals,
            // которые позволяют вставлять выражения внутри строковых литералов, заключая их в фигурные скобки {}.
            // В данном случае, {sb} будет заменено на значение переменной sb при выводе строки.
            Console.WriteLine($"From StringBuilder {sb}"); // Вывод: Hyllo, так как метод Replace изменяет существующий объект StringBuilder,
                                                           // а не создает новый объект, как это происходит с обычными строками.

            // Пример безопасной строки для хранения пароля, которая очищается из памяти после использования
            // Такая строка создается в неуправляемой памяти и не может быть перемещена сборщиком мусора (GC),
            // что позволяет гарантировать, что она будет очищена из памяти после использования.
            // То есть такой объект нужно очищать вручную, вызывая метод Dispose()
            // или используя конструкцию using, чтобы гарантировать, что память будет освобождена
            // даже в случае возникновения исключения.
            SecureString securePassword = new();
            securePassword?.AppendChar('P');
            Console.WriteLine($"Secure password length: {securePassword.Length}");
            securePassword?.Dispose(); // Очищаем память, выделенную для securePassword

            // После вызова Dispose() объект securePassword становится недопустимым для использования,
            // так как его ресурсы были освобождены.
            // Поэтому, если попытаться обратиться к свойству Length после вызова Dispose(),
            // будет выброшено исключение ObjectDisposedException,
            //Console.WriteLine($"Secure password length: {securePassword.Length}");

            // Здесь securePassword2 будет автоматически очищен из памяти после выхода из блока using
            // даже если внутри блока произойдет исключение, так как конструкция using
            // гарантирует вызов метода Dispose() для объекта securePassword2 при выходе из блока.
            using (SecureString securePassword2 = new())
            {
                securePassword2.AppendChar('S');
                Console.WriteLine($"Secure password length: {securePassword2.Length}");
            } 

            Console.WriteLine(new string('-', 100));
        }

        // Коллекции
        private static void Test021()
        {
            Console.WriteLine("Hello, World! From Test021");
            // Пример старой коллекции ArrayList, которая может хранить объекты любого типа,
            // так как она не является обобщенной, но для доступа к элементам нужно выполнять приведение типов,
            // что может привести к ошибкам времени выполнения.
            // Приведение типов - это boxing и unboxing, которые могут негативно влиять на производительность,
            // так как требуют дополнительных операций для упаковки и распаковки значимых типов.
            // Также к старым типам коллекций относятся Hashtable, Stack и Queue
            // из пространства имен System.Collections.
            
            ArrayList list = [3, "Hello"]; // Вместо 3 строк ниже
            //ArrayList list = new();
            //list.Add(3);
            //list.Add("Hello");
            
            foreach (object obj in list)
            {
                Console.WriteLine(obj);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // Новые коллекции из пространства имен System.Collections.Generic используют обобщенные типы,
            // которые обеспечивают безопасность типов на этапе компиляции,
            // такие как List<T>, LinkedList<T>, Dictionary<TKey, TValue>, SortedDictionary<TKey, TValue>,
            // Stack<T> и Queue<T>
            // HashSet<T> и SortedSet<T>. Они позволяют хранить
            // элементы определенного типа без необходимости приведения типов,
            // HashSet<T> и SortedSet<T> - это коллекции, которые хранят уникальные элементы и обеспечивают
            // высокую производительность при операциях добавления, удаления и поиска элементов.
            // HashSet<T> не гарантирует порядок элементов, а SortedSet<T> хранит элементы в отсортированном
            // порядке.
            // Список всех коллекций из пространства имен System.Collections.Generic
            // можно найти в официальной документации Microsoft по ссылке:
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-10.0

            List<int> list1 = [3, 5]; // Вместо 3 строк ниже

            //List<int> list1 = new();
            //list1.Add(3);
            //list1.Add(5);

            foreach (int item in list1) 
            { 
                Console.WriteLine(item);
            }

            SortedDictionary<int,string> SrtDic= new SortedDictionary<int, string>
            {
                { 2, "Two" },
                { 1, "One" }
            }; // Вместо 3 строк ниже

            //SortedDictionary<int, string> SrtDic = new SortedDictionary<int, string>();
            //SrtDic.Add(2, "Two");
            //SrtDic.Add(1, "One");

            Console.WriteLine($"Value with key 1 in SortedDictionary: {SrtDic[1]}");
            Console.WriteLine($"Value with key 2 in SortedDictionary: {SrtDic[2]}");

            // Безопасность коллекций в многопоточном окружении
            // обеспечивается с помощью классов из пространства имен System.Collections.Concurrent,
            // таких как ConcurrentDictionary<TKey, TValue>, ConcurrentQueue<T>, ConcurrentBag<T>
            // ConcurrentStack<T> и BlockingCollection<T>.
            ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();

            Parallel.For(0, 100, i =>
            {
                dict.TryAdd(i, $"Value {i}");
            });

            Console.WriteLine($"размер словаря: {dict.Count}");
            
            Console.WriteLine(new string('-', 100));
        }

        // Использование LINQ
        // LINQ (Language Integrated Query) - это мощный инструмент для работы с коллекциями данных,
        // который позволяет выполнять запросы к данным в стиле SQL прямо в коде C#.
        // Он обеспечивает удобный синтаксис для фильтрации, сортировки, группировки и проекции данных
        // из различных источников, таких как массивы, списки, базы данных и XML-документы.
        // Примеры методов расширения LINQ включают Where, Select, OrderBy, GroupBy, Join и многие другие,
        // которые позволяют легко и эффективно обрабатывать данные в коллекциях.
        private static void Test022()
        {
            Console.WriteLine("Hello, World! From Test022");

            // Пример создания расширения для существующего класса string
            string s = "Hello World !";
            Console.WriteLine($"Original string: {s}");

            // Вазывается статический метод расширения ToUpperCase, который определен в классе
            // StringExtensions и принимает строку в качестве аргумента,
            // и возвращает новую строку, которая является верхним регистром исходной строки.
            Console.WriteLine($"Uppercase string: {StringExtensions.ToUpperCase(s)}");
            // Вазывается статический метод расширения RemoveSpaces, который определен в классе
            // StringExtensions и принимает строку в качестве аргумента, и возвращает новую строку,
            // которая является исходной строкой без пробелов.
            Console.WriteLine($"String without spaces: {StringExtensions.RemoveSpaces(s)}");

            // Цепочка вызовов методов расширения для преобразования строки в верхний регистр и
            // удаления пробелов
            Console.WriteLine($"Uppercase string without spaces: {s.ToUpperCase().RemoveSpaces()}");

            // Пример создания анонимного типа для хранения данных о человеке,
            // который не требует создания отдельного класса для представления этих данных.
            // При этом автоматически создается класс с именем,
            // сгенерированным компилятором, который содержит свойства Name и Street,
            // и эти свойства доступны только для чтения, так как анонимные типы являются неизменяемыми.
            var p1 = new { Name = "John Doe", Street = "123 Main St" };

            List<Person> p = new();
            // Пример инициализации свойств класса Person с помощью инициализатора объектов (object initializer),
            // который позволяет создавать объекты и задавать значения их свойств в одной конструкции.
            p.Add(new Person() { FirstName = "John", LastName = "Doe", Age = 30, Address = "123 Main St" });
            p.Add(new Person() { FirstName = "Jane", LastName = "Smith", Age = 25, Address = "456 Elm St" });
            p.Add(new Person() { FirstName = "Bob", LastName = "Johnson", Age = 40, Address = "789 Oak St" });
            p.Add(new Person() { FirstName = "Alice", LastName = "Williams", Age = 35, Address = "321 Pine" });

            // Пример использования старого метода поиска элементов в коллекции с помощью цикла foreach,
            // который требует явного перебора всех элементов и проверки условия внутри цикла.
            List<Person> selected = new();

            // var person - это переменная цикла, которая последовательно принимает значение каждого элемента
            // из коллекции p при каждой итерации цикла foreach. Тип переменной person определяется
            // автоматически компилятором на основе типа элементов в коллекции p, который является
            // List<Person>, поэтому person будет иметь тип Person.
            foreach (var person in p)
            {
                if (person.Age > 30)
                {
                    selected.Add(person);
                    Console.WriteLine($"Person older than 30: {person.FirstName} {person.LastName}");
                }
            }
            Console.WriteLine(selected.Count); // Вывод: 2, так как в списке selected будут
                                               // добавлены только те объекты Person,
                                               // у которых возраст больше 30 (Bob Johnson и Alice Williams)

            // LINQ-запрос для получения тех же результатов, что и в цикле foreach,
            // но с более удобным синтаксисом и
            // без необходимости явного перебора всех элементов и проверки условия внутри цикла.
            Console.WriteLine("Using LINQ:");
            // => - это лямбда-выражение, которое представляет собой анонимный метод,
            // которая может быть передана в качестве аргумента метода расширения Where.
            // => — "стрелка", читается как "возвращает"
            /*
            person => person.Age > 30 
            можно записать в виде отдельного метода, 
            который будет выполнять ту же функцию, что и лямбда-выражение,
            bool IsOlderThan30(Person person)
            {
                return person.Age > 30;
            }
            */

            p.Where(person => person.Age > 30)
             .ToList()
             .ForEach(person => Console.WriteLine($"Person older than 30: {person.FirstName} {person.LastName}"));

            var list = p.Where(it => it.Age > 30).Select(item => item);
            // или так, используя метод расширения Select для проекции данных в новый анонимный тип,
            // который содержит только имя человека, составленное из его имени и фамилии.
            var list1 = p.Where(it => it.Age > 30).Select(item => 
            new {Name=String.Format("{0} {1}", item.FirstName, item.LastName), AgeAge=item.Age });
            foreach (var item in list)
            {
                Console.WriteLine($"Person older than 30: {item}");
            }

            foreach (var item in list1)
            {
                Console.WriteLine($"Person older than 30: {item.Name}  {item.AgeAge}");
            }

            // или так
            var list2 = 
                from item in p
                where item.Age > 30
                select new { Name = String.Format("{0} {1}", item.FirstName, item.LastName), AgeAge = item.Age };
            
            foreach (var item in list2)
            {
                Console.WriteLine($"Person older than 30: {item.Name}  {item.AgeAge}");
            }

            // или так
            var list3 = 
                from item in p
                where item.Age > 30
                select item;
            
            foreach (var item in list3)
            {
                Console.WriteLine($"Person older than 30: {item}");
            }

            Console.WriteLine(new string('-', 100));
        }
        
        // Task без async/await
        private static void Test100()
        {
            Console.WriteLine("Hello, World! From Test100");
            Task task = new(() =>
            {
                for (int i = 0; i < 1000; i++)
                    Console.WriteLine($"Работа выполняется {i}");
            });
            task.Start();
            for (int i = 0; i < 10; i++)
                Console.WriteLine(StrExpls.DoSmth());
            //task.Wait();
            Console.WriteLine(new string('-', 100));
        }
    }
}

