using MediatR;
using SelfieAWookie.API.Application.DTO;

namespace SelfieAWookie.API.Application.Queries
{
    public class SelectAllSelfiesQuery : IRequest<List<SelfieResumeDTO>>
    {
        public int WookieId { get; set; }
    }
}
