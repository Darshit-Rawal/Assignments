using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    public class RoomController : ApiController
    {

        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        // GET: api/Room
        public IHttpActionResult Get()
        {
            List<Rooms> rooms = _roomManager.GetAllRooms();
            if (!rooms.Any())
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            List<Rooms> rooms = _roomManager.GetRoom(id);
            if (!rooms.Any())
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // POST: api/Room
        public IHttpActionResult Post([FromBody]Rooms room)
        {
            string response = _roomManager.CreateRoom(room);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // GET: api/Room/param?city={city}&pinCode={pinCode}&price={price}&category={category}
        [Route("api/Room/param")]
        public IHttpActionResult Get([FromUri]string city, [FromUri]string pinCode, [FromUri]decimal price, [FromUri]string category)
        {
            List<Rooms> rooms = _roomManager.GetRoom(city, pinCode, price, category);
            if (!rooms.Any())
            {
                return NotFound();
            }
            return Ok(rooms);
        }
    }
}
