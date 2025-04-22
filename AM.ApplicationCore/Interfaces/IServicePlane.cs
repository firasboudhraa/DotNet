using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
       IEnumerable<Passenger> GetPassengers(Plane plane);
       IEnumerable<Flight> GetFlight(int n );
        bool IsAvailablePlane(int n , Flight flight);
        void DeletePlanes();
    }
}
