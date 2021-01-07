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
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        //// GET: api/Booking
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Booking/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]Bookings booking)
        {
            string response = _bookingManager.CreateBooking(booking);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT: api/Booking/5
        public IHttpActionResult Put(int bookingId, [FromBody]string status)
        {
            string response = _bookingManager.UpdateBooking(bookingId, status);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT: api/Booking
        public IHttpActionResult Put([FromBody]Bookings booking)
        {
            string response = _bookingManager.UpdateBooking(booking);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/Booking/5
        public IHttpActionResult Delete(int id)
        {
            string response = _bookingManager.DeleteBooking(id);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // GET: api/Booking?roomId={roomId}&date={date}
        public IHttpActionResult Get([FromUri]int roomId, [FromUri]DateTime date)
        {
            bool response = _bookingManager.RoomCheckAvail(roomId, date);
            return Ok(response);
        }
    }
}
