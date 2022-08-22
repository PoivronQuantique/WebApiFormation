using MediatR;
using SelfieAWookie.API.Application.DTO;

namespace SelfieAWookie.API.Application.Commands
{
    public class AddSelfieCommand : IRequest<SelfieDTO>
    {
        public SelfieDTO SelfieDTO { get; set; }

    }
}
