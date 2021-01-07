using AutoMapper;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.HotelManagementDBEntities _dbContext;

        public BookingRepository()
        {
            _dbContext = new Database.HotelManagementDBEntities();
        }

        public string CreateBooking(Bookings booking)
        {
            try
            {
                Database.Booking entity = new Database.Booking();

                var config = new MapperConfiguration(cfg => cfg.CreateMap<Bookings, Database.Booking>());
                var mapper = new Mapper(config);

                entity = mapper.Map<Database.Booking>(booking);

                _dbContext.Bookings.Add(entity);
                _dbContext.SaveChanges();

                return "created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int bookingId)
        {
            return UpdateBooking(bookingId, "Deleted");
        }

        public bool RoomCheckAvail(int roomId, DateTime date)
        {
            Database.Booking avail = _dbContext.Bookings.Where(x => x.Id == roomId && x.BookingDate == date && x.Status != "Deleted").FirstOrDefault();
            if (avail == null)
            {
                return true;
            }
            return false;
        }

        public string UpdateBooking(Bookings booking)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(booking.Id);

                if (entity != null)
                {

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Bookings, Database.Booking>());
                    var mapper = new Mapper(config);

                    entity = mapper.Map<Database.Booking>(booking);
                    _dbContext.SaveChanges();

                    return "Updated";
                }

                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBooking(int bookingId, string status)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(bookingId);

                if (entity != null)
                {
                    entity.Status = status;
                    _dbContext.SaveChanges();

                    return "Updated status";
                }

                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
