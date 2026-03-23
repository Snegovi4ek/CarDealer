namespace CarDealer.Services;


public interface IExpenseService
{
    void AddCategory(string id, string name);

    void AddExpense(DateTime date, decimal amount, string categoryId, string description = "");

    decimal GetTotal(DateTime? from = null, DateTime? to = null);

    IReadOnlyList<Entities.Expense> GetByCategory(DateTime? from = null, DateTime? to = null);

    IReadOnlyList<Entities.Expense> GetRecent(int count);
}