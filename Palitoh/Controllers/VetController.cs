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
    public class VetController : ApiController
    {
        [Route("api/vet/appointments/{id}")]
        [HttpGet]
        public HttpResponseMessage Appoinments(int id) //can see his schedule
        {
            var data = MapCustomerVetService.GetAppointmentsOfVet(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/appointments/add")]
        [HttpPost]
        public HttpResponseMessage CreateAppoinment(MapCustomerVetDTO appoint) //CreateAppoinment
        {           
            var data = MapCustomerVetService.AddMapCustomerVet(appoint);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/appointments/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteAppoinment(int id) //CreateAppoinment
        {
            var appoint = MapCustomerVetService.GetMapCustomerVet(id);
            var data = MapCustomerVetService.DeleteMapCustomerVet(appoint);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/appointments/search")]
        [HttpPost]
        public HttpResponseMessage SearchByDate(MapCustomerVetDTO obj) //CreateAppoinment
        {
            var data = MapCustomerVetService.GetAppointmentsByTime(obj.AppointmentDate);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/appointments/update")]
        [HttpPost]
        public HttpResponseMessage UpdateAppoinment(MapCustomerVetDTO appoint) //CreateAppoinment
        {
            var data = MapCustomerVetService.EditMapCustomerVet(appoint);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/appointments/consult/{id}")]
        [HttpGet]
        public HttpResponseMessage Consultation(int id) //consult will take you to a chatting system
        {
            /*var data = MapCustomerVetService.GetMapCustomerVet(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);*/
            return null;
        }

        [Route("api/vet/{id}")]
        [HttpPost]
        public HttpResponseMessage GetVet(int id) //Get a vet's info
        {
            var data = VetService.GetVet(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/vet/update")]
        [HttpPost]
        public HttpResponseMessage UpdateVet(VetDTO vet) //Update vet's info
        {
            var data = VetService.EditVet(vet);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/vet/search")]
        [HttpPost]

        public HttpResponseMessage SearchVet(AccountDTO obj)
        //ACC table e username diye search maira id er against e customer table ansi name soho
        {
            var data = VetService.SearchVet(obj.Name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
