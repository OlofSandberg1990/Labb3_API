

using Labb3_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterest _interestRepository;

        public InterestController(IInterest interest)
        {
            _interestRepository = interest;
        }

        [HttpGet("Interests")]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interestRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

    }
}
