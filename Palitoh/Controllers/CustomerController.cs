using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Palitoh.Controllers
{
    public class CustomerController : ApiController
    {

        [Route("api/vet/all")]
        [HttpGet]
        public HttpResponseMessage VetList() //Customer Can see All Vets
        {
            var data = VetService.GetAllVets();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/appointment/consult")]
        [HttpGet]
        public HttpResponseMessage Consult() //Customer can consult
        {
            //HEHE
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/customer/appointment/history")]
        [HttpGet]
        public HttpResponseMessage History() //Past consultation
        {
            var data = MapCustomerVetService.GetAppointmentsByTime(System.DateTime.Now);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
