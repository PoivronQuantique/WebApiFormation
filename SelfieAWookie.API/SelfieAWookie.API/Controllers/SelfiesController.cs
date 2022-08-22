using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.API.Extensions;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors(SecuriteMethodes.DEFAULT_POLICY)]
    public class SelfiesController : ControllerBase
    {
        private readonly ISelfieRepository _SelfieRepository = null;
        private readonly IWebHostEnvironment _HostEnvironment = null;
        public SelfiesController([FromServices] ISelfieRepository selfieRepository, [FromServices] IWebHostEnvironment HostEnvironment = null)
        {
            _SelfieRepository = selfieRepository;
            _HostEnvironment = HostEnvironment;
        }

        [HttpGet]
        [DisableCors]
        public IActionResult GetAll([FromQuery] int wookieId = 0)
        {
            var model = _SelfieRepository.GetAll(wookieId).Select(item => new SelfieResumeDTO() { Titre = item.Titre, NomWookie = item.Wookie.Prenom, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return this.StatusCode(StatusCodes.Status200OK, model);
        }

        [HttpPost]
        [EnableCors(SecuriteMethodes.DEFAULT_POLICY)]
        public IActionResult AddOne(SelfieDTO selfie)
        {
            IActionResult result = this.BadRequest();

            Selfie addSelfie = _SelfieRepository.AddOne(new Selfie()
            {
                Titre = selfie.Titre,
                ImagePath = selfie.ImagePath,
                Description = selfie.Description,
                WookieId = selfie.IdWookie
            });

            _SelfieRepository.UnitOfWork.SaveChanges();

            if(addSelfie != null)
            {
                selfie.Id = addSelfie.Id;
                result =  this.StatusCode(StatusCodes.Status200OK, selfie);
            }

            return result;
        }

        //[Route("Photos")]
        //[HttpPost]
        //public async Task<IActionResult> AddPhoto()
        //{
        //    using (var stream = new StreamReader(this.Request.Body))
        //    {
        //        var content = await stream.ReadToEndAsync();

        //    }
        //    return this.Ok();
        //}

        [Route("Photos")]
        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile photoFile)
        {
            string FilePath = Path.Combine(_HostEnvironment.ContentRootPath, "Images", "Selfies");
            if(!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            FilePath = Path.Combine(FilePath, photoFile.FileName);

            using (var stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                await photoFile.CopyToAsync(stream);
            }

            _SelfieRepository.AddOnePhoto(FilePath);
            _SelfieRepository.UnitOfWork.SaveChanges();

            return this.Ok();
        }
    }
}
