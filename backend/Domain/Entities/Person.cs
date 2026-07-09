namespace financas.Domain.Entities;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = [];
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}