namespace financas.Domain.Entities;

/// <summary>
/// Representa uma pessoa cadastrada no sistema.
/// Uma pessoa pode possuir uma ou mais transações financeiras.
/// </summary>
public class Person
{
    /// <summary>
    /// Identificador único da pessoa.
    /// O valor é gerado automaticamente na criação da entidade.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Nome da pessoa.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Idade da pessoa.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Coleção de transações associadas à pessoa.
    /// Representa o relacionamento de um-para-muitos entre
    /// <see cref="Person"/> e <see cref="Transaction"/>.
    /// </summary>
    public ICollection<Transaction> Transactions { get; set; } = [];

    /// <summary>
    /// Inicializa uma nova instância da entidade <see cref="Person"/>.
    /// </summary>
    /// <param name="name">Nome da pessoa.</param>
    /// <param name="age">Idade da pessoa.</param>
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}