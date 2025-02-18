using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{

    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public Action<Plane> FlightDetailsDel;

        public Func<String,float> DurationAverageDel;

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {

            IEnumerable<DateTime> result = new List<DateTime>();
            //question6
            //for (int i = 0; i < Flights.Count; i++) { 
            //   if (Flights[i].Destination.Equals(destination))
            //   {
            //      result.Add(Flights[i].FlightDate);
            // }
            // }
            //question7
            // foreach (Flight f in Flights) {
            // if (f.Destination.Equals(destination)) { 
            // result.Add(f.FlightDate);
            // }
            //question9
            //le language LINQ
            //var query = from instance in Collection
            //            where Condition a
            //            select retour
            //return query.ToList();

            result = from f in Flights
                     where f.Destination.Equals(destination)
                     select f.FlightDate;

            //fonction lambda
            //result = Flights.Where(f => f.Destination.Equals(destination))
            //                .Select(f => f.FlightDate);
            return new List<DateTime>();
        }
        //Question8
        public IEnumerable<Flight> GetFlights(string filterType, string filterValue)
        {
            PropertyInfo property = typeof(Flight).GetProperty(filterType);
            if (property == null) {
                Console.WriteLine($"Propriété '{filterType}' introuvable !");
                return Enumerable.Empty<Flight>();
            }
            return Flights.Where(f => property.GetValue(f, null).ToString() == filterValue).ToList();
        }

        //question10
        public void ShowFlightDetails(Plane plane)
        {
            /* var req = from f in Flights
                       where f.plane == plane
                       select new { f.FlightDate, f.Destination };
             foreach (var f in req)
             {
                 Console.WriteLine(f);
             }*/
            var req = Flights.Where(f => f.plane == plane)
                            .Select(f => new { f.FlightDate, f.Destination });
            foreach (var f in req)
            {
                Console.WriteLine(f);
            }
        }

        //Question11
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //DateTime endDate = startDate.AddDays(7);

            /*var req = from f in Flights
                      where DateTime.Compare(startDate,f.FlightDate) <0 && (f.FlightDate-startDate).TotalDays < 8
                      select f;
            return req.Count();*/
            var req = Flights.Where(f => f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7))
                             .Count();
            return req;
        }

        //Question12
        public float DurationAverage(string destination)
        {
            /*var req = from f in Flights
                      where f.Destination.Equals(destination)
                      select f.EstimateDuration;
            return (float)req.Average();*/
            var req = Flights.Where(f => f.Destination.Equals(destination))
                            .Average(f=> f.EstimateDuration);
            return (float)req;
        }

        //Question13
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimateDuration descending
                      select f;
            return req;
           // return req.OrderByDescending(f => f.EstimateDuration);
        }

        //Question14
        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            /*var req = from p in flight.Passengers
                      where p is Traveller
                      orderby p.BirthDate
                      select p;
            return req.Take(3);*/
            /*var req = from p in flight.Passengers.OfType<Traveller>()
                      orderby p.BirthDate
                      select p;
            return req.Take(3);*/
            var req = flight.Passengers.OfType<Traveller>().OrderByDescending(p => p.BirthDate).Take(3);
            return req;

        }
        
        //Question15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            /* var req = from f in Flights
                       group f by f.Destination into g
                       select g;

             return req.ToList();*/

            /*var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine("Destinationn : " +g.Key);
                foreach (Flight f in g)
                {
                    Console.WriteLine(f);
                }
            }
            return req;*/
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (Flight f in g)
                {
                    Console.WriteLine($"Décollage : {f.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
            return req;
        }
        public FlightMethods()
        {
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                return (float)(from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimateDuration).Average();
            };
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.plane == p
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
            };
        }


}
}
