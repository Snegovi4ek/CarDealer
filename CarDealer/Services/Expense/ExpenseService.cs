using CarDealer.Repositories.Expense;
using CarDealer.Repositories.ExpenseCategory;

namespace CarDealer.Services;

using CarDealer.Entities;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepo;
    private readonly IExpenseCategoryRepository _categoryRepo;

    public ExpenseService(IExpenseRepository expenseRepo, IExpenseCategoryRepository categoryRepo)
    {
        _expenseRepo = expenseRepo;
        _categoryRepo = categoryRepo;
    }

    public void AddCategory(string id, string name)
    {
        _categoryRepo.Add(new ExpenseCategory(id, name));
    }

    public void AddExpense(DateTime date, decimal amount, string categoryId, string description = "")
    {
        _expenseRepo.Add(new Expense(date, amount, categoryId, description));
    }

    public decimal GetTotal(DateTime? from = null, DateTime? to = null)
    {
        var q = _expenseRepo.GetAll().AsEnumerable();

        if (from.HasValue)
            q = q.Where(e => e.Date >= from.Value);

        if (to.HasValue)
            q = q.Where(e => e.Date <= to.Value);

        return q.Sum(e => e.Amount);
    }

    public IReadOnlyList<Expense> GetByCategory(DateTime? from = null, DateTime? to = null)
    {
        var q = _expenseRepo.GetAll().AsEnumerable();

        if (from.HasValue)
            q = q.Where(e => e.Date >= from.Value);

        if (to.HasValue)
            q = q.Where(e => e.Date <= to.Value);

        return q
            .GroupBy(e => e.CategoryId)
            .SelectMany(g => g)
            .ToList();
    }

    public IReadOnlyList<Expense> GetRecent(int count)
    {
        return _expenseRepo.GetAll()
            .OrderByDescending(e => e.Date)
            .Take(count)
            .ToList();
    }
}