namespace CarDealer.Services;

using CarDealer.Entities;

public interface ICarService
{
    void AddCategory(string id, string name);

    void AddCar(int id, string sku, string name, string categoryId, decimal price, int stock = 0);

    IReadOnlyList<Car> SearchByName(string part);

    IReadOnlyList<Car> GetTopByPrice(int count);

    IEnumerable<Car> GetCarsByCategory(string categoryId);
}