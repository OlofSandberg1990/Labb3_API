using Labb3_API.Models;
using Labb3_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _personRepository;
        public PersonController(IPerson person)
        {
            _personRepository = person;
        }


        [HttpGet("GetAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _personRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database.......");
            }
        }

        [HttpGet("GetInterest/{id:int}")]
        public async Task<IActionResult> GetAllInterests(int id)
        {
            try
            {
                return Ok(await _personRepository.GetInterestById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database.......");
            }
        }

        [HttpGet("GetLinksForPerson/{id:int}")]
        public async Task<IActionResult> GetAllLinksByPerson(int id)
        {
            try
            {
                var result = await _personRepository.GetLinksById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data to database");
            }
        }

        [HttpPost("AddNewInterestForPerson/{personId:int}/{interestId:int}")]
        public async Task<IActionResult> AddNewInterestToPerson(int personId, int interestId)
        {
            try
            {
                var newPersonInterest = await _personRepository.AddNewPersonInterest(personId, interestId);

                // Kontrollera om ingen ny relation skapades
                if (newPersonInterest == null)
                {
                    return BadRequest("The relation already exists in the database");
                }

                // Om relationen är helt ny och korrekt skapad
                return Ok(newPersonInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add new data to database");
            }
        }

        [HttpPost("AddNewLinkForPerson/{personId:int}/{interestId:int}")]
        public async Task<IActionResult> AddNewLinkToPerson(int personId, int interestId, [FromBody] string url)
        {
            try
            {
                var newLink = await _personRepository.AddLink(personId, interestId, url);
                if (newLink == null)
                {
                    return NotFound("No relation found");
                }
                return Ok(newLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add new data to database");
            }
        }

    }
}
