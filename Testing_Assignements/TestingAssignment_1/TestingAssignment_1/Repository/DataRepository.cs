using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingAssignment_1.Models;

namespace TestingAssignment_1.Repository
{
    
    public class DataRepository : IDataRepository
    {
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        public DataRepository()
        {
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();
            _passenger.Add(id1, new Passenger { Id = id1, firstName = "Darshit", lastName = "Rawal", phoneNumber = "12334324234"});
            _passenger.Add(id2, new Passenger { Id = id2, firstName = "Rawal", lastName = "Darshit", phoneNumber = "12334324239" });
            _passenger.Add(id3, new Passenger { Id = id3, firstName = "Darshit_R", lastName = "Rawal_D", phoneNumber = "12334324231" });
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            Guid newId = Guid.NewGuid();
            passenger.Id = newId;
            _passenger.Add(newId, passenger);
            return passenger;
        }

        public bool Delete(Guid Id)
        {
            var result = _passenger.Remove(Id);
            return result;
        }

        public Passenger GetById(Guid Id)
        {
            return _passenger.FirstOrDefault(x => x.Key == Id).Value;
        }

        public IList<Passenger> getPassengersList()
        {
            return _passenger.Select(x => x.Value).ToList();
        }

        public Passenger Update(Passenger passenger)
        {
            Passenger passengerEntity = GetById(passenger.Id);
            if (passengerEntity == null)
            {
                return null;
            }
            else
            {
                _passenger[passenger.Id] = passenger;
            }
            return passenger;
        }
    }
}