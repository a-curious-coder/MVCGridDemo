using System;

namespace MVCGridProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsAvailable { get; set; }
}