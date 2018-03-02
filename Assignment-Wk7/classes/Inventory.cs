using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public List<Category> Categories { get; set; } = new List<Category>();

        public override string ToString() 
        {
            var categories = Categories.Select(c => c.Name).Aggregate((c,c2) => c+", "+c2);

            var result = $" Id: {Id}, Name: {Name}, Price: {Price}, EntryDate: {EntryDate}, Categories: {categories} ";
            return result;
        }
    }
}