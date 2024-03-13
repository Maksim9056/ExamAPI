using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamAPI.Data;
using Microsoft.AspNetCore.Cors;

namespace ExamAPI.Controllers.TestQuestion
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestQuestionsController : ControllerBase
    {
        private readonly ExamAPIContext _context;

        public TestQuestionsController(ExamAPIContext context)
        {
            _context = context;
        }

        // GET: api/TestQuestions
        [HttpGet("GET")]
        public async Task<ActionResult<IEnumerable<ExamAPI.Models.TestQuestion>>> GetTestQuestion()
        {
            return await _context.TestQuestion.Include(u => u.IdTest).Include(u => u.IdQuestions).ToListAsync();
        }

        // GET: api/TestQuestions/5
        [HttpGet("GETId/{id}")]
        public async Task<ActionResult<ExamAPI.Models.TestQuestion>> GetTestQuestion(int id)
        {
            var testQuestion = await _context.TestQuestion.Include(u => u.IdTest).Include(u => u.IdQuestions).FirstOrDefaultAsync(u => u.Id == id);

            if (testQuestion == null)
            {
                return NotFound();
            }

            return testQuestion;
        }

        // PUT: api/TestQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PUTId/{id}")]
        public async Task<IActionResult> PutTestQuestion(int id, ExamAPI.Models.TestQuestion testQuestion)
        {
            if (id != testQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(testQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionExists(id))
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

        // POST: api/TestQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<ExamAPI.Models.TestQuestion>> PostTestQuestion(ExamAPI.Models.TestQuestion testQuestion)
        {
            _context.TestQuestion.Add(testQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestion", new { id = testQuestion.Id }, testQuestion);
        }

        // DELETE: api/TestQuestions/5
        [HttpDelete("DELETE/{id}")]
        public async Task<IActionResult> DeleteTestQuestion(int id)
        {
            var testQuestion = await _context.TestQuestion.FindAsync(id);
            if (testQuestion == null)
            {
                return NotFound();
            }

            _context.TestQuestion.Remove(testQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestionExists(int id)
        {
            return _context.TestQuestion.Any(e => e.Id == id);
        }
    }
}
