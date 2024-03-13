using ExamAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamAPI.Models;

namespace ExamAPI.Controllers.Exam
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ExamAPIContext _context;

        public ExamController(ExamAPIContext context)
        {
            _context = context;
        }

        // GET: api/Exam
        [HttpGet("GET")]
        public async Task<ActionResult<IEnumerable<ExamAPI.Models.Exam>>> GetExam()
        {
            return await _context.Exam.Include(u => u.Exams).Include(u => u.Questtion).Include(u => u.User).ToListAsync();
        }

        // GET: api/Exam/5
        [HttpGet("GETId/{id}")]
        public async Task<ActionResult<ExamAPI.Models.Exam>> GetExam(int id)
        {
            var exam = await _context.Exam.Include(u => u.Exams).Include(u => u.Questtion).Include(u => u.User).FirstOrDefaultAsync(u => u.Id == id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PUTId/{id}")]
        public async Task<IActionResult> PutExam(int id, ExamAPI.Models.Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<ExamAPI.Models.Exam>> PostExam(ExamAPI.Models.Exam exam)
        {
            _context.Exam.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exam/5
        [HttpDelete("DELETE/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.Id == id);
        }
    }
}
