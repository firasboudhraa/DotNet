using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManuFactureDate  { get; set; }
        public PlaneType planeType { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "Capacity:" +Capacity+ "ManuFactureDate:" +ManuFactureDate;
        }

        public Plane()
        {
        }

        public Plane(int capacity, DateTime manuFactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManuFactureDate = manuFactureDate;
            planeType = planeType;
        }
    }
}
