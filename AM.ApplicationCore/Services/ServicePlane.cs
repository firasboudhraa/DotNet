using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(f => f.Tickets).Select(t => t.passenger);
            
        }

        public IEnumerable<Flight> GetFlight(int n)
        {
            return GetMany().OrderByDescending(p => p.PlaneId).Take(n)
                  .SelectMany(p => p.Flights).OrderBy(f => f.FlightDate);
                   
        }

        public bool IsAvailablePlane(int n, Flight flight)
        {
            int availablePlaces = flight.plane.Capacity - flight.Tickets.Count;
            return availablePlaces > n;
        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManuFactureDate).TotalDays > 3650);
        }
    }
}
