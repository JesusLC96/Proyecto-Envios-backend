using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        protected readonly ILoginRepository __LoginRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRepository"></param>
        public LoginController(ILoginRepository loginRepository)
        {
            __LoginRepository = loginRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listarusuarios")]
        public ActionResult GetUsers()
        {
            var ret = __LoginRepository.GetUsers();
            return Json(ret);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getuser")]
        public ActionResult GetUserByID(int id)
        {
            var ret = __LoginRepository.GetUserByID(id);
            return Json(ret);
        }
    }
}
