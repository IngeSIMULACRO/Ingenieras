using FoodSIMULACRO.Data;
using FoodSIMULACRO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodSIMULACRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly FoodContext _context;
        public BebidasController(FoodContext context) => _context = context;

        // GET: api/bebidas?color=Rojo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetAll([FromQuery] string? color)
        {
            IQueryable<Bebida> q = _context.Bebidas.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(color))
                q = q.Where(b => b.Color == color);

            var list = await q.OrderBy(b => b.Nombre).ToListAsync();
            return Ok(list);
        }

        // GET: api/bebidas/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Bebida>> GetById(int id)
        {
            var bebida = await _context.Bebidas.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            return bebida is null ? NotFound() : Ok(bebida);
        }

        // POST: api/bebidas
        [HttpPost]
        public async Task<ActionResult<Bebida>> Create([FromBody] Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = bebida.Id }, bebida);
        }

        // PUT: api/bebidas/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Bebida bebida)
        {
            if (id != bebida.Id) return BadRequest("El Id del body no coincide con la ruta.");
            var exists = await _context.Bebidas.AnyAsync(b => b.Id == id);
            if (!exists) return NotFound();

            _context.Entry(bebida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/bebidas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida is null) return NotFound();

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
