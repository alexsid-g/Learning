
public class Module3_1
{
    public class Person
    {
        public string Name {get;set;}
        public int Age {get; set;}
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public void Greet()
        {
            Console.WriteLine("Hey, I'm " + Name);
        }
    }

    public static void Main()
    {
        var p1 = new Person("Bob", 10);
        var p2 = new Person("Marley", 22);
        p1.Greet();
        p2.Greet();

        var newPerson = new Person("New Person", 25);
        newPerson.Greet();
    }

}
