namespace CarDealer.Repositories.Expense;

using CarDealer.Entities;

public interface IExpenseRepository
{
    void Add(Expense expense);
    IReadOnlyList<Expense> GetAll();
}