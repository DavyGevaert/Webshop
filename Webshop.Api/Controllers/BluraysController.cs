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
        public IActionResult Get(int id)
        {
            var item = _blurayService.GetAsync(id);
            return Ok(item);
        }

        [HttpGet("Find")]
        public async Task<IActionResult> Find()
        {
            var result = await _blurayService.FindAsync();

            return Ok(result);
        }


        [HttpPost("Create")]
        public IActionResult Create(Bluray bluray)
        {
            _blurayService.Create(bluray);
            return Ok(bluray);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Bluray bluray)
        {
            var updatedBluray = _blurayService.Update(id, bluray);
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
