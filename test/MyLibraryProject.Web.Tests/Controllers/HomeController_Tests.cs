using System.Threading.Tasks;
using MyLibraryProject.Models.TokenAuth;
using MyLibraryProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyLibraryProject.Web.Tests.Controllers
{
    public class HomeController_Tests: MyLibraryProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}