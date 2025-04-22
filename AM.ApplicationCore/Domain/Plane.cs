using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManuFactureDate  { get; set; }
        public PlaneType planeType { get; set; }
        public ICollection<Flight> Flights { get; set; }
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManuFactureDate + " " + Capacity; } }




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
