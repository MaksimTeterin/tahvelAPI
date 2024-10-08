using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentHistory>>> GetStudentHistory()
        {
            if (_context.StudentHistory == null)
            {
                return NotFound();
            }
            return await _context.StudentHistory.ToListAsync();
        }

        // GET: api/StudentHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentHistory>> GetStudentHistory(int id)
        {
            if (_context.StudentHistory == null)
            {
                return NotFound();
            }
            var studentHistory = await _context.StudentHistory.FindAsync(id);

            if (studentHistory == null)
            {
                return NotFound();
            }

            return studentHistory;
        }

        // PUT: api/StudentHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentHistory(int id, StudentHistory studentHistory)
        {
            if (id != studentHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentHistoryExists(id))
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

        // POST: api/StudentHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentHistory>> PostStudentHistory(StudentHistory studentHistory)
        {
            if (_context.StudentHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentHistory'  is null.");
            }
            _context.StudentHistory.Add(studentHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentHistory", new { id = studentHistory.Id }, studentHistory);
        }

        // DELETE: api/StudentHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentHistory(int id)
        {
            if (_context.StudentHistory == null)
            {
                return NotFound();
            }
            var studentHistory = await _context.StudentHistory.FindAsync(id);
            if (studentHistory == null)
            {
                return NotFound();
            }

            _context.StudentHistory.Remove(studentHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentHistoryExists(int id)
        {
            return (_context.StudentHistory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
