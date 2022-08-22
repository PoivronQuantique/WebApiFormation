using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Application.Commands;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.API.Application.Queries;
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
        private readonly IMediator _Mediator;
        public SelfiesController([FromServices] ISelfieRepository selfieRepository,[FromServices] IMediator mediator, [FromServices] IWebHostEnvironment HostEnvironment = null)
        {
            _SelfieRepository = selfieRepository;
            _HostEnvironment = HostEnvironment;
            _Mediator = mediator;
        }

        [HttpGet]
        [DisableCors]
        public async Task<IActionResult> GetAll([FromQuery] int wookieId = 0)
        {
            IActionResult result = this.BadRequest();
            var model = await  _Mediator.Send(new SelectAllSelfiesQuery() { WookieId = wookieId});
            if(model != null)
                result = this.StatusCode(StatusCodes.Status200OK, model);

            return result;
        }

        [HttpPost]
        [EnableCors(SecuriteMethodes.DEFAULT_POLICY)]
        public async Task<IActionResult> AddOne([FromBody] SelfieDTO selfie)
        {
            IActionResult result = this.BadRequest();

            var item = await _Mediator.Send(new AddSelfieCommand() { SelfieDTO = selfie });
            if(item != null)
                result = this.StatusCode(StatusCodes.Status200OK, item);

            return result;
        }


        [Route("Photos")]
        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile photoFile)
        {
            IActionResult result = this.BadRequest();

            var item = await _Mediator.Send(new AddPhotoCommand() { photoFile = photoFile });
            if (item != null)
                result = this.StatusCode(StatusCodes.Status200OK, item);

            return result;
            //string FilePath = Path.Combine(_HostEnvironment.ContentRootPath, "Images", "Selfies");
            //if(!Directory.Exists(FilePath))
            //{
            //    Directory.CreateDirectory(FilePath);
            //}
            //FilePath = Path.Combine(FilePath, photoFile.FileName);

            //using (var stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            //{
            //    await photoFile.CopyToAsync(stream);
            //}

            //_SelfieRepository.AddOnePhoto(FilePath);
            //_SelfieRepository.UnitOfWork.SaveChanges();

            //return this.Ok();
        }
    }
}
