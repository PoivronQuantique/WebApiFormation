using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.Application.Commands
{
    public class AddPhotoHandler : IRequestHandler<AddPhotoCommand, Photo>
    {
        private readonly ISelfieRepository _Repository = null;
        private readonly IWebHostEnvironment _HostEnvironment = null;
        public AddPhotoHandler([FromServices] ISelfieRepository repository, [FromServices] IWebHostEnvironment HostEnvironment)
        {
            _Repository = repository;
            _HostEnvironment = HostEnvironment;
        }

        public Task<Photo> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            string FilePath = Path.Combine(_HostEnvironment.ContentRootPath, "Images", "Selfies");
            Photo result = null;
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            FilePath = Path.Combine(FilePath, request.photoFile.FileName);

            using (var stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                request.photoFile.CopyTo(stream);
            }

            result = _Repository.AddOnePhoto(FilePath);
            _Repository.UnitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
