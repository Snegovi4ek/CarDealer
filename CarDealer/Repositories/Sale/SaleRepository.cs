namespace CarDealer.Repositories.Sale;

using CarDealer.Entities;

public class SaleRepository : ISaleRepository
{
    private readonly List<Sale> _sales = [];

    private int _nextId = 1;

    public void Add(Sale sale) => _sales.Add(sale);

    public int GetNextId() => _nextId++;

    public Sale? GetById(int id) => _sales.FirstOrDefault(s => s.Id == id);

    public IReadOnlyList<Sale> GetAll() => _sales;
}