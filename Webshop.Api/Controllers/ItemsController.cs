using Microsoft.AspNetCore.Mvc;
using Webshop.Model;
using Webshop.Services.Abstractions;

namespace Webshop.Api.Controllers
{
    public class ItemsController : ApiBaseController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _itemService.GetAsync(id);
            return Ok(item);
        }

        [HttpGet("Find")]
        public async Task<IActionResult> Find()
        {
            var result = await _itemService.FindAsync();

            return Ok(result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(Item item)
        {
            await _itemService.Create(item);
            return Ok(item);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Item item)
        {
            var updatedItem = await _itemService.Update(id, item);
            return Ok(updatedItem);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _itemService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
