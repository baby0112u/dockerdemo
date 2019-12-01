using Api.User.Models;
using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Api.User.Controllers;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using Api.User.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Api.User.UnitTests
{
    //public class UserControllerUnitTests : BaseUserControllerUnitTests
    public class UserControllerUnitTests 
    {

        private UserContext GetUserContext() {
            var options = new DbContextOptionsBuilder<Data.UserContext>().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var userContext = new Data.UserContext(options);

            userContext.Users.Add(new AppUser {
                Id = 1, Name = "jesse"
            });

            userContext.SaveChanges();
            return userContext;
        }

        private (UserController,UserContext) GetUserController() {
            var userContext = GetUserContext();
            var loggerMoq = new Mock<ILogger<UserController>>();
            var logger = loggerMoq.Object;
            var controller = new UserController(userContext, logger);

            return (controller, userContext);
        }

        [Fact]
        public async Task GetUserById_ReturnCorrectUserAsync() {
            //var user = await UserControllerUnderTest.Get();

            (UserController controller, UserContext userContext) = GetUserController();

            var response = await controller.Get();

            var result = response.Should().BeOfType<JsonResult>().Subject;

            var appUser = result.Value.Should().BeAssignableTo<AppUser>().Subject;

            appUser.Id.Should().Be(1);
            appUser.Name.Should().Be("jesse");
        }


        [Fact]
        public async Task Patch_ReturnNewName_WithExpectedNewParamter() {
            //var user = await UserControllerUnderTest.Get();

            (UserController controller, UserContext userContext) = GetUserController();
            var document = new JsonPatchDocument<AppUser>();
            document.Replace(u => u.Name, "tanzb");

            var response = await controller.Patch(document);
            var result = response.Should().BeOfType<JsonResult>().Subject;

            var appUser = result.Value.Should().BeAssignableTo<AppUser>().Subject;
            appUser.Name.Should().Be("tanzb");

            var userModel = await userContext.Users.SingleOrDefaultAsync(u => u.Id == 1);
            userModel.Should().NotBeNull();
            userModel.Name.Should().Be("tanzb");
        }
    }
}
