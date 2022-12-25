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

    public class ShopController : ApiController
    {
        //Shop Table
        [Route("api/Shops")]
        [HttpGet]
        public HttpResponseMessage GetAllShops()
        {
            var data = ShopService.GetAllShops();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Shop/{id}")]
        [HttpGet]
        public HttpResponseMessage GetShop(int id)
        {
            var data = ShopService.GetShop(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Shop/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteShop(ShopDTO obj)
        {
            var data = ShopService.DeleteShop(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Shop/add")]
        [HttpPost]
        public HttpResponseMessage AddShop(ShopDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = ShopService.AddShop(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Shop/edit")]
        [HttpPost]
        public HttpResponseMessage EditShop(ShopDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = ShopService.EditShop(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //Pet Table
        [Route("api/Pets")]
        [HttpGet]
        public HttpResponseMessage GetAllPets()
        {
            var data = PetService.GetAllPets();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Pet/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPet(int id)
        {
            var data = PetService.GetPet(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Pet/delete")]
        [HttpPost]
        public HttpResponseMessage DeletePet(PetDTO obj)
        {
            var data = PetService.DeletePetFromTable(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Pet/add")]
        [HttpPost]
        public HttpResponseMessage AddPet(PetDTO obj)
        {
            
                var res = PetService.AddPet(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Pet/edit")]
        [HttpPost]
        public HttpResponseMessage EditPet(PetDTO obj)
        {
            
                var res = PetService.EditPet(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        /*[Route("api/Pet/edit")]
        [HttpPost]
        public HttpResponseMessage EditPet(PetDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = PetService.EditPet(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }*/



        //Food Table
        [Route("api/Foods")]
        [HttpGet]
        public HttpResponseMessage GetAllFoods()
        {
            var data = FoodService.GetAllFoods();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Food/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFood(int id)
        {
            var data = FoodService.GetFood(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Food/search/")]
        [HttpPost]
        public HttpResponseMessage SearchFood(FoodDTO obj)
        {
            var data = FoodService.SearchFood(obj.Name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Food/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteFood(FoodDTO obj)
        {
            var data = FoodService.DeleteFood(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Food/add")]
        [HttpPost]
        public HttpResponseMessage AddFood(FoodDTO obj)
        {
            
                var res = FoodService.AddFood(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Added", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            
        }

        [Route("api/Food/edit")]
        [HttpPost]
        public HttpResponseMessage EditFood(FoodDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = FoodService.EditFood(obj);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Edited", data = res });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }



        //Nevigation values
        [Route("api/Shop/{id}/Employees")]
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
        [Route("api/Shop/{id}/Pets")]
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
        [Route("api/Shop/{id}/Foods")]
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
    }
}
