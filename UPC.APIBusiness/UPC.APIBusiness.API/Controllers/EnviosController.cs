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

namespace UPC.APIBusiness.API.Controllers
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
        [AllowAnonymous]
        [HttpGet]
        [Route("listarenvios")]
        public ActionResult GetEnvios()
        {
            var ret = __EnviosRepository.GetEnvios();
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
