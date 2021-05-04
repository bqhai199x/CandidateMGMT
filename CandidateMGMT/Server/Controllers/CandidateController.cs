using CandidateMGMT.Server.Services;
using CandidateMGMT.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMGMT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/Candidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidate()
        {
            try
            {
                return Ok(await _candidateService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/Candidate/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            try
            {
                var result = await _candidateService.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/Candidate/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> PutCandidate(int id, Candidate candidate)
        {
            try
            {
                if (id != candidate.CandidateId)
                    return BadRequest("Candidate ID mismatch");

                var candidateToUpdate = await _candidateService.GetById(id);

                if (candidateToUpdate == null)
                    return NotFound($"Candidate with Id = {id} not found");

                return await _candidateService.Update(candidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/Candidate
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            try
            {
                if (candidate == null)
                    return BadRequest();

                var createdCandidate = await _candidateService.Create(candidate);

                return CreatedAtAction(nameof(GetCandidate),
                    new { id = createdCandidate.CandidateId }, createdCandidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new candidate record");
            }
        }

        // DELETE: api/Candidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            try
            {
                var candidateToDelete = await _candidateService.GetById(id);

                if (candidateToDelete == null)
                {
                    return NotFound($"Candidate with Id = {id} not found");
                }

                return await _candidateService.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
