namespace CarDealer.Repositories.ExpenseCategory;

using CarDealer.Entities;

public interface IExpenseCategoryRepository
{
    void Add(ExpenseCategory category);
    ExpenseCategory? GetById(string id);
    IReadOnlyList<ExpenseCategory> GetAll();
}