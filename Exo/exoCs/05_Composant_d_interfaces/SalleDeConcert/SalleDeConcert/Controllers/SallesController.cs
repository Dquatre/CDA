using Microsoft.AspNetCore.Mvc;
using SalleDeConcert.Data.Models;
using SalleDeConcert.Data.Services;

namespace SalleDeConcert.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SallesController
    {
        private readonly SallesService _SallesService;

        public SallesController(SallesService SallesService) =>
            _SallesService = SallesService;

        [HttpGet]
        public async Task<List<Salle>> Get() =>
            await _SallesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Salle>> Get(string id)
        {
            var Salle = await _SallesService.GetAsync(id);

            if (Salle is null)
            {
                return NotFound();
            }

            return Salle;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Salle newSalle)
        {
            await _SallesService.CreateAsync(newSalle);

            return CreatedAtAction(nameof(Get), new { id = newSalle.Id }, newSalle);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Salle updatedSalle)
        {
            var Salle = await _SallesService.GetAsync(id);

            if (Salle is null)
            {
                return NotFound();
            }

            updatedSalle.Id = Salle.Id;

            await _SallesService.UpdateAsync(id, updatedSalle);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Salle = await _SallesService.GetAsync(id);

            if (Salle is null)
            {
                return NotFound();
            }

            await _SallesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
