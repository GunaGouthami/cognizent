using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

// Retrieve all products
var products = await context.Products.ToListAsync();

Console.WriteLine("All Products:");
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - {p.Price}");
}

// Find product by ID
var product = await context.Products.FindAsync(1);
Console.WriteLine($"\nFound: {product?.Name}");

// First product whose price is greater than 5000
var expensive = await context.Products
    .FirstOrDefaultAsync(p => p.Price > 5000);

Console.WriteLine($"Expensive Product: {expensive?.Name}");