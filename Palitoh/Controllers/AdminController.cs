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
using System.Web.UI;

namespace Palitoh.Controllers
{

    [EnableCors("*", "*", "*")]
    [CustomAuth]

    public class AdminController : ApiController
    {
        //[CustomAuth]
        //Account Table
        [Route("api/Accounts")] //All accounts list show
        [HttpGet]
        public HttpResponseMessage GetAllAccounts()
        {
            var data = AccountService.GetAllAccountsAdmin();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Accounts/user/Count")] //All accounts for graph
        [HttpGet]
        public HttpResponseMessage AccountsPerType()
        {
            var data = AccountService.AccountsPerType();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/accounts/search/")] //All accounts list er upor search
        [HttpPost]
        public HttpResponseMessage SearchFromGetAllAccounts(AccountDTO obj)
        {
            var data = AccountService.SearchIntoGetAllAccounts(obj.Name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [Route("api/Account/{id}")] // Single user info show
        [HttpGet]
        public HttpResponseMessage GetAccount(int id)
        {
            var data = AccountService.GetAccount(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/users/delete/{id}")] //Permanently ban user
        [HttpPost]
        public HttpResponseMessage DeleteUser(int id)
        {
            var data = AccountService.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Account/delete")] //Permanently ban user
        [HttpPost]
        public HttpResponseMessage DeleteAccount(AccountDTO obj)
        {
            var data = AccountService.DeleteAccount(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Account/temporaryBan")] //Temporarily ban user
        [HttpPost]
        public HttpResponseMessage BanAccount(AccountDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AccountService.BanAccount(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Banned", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Account/Acrivate")] //Activate user
        [HttpPost]
        public HttpResponseMessage ActivateAccount(AccountDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AccountService.ActivateAccount(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Activated", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        

        [Route("api/Account/edit")] //Edit user info
        [HttpPost]
        public HttpResponseMessage EditAccount(AccountDTO obj)
        {
            var res = AccountService.UpdateAccount(obj);
            if (res != null)
            {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
            
        }

       /* [Route("api/Account/edit")] //Edit user info
        [HttpPost]
        public HttpResponseMessage EditAccount(AccountDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AccountService.EditAccount(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        */


        //Admin Table
        [Route("api/Admins")] //Admin info show
        [HttpGet]
        public HttpResponseMessage GetAllAdmins()
        {
            var data = AdminService.GetAllAdmins();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/{id}")] //Single admin info show
        [HttpGet]
        public HttpResponseMessage GetAdmin(int id)
        {
            var data = AdminService.GetAdmin(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/delete")] //Delete admin
        [HttpPost]
        public HttpResponseMessage DeleteAdmin(AdminDTO obj)
        {
            var data = AdminService.DeleteAdmin(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/add")] //Add new admin
        [HttpPost]
        public HttpResponseMessage AddAdmin(AdminDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AdminService.AddAdmin(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Admin/edit")] //Edit admin info
        [HttpPost]
        public HttpResponseMessage EditAdmin(AdminDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AdminService.EditAdmin(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //Token Table
        [Route("api/Tokens")]
        [HttpGet]
        public HttpResponseMessage GetAllTokens()
        {
            var data = TokenService.GetAllTokens();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Token/{id}")]
        [HttpGet]
        public HttpResponseMessage GetToken(int id)
        {
            var data = TokenService.GetToken(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Token/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteToken(TokenDTO obj)
        {
            var data = TokenService.DeleteToken(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Token/add")]
        [HttpPost]
        public HttpResponseMessage AddToken(TokenDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = TokenService.AddToken(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Token/edit")]
        [HttpPost]
        public HttpResponseMessage EditToken(TokenDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = TokenService.EditToken(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //Report Table
        [Route("api/Reports")] //All reports 
        [HttpGet]
        public HttpResponseMessage GetAllReports()
        {
            var data = ReportService.AllReports();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/reports/search/")] //All reports 
        [HttpPost]
        public HttpResponseMessage SearchReports(AccountDTO obj)
        {
            var data = ReportService.SearchReports(obj.Name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        /*[Route("api/Reports")] //All reports get
        [HttpGet]
        public HttpResponseMessage GetAllReports()
        {
            var data = ReportService.GetAllReports();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }*/

        [Route("api/Report/{id}")] //Single report get
        [HttpGet]
        public HttpResponseMessage GetReport(int id)
        {
            var data = ReportService.GetReport(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/delete")] //Delete report
        [HttpPost]
        public HttpResponseMessage DeleteReport(ReportDTO obj)
        {
            var data = ReportService.DeleteReport(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/add")] //Add new report
        [HttpPost]
        public HttpResponseMessage AddReport(ReportDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = ReportService.AddReport(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Report/edit")] //Edit report
        [HttpPost]
        public HttpResponseMessage EditReport(ReportDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = ReportService.EditReport(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //Nevigation values
        [Route("api/Accounts/{id}/Reports")] //Account with reports
        [HttpGet]
        public HttpResponseMessage AccountWithReports(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AccountService.AccountWithReports(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Accounts/{id}/Tokens")] //Account with tokens
        [HttpGet]
        public HttpResponseMessage AccountWithTokens(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AccountService.AccountWithTokens(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Shop/{id}/Employees")] //Shop with employees
        [HttpGet]
        public HttpResponseMessage ShopWithEmployees(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ShopService.ShopWithEmployees(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Shop/{id}/Pets")] //Shop with pets
        [HttpGet]
        public HttpResponseMessage ShopWithPets(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ShopService.ShopWithPets(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Shop/{id}/Foods")] //Shop with foods
        [HttpGet]
        public HttpResponseMessage ShopWithFoods(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ShopService.ShopWithFoods(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/Consultations/Details")] //Admin deatils dekhbe consulation er
        [HttpGet]
        public HttpResponseMessage ConsultationDetails()
        {
            var data = MapCustomerVetService.ConsultationData();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/Shop/Details")] //Admin deatils dekhbe consulation er
        [HttpGet]
        public HttpResponseMessage ShopDetails()
        {
            var data = MapCustomerVetService.ShopData();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


    }
}
