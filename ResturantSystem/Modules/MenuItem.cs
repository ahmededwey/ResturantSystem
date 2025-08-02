using ResturantSystem.Enums;
using System;

namespace ResturantSystem.Modules
{
    public class MenuItem
    {
        // Properties
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public ItemSize ItemSize { get; set; }
        public Category Category { get; set; }

        // Default Constructor
        public MenuItem() { }

        // Parameterized Constructor
        public MenuItem(int id, string title, string description, double price, ItemSize itemSize, Category category)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            ItemSize = itemSize;
            Category = category;
        }

        // Override ToString - Grid Style
        public override string ToString()
        {
            return $"| {Id} | {Title,-18} | {Description,-30} | {Price,7} $ | {ItemSize,-6} | {Category,-12} |";
        }
    }
}
