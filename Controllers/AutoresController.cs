using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoODataVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AutoresController : ODataController
    {
        private readonly BibliotecaContext _context;

        public AutoresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Autores
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autores>>> GetAutores()
        {
            return await _context.Autores.Include(l => l.Libros).ToListAsync();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Autores>> GetAutores(int id)
        {
            var autores = await _context.Autores.Include(l => l.Libros).Where(l => l.Id == id).SingleOrDefaultAsync();

            if (autores == null)
            {
                return NotFound();
            }

            return autores;
        }



    }
}
