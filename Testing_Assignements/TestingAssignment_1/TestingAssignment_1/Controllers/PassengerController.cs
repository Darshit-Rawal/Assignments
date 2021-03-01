using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAssignment_1.Models;
using TestingAssignment_1.Repository;

namespace TestingAssignment_1.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IDataRepository _repo;
        public PassengerController(IDataRepository dataRepository)
        {
            _repo = dataRepository;
        }
        public IList<Passenger> GetList()
        {
            return _repo.getPassengersList();
        }

        public IHttpActionResult Get(Guid id)
        {
            var passenger = _repo.GetById(id);
            return Ok(passenger);
        }

        public Passenger Create(Passenger passenger)
        {
            return _repo.AddPassenger(passenger);
        }
        
        public Passenger Update(Passenger passenger)
        {
            return _repo.Update(passenger);
        }

        public bool Delete(Guid id)
        {
            var passenger = _repo.Delete(id);
            return passenger;
        }
    }
}
