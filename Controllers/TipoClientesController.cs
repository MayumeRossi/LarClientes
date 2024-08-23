using Microsoft.AspNetCore.Mvc;
using LarClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace LarClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoClientesController : ControllerBase
    {
        private readonly Clientes1Contexto _context;

        public TipoClientesController(Clientes1Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCliente>>> GetTipoClientes()
        {
            return await _context.TipoClientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCliente>> GetTipoCliente(int id)
        {
            var tipoCliente = await _context.TipoClientes.FindAsync(id);

            if (tipoCliente == null)
            {
                return NotFound();
            }

            return tipoCliente;
        }

        [HttpPost]
        public async Task<ActionResult<TipoCliente>> PostTipoCliente(TipoCliente tipoCliente)
        {
            _context.TipoClientes.Add(tipoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoCliente), new { id = tipoCliente.ID }, tipoCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCliente(int id, TipoCliente tipoCliente)
        {
            if (id != tipoCliente.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCliente(int id)
        {
            var tipoCliente = await _context.TipoClientes.FindAsync(id);
            if (tipoCliente == null)
            {
                return NotFound();
            }

            _context.TipoClientes.Remove(tipoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoClienteExists(int id)
        {
            return _context.TipoClientes.Any(e => e.ID == id);
        }
    }
}
