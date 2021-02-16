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
    [RoutePrefix("Appointment")]
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        public IHttpActionResult Create(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var Id = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                appointment.CustomerId = Id;
                appointment.UpdatedBy = Id;
            }
            string response = _appointmentManager.Create(appointment);
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

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public IHttpActionResult Update(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var Id = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                appointment.CustomerId = Id;
                appointment.UpdatedBy = Id;
            }
            string response = _appointmentManager.Update(appointment);
            if (response != "Updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateStatus")]
        public IHttpActionResult UpdateStatus(int appointmentId, bool status)
        {
            string response = _appointmentManager.UpdateStatus(appointmentId, status);
            if (response != "Updated")
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
            string response = _appointmentManager.Delete(id);
            if (response != "Deleted")
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
            var identity = (ClaimsIdentity)User.Identity;
            int customerId = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            var response = _appointmentManager.GetAppointments(customerId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var response = _appointmentManager.GetAppointments();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetFilter")]
        public IHttpActionResult GetFilter([FromBody]DateTime startDate, [FromBody]DateTime endDate)
        {
            var response = _appointmentManager.GetAppointments(startDate, endDate);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var response = _appointmentManager.GetAppointment(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
