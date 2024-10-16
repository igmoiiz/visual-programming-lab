using System;
namespace Task1
{
    enum Department { CS, IT, EE }

    class Person
    {
        public string Name;

        public Person() { }
        public Person(string name) { Name = name; }
    }

    class Student : Person
    {
        public string RegNo;
        public int Age;
        public Department Program;

        public Student() { }
        public Student(string name, string regNo, int age, Department program) : base(name)
        {
            RegNo = regNo;
            Age = age;
            Program = program;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Abdul Moaiz", "233507", 19, Department.CS);
            Student student2 = new Student("Ayyan bin Irfan", "233595", 18, Department.IT);

            Console.WriteLine(student1.Name);
            Console.WriteLine(student1.RegNo);
            Console.WriteLine(student1.Age);
            Console.WriteLine(student1.Program);

            Console.WriteLine();

            Console.WriteLine(student2.Name);
            Console.WriteLine(student2.RegNo);
            Console.WriteLine(student2.Age);
            Console.WriteLine(student2.Program);
        }
    }
}