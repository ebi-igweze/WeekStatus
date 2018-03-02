using System;
using System.Linq;
using Inventory.Manager;

namespace Assignment_Wk7
{
    class Sum
    {
        public static void Run(string[] args)
        {
            var inventoryManager = new InventoryManager();
            var sum = inventoryManager.GetInventories().Sum(i => i.Price);
            Console.WriteLine($"The sum of all Prices in Inventory is: {sum}");
        }
    }


    public class SkipTake
    {
        public static void Run(string[] args) 
        {
            var inventoryManager = new InventoryManager();
            var result = inventoryManager.GetInventories()
                            .SkipWhile(i => i.EntryDate > new DateTime(2017,05,12))
                            .TakeWhile(i => i.Price > 40).ToList();
            result.ForEach(Console.WriteLine);
        }
    }

    public class OrderByThenBy 
    {
        public static void Run(string[] args) 
        {
            var inventoryManager = new InventoryManager();
            var result = inventoryManager.GetInventories()
                            .OrderBy(i => i.Id)
                            .ThenBy(i => i.EntryDate)
                            .ToList();
            result.ForEach(Console.WriteLine);
        }
    }
    
    public class Operators 
    {
        public static void Run(string[] args) 
        {
            Console.WriteLine("Union");
            var inventoryManager = new InventoryManager();
            var union = inventoryManager.GetInventories().Union(inventoryManager.FreshInventory());
            union.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("\n==================\n");
            
            Console.WriteLine("Concat");
            var concat = inventoryManager.GetInventories().Concat(inventoryManager.FreshInventory());
            concat.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("\n==================\n");

            Console.WriteLine("Distinct");
            var distinct = concat.Distinct();
            distinct.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("\n==================\n");
            
            Console.WriteLine("Intersect");
            var intersect = inventoryManager.GetInventories().Intersect(inventoryManager.FreshInventory());
            intersect.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("\n==================\n");
        }
    }

    public class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("\n==================\n");
            Console.WriteLine("Results");
            Console.WriteLine("\n==================\n");
            Console.WriteLine("Sum");
            Sum.Run(null);
            
            Console.WriteLine("\n==================\n");
            
            Console.WriteLine("SkipTake");
            SkipTake.Run(null);

            Console.WriteLine("\n==================\n");
            
            Console.WriteLine("OrderThenBy");
            OrderByThenBy.Run(null);
            
            Console.WriteLine("\n==================\n");
            
            Console.WriteLine("Operators");
            Operators.Run(null);
        }
    }
}
