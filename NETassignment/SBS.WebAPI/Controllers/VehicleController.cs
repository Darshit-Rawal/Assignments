using SBS.BLL.Interface;
using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SBS.WebAPI.Controllers
{
    [RoutePrefix("Vehicle")]
    public class VehicleController : ApiController
    {
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        public IHttpActionResult Create(Vehicle vehicle)
        {
            var identity = (ClaimsIdentity)User.Identity;
            vehicle.CustomerId = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            string response = _vehicleManager.Create(vehicle);
            if (response == "already")
            {
                return Conflict();
            }
            else if (response != "created")
            {
                return InternalServerError();
            }
            return Ok();
        }


        [HttpDelete]
        [Authorize]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
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
        [Route("Update")]
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
        [Route("Get")]
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
            var identity = (ClaimsIdentity)User.Identity;
            int customerId = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            var response = _vehicleManager.GetVehicles(customerId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
