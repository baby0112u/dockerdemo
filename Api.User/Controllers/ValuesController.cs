using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.User.Data;
using Api.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UserContext _userContext;
        public ValuesController(UserContext userContext)
        {
            _userContext = userContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<AppUser> Get()
        {
            return await _userContext.Users.SingleOrDefaultAsync(u=>u.Name == "tanzb");
        }

    }
}
