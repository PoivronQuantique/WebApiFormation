using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SelfieAWookie.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Selfie> Get()
        {
            return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        }
    }
}
