﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Palitoh.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(AccountDTO user)
        {
            var token = AuthService.Authenticate(user);
            if(token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,"User not found");
        }
    }
}
