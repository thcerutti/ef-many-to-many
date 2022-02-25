// See https://aka.ms/new-console-template for more information
using ManyToMany.Contexts;
using ManyToMany.Models;

Console.WriteLine("Hello, World!");

using var context = new StoreContext();
context.Database.EnsureCreated();

context.Products.ToList().ForEach(p => context.Products.Remove(p));
context.Categories.ToList().ForEach(c => context.Categories.Remove(c));

var categories = new[] {
    new Category{
        Name = "Fruits",
    },
    new Category{
        Name = "Vegetables",
    },
    new Category{
        Name = "Cleaning",
    },
};
context.Categories.AddRange(categories);

var product1 = new Product{
    Name = "Tomato",
    Description = "Red Delicious",
    Price = 1.99m,
};
product1.Categories.Add(categories[1]);
context.Products.Add(product1);
Console.WriteLine($"old category={product1.Categories.Single().Name}");
context.SaveChanges();

var product2 = context.Products.Where(p => p.Name == "Tomato").FirstOrDefault();
product2.Categories.Remove(categories[1]);
product2.Categories.Add(categories[0]);
Console.WriteLine($"new category={product2.Categories.Single().Name}");
context.SaveChanges();