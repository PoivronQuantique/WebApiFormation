using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.API.Application.Queries;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Framework;

namespace SelfieAWookie.API.Application.Commands
{
    public class AddSelfieHandler : IRequestHandler<AddSelfieCommand, SelfieDTO>
    {
        private readonly ISelfieRepository _Repository = null;
        public AddSelfieHandler([FromServices] ISelfieRepository repository)
        {
            _Repository = repository;
        }

        public Task<SelfieDTO> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
        {
            SelfieDTO result = null;

            Selfie addSelfie = _Repository.AddOne(new Selfie()
            {
                Titre = request.SelfieDTO.Titre,
                ImagePath = request.SelfieDTO.ImagePath,
                Description = request.SelfieDTO.Description,
                WookieId = request.SelfieDTO.WookieId,
                PhotoId = request.SelfieDTO.ImageId
            });

            _Repository.UnitOfWork.SaveChanges();

            if (addSelfie != null)
            {
                request.SelfieDTO.Id = addSelfie.Id;
                result = request.SelfieDTO;
            }
            return Task.FromResult(result);
        }
    }
}
