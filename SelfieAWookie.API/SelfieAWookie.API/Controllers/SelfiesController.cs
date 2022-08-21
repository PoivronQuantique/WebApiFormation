using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
            return this.StatusCode(StatusCodes.Status200OK, model);
        }
    }
}
