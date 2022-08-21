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
        private readonly Contexte _Contexte = null;
        public SelfiesController(/*[FromServices]*/Contexte contexte)
        {
            _Contexte = contexte;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _Contexte.Selfies.Include(s=>s.Wookie).Select(item => new { Title = item.Titre, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count}).ToList();
            return this.StatusCode(StatusCodes.Status200OK, model);
        }
    }
}
