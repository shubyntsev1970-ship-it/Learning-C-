using System.Text;

namespace Learning
{

    // StringBuilder
    internal static class StrExpls

    {
        public static string DoSmth()
        {
            var sb = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }
    }

    // Просто класс 1
    class Butterfly
    {
        public string? Name { get; set; } // Знак вопроса означает, что переменная может быть null (nullable reference type)
        public void Fly()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Fly! {Name}");
        }
    }

    // Просто класс 2
    class MyClass
    {
        public string? field; // Знак вопроса означает, что переменная может быть null (nullable reference type)
        public void Method()
        {
            Console.WriteLine(field + " From Method()");
        }
    }

    /*  Старый стиль
    // Пример мспользования get и set
    class MyClass001
    {
        private string field = null;
        public string Field
        {
            get => field;
            set => field = value;
        }

    }

    */

    // Пример мспользования get и set (новый стиль, с C# 14.0)
    class MyClass001
    {
        public string? Field
        {
            get;
            set;
        }
         = null;
    }

    // Пример использования get и set еслм есть проверки
    class MyClass002
    {
        //private readonly string field = null; это уже не нужно, так как мы будем использовать свойство для доступа к полю
        public string Field
        {
            set
            {
                if (value == "Goodbye")
                    Console.WriteLine("Недопустимое значение");
                else
                    field = value;
            }
            get
            {
                if (field == null)
                    return "В поле field отсутствуют данные";
                else if (field == "hello world")
                    return field.ToUpper() + " !";
                else
                    return field;
            }
        }

    }

    // Пример использования конструктора для инициализации поля и конструктора по умолчанию
    // При создании пользовательского конструктора, конструктор по умолчанию не создается компилятором,
    // его нужно создавать вручную, если он необходим
    class Point
    {
        // Поля класса Point
        private readonly int x;
        private readonly int y;
        private readonly string? name;

        // Свойства для доступа к полям x и y
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

        public string? Name
        {
            get { return name; }
        }

        // Конструктор по умолчанию, который инициализирует поля x и y значениями по умолчанию (0)
        public Point()
        {
            Console.WriteLine("Конструктор по умолчанию вызван. Поля x и y инициализированы значениями по умолчанию (0).");
        }

        // Пользовательский конструктор, который позволяет инициализировать поля x и y заданными значениями (с двумя параметрами)
        public Point(int x, int y)
        {
            Console.WriteLine("Пользовательский конструктор с двумя параметрами вызван. Поля x и y инициализированы заданными значениями.");
            this.x = x;
            this.y = y;
        }

        // Использование ключевого слова this в пользовательском конструкторе приводит к вызову
        // конструктора с 2-мя параметрами
        public Point(string name) : this(300, 400)
        {
            Console.WriteLine("Пользовательский конструктор  с 1 параметром");
            this.name = name;
        }
        // Конструтор c 3 параметрами
        public Point(int x, int y, string name) : this(x, y)
        {
            Console.WriteLine("Пользовательский конструктор  с 3 параметрами");
            this.name = name;
        }
    }

    // Передача экземпляра класса в качестве аргумента метода
    class MyClass003
    {
        public void Method()
        {
            Console.WriteLine("Вызвын метод класса MyClass003");
        }
    }
    class MyClass004
    {
        public void CallMethod(MyClass003 my)
        {
            my.Method();
        }
    }
    class Author
    {
        // Автоматически реализуемые свойства для хранения имени автора и названия книги
        public string? Name { get; set; }
        public string? Book { get; set; }
    }

    // Мое собственное исключение, наследуемое от базового класса Exception
    public class MyOwnException : Exception
    {
        public MyOwnException()
            : base("Это мое собственное исключение!")
        {
        }

        public MyOwnException(string message)
            : base(message)
        {
        }

        public MyOwnException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
