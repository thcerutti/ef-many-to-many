namespace ManyToMany.Models;
public class Product
{

    public Product()
    {
        Categories = new List<Category>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ICollection<Category> Categories { get; set; }
}