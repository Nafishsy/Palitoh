using BLL.DTOs;
using BLL.Services;
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

        [Route("api/palitoh/shop/cart")]
        [HttpPost]
        public HttpResponseMessage addtocart(List<int> ids) //react er store kore rakhte hobe cart 
        {
            var data = MapCustomerFoodService.addOrder(ids);
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

        [Route("api/palitoh/report/vet/{id}/done")]
        [HttpPost]
        public HttpResponseMessage report(ReportDTO obj) //Vet ke report dewar jonno
        {
            var data = ReportService.AddReport(obj);
            return Request.CreateResponse(HttpStatusCode.OK,data);
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
    }
}
