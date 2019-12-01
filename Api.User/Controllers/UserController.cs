using Api.User.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Controllers
{
    [Route("api/users")]
    public class UserController:BaseController
    {
        private UserContext _userContext;
        private ILogger<UserController> _logger;
        public UserController(UserContext userContext, ILogger<UserController> logger) {
            _userContext = userContext;
            _logger = logger;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get() {
            var user = await _userContext.Users
                .Include(u => u.Properties)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == UserIdentity.UserId);
            if(user == null) {
                //return NotFound();
                throw new UserOperationException($"错误的用户上下文 Id { UserIdentity.UserId }");
            }
            return Json(user);
        }

        [Route("")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody]JsonPatchDocument<Models.AppUser> patch) {
            var user = await _userContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == UserIdentity.UserId);

            var properties = await _userContext.Properties.AsNoTracking().SingleOrDefaultAsync(u => u.AppUserId == UserIdentity.UserId);
            if (properties != null) {
                _userContext.Properties.RemoveRange(properties);
            }
            
            patch.ApplyTo(user);
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
            
            return Json(user);
        }

    }
}
