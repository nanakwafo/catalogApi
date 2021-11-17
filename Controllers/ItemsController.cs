using System.Security.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepositoryInterface repository;

        public ItemsController(InMemItemsRepositoryInterface repository){
            this.repository = repository;
        }

        //GET /items
        [HttpGet] 
        public IEnumerable<ItemDto> GetItems()
        {
             var items = repository.GetItems().Select(item => item.AsDto());
             return items;
        }

        //GET /items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
          var item = repository.GetItem(id);
       
          if(item is null){
              return NotFound();
          }
          return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new Item(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return  CreatedAtAction(nameof(GetItem),new{Id = item.Id},item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id,UpdateItemDto itemDto){
            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name =itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        //DELETE  /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
              var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return NotFound();
            }
            repository.DeleteItem(existingItem.Id);
            return NoContent();
        }
    }
}