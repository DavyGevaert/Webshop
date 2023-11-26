using Microsoft.AspNetCore.Mvc;
using Webshop.Model;
using Webshop.Services.Abstractions;

namespace Webshop.Api.Controllers
{
    public class BluraysController : ApiBaseController
    {
        private readonly IBlurayService _blurayService;

        public BluraysController(IBlurayService blurayService)
        {
            _blurayService = blurayService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _blurayService.GetAsync(id);
            return Ok(item);
        }

        [HttpGet("Find")]
        public async Task<IActionResult> Find()
        {
            var result = await _blurayService.FindAsync();

            return Ok(result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(Bluray bluray)
        {
            await _blurayService.Create(bluray);
            return Ok(bluray);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Bluray bluray)
        {
            var updatedBluray = await _blurayService.Update(id, bluray);
            return Ok(updatedBluray);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _blurayService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
