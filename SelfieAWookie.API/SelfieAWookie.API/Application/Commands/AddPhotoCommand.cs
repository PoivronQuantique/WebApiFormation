using MediatR;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.Application.Commands
{
    public class AddPhotoCommand : IRequest<Photo>
    {
        public IFormFile photoFile { get; set; }
    }
}
