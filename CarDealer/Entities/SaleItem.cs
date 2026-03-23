namespace CarDealer.Entities;

public class SaleItem
{
    public string CarName { get; set; } = "";

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total => Quantity * UnitPrice;
}