namespace CarDealer.Entities;

public class Customer
{
    public Customer(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public int Id { get; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";
}