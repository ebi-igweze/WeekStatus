using System.Collections.Generic;
using System.Linq;

namespace Inventory.Manager
{

    public class InventoryManager 
    {

        public IEnumerable<Models.Inventory> GetInventories () => _inventories;

        public IEnumerable<Models.Inventory> FreshInventory () => _inventories.Where(i => i.EntryDate.Year > 2017);       
        
        
        
        private readonly List<Models.Inventory> _inventories = new List<Models.Inventory>() {
            new Models.Inventory { Id=1, Name="Milo", Price=23M, EntryDate=new System.DateTime(2017,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=2, Name="Rolex", Price=53M, EntryDate=new System.DateTime(2017,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Wearable"},  new Models.Category { Name="Customizeable"} } },
            new Models.Inventory { Id=3, Name="Peak Milk", Price=13M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=4, Name="Timberland Boot", Price=26M, EntryDate=new System.DateTime(2017,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Wearable"} } },
            new Models.Inventory { Id=5, Name="Lipton", Price=28M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=6, Name="Nike Trainners", Price=43M, EntryDate=new System.DateTime(2017,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Wearable"}, new Models.Category { Name="Customizeable"} } },
            new Models.Inventory { Id=7, Name="Coke", Price=83M, EntryDate=new System.DateTime(2017,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=8, Name="Fanta", Price=123M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=9, Name="Sprite", Price=663M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Consumable"} } },
            new Models.Inventory { Id=10, Name="Polo sport", Price=53M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Wearable"}, new Models.Category { Name="Customizeable"} } },
            new Models.Inventory { Id=11, Name="Tom Ford", Price=813M, EntryDate=new System.DateTime(2018,05,12), 
                                    Categories=new List<Models.Category> { new Models.Category { Name="Wearable"} } },
        };
    }
}