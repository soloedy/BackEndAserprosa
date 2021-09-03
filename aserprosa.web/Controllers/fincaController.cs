using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aserprosa.Datos;
using aserprosa.Entidades.Finca;
using aserprosa.web.Models.Finca.ase_finca;
using System.Text.Json;
using Newtonsoft.Json;

namespace aserprosa.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fincaController : ControllerBase
    {
        private readonly DbContextAserprosa _context;

        public fincaController(DbContextAserprosa context)
        {
            _context = context;
        }

        // GET: api/ase_finca/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<fincaViewModel>> Listar()
        {
            var finca = await _context.ase_Finca.Include(f => f.productor).ToListAsync();

            return finca.Select(f => new fincaViewModel
            {
                id = f.finc_id,
                nombre = f.finc_nombre,
                descripcion = f.finc_descripcion,
                direccion = f.finc_direccion,
                productorId = f.prod_id,
                productor = f.productor.prod_nombre,
                estado = f.finc_estado
            });
        }

        // GET: api/ase_finca/mostrar/5

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> mostrar([FromRoute]int id)
        {
            var ase_finca = await _context.ase_Finca.Include(f => f.productor)
                .SingleOrDefaultAsync(f=>f.finc_id==id);

            if (ase_finca == null)
            {
                return NotFound();
            }

            return Ok(new fincaViewModel
            {
                id = ase_finca.finc_id,
                nombre = ase_finca.finc_nombre,
                descripcion = ase_finca.finc_descripcion,
                direccion = ase_finca.finc_direccion,
                productorId = ase_finca.prod_id,
                //productorNombre = ase_finca.productor.prod_nombre,
                estado = ase_finca.finc_estado
            });
        }

        // PUT: api/ase_finca/actualizar/id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar(int id, [FromBody]  actualizarFincaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.id < 0)
            {
                return BadRequest();
            }

            var finca = await _context.ase_Finca.FirstOrDefaultAsync(f => f.finc_id == model.id);

            if (finca == null)
            {
                return NotFound();
            }

            finca.finc_nombre = model.nombre;
            finca.finc_descripcion = model.descripcion;
            finca.finc_direccion = model.direccion;
            finca.prod_id = model.productorId;

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

        // POST: api/ase_finca/agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<ase_finca>> agregar(CrearFincaViewModel model)
        {
            int maxId = _context.ase_Finca.Max(f => f.finc_id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ase_finca finca = new ase_finca
            {
                finc_id = (maxId + 1),
                finc_nombre = model.nombre,
                finc_direccion = model.direccion,
                finc_descripcion = model.descripcion,
                prod_id = model.productorId,
                finc_estado = true
            };
            _context.ase_Finca.Add(finca);
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

        // PUT: api/ase_finca/desactivar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar(int id, [FromBody] actualizarFincaViewModel model)
        {
           if(id < 0)
            {
                return BadRequest();
            }

            var finca = await _context.ase_Finca.FirstOrDefaultAsync(f => f.finc_id == model.id);

            if (finca == null)
            {
                return NotFound();
            }

            finca.finc_estado = false;

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
        // PUT: api/ase_finca/activar/id
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id, [FromBody] actualizarFincaViewModel model)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var finca = await _context.ase_Finca.FirstOrDefaultAsync(f => f.finc_id == model.id);

            if (finca == null)
            {
                return NotFound();
            }

            finca.finc_estado = true;

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
    }
}
