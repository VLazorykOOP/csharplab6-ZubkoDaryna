using System;
using System.Collections;

public interface IUserInterface
{
    void DisplayUserInterface();
}

public interface IDotNetInterface
{
    void DisplayDotNetInfo();
}

public abstract class Organization : IUserInterface, IDotNetInterface
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Organization(string name, string address)
    {
        Name = name;
        Address = address;
        Console.WriteLine($"Конструктор базового класу Organization для {Name}");
    }

    public Organization()
    {
        Name = "Невідома організація";
        Address = "Невідома адреса";
        Console.WriteLine($"Конструктор базового класу Organization для {Name}");
    }

    public Organization(string name)
    {
        Name = name;
        Address = "Невідома адреса";
        Console.WriteLine($"Конструктор базового класу Organization для {Name}");
    }

    ~Organization()
    {
        Console.WriteLine($"Деструктор базового класу Organization для {Name}");
    }
    
    public virtual void Show()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Адреса: {Address}");
    }

    public void DisplayUserInterface()
    {
        Console.WriteLine($"Відображення користувацького інтерфейсу для {Name}");
    }
  
    public void DisplayDotNetInfo()
    {
        Console.WriteLine($"Відображення інформації про .NET для {Name}");
    }
}

public class InsuranceCompany : Organization
{
    public string InsuranceType { get; set; }

    public InsuranceCompany(string name, string address, string insuranceType)
        : base(name, address)
    {
        InsuranceType = insuranceType;
        Console.WriteLine($"Конструктор класу InsuranceCompany для {Name}");
    }

    public InsuranceCompany()
        : base()
    {
        InsuranceType = "Невідомий тип страхування";
        Console.WriteLine($"Конструктор класу InsuranceCompany для {Name}");
    }

    public InsuranceCompany(string name)
        : base(name)
    {
        InsuranceType = "Невідомий тип страхування";
        Console.WriteLine($"Конструктор класу InsuranceCompany для {Name}");
    }

    ~InsuranceCompany()
    {
        Console.WriteLine($"Деструктор класу InsuranceCompany для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип страхування: {InsuranceType}");
    }
}

public class OilGasCompany : Organization
{
    public string OilGasType { get; set; }

    public OilGasCompany(string name, string address, string oilGasType)
        : base(name, address)
    {
        OilGasType = oilGasType;
        Console.WriteLine($"Конструктор класу OilGasCompany для {Name}");
    }

    public OilGasCompany()
        : base()
    {
        OilGasType = "Невідомий тип нафти/газу";
        Console.WriteLine($"Конструктор класу OilGasCompany для {Name}");
    }

    public OilGasCompany(string name)
        : base(name)
    {
        OilGasType = "Невідомий тип нафти/газу";
        Console.WriteLine($"Конструктор класу OilGasCompany для {Name}");
    }

    ~OilGasCompany()
    {
        Console.WriteLine($"Деструктор класу OilGasCompany для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип нафти/газу: {OilGasType}");
    }
}

public class Factory : Organization
{
    public string ProductionType { get; set; }

    public Factory(string name, string address, string productionType)
        : base(name, address)
    {
        ProductionType = productionType;
        Console.WriteLine($"Конструктор класу Factory для {Name}");
    }

    public Factory()
        : base()
    {
        ProductionType = "Невідомий тип виробництва";
        Console.WriteLine($"Конструктор класу Factory для {Name}");
    }

    public Factory(string name)
        : base(name)
    {
        ProductionType = "Невідомий тип виробництва";
        Console.WriteLine($"Конструктор класу Factory для {Name}");
    }

    ~Factory()
    {
        Console.WriteLine($"Деструктор класу Factory для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип виробництва: {ProductionType}");
    }
}
//  Task 2

public abstract class Persona : IEnumerable
{
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Persona(string lastName, DateTime dateOfBirth)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }
    
    public int CalculateAge()
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - DateOfBirth.Year;
        if (currentDate < DateOfBirth.AddYears(age)) age--;
        return age;
    }

    public abstract void ShowInfo();
   
    public IEnumerator GetEnumerator()
    {
        yield return LastName;
    }
}

public class Applicant : Persona, IDotNetInterface
{
    public string Faculty { get; set; }

