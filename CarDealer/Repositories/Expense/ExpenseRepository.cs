namespace CarDealer.Repositories.Expense;

using CarDealer.Entities;

public class ExpenseRepository : IExpenseRepository
{
    private readonly List<Expense> _expenses = [];

    public void Add(Expense expense) => _expenses.Add(expense);

    public IReadOnlyList<Expense> GetAll() => _expenses;
}