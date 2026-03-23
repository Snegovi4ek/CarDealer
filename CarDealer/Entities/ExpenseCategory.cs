namespace CarDealer.Entities;

public class ExpenseCategory
{
    public ExpenseCategory(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }

    public string Name { get; set; } = "";
}