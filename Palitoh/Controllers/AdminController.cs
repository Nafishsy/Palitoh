using BLL.DTOs;
using BLL.Services;
using Palitoh.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Palitoh.Controllers
{
    public class AdminController : ApiController
    {
        //[CustomAuth]
        //Account Table
        [Route("api/Accounts")]
        [HttpGet]
        public HttpResponseMessage GetAllAccounts()
        {
            var data = AccountService.GetAllAccounts();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Account/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAccount(int id)
        {
            var data = AccountService.GetAccount(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Account/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteAccount(AccountDTO obj)
        {
            var data = AccountService.DeleteAccount(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Account/add")]
        [HttpPost]
        public HttpResponseMessage AddAccount(AccountDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = AccountService.AddAccount(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Account/edit")]
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



        //Admin Table
        [Route("api/Admins")]
        [HttpGet]
        public HttpResponseMessage GetAllAdmins()
        {
            var data = AdminService.GetAllAdmins();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAdmin(int id)
        {
            var data = AdminService.GetAdmin(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteAdmin(AdminDTO obj)
        {
            var data = AdminService.DeleteAdmin(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/add")]
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

        [Route("api/Admin/edit")]
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
        [Route("api/Reports")]
        [HttpGet]
        public HttpResponseMessage GetAllReports()
        {
            var data = ReportService.GetAllReports();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReport(int id)
        {
            var data = ReportService.GetReport(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteReport(ReportDTO obj)
        {
            var data = ReportService.DeleteReport(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/add")]
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

        [Route("api/Report/edit")]
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
        [Route("api/Accounts/{id}/Reports")]
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
        [Route("api/Accounts/{id}/Tokens")]
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
    }
}
