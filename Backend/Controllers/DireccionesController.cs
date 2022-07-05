using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/direcciones")]
    public class DireccionesController : ControllerBase
    {
       private readonly MyDbContext _context;

        public DireccionesController(MyDbContext context) => _context= context;

        [HttpGet]
        public async Task<IEnumerable<Direccion>> Get()
        {
            return await _context.Direcciones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Save(Direccion direccion)
        {
            _context.Add(direccion);
            await _context.SaveChangesAsync();
            await AuditoriaDirecciones("Nueva, Ciente ID: " + direccion.ClienteId + " id: "+ direccion.DireccionId);
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(Direccion direccion, int id)
        {
            var direccionDB = await _context.Direcciones.FirstOrDefaultAsync(c => c.DireccionId == id);

            if (direccionDB is null)
                return NotFound();

            direccionDB.CampoDireccion = direccion.CampoDireccion;
            direccionDB.Departamento = direccion.Departamento;
            direccionDB.Municipio = direccion.Municipio;

            _context.Update(direccionDB);
            await _context.SaveChangesAsync();
            await AuditoriaDirecciones("Modificado, Ciente ID: " + direccion.ClienteId + " id: " + direccion.ClienteId);
            return Ok();

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var direccion = await _context.Direcciones.FirstOrDefaultAsync(c => c.DireccionId == id);

            if (direccion is null)
                return NotFound();


            _context.Remove(direccion);
            await _context.SaveChangesAsync();
            await AuditoriaDirecciones("Eliminado, Ciente ID: " + direccion.ClienteId + " id: " + direccion.ClienteId);
            return Ok();

        }

        [NonAction]
        private async Task<bool> AuditoriaDirecciones(String descripcion)
        {
            Auditoria auditoria = new Auditoria()

            {
                FechaHora = DateTime.Now,
                Descripcion = "Direccion de Cliente" + descripcion,
            };

            _context.Add(auditoria);
            int result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

    }
}
