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
        [AllowAnonymous]
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

        [Route("api/logout")]
        [HttpPost]
        [AllowAnonymous]

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

        [Route("api/Add/account")] 
        [HttpPost]
        public HttpResponseMessage AddAccount(AccountDTO obj) //Using for Login
        {
            var res = AccountService.AddAccount(obj);
            if (obj.Type == "Customer")
            {

                CustomerDTO cst = new CustomerDTO();
                cst.Id = res.Id;
                cst.Location = "empty";
                cst.Balance = 5000;
                var customer = CustomerService.AddCustomer(cst);
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            else if (obj.Type == "Vet")
            {

                VetDTO vt = new VetDTO();
                vt.Id = res.Id;
                vt.Designation = "empty";
                vt.AppointmentFees = 1000;
                vt.Location = "empty";
                var vet = VetService.AddVet(vt);
                return Request.CreateResponse(HttpStatusCode.OK, vet);
            }
            else if (obj.Type == "Shop")
            {

                ShopDTO sh = new ShopDTO();
                sh.Id = res.Id;
                sh.Location = "empty";

                var shop = ShopService.AddShop(sh);
                return Request.CreateResponse(HttpStatusCode.OK, shop);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
            //return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = ModelState.Values.SelectMany(v => v.Errors) });


        }
    }
}
