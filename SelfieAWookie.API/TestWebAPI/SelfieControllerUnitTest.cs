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
            var controller = new SelfiesController();

            // ACT
            var result = controller.Get();

            // ASSERT
            Assert.NotNull(result); 
            Assert.
            Assert.True(result.Count() > 0);    


        }
    }
}