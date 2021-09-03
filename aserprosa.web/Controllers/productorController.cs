using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aserprosa.Datos;
using aserprosa.Entidades.Finca;
using aserprosa.web.Models.Finca.ase_productor;

namespace aserprosa.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productorController : ControllerBase
    {
        private readonly DbContextAserprosa _context;

        public productorController(DbContextAserprosa context)
        {
            _context = context;
        }

        // GET: api/productor/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<productorViewModel>> Listar()
        {
            var productor = await _context.ase_Productor.ToListAsync();

            return productor.Select(p => new productorViewModel
            {
                productorId = p.prod_id,
                nombre = p.prod_nombre,
                descripcion = p.prod_descripcion,
                telefono = p.prod_telefono,
                correo = p.prod_correo,
                estado = p.prod_estado
            });

        }

        // GET: api/productor/mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ase_productor>> mostrar([FromRoute]int id)
        {
            var ase_productor = await _context.ase_Productor.FindAsync(id);

            if (ase_productor == null)
            {
                return NotFound();
            }

            return Ok(new productorViewModel
            {
                productorId = ase_productor.prod_id,
                nombre = ase_productor.prod_nombre,
                descripcion = ase_productor.prod_descripcion,
                telefono = ase_productor.prod_telefono,
                correo = ase_productor.prod_correo,
                estado = ase_productor.prod_estado
            });
        }

        // PUT: api/productor/actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] actualizarProductorViewModel ase_productor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ase_productor.productorId < 0)
            {
                return BadRequest();
            }

            var productor = await _context.ase_Productor.FirstOrDefaultAsync(p => p.prod_id == ase_productor.productorId);

            if(ase_productor == null)
            {
                return NotFound();
            }

            productor.prod_nombre = ase_productor.nombre;
            productor.prod_descripcion = ase_productor.descripcion;
            productor.prod_telefono = ase_productor.telefono;
            productor.prod_correo = ase_productor.correo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/productor/agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<ase_productor>> agregar(productorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ase_productor productor = new ase_productor
            {
                prod_id = model.productorId,
                prod_nombre = model.nombre,
                prod_descripcion = model.descripcion,
                prod_telefono = model.telefono,
                prod_correo = model.correo,
                prod_estado = true
            };
            _context.ase_Productor.Add(productor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();

        }

        // DELETE: api/productor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ase_productor>> Deletease_productor(int id)
        {
            var ase_productor = await _context.ase_Productor.FindAsync(id);
            if (ase_productor == null)
            {
                return NotFound();
            }

            _context.ase_Productor.Remove(ase_productor);
            await _context.SaveChangesAsync();

            return ase_productor;
        }

        // PUT: api/productor/desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> desactivar(int id, [FromBody] actualizarProductorViewModel ase_productor)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var productor = await _context.ase_Productor.FirstOrDefaultAsync(p => p.prod_id == id);

            if (ase_productor == null)
            {
                return NotFound();
            }

            productor.prod_estado = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/productor/activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> activar(int id, [FromBody] actualizarProductorViewModel ase_productor)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var productor = await _context.ase_Productor.FirstOrDefaultAsync(p => p.prod_id == id);

            if (ase_productor == null)
            {
                return NotFound();
            }

            productor.prod_estado = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }
        private bool ase_productorExists(int id)
        {
            return _context.ase_Productor.Any(e => e.prod_id == id);
        }
    }
}
