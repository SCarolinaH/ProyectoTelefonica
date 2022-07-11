using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ClientesController(MyDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes.Include(c => c.Direcciones).Include(c => c.Documentos).OrderBy(c => c.Nombre).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Save(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            await AuditoriaClientes("Nuevo" + cliente.ToString());
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(Cliente cliente, int id)
        {
            var clienteDB = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);

            if(clienteDB is null)
                return NotFound();

            clienteDB.Nombre = cliente.Nombre;
            clienteDB.TelefonoFijo = cliente.TelefonoFijo;
            clienteDB.TelefonoMovil = cliente.TelefonoMovil;
            clienteDB.Correo = cliente.Correo;

             _context.Update(clienteDB);
            await _context.SaveChangesAsync();
            await AuditoriaClientes("Modificado id: " + id);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente is null)
                return NotFound();


            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            await AuditoriaClientes("Eliminado id: " + id);
            return Ok();

        }

        [NonAction]
        private async Task<bool> AuditoriaClientes(String descripcion)
        {
            Auditoria auditoria = new Auditoria()

            {
                FechaHora = DateTime.Now,
                Descripcion = "Cliente" + descripcion,
            };

            _context.Add(auditoria);
            int result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

    }
}
