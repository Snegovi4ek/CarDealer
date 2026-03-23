namespace CarDealer.Console;

using CarDealer.Entities;
using CarDealer.Services;

public class AppMenu
{
    private readonly ISaleService _saleService;
    private readonly ICarService _carService;
    private readonly IExpenseService _expenseService;

    public AppMenu(ISaleService saleService, ICarService carService, IExpenseService expenseService)
    {
        _saleService = saleService;
        _carService = carService;
        _expenseService = expenseService;
    }

    public void Run()
    {
        while (true)
        {
            PrintMenu();
            var key = System.Console.ReadLine()?.Trim() ?? "";

            if (key == "0") break;

            switch (key)
            {
                case "1": ShowSalesByStatus(); break;
                case "2": ShowRevenueDelivered(); break;
                case "3": ShowCarSearch(); break;
                case "4": ShowTopCars(); break;
                case "5": ShowCarsByCategory(); break;
                case "6": ShowExpenseTotal(); break;
                case "7": ShowExpensesByCategory(); break;
                case "8": ShowRecentExpenses(); break;
                default:
                    System.Console.WriteLine("Неизвестный пункт.");
                    break;
            }

            System.Console.WriteLine();
        }

        System.Console.WriteLine("Выход.");
    }

    private void PrintMenu()
    {
        System.Console.WriteLine("--- Меню ---");
        System.Console.WriteLine("1 — Продажи по статусу Submitted");
        System.Console.WriteLine("2 — Выручка по статусу Delivered");
        System.Console.WriteLine("3 — Поиск автомобиля по имени");
        System.Console.WriteLine("4 — Топ-2 по цене");
        System.Console.WriteLine("5 — Авто по категории");
        System.Console.WriteLine("6 — Общая сумма расходов");
        System.Console.WriteLine("7 — Расходы по категориям");
        System.Console.WriteLine("8 — Последние 2 расхода");
        System.Console.WriteLine("0 — Выход");
        System.Console.Write("Выбор: ");
    }

    private void ShowSalesByStatus()
    {
        var sales = _saleService.GetSalesByStatus(SaleStatus.Submitted);
        System.Console.WriteLine("Продажи (Submitted):");

        foreach (var s in sales)
            System.Console.WriteLine($"  #{s.Id} клиент {s.CustomerId} сумма {s.Total}");

        if (sales.Count == 0)
            System.Console.WriteLine("  Нет продаж.");
    }

    private void ShowRevenueDelivered()
    {
        var revenue = _saleService.GetRevenueByStatus(SaleStatus.Delivered);
        System.Console.WriteLine("Выручка (Delivered): " + revenue);
    }

    private void ShowCarSearch()
    {
        System.Console.Write("Введите часть имени: ");
        var part = System.Console.ReadLine()?.Trim() ?? "";

        var list = _carService.SearchByName(part);

        System.Console.WriteLine("Найдено:");
        foreach (var c in list)
            System.Console.WriteLine($"  {c.Sku} {c.Name} {c.Price}");

        if (list.Count == 0)
            System.Console.WriteLine("  Ничего.");
    }

    private void ShowTopCars()
    {
        var list = _carService.GetTopByPrice(2);

        System.Console.WriteLine("Топ-2 по цене:");
        foreach (var c in list)
            System.Console.WriteLine($"  {c.Name} {c.Price}");
    }

    private void ShowCarsByCategory()
    {
        System.Console.Write("Введите категорию: ");
        var categoryId = System.Console.ReadLine()?.Trim() ?? "";

        var list = _carService.GetCarsByCategory(categoryId);

        System.Console.WriteLine("Автомобили:");
        foreach (var c in list)
            System.Console.WriteLine($"  {c.Name} {c.Price}");
    }

    private void ShowExpenseTotal()
    {
        var total = _expenseService.GetTotal();
        System.Console.WriteLine("Общая сумма расходов: " + total);
    }

    private void ShowExpensesByCategory()
    {
        var list = _expenseService.GetByCategory();

        System.Console.WriteLine("Расходы по категориям:");
        foreach (var e in list)
            System.Console.WriteLine($"  {e.CategoryId} {e.Amount}");
    }

    private void ShowRecentExpenses()
    {
        var list = _expenseService.GetRecent(2);

        System.Console.WriteLine("Последние 2 расхода:");
        foreach (var e in list)
            System.Console.WriteLine($"  {e.Date:dd.MM.yyyy} {e.Amount} {e.CategoryId} {e.Description}");
    }
}