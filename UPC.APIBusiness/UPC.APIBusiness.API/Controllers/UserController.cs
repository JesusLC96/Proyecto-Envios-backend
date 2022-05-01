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
    [ApiController]
    public class UserController : Controller
    {
        protected readonly IUserRepository __UserRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            __UserRepository = userRepository;
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
            var ret = __UserRepository.GetUsers();
            return Json(ret);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getuserbyId")]
        public ActionResult GetUserByID(int id)
        {
            var ret = __UserRepository.GetUserByID(id);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("registerUser")]
        public ActionResult RegistertUser(EntityUser user)
        {
            var ret = __UserRepository.RegistertUser(user);
            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {

            var ret = __UserRepository.Login(login);

            if (ret.issuccess)
            {
                var loginresponse = ret.data as EntityLoginResponse;
                var userid = loginresponse.iduser.ToString();
                var userdni = loginresponse.email;

                //var token = JsonConvert.DeserializeObject<AccessToken>
                  //  (
                  //      await new Authentication().GenerateToken(userdni, userid)
                 //   ).access_token;

                //loginresponse.token = token;
                ret.data = loginresponse;


            }

            return Json(ret);
        }
    }
}
