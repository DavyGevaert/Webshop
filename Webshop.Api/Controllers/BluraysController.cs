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
            var item = _blurayService.Get(id);
            return Ok(item);
        }

        [HttpGet("Find")]
        public IActionResult Find()
        {
            var result = _blurayService.Find();

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
