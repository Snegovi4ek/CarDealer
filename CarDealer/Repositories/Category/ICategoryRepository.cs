namespace CarDealer.Repositories.Category;

using CarDealer.Entities;

public interface ICategoryRepository
{
    void Add(Category category);
    Category? GetById(string id);
    IReadOnlyList<Category> GetAll();
}