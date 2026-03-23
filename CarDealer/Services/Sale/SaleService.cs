using CarDealer.Repositories.Sale;

namespace CarDealer.Services;

using CarDealer.Entities;


public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepo;

    public SaleService(ISaleRepository saleRepo)
    {
        _saleRepo = saleRepo;
    }

    public Sale CreateSale(int customerId)
    {
        var id = _saleRepo.GetNextId();
        var sale = new Sale(id, customerId);
        _saleRepo.Add(sale);
        return sale;
    }

    public void AddItemToSale(int saleId, string productName, int quantity, decimal unitPrice)
    {
        var sale = _saleRepo.GetById(saleId);
        sale?.AddItem(productName, quantity, unitPrice);
    }

    public void SetSaleStatus(int saleId, SaleStatus status)
    {
        var sale = _saleRepo.GetById(saleId);
        if (sale != null)
            sale.Status = status;
    }

    public Sale? GetSaleById(int id)
    {
        return _saleRepo.GetById(id);
    }

    public IReadOnlyList<Sale> GetSalesByStatus(SaleStatus status)
    {
        return _saleRepo.GetAll()
            .Where(s => s.Status == status)
            .ToList();
    }

    public decimal GetRevenueByStatus(SaleStatus status)
    {
        return _saleRepo.GetAll()
            .Where(s => s.Status == status)
            .Sum(s => s.Total);
    }
}