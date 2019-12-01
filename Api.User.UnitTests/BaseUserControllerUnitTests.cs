using Api.User.Controllers;
using Api.User.Data;
using Api.User.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.User.UnitTests
{
    public abstract class BaseUserControllerUnitTests
    {
        protected readonly List<AppUser> AppUsers;
        protected readonly Mock<ILogger<UserController>> logger;
        protected readonly Mock<UserContext> _userContext;
        protected readonly UserController UserControllerUnderTest;

        protected BaseUserControllerUnitTests(List<AppUser> appUsers) {
            AppUsers = appUsers;
            logger = new Mock<ILogger<UserController>>();
            _userContext = new Mock<UserContext>();
            UserControllerUnderTest = new UserController(_userContext.Object,logger.Object);
        }
    }
}
