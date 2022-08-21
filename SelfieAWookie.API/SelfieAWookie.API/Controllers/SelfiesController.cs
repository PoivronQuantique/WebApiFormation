using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        private readonly ISelfieRepository _SelfieRepository = null;
        public SelfiesController([FromServices] ISelfieRepository selfieRepository)
        {
            _SelfieRepository = selfieRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _SelfieRepository.GetAll().Select(item => new { Title = item.Titre, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return this.StatusCode(StatusCodes.Status200OK, model);
        }
    }
}
