using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
     public interface InMemItemsRepositoryInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);

        void UpdateItem(Guid id ,Item item);

        void DeleteItem(Guid id);
    }
}
