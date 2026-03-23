namespace CarDealer.Repositories.Sale;

using CarDealer.Entities;

public interface ISaleRepository
{
    void Add(Sale sale);
    int GetNextId();
    Sale? GetById(int id);
    IReadOnlyList<Sale> GetAll();
}