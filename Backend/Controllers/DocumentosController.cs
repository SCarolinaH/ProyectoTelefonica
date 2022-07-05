using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/documentos")]
    public class DocumentosController : ControllerBase
    {

        private readonly MyDbContext _context;

        public DocumentosController(MyDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Documento>> Get()
        {
            return await _context.Documentos.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Save(Documento documento)
        {
            _context.Add(documento);
            await _context.SaveChangesAsync();
            await AuditoriaDocumentos("Nueva, Ciente ID: " + documento.ClienteId + " id: " + documento.DocumentoId);
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(Documento documento, int id)
        {
            var documentoDB= await _context.Documentos.FirstOrDefaultAsync(c => c.DocumentoId == id);

            if (documentoDB is null)
                return NotFound();

            documentoDB.TipoDocumento = documento.TipoDocumento;
            documentoDB.NumeroDocumento = documento.NumeroDocumento;

            _context.Update(documentoDB);
            await _context.SaveChangesAsync();
            await AuditoriaDocumentos("Modificado, Ciente ID: " + documento.ClienteId + " id: " + documento.DocumentoId);
            return Ok();

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(c => c.DocumentoId == id);

            if (documento is null)
                return NotFound();


            _context.Remove(documento);
            await _context.SaveChangesAsync();
            await AuditoriaDocumentos("Eliminado, Ciente ID: " + documento.ClienteId + " id: " + documento.DocumentoId);
            return Ok();

        }


        [NonAction]
        private async Task<bool> AuditoriaDocumentos(String descripcion)
        {
            Auditoria auditoria = new Auditoria()

            {
                FechaHora = DateTime.Now,
                Descripcion = "Documento del Cliente" + descripcion,
            };

            _context.Add(auditoria);
            int result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }


    }
}
