﻿using ExamAPI.Data;
using ExamAPI.Models;
using Microsoft.AspNetCore.Cors;


//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Controllers.ExamsTests
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]

    public class ExamsTestsController : ControllerBase
    {
        private readonly ExamAPIContext _context;

        public ExamsTestsController(ExamAPIContext context)
        {
            _context = context;
        }

        // GET: api/ExamsTests
        [HttpGet("GET")]
        public async Task<ActionResult<IEnumerable<ExamsTest>>> GetExamsTest()
        {
            return await _context.ExamsTest.Include(u => u.Test).Include(u => u.Exams).ToListAsync();
        }

        // GET: api/ExamsTests/5
        [HttpGet("GETId/{id}")]
        public async Task<ActionResult<ExamsTest>> GetExamsTest(int id)
        {
            var examsTest = await _context.ExamsTest.Include(u => u.Test).Include(u => u.Exams).FirstOrDefaultAsync(u => u.Id == id);

            if (examsTest == null)
            {
                return NotFound();
            }

            return examsTest;
        }

        // PUT: api/ExamsTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PUTId/{id}")]
        public async Task<IActionResult> PutExamsTest(int id, ExamsTest examsTest)
        {
            if (id != examsTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(examsTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamsTestExists(id))
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

        // POST: api/ExamsTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<ExamsTest>> PostExamsTest(ExamsTest examsTest)
        {
            _context.ExamsTest.Add(examsTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamsTest", new { id = examsTest.Id }, examsTest);
        }

        // DELETE: api/ExamsTests/5
        [HttpDelete("DELETE/{id}")]
        public async Task<IActionResult> DeleteExamsTest(int id)
        {
            var examsTest = await _context.ExamsTest.FindAsync(id);
            if (examsTest == null)
            {
                return NotFound();
            }

            _context.ExamsTest.Remove(examsTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamsTestExists(int id)
        {
            return _context.ExamsTest.Any(e => e.Id == id);
        }
    }
}
