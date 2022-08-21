using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.Application.DTO;
using SelfieAWookie.API.Controllers;
using SelfieAWookie.Core.Selfies.Domain;
using System.Collections.Generic;
using Xunit;

namespace TestWebAPI
{
    public class SelfieControllerUnitTest
    {
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // ARRANGE
            var MonMock = new Mock<ISelfieRepository>();
            MonMock.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie()
                {
                    Id = 1,
                    Titre = "Ceci est un test 1",
                    ImagePath = null,
                    Wookie = new Wookie()
                    {
                        Id = 1,
                        Prenom = "Prénom"
                    }
                },
                new Selfie()
                {
                    Id = 2,
                    Titre = "Ceci est un test 2",
                    ImagePath = null,
                    Wookie = new Wookie()
                    {
                        Id = 1,
                        Prenom = "Prénom2"
                    }
                }
            });
            var controller = new SelfiesController(MonMock.Object);

            // ACT
            var result = controller.Get();

            // ASSERT
            Assert.NotNull(result);
            ObjectResult or = result as ObjectResult;
            Assert.NotNull(or);
            Assert.True(or.StatusCode == 200);
            Assert.NotNull(or.Value);
            Assert.IsType<List<SelfieResumeDTO>>(or.Value);
            List<SelfieResumeDTO> liste = or?.Value as List<SelfieResumeDTO>;
            Assert.True(liste?.Count == 2);

        }
    }
}