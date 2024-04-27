using Labb3_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILink _linkRepo;

        public LinkController(ILink linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet("Links")]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _linkRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }


    }
}
