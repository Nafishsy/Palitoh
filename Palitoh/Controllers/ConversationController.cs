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
    [EnableCors("*", "*", "*")]
    [CustomAuth]
    public class ConversationController : ApiController
    {
        [Route("api/chat/oldmessages/{id}")]
        [HttpGet]
        public HttpResponseMessage WholeChat(int id) //can see his schedule
        {
            var data = ConversationService.GetConversationByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/sendtext")]
        [HttpPost]
        public HttpResponseMessage SendText(ConversationDTO ct ) //can see his schedule
        {
            var data = ConversationService.AddConversation(ct);
            return Request.CreateResponse(HttpStatusCode.OK, ct);
        }
    }
}