    public Applicant(string lastName, DateTime dateOfBirth, string faculty)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Абiтурiєнт: {LastName}");
        Console.WriteLine($"Дата народження: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Факультет: {Faculty}");
        Console.WriteLine($"Вiк: {CalculateAge()} рокiв");
    }
    
    public void DisplayDotNetInfo()
    {
        Console.WriteLine($"Відображення інформації про .NET для {LastName}");
    }
}

public class Student : Persona, IDotNetInterface
{
    public string Faculty { get; set; }
    public int Course { get; set; }

    public Student(string lastName, DateTime dateOfBirth, string faculty, int course)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Course = course;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Студент: {LastName}");
        Console.WriteLine($"Дата народження: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Факультет: {Faculty}");
        Console.WriteLine($"Курс: {Course}");
        Console.WriteLine($"Вiк: {CalculateAge()} рокiв");
    }

    public void DisplayDotNetInfo()
    {
        Console.WriteLine($"Відображення інформації про .NET для {LastName}");
    }
}

public class Teacher : Persona, IDotNetInterface
{
    public string Faculty { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }

    public Teacher(string lastName, DateTime dateOfBirth, string faculty, string position, int experience)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Position = position;
        Experience = experience;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Викладач: {LastName}");
        Console.WriteLine($"Дата народження: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Факультет: {Faculty}");
        Console.WriteLine($"Посада: {Position}");
        Console.WriteLine($"Стаж: {Experience} рокiв");
        Console.WriteLine($"Вiк: {CalculateAge()} рокiв");
    }

    public void DisplayDotNetInfo()
    {
        Console.WriteLine($"Відображення інформації про .NET для {LastName}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Task 1");
        Console.WriteLine("2. Task 2");
        Console.WriteLine("3. Task 3");
        Console.WriteLine("Exit");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Демонстрацiя роботи класiв:");

              
                InsuranceCompany insuranceCompany = new InsuranceCompany("Страхова компанiя 1", "Адреса 1", "Автострахування");
                insuranceCompany.Show();
                insuranceCompany.DisplayUserInterface();
                insuranceCompany.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");

               
                OilGasCompany oilGasCompany = new OilGasCompany("Нафтогазова компанiя 1", "Адреса 2", "Нафта");
                oilGasCompany.Show();
                oilGasCompany.DisplayUserInterface();
                oilGasCompany.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");

                
                Factory factory = new Factory("Фабрика 1", "Адреса 3", "Текстиль");
                factory.Show();
                factory.DisplayUserInterface();
                factory.DisplayDotNetInfo();

                Console.ReadLine();
                break;
            case "2":
                Console.WriteLine("Демонстрацiя роботи класiв:");


                Applicant applicant = new Applicant("Iванов", new DateTime(2000, 1, 15), "Факультет програмування");
                applicant.ShowInfo();
                applicant.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");

               
                Student student = new Student("Петров", new DateTime(1999, 5, 20), "Факультет економiки", 3);
                student.ShowInfo();
                student.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");


                Teacher teacher = new Teacher("Сидоров", new DateTime(1985, 10, 10), "Факультет математики", "Доцент", 10);
                teacher.ShowInfo();
                teacher.DisplayDotNetInfo();

                Console.ReadLine();
                break;
            case "3":

                Console.WriteLine("Демонстрацiя роботи класiв:");

               
                Applicant applicant1 = new Applicant("Iванов", new DateTime(2000, 1, 15), "Факультет програмування");

                
                foreach (var item in applicant1)
                {
                    Console.WriteLine(item);
                }

                applicant1.ShowInfo();
                applicant1.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");

                
                Student student1 = new Student("Петров", new DateTime(1999, 5, 20), "Факультет економiки", 3);

                
                foreach (var item in student1)
                {
                    Console.WriteLine(item);
                }

                student1.ShowInfo();
                student1.DisplayDotNetInfo();

                Console.WriteLine("-------------------------------------");

                
                Teacher teacher1 = new Teacher("Сидоров", new DateTime(1985, 10, 10), "Факультет математики", "Доцент", 10);

                
                foreach (var item in teacher1)
                {
                    Console.WriteLine(item);
                }

                teacher1.ShowInfo();
                teacher1.DisplayDotNetInfo();

                Console.ReadLine();

                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }

    }
}