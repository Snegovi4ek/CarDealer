using CarDealer.Repositories.Car;
using CarDealer.Repositories.Category;

namespace CarDealer.Services;

using CarDealer.Entities;


public class CarService : ICarService
{
    private readonly ICarRepository _carRepo;
    private readonly ICategoryRepository _categoryRepo;

    public CarService(ICarRepository carRepo, ICategoryRepository categoryRepo)
    {
        _carRepo = carRepo;
        _categoryRepo = categoryRepo;
    }

    public void AddCategory(string id, string name)
    {
        _categoryRepo.Add(new Category(id, name));
    }

    public void AddCar(int id, string sku, string name, string categoryId, decimal price, int stock = 0)
    {
        _carRepo.Add(new Car(id, sku, name, categoryId, price, stock));
    }

    public IReadOnlyList<Car> SearchByName(string part)
    {
        return _carRepo.GetAll()
            .Where(c => c.Name.Contains(part, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Car> GetTopByPrice(int count)
    {
        return _carRepo.GetAll()
            .OrderByDescending(c => c.Price)
            .Take(count)
            .ToList();
    }

    public IEnumerable<Car> GetCarsByCategory(string categoryId)
    {
        return _carRepo.GetAll()
            .Where(c => c.CategoryId == categoryId);
    }
}