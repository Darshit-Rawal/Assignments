using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class HotelManager : IHotelManager
    {

        private readonly IHotelRepository _hotelReposetory;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelReposetory = hotelRepository;
        }

        public string CreateHotel(Hotels hotel)
        {
            return _hotelReposetory.CreateHotel(hotel);
        }

        public List<Hotels> GetAllHotels()
        {
            return _hotelReposetory.GetAllHotels();
        }

        public Hotels GetHotel(int id)
        {
            return _hotelReposetory.GetHotel(id);
        }
    }
}
