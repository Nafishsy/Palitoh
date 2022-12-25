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
using System.Web.ModelBinding;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using static System.Net.Mime.MediaTypeNames;

namespace Palitoh.Controllers
{
    [EnableCors("*", "*", "*")]
    [CustomAuth]
    public class CustomerController : ApiController
    {
        public System.Web.SessionState.HttpSessionState Session { get; set; }

        [Route("api/vets/all")]
        [HttpGet]
        public HttpResponseMessage VetList() //Customer Can see All Vets
        {
            var data = VetService.GetAllVetsInfo();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/appointment/request/vet")]
        [HttpPost]
        public HttpResponseMessage AppointmentReq(MapCustomerVetDTO obj) //Customer can consult
        {
            var data = MapCustomerVetService.SetAppointment(obj);
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/customer/appointment/consult")]
        [HttpGet]
        public HttpResponseMessage Consult() //Customer can consult
        {
            //HEHE
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/customer/appointment/history/{id}")]
        [HttpGet]
        public HttpResponseMessage History(int id) //Past consultation
        {
            var data = MapCustomerVetService.GetAppointmentsHistoryUser(System.DateTime.Now,id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/adoptions")]
        [HttpGet]
        public HttpResponseMessage adoption() //Adoption //Only Pet's status Available
        {
            var data = PetService.GetAvailablePets();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/adoptions/{id}/adopt")]
        [HttpGet]
        public HttpResponseMessage adopt(int id) //Adoption //Only Pet's status Available //Pet id , Customer iD, Time of delivery.
        {
            var data = MapCustomerPetService.Adopt(id, 1, DateTime.Now);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/rescue/")]
        [HttpGet]
        public HttpResponseMessage rescueReq(int id)
        {
            //addiotnal work
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/palitoh/shop")]
        [HttpGet]
        public HttpResponseMessage Shop() //Inventory dekhbo
        {
            var data = FoodService.GetAllFoods();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/shop/cart/{customer_id}")]
        [HttpPost]
        public HttpResponseMessage addtocart(List<int> ids,int customer_id) //react er store kore rakhte hobe cart //Cart e loop diya  insertion
        {
            var data = MapCustomerFoodService.addOrder(ids,customer_id);
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/palitoh/shop/{id}/request")]
        [HttpPost]
        //NOT IMPLEMENTED
        public HttpResponseMessage RequestItem(int id) //Request Item jeta MapCustomerFood e jabega //Request Item gular customerId 0
        {
            // var data = MapCustomerFoodService.AddMapCustomerFood(new { });
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [Route("api/palitoh/report/vet/{name}")]
        [HttpGet]
        public HttpResponseMessage reportVetID(string name) //Vet ke report dewar jonno Id lagbe oita ani
        {
            var data = AccountService.GetAllAccounts().Find(ac => ac.Name == name && ac.Type == "Vet");
            return Request.CreateResponse(HttpStatusCode.OK, data.Id);
        }

        [Route("api/palitoh/report/item/{name}")]
        [HttpGet]

        //Reports e ACC_id ache Food Id er jonno kisu nai
        public HttpResponseMessage reportItemID(string name) //Food ke report dewar jonno Id lagbe oita ani
        {
            //Food report dewar jonno proper kisu nai
            var data = FoodService.GetAllFoods().Find(ac => ac.Name == name);
            return Request.CreateResponse(HttpStatusCode.OK, data.Id);
        }

        [Route("api/palitoh/customer/search")]
        [HttpPost]

        public HttpResponseMessage SearchCutomser(AccountDTO obj)
        //ACC table e username diye search maira id er against e customer table ansi name soho
        { 
            var data = CustomerService.SearchCutomser(obj.Name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/pets/")]
        [HttpGet]

        public HttpResponseMessage AllPets()
        //ACC table e username diye search maira id er against e customer table ansi name soho
        {
            var data = PetService.GetAvailablePets();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/vets/report/")]
        [HttpPost]

        public HttpResponseMessage AddReport(ReportDTO rt)
        //ACC table e username diye search maira id er against e customer table ansi name soho
        {
            var data = ReportService.AddReport(rt);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/addkori")]
        [HttpPost]
        //Testing api
        public HttpResponseMessage Add(VetDTO ct)
        //ACC table e username diye search maira id er against e customer table ansi name soho
        {
            var data = VetService.AddVet(ct);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/customer/{id}/Appoinments")]
        [HttpGet]
        [CustomAuth]

        public HttpResponseMessage Appoinments(int id) //can see his schedule
        {
            var data = MapCustomerVetService.GetAppointmentsOfCus(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/palitoh/shop/history/{id}")]
        [HttpGet]

        public HttpResponseMessage OldOrder(int id) //can see his schedule
        {
            var data = MapCustomerFoodService.GetAllCartCustomer(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
