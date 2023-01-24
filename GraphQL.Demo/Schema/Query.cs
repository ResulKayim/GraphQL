
namespace GraphQLDemo.API.Schema;

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age{ get; set; }
}

public class Query
{


    public List<Person> Persons
            => new()
            {
                new Person{ Name = "ASD", Surname = "QWE", Age = 111},
                new Person{ Name = "FHG", Surname = "ASFF", Age = 111},
                new Person{ Name = "ASGASG", Surname = "ASF", Age = 111}
            };
}
