﻿using Api.User.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Controllers
{
    public class BaseController:Controller
    {
        protected UserIdentity UserIdentity => new UserIdentity { UserId = 1, Name = "tanzb" };
    }
}
