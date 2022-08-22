using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.Application.Queries
{
    public class SelectAllSelfiesHandler : IRequestHandler<SelectAllSelfiesQuery, List<SelfieResumeDTO>>
    {
        private readonly ISelfieRepository _Repository = null;
        public SelectAllSelfiesHandler([FromServices] ISelfieRepository repository)
        {
             _Repository = repository;  
        }

        public Task<List<SelfieResumeDTO>> Handle(SelectAllSelfiesQuery request, CancellationToken cancellationToken)
        {
            var result = _Repository.GetAll(request.WookieId).Select(item => new SelfieResumeDTO() { Titre = item.Titre, NomWookie = item.Wookie.Prenom, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return Task.FromResult(result);
        }
    }
}
