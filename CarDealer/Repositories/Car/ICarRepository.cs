namespace CarDealer.Repositories.Car;


using CarDealer.Entities;

public interface ICarRepository
{
    void Add(Car car);
    Car? GetById(int id);
    IReadOnlyList<Car> GetAll();
}