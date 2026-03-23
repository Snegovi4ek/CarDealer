namespace CarDealer.Repositories.Category;

using CarDealer.Entities;

public class CategoryRepository : ICategoryRepository
{
    private readonly Dictionary<string, Category> _categories = [];

    public void Add(Category category) => _categories[category.Id] = category;

    public Category? GetById(string id) => _categories.TryGetValue(id, out var c) ? c : null;

    public IReadOnlyList<Category> GetAll() => _categories.Values.ToList();
}