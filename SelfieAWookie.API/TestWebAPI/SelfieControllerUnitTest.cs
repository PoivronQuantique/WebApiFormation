using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Controllers;
using Xunit;

namespace TestWebAPI
{
    public class SelfieControllerUnitTest
    {
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // ARRANGE
            var controller = new SelfiesController(null);

            // ACT
            var result = controller.Get();

            // ASSERT
            Assert.NotNull(result);


        }
    }
}