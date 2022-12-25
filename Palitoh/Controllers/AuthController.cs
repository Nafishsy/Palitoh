using BLL.DTOs;
using BLL.Services;
using Palitoh.Auth;
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
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [AllowAnonymous]

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

        [Route("api/logout")]
        [HttpPost]
        public HttpResponseMessage Logout(AccountDTO user)
        {
            var account = AccountService.GetAccount(user.Id);
            var token = AuthService.Authenticate(account);
            if(AuthService.Logout(token.AccessToken))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "NO token");

        }
    }
}
