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

    public class EmployeeController : ApiController
    {
        [Route("api/Employees")]
        [HttpGet]
        public HttpResponseMessage GetAllEmployees()
        {
            var data = EmployeeService.GetAllEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Employee/{id}")]
        [HttpGet]
        public HttpResponseMessage GetEmployee(int id)
        {
            var data = EmployeeService.GetEmployee(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Employee/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteEmployee(EmployeeDTO obj)
        {
            var data = EmployeeService.DeleteEmployee(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Employee/add")]
        [HttpPost]
        public HttpResponseMessage AddEmployee(EmployeeDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = EmployeeService.AddEmployee(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Employee/edit")]
        [HttpPost]
        public HttpResponseMessage EditEmployee(EmployeeDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = EmployeeService.EditEmployee(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
