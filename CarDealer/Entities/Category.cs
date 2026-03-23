namespace CarDealer.Entities;

public class Category
{
    public Category(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }

    public string Name { get; set; } = "";
}