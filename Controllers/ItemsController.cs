using System.Security.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Catalog.Dtos;
using System.Threading.Tasks;

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
        public async Task< IEnumerable<ItemDto>> GetItemsAsync()
        {
             var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
             return items;
        }

        //GET /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id){
          var item = await repository.GetItemAsync(id);
       
          if(item is null){
              return NotFound();
          }
          return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto){
            Item item = new Item(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

           await repository.CreateItemAsync(item);

            return  CreatedAtAction(nameof(GetItemAsync),new{Id = item.Id},item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id,UpdateItemDto itemDto){
            var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null){
                return NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name =itemDto.Name,
                Price = itemDto.Price
            };

           await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        //DELETE  /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id){
              var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null){
                return NotFound();
            }
           await repository.DeleteItemAsync(existingItem.Id);
            return NoContent();
        }
    }
}