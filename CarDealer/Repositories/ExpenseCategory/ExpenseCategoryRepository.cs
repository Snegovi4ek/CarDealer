namespace CarDealer.Repositories.ExpenseCategory;

using CarDealer.Entities;

public class ExpenseCategoryRepository : IExpenseCategoryRepository
{
    private readonly Dictionary<string, ExpenseCategory> _categories = [];

    public void Add(ExpenseCategory category) => _categories[category.Id] = category;

    public ExpenseCategory? GetById(string id) => _categories.TryGetValue(id, out var c) ? c : null;

    public IReadOnlyList<ExpenseCategory> GetAll() => _categories.Values.ToList();
}