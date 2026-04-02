using System.Text;
using System.Xml.Serialization;

namespace Learning
{

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

    // Наследование и полиморфизм интерфейсов и классов
    class Animal
    {
        readonly string name;

        public Animal(string n)
        {
            name = n;
        }

        public string GetName()
        {
            return name;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // Ключевое слово sealed означает, что от класса Dog нельзя наследоваться дальше.
    // Может быть наследован только от одного класса, в данном случае от класса Animal,
    // и может реализовывать несколько интерфейсов (ICloneable, IComparable, IDisposable).
    sealed class Dog : Animal, ICloneable, IComparable, IDisposable
    {
        // Конструктор класса Dog, который вызывает конструктор базового
        // класса (:base) Animal для инициализации имени
        public Dog(string name) : base(name)
        {

        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing Dog resources...");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    // Класс SmallDog пытается наследоваться от класса Dog,
    // но это невозможно, так как класс Dog объявлен как sealed (запечатанный).
    /*
    class SmallDog : Dog
    {
     
    }
    */

    // Интерфейсы
    // Интерфейс IAnimal, который определяет контракт для классов, которые его реализуют.
    // Внутри интерфейса объявлены методы MakeSound(), GetLegs() и GetName(), которые должны быть реализованы
    // в классах, которые реализуют этот интерфейс.
    // Внутри только объявления методов, без реализации,
    // так как интерфейс не может содержать реализацию методов (до C# 8.0).
    interface IAnimal
    {
        void MakeSound();
        int GetLegs();
        string GetName();
    }

    class Cat : IAnimal
    {
        private readonly string name;
        public Cat(string name)
        {
            this.name = name;
        }
        public void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
        public int GetLegs()
        {
            return 4;
        }
        public string GetName()
        {
            return name;
        }
    }

    // Абстрактный класс Shape, который содержит абстрактный метод GetArea(),
    // который должен быть реализован в классах, которые наследуются от этого абстрактного класса.
    // Абстрактный класс не может быть инстанцирован напрямую, и может содержать 
    // как абстрактные методы (без реализации), так и обычные методы (с реализацией).
    abstract class AbstractAnimal
    {
        public abstract int GetLegs();
        public virtual void MakeSound()
        {
            Console.WriteLine("Sound from AbstractAnimal");
        }
    }
    class NonAbstractAnimal : AbstractAnimal
    {
        public override int GetLegs()
        {
            return 4;
        }
        public void MakeSound1()
        {
            Console.WriteLine("Sound from NonAbstractAnimal");
        }
    }

    // Перегрузка операторов
    class MyNumber
    {
        public int Value { get; set; }
        public MyNumber(int value)
        {
            Value = value;
        }
        // Перегрузка оператора +
        public static MyNumber operator +(MyNumber a, MyNumber b)
        // Можно также перегрузить оператор + для сложения MyNumber и int, например:
        //public static MyNumber operator +(MyNumber a, int b)   или
        //public static MyNumber operator +(int b, MyNumber a)
        {
            return new MyNumber(a.Value + b.Value);
        }
        // Перегрузка оператора -
        public static MyNumber operator -(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.Value - b.Value);
        }
        // Перегрузка оператора *
        public static MyNumber operator *(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.Value * b.Value);
        }
        // Перегрузка оператора /
        public static MyNumber operator /(MyNumber a, MyNumber b)
        {
            if (b.Value == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new MyNumber(a.Value / b.Value);
        }

        // Перегрузка оператора ++
        public static MyNumber operator ++(MyNumber a)
        {
            return new MyNumber(a.Value + 1);
        }
    }

    // Перегрузка операторов == != следкет также перегружать методы Equals() и GetHashCode(),
    // чтобы обеспечить согласованное поведение при сравнении объектов.
    // Операторы сравнения (<  >,  <=  >=,  == !=) должны быть перегружены вместе,
    // чтобы обеспечить согласованное поведение при сравнении объектов.
    class SuperInt
    {
        public int N { get; }

        public SuperInt(int n)
        {
            N = n;
        }

        public SuperInt Add(SuperInt other)
        {
            return new SuperInt(N + other.N);
        }


        public static bool operator ==(SuperInt a, SuperInt b)
        {
            return a.N == b.N;
        }
        public static bool operator !=(SuperInt a, SuperInt b)
        {
            return a.N != b.N;
        }
        public override bool Equals(object? obj)
        {
            if (obj is SuperInt other)
            {
                return N == other.N;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return N.GetHashCode();
        }

        // Пример неявного (implicit) преобразования типов (неявная конверсия)
        public static implicit operator SuperInt(int n)
        {
            return new SuperInt(n);
        }
        // Пример явного (explicit) преобразования типов (явная конверсия)
        public static explicit operator int(SuperInt superInt)
        {
            return superInt.N;
        }
    }

    // Индексаторы перегруженные в классе Mylist для доступа к элементам списка по индексу
    // Без заполнения списка данными - только пример синтаксиса индексатора,
    // который позволяет обращаться к элементам класса Mylist по индексу, как к массиву. 
    class Mylist
    {
        public int this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
                value = 0;
            }
        }

        Node root;

        public class Node
        {
            public int Data { get; set; }
            public required Node Next { get; set; }
        }
    }

    // Обобщенные типы (Generics) - позволяют создавать классы, методы, интерфейсы
    // и делегаты с параметрами типа,
    // что обеспечивает типобезопасность и повторное использование кода.
    // Обобщенные типы импользуются для создания коллекций, таких как List<T>, Dictionary<TKey, TValue> и т.д.
    interface INode<T>
    {
        T GetData();
    }
    // Сдесь <T> означает, что класс Tree и Node является обобщенным типом,
    // который может работать с любым типом данных,
    // и T будет заменен на конкретный тип данных при создании экземпляра класса Node.
    class Tree<T>
    {
        class Node<T> : INode<T>
        {
            T value;

            Node<T> left;
            Node<T> right;

            public T GetData()
            {
                return value;
            }
        }

        Node<T> root;

    }

    // Работа с потоками сериализация и десериализация объектов
    // Класс RssClass, который может быть сериализован в XML формат с помощью атрибута [XmlRoot].
    [XmlRoot(ElementName ="rss")]
    public class RssClass
    {
        [XmlElement(ElementName = "channel")]
        public ChannelClass? Channel { get; set; }
    }

    public class ChannelClass
    {
        [XmlElement(ElementName = "item")]
        public List<ItemClass>? Items { get; set; }
    }

    public  class ItemClass
    {
        [XmlElement(ElementName = "title")]
        public string? Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string? Link { get; set; }
        [XmlElement(ElementName = "description")]
        public string? Description { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string? PubDate { get; set; }
    }

    // Использование LINQ
    class Person
    { 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }

    }
    
    // Пример создания расширения для существующего класса string
    public static class StringExtensions
    {
        // Метод расширения для класса string, который возвращает строку в верхнем регистре
        // this string str - означает, что этот метод расширения будет применяться к объектам типа string,
        // и str будет представлять собой экземпляр строки, к которому применяется этот метод расширения.
        public static string ToUpperCase(this string str)
        {
            return str.ToUpper();
        }

        // Метод расширения для класса string, который удаляет все пробелы из строки
        public static string RemoveSpaces(this string str)
        {
            return str.Replace(" ", "");
        }
    }
}
