using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Palitoh.Controllers
{
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(AccountDTO user)
        {
            var token = AuthService.Authenticate(user);
            if(token != null)
            {
                var acc = AccountService.GetAccount(token.AccountId);
                return Request.CreateResponse(HttpStatusCode.OK, new { Token = token, user = acc });
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,"User not found");
        }
    }
}
