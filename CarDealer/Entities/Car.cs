namespace CarDealer.Entities;

public class Car
{
    private int _stock;

    public Car(int id, string sku, string name, string categoryId, decimal price, int stock = 0)
    {
        Id = id;
        Sku = sku;
        Name = name;
        CategoryId = categoryId;
        Price = price;
        _stock = stock;
    }

    public int Id { get; }

    public string Sku { get; set; } = "";

    public string Name { get; set; } = "";

    public string CategoryId { get; set; } = "";

    public decimal Price { get; set; }

    public int Stock => _stock;

    public void Restock(int quantity)
    {
        if (quantity > 0) _stock += quantity;
    }
}