using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleAPI.DTOs;
using SampleAPI.Models;
using SampleAPI.Services;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TShirtController : ControllerBase
    {
        private readonly ITShirtService _tshirtService;

        public TShirtController(ITShirtService tshirtService)
        {
            _tshirtService = tshirtService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TShirtDTO>>> GetAll()
        {
            var tshirts = await _tshirtService.GetAllTShirtsAsync();
            return Ok(tshirts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TShirtDTO>> GetById(int id)
        {
            var tshirt = await _tshirtService.GetTShirtByIdAsync(id);

            if (tshirt == null)
            {
                return NotFound();
            }

            return Ok(tshirt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TShirtDTO tShirtDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tShirt = await _tshirtService.AddAsync(tShirtDto);

                var createdTShirtDTO = new TShirtDTO
                {
                    TShirtID = tShirt.TShirtID,
                    CategoryID = tShirt.CategoryID,
                    Name = tShirt.Name,
                    Description = tShirt.Description,
                    ImageUrl = tShirt.ImageUrl,
                    Price = tShirt.Price,
                    Stock = tShirt.Stock,
                    Sizes = tShirt.Sizes
                };

                return CreatedAtAction(nameof(GetById), new { id = tShirt.TShirtID }, createdTShirtDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/tshirts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TShirtDTO tShirtDto)
        {
            if (id != tShirtDto.TShirtID)
            {
                return BadRequest("TShirt ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedTShirt = await _tshirtService.UpdateAsync(tShirtDto);
                return Ok(updatedTShirt);
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await TShirtExists(id);
                if (!exists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> TShirtExists(int id)
        {
            var tShirt = await _tshirtService.GetTShirtByIdAsync(id);
            return tShirt != null;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTShirt(int id)
        {
            await _tshirtService.DeleteAsync(id);
            return NoContent();
        }

    }
}
