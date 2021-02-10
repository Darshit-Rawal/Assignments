using Microsoft.AspNet.Identity;
using SBS.BLL.Classes;
using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SBS.API.Controllers
{
    [RoutePrefix("Vehicle")]
    public class VehicleController : ApiController
    {
        private readonly VehicleManager _vehicleManager;

        public VehicleController(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(Vehicle vehicle)
        {
            string response = _vehicleManager.Create(vehicle);
            if (response != "created")
            {
                return InternalServerError();
            }
            return Ok();
        }


        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            string response = _vehicleManager.Delete(id);
            if (response != "Deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Update(Vehicle vehicle)
        {
            string response = _vehicleManager.Update(vehicle);
            if (response != "Updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var response = _vehicleManager.GetVehicles();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetById")]
        public IHttpActionResult GetVehicles()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            return Ok(userId);
        }
    }
}
