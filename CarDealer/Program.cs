using CarDealer.Console;
using CarDealer.Entities;
using CarDealer.Repositories;
using CarDealer.Repositories.Car;
using CarDealer.Repositories.Category;
using CarDealer.Repositories.Expense;
using CarDealer.Repositories.ExpenseCategory;
using CarDealer.Repositories.Sale;
using CarDealer.Services;

var saleRepo = new SaleRepository();
var carRepo = new CarRepository();
var categoryRepo = new CategoryRepository();
var expenseRepo = new ExpenseRepository();
var expenseCategoryRepo = new ExpenseCategoryRepository();

ISaleService saleService = new SaleService(saleRepo);
ICarService carService = new CarService(carRepo, categoryRepo);
IExpenseService expenseService = new ExpenseService(expenseRepo, expenseCategoryRepo);

SeedData(saleService, carService, expenseService);

var menu = new AppMenu(saleService, carService, expenseService);
menu.Run();

static void SeedData(ISaleService saleService, ICarService carService, IExpenseService expenseService)
{
    var s1 = saleService.CreateSale(1);
    saleService.AddItemToSale(s1.Id, "BMW M5 F90", 1, 90000m);
    saleService.SetSaleStatus(s1.Id, SaleStatus.Submitted);

    var s2 = saleService.CreateSale(2);
    saleService.AddItemToSale(s2.Id, "Audi A6 C6", 1, 70000m);
    saleService.SetSaleStatus(s2.Id, SaleStatus.Delivered);

    var s3 = saleService.CreateSale(1);
    saleService.AddItemToSale(s3.Id, "Mercedes E200", 1, 80000m);
    saleService.SetSaleStatus(s3.Id, SaleStatus.Shipped);

    carService.AddCategory("sedan", "Седан");
    carService.AddCategory("suv", "Внедорожник");

    carService.AddCar(1, "BMW-01", "BMW M5", "sedan", 90000m, 3);
    carService.AddCar(2, "AUDI-01", "Audi A6", "sedan", 70000m, 5);
    carService.AddCar(3, "MB-01", "Mercedes E", "sedan", 80000m, 2);
    carService.AddCar(4, "BMW-X5", "BMW X5", "suv", 95000m, 4);

    expenseService.AddCategory("fuel", "Топливо");
    expenseService.AddCategory("service", "Обслуживание");

    var baseDate = new DateTime(2025, 2, 1);

    expenseService.AddExpense(baseDate.AddDays(0), 500m, "fuel", "Заправка");
    expenseService.AddExpense(baseDate.AddDays(1), 1500m, "service", "ТО");
    expenseService.AddExpense(baseDate.AddDays(2), 700m, "fuel", "Заправка");
    expenseService.AddExpense(baseDate.AddDays(3), 2000m, "service", "Ремонт");
}