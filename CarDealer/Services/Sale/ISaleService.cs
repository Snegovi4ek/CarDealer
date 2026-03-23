namespace CarDealer.Services;

using CarDealer.Entities;

public interface ISaleService
{
    Sale CreateSale(int customerId);

    void AddItemToSale(int saleId, string productName, int quantity, decimal unitPrice);

    void SetSaleStatus(int saleId, SaleStatus status);

    IReadOnlyList<Sale> GetSalesByStatus(SaleStatus status);

    decimal GetRevenueByStatus(SaleStatus status);

    Sale? GetSaleById(int id);
}