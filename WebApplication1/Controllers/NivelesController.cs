using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class NivelesController : ControllerBase
{
    private readonly WebApplication1Context _context;
    private readonly IMapper _mapper;

    public NivelesController(WebApplication1Context context, IMapper mapper)
    {
        _context = context;
        this._mapper = mapper;
    }

    // GET: api/Nivel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Nivel>>> GetNivel()
    {
        return await _context.Nivel.ToListAsync();
    }

    // GET: api/Nivel/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Nivel>> GetNivel(int id)
    {
        var nivel = await _context.Nivel.FindAsync(id);

        if (nivel == null)
        {
            return NotFound();
        }

        return nivel;
    }

    // PUT: api/Nivel/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNivel(int? id, Nivel nivel)
    {
        if (id != nivel.Id)
        {
            return BadRequest();
        }

        _context.Entry(nivel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NivelExists(id))
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

    // POST: api/Nivel
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Nivel>> PostNivel(Nivel nivel)
    {
        _context.Nivel.Add(nivel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNivel", new { id = nivel.Id }, nivel);
    }

    // DELETE: api/Nivel/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNivel(int? id)
    {
        var nivel = await _context.Nivel.FindAsync(id);
        if (nivel == null)
        {
            return NotFound();
        }

        _context.Nivel.Remove(nivel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}/Cursos")]
    public async Task<ActionResult<List<CursosDto>>> GetCursosByNivelID(int id) 
    {
        var nivel = await _context.Nivel.FindAsync(id);

        if (nivel == null)
        {
            return NotFound();
        }

        var cursos = _context.Curso.Where(c => c.NivelId == id).ToList();

        var cursosDto = _mapper.Map<List<CursosDto>>(cursos);

        return cursosDto;
    }
    private bool NivelExists(int? id)
    {
        return _context.Nivel.Any(e => e.Id == id);
    }


}
