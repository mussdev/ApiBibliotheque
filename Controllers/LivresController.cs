using biblioApi.Data;
using biblioApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace biblioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // api/controller
    public class LivresController:ControllerBase
    {
        private readonly BiblioDbContext _biblioDbContext;
        public LivresController(BiblioDbContext biblioDbContext){
            _biblioDbContext=biblioDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Livres>> GetLivres()
        {
            var livres = await _biblioDbContext.livres.AsNoTracking().ToListAsync();

            return livres;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livres livres){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            await _biblioDbContext.AddAsync(livres);

            var result = await _biblioDbContext.SaveChangesAsync();

            if(result > 0 ){
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Livres>> GetLivre(Guid id)
        {
            var livre = await _biblioDbContext.livres.FindAsync(id);

            if (livre is null)
                return NotFound();
            return Ok(livre);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livre = await _biblioDbContext.livres.FindAsync(id);

            if(livre is null)
                return NotFound();
            _biblioDbContext.Remove(livre);

            var result = await _biblioDbContext.SaveChangesAsync();
            if( result > 0)
                return Ok("Livre deleted");
            
            return BadRequest("Unable to delete livres");
        }
    }
}