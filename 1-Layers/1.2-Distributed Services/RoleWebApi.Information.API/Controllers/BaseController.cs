namespace RoleWebApi.Information.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RoleWebApi.Information.API._Code.ExceptionHandling;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;

    [ServiceFilter(typeof(ApiActionFilter))]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAllCORS")]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
    }
}