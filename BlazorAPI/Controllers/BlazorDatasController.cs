
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAPI.Model;
using Microsoft.AspNetCore.Authorization;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlazorDatasController : ControllerBase
    {
        private readonly BlazorDbContext _context;
       

        public BlazorDatasController(BlazorDbContext context)
        {
            _context = context;
        
        }

        // GET: api/BlazorDatas
        
        [HttpGet("GetData")]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<BlazorData>>> GetBlazorDatas()
        {
            return await _context.BlazorDatas.ToListAsync();
        }

        // GET: api/BlazorDatas/5
       // [Authorize(Roles = "Admin,Executive")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BlazorData>> GetBlazorData(int id)
        {
            var blazorData = await _context.BlazorDatas.FindAsync(id);

            if (blazorData == null)
            {
                return NotFound();
            }
            return blazorData;
        }

        // PUT: api/BlazorDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlazorData(int id, BlazorData blazorData)
        {
            if (id != blazorData.ID)
            {
                return BadRequest();
            }

            _context.Entry(blazorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlazorDataExists(id))
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

        // POST: api/BlazorDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlazorData>> PostBlazorData(BlazorData blazorData)
        {
            _context.BlazorDatas.Add(blazorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlazorData", new { id = blazorData.ID }, blazorData);
        }

        // DELETE: api/BlazorDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlazorData(int id)
        {
            var blazorData = await _context.BlazorDatas.FindAsync(id);
            if (blazorData == null)
            {
                return NotFound();
            }

            _context.BlazorDatas.Remove(blazorData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlazorDataExists(int id)
        {
            return _context.BlazorDatas.Any(e => e.ID == id);
        }
    }
}
