namespace CarDealer.Repositories.Car;

using CarDealer.Entities;

public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars = [];

    public void Add(Car car) => _cars.Add(car);

    public Car? GetById(int id) => _cars.FirstOrDefault(c => c.Id == id);

    public IReadOnlyList<Car> GetAll() => _cars;
}