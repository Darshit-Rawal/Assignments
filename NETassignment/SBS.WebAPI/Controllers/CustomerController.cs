using SBS.BLL.Interface;
using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBS.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // POST: Account/Register
        [HttpPost]
        [Route("Account/Register")]
        public IHttpActionResult Register([FromBody]Customer customer)
        {
            string response = _customerManager.Register(customer);
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

        // POST: Account/Login
        [HttpGet]
        [Authorize]
        [Route("Account/Login")]
        public IHttpActionResult Login()
        {
            //string token = Request.Headers.Authorization.Parameter;
            //string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            //string[] tokenArray = decodedToken.Split(':');
            //string email = tokenArray[0];
            //string password = tokenArray[1];

            //bool response = _customerManager.Login(email, password);
            //if (response == false)
            //{
            //    return Unauthorized();
            //}
            //return Ok();
            return Ok();
        }
    }
}
