using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public class Ticket
    {
        public double Prix { get; set; }
        public string Siege { get; set; }

        public Boolean VIP { get; set; }

        [ForeignKey("PassengerFK")]

        public virtual Passenger passenger { get; set; }
        public string PassengerFK { get; set; }

        [ForeignKey("FlightFK")]
        public virtual Flight flight { get; set; }
        public int FlightFK { get; set; }

    }
}
