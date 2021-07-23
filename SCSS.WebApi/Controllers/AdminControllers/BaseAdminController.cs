﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCSS.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCSS.WebApi.Controllers.AdminControllers
{
    [Route(ApplicationRestfulApi.BaseApiUrl)]
    [Produces(ApplicationRestfulApi.ApplicationProduce)]
    [ApiController]
    [Authorize(Policy = SystemPolicy.AdminPolicy)]
    public class BaseAdminController : ControllerBase
    {
    }
}
