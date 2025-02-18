using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;



namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        IEnumerable<DateTime>GetFlightDates(string destination);
        void ShowFlightDetails(Plane plane);
        IEnumerable<Flight> GetFlights(string filterType, string filterValue);
        int ProgrammedFlightNumber(DateTime startDate);
        float DurationAverage(string destination);

        IEnumerable<Flight> OrderedDurationFlights();

        IEnumerable<Passenger> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();

    }
}
