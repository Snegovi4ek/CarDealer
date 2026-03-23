namespace CarDealer.Entities;

public class Sale
{
    private readonly List<SaleItem> _items = [];

    public Sale(int id, int customerId)
    {
        Id = id;
        CustomerId = customerId;
        Status = SaleStatus.Draft;
    }

    public int Id { get; }

    public int CustomerId { get; set; }

    public SaleStatus Status { get; set; }

    public IReadOnlyList<SaleItem> Items => _items;

    public decimal Total => _items.Sum(i => i.Total);

    public void AddItem(string carName, int quantity, decimal unitPrice)
    {
        _items.Add(new SaleItem { CarName = carName, Quantity = quantity, UnitPrice = unitPrice });
    }
}