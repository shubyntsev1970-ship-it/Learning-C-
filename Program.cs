using System;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Test013();  // Для использования в будущем GitHub

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
            y++;   // Изменение значения обычного параметра не влияет на аргумент, переданный в метод
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
            // Это лаконично но без контроля над порядком элементов, так как Distinct() не гарантирует сохранение порядка
            // в старых версиях C#. В C# 14.0 и выше Distinct() сохраняет порядок, так что этот способ будет работать, если проект настроен на использование C# 14.0 или выше.
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

        // Для использования в будущем
        private static void Test013()
        {
            Console.WriteLine("Hello, World! From Test013");
            Console.WriteLine(new string('-', 100));
        }

        // Task без async/await
        private static void Test100()
        {
            Task task = new(() =>
            {
                for (int i = 0; i < 1000; i++)
                    Console.WriteLine($"Работа выполняется {i}");
            });
            task.Start();
            Console.WriteLine("Hello, World! From Test100");
            for (int i = 0; i < 10; i++)
                Console.WriteLine(StrExpls.DoSmth());
            //task.Wait();
        }
    }
}

