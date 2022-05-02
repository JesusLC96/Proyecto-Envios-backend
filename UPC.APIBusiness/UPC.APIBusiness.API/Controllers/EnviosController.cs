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
using API.Security;
using System;

namespace API.Controllers
{
    public class EnviosController : Controller
    {
        protected readonly IEnviosRepository __EnviosRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enviosRepository"></param>
        public EnviosController(IEnviosRepository enviosRepository)
        {
            __EnviosRepository = enviosRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("listarenvios")]
        public ActionResult GetEnvios()
        {
            //var accessToken = Request.Headers["Authorization"];
            
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userid = claims.Where(p => p.Type == "client_client_codigo_usuario").FirstOrDefault()?.Value;
            //var ret = __EnviosRepository.GetEnvios();

            var ret = __EnviosRepository.GetEnvioxUsuario(int.Parse(userid));

            return Json(ret);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("enviosxusuario")]
        public ActionResult GetEnvioxUsuario(int id)
        {
            var ret = __EnviosRepository.GetEnvioxUsuario(id);
            return Json(ret);
        }
    }
}
