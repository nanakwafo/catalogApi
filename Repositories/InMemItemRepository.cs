
using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;

namespace Catalog.Repositories
{
   

    public class InMemItemsRepository : InMemItemsRepositoryInterface
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Nana Kwafo Mensah", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Portia Quah", Price = 9, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
           items.Add(item);
        }

        public void UpdateItem(Item item)
        {
           var index =  this.items.FindIndex(existingTitem => existingTitem.Id == item.Id);
           items[index] =  item;
            
           return;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingTitem => existingTitem.Id == id);
            items.RemoveAt(index);
        }
    }





}