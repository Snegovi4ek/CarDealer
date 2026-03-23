namespace CarDealer.Entities;

public class Expense
{
    public Expense(DateTime date, decimal amount, string categoryId, string description = "")
    {
        Date = date;
        Amount = amount;
        CategoryId = categoryId;
        Description = description;
    }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public string CategoryId { get; set; } = "";

    public string Description { get; set; } = "";
}